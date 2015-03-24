using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
namespace com.azmisahin.PlugIn.Payment.AzurePayment
{
    public class Sender
    {

        #region General Filed [ Web Configuration ]
        private string _domain { get; set; }
        private string _uriToken { get; set; }
        private string _uriXml { get; set; }

        /// <summary>
        /// Alphanumeric 32
        /// </summary>
        private string _sender { get; set; }
        private string _type { get; set; }
        private string _mode { get; set; }

        /// <summary>
        /// Alphanumeric 32
        /// </summary>
        private string _channel { get; set; }
        private string _responses { get; set; }

        /// <summary>
        /// Alphanumeric 32 
        /// </summary>
        private string _transactionUserLogin { get; set; }

        /// <summary>
        /// Alphanumeric 5..32
        /// </summary>
        private string _transactionUserPwd { get; set; }
        private string _token { get; set; }
        private string _paymentCode { get; set; }
        private string _paymentMemo { get; set; }
        private PlugIn.Payment.Models.Request requestModel = null;
        #endregion

        #region Ctor
        public Sender(PlugIn.Payment.Models.Request model)
        {
            _domain = "PlugIn.Payment.Domain".appSettingValue();
            _uriToken = "PlugIn.Payment.AzurePayment.Uri.Token".appSettingValue();
            _uriXml = "PlugIn.Payment.AzurePayment.Uri.Xml".appSettingValue();
            _sender = "PlugIn.Payment.AzurePayment.Sender".appSettingValue();
            _channel = "PlugIn.Payment.AzurePayment.Channel".appSettingValue();
            _transactionUserLogin = "PlugIn.Payment.AzurePayment.User".appSettingValue();
            _transactionUserPwd = "PlugIn.Payment.AzurePayment.Password".appSettingValue();
            _type = "PlugIn.Payment.AzurePayment.Type".appSettingValue();
            _mode = "PlugIn.Payment.AzurePayment.Mode".appSettingValue();
            _responses = "PlugIn.Payment.AzurePayment.responses".appSettingValue();
            _token = "PlugIn.Payment.AzurePayment.Token".appSettingValue();
            _paymentCode = "PlugIn.Payment.AzurePayment.PaymentCode".appSettingValue();
            _paymentMemo = "PlugIn.Payment.AzurePayment.PaymentMemo".appSettingValue();


            requestModel = model;
            _token = GenerateToken(requestModel.PAYMENT.Amount.ToString(), requestModel.PAYMENT.Currency.ToString());
        }
        #endregion

        #region Property
        public Models.ResponseModel.Response Now()
        {
            var xmlData = SeriaizeData();
            var loadData = Load(xmlData);
            var result = DeserializeData(loadData);
            return result;
        }
        #endregion

        #region Internal
        /// <summary>
        /// Generate Token
        /// </summary>
        private string GenerateToken(string amount, string currency)
        {
            var token = string.Empty;
            var data = new NameValueCollection()
            {
                { "SECURITY.SENDER"         ,_sender},
                { "USER.LOGIN"              ,_transactionUserLogin},
                { "USER.PWD"                ,_transactionUserPwd},
                { "TRANSACTION.CHANNEL"     ,_channel},
                { "TRANSACTION.MODE"        ,_mode},
                { "PAYMENT.TYPE"            ,_type},
                { "PRESENTATION.AMOUNT"     ,amount},
                { "PRESENTATION.CURRENCY"   ,currency}
            };
            try
            {
                using (var webClient = new WebClient())
                {
                    var fullUriToken = string.Format("{0}/frontend/GenerateToken", _uriToken);
                    var result = webClient.UploadValues(fullUriToken, data);
                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Deserialize<Dictionary<string, dynamic>>(Encoding.UTF8.GetString(result));
                    if (json.ContainsKey("transaction"))
                    {
                        token = json["transaction"]["token"];
                    }
                    else
                    {
                        token = null;
                    }
                }
            }
            catch (Exception ex)
            {
                var e = ex;
                token = null;

            }

            return token;
        }

        /// <summary>
        /// obje Model To Xml Seriliazisyon
        /// </summary>
        /// <returns></returns>
        private string SeriaizeData()
        {
            Models.RequestModel.Request r = new Models.RequestModel.Request();

            r.version = 1.0m;

            r.Header = new Models.RequestModel.RequestHeader();
            r.Header.Security = new Models.RequestModel.RequestHeaderSecurity();
            r.Header.Security.sender = _sender;
            //r.Header.Security.type = _type;
            //r.Header.Security.token = _token;

            r.Transaction = new Models.RequestModel.RequestTransaction();
            r.Transaction.mode = _mode;
            r.Transaction.channel = _channel;
            r.Transaction.response = _responses;

            r.Transaction.Identification = new Models.RequestModel.RequestTransactionIdentification();
            //r.Transaction.Identification.TransactionID = requestModel.TRANSACTION.ReferansID;
            r.Transaction.Identification.ReferenceID = requestModel.TRANSACTION.ReferansID;

            r.Transaction.User = new Models.RequestModel.RequestTransactionUser();
            r.Transaction.User.login = _transactionUserLogin;
            r.Transaction.User.pwd = _transactionUserPwd;

            r.Transaction.Payment = new Models.RequestModel.RequestTransactionPayment();
            r.Transaction.Payment.code = _paymentCode;
            //CT = Credit Transfer
            //RM = Risk Management
            //VA = Virtual Account
            //DD = Direct Debit
            //DC = Debit Card
            //OD = Cash on Delivery
            //UA = User Account
            //PP = Prepayment
            //CC = Credit Card
            //OT = Online Transfer
            //IV = Invoice
            //WA = Wallet Account

            //r.Transaction.Payment.Memo = _paymentMemo;

            //000.000.000	Transaction succeeded
            //000.100.110	Request successfully processed in 'Merchant in Integrator Test Mode'
            //000.100.111	Request successfully processed in 'Merchant in Validator Test Mode'
            //000.100.112	Request successfully processed in 'Merchant in Connector Test Mode'

            r.Transaction.Payment.Presentation = new Models.RequestModel.RequestTransactionPaymentPresentation();
            r.Transaction.Payment.Presentation.Amount = requestModel.PAYMENT.Amount;
            r.Transaction.Payment.Presentation.Currency = requestModel.PAYMENT.Currency.ToString();
            r.Transaction.Payment.Presentation.Usage = string.Format("Domain: {0} Order:{1}", _domain, requestModel.TRANSACTION.ReferansID);

            r.Transaction.Recurrence = new Models.RequestModel.RequestTransactionRecurrence();

            //r.Transaction.Recurrence.mode = "INITIAL";

            r.Transaction.Account = new Models.RequestModel.RequestTransactionAccount();
            r.Transaction.Account.Number = requestModel.ACCOUNT.Number;
            r.Transaction.Account.Holder = requestModel.ACCOUNT.Holder;
            r.Transaction.Account.Brand = requestModel.ACCOUNT.Brand.ToString();

            r.Transaction.Account.Year = requestModel.ACCOUNT.Year;
            r.Transaction.Account.Month = requestModel.ACCOUNT.Month;

            r.Transaction.Account.Verification = requestModel.ACCOUNT.Verification;

            r.Transaction.Account.Expiry = new Models.RequestModel.RequestTransactionAccountExpiry();
            r.Transaction.Account.Expiry.month = requestModel.ACCOUNT.Month;
            r.Transaction.Account.Expiry.year = requestModel.ACCOUNT.Year;

            r.Transaction.Customer = new Models.RequestModel.RequestTransactionCustomer();
            r.Transaction.Customer.Name = new Models.RequestModel.RequestTransactionCustomerName();
            r.Transaction.Customer.Name.Family = requestModel.CUSTOMER.FamliyName;
            r.Transaction.Customer.Name.Given = requestModel.CUSTOMER.Given;
            //r.Transaction.Customer.Name.Company = requestModel.CUSTOMER.Company;
            r.Transaction.Customer.Name.Salutation = requestModel.CUSTOMER.Salutation;
            //r.Transaction.Customer.Name.Title = "";

            r.Transaction.Customer.Contact = new Models.RequestModel.RequestTransactionCustomerContact();
            r.Transaction.Customer.Contact.Email = requestModel.CONTACT.Email;
            r.Transaction.Customer.Contact.Ip = requestModel.CONTACT.Ip;
            r.Transaction.Customer.Contact.Phone = requestModel.CONTACT.Phone;

            r.Transaction.Customer.Address = new Models.RequestModel.RequestTransactionCustomerAddress();
            r.Transaction.Customer.Address.City = requestModel.ADRESS.City;
            r.Transaction.Customer.Address.Country = requestModel.ADRESS.Country;
            r.Transaction.Customer.Address.State = requestModel.ADRESS.State;
            r.Transaction.Customer.Address.Street = requestModel.ADRESS.Street;
            r.Transaction.Customer.Address.Zip = requestModel.ADRESS.Zip;

            r.Transaction.Customer.Details = new Models.RequestModel.RequestTransactionCustomerDetails();
            r.Transaction.Customer.Details.Identity = new Models.RequestModel.RequestTransactionCustomerDetailsIdentity();
            r.Transaction.Customer.Details.Identity.paper = "IDCARD";
            r.Transaction.Customer.Details.Identity.Value = string.Format("IDENT{0}", requestModel.TRANSACTION.ReferansID);

            var result = r.SerializeObject<Models.RequestModel.Request>();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Models.ResponseModel.Response DeserializeData(string data)
        {
            Models.ResponseModel.Response result = (Models.ResponseModel.Response)data.DeserializeObject<Models.ResponseModel.Response>();
            return result;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        private string Load(string xmlData)
        {
            var data = "load=" + xmlData;
            var result = new PaymentRequest().Send(data);
            return result;
        }

        class PaymentRequest
        {
            private string _uriXml { get; set; }
            private HttpWebRequest httpWebRequest;
            private HttpWebResponse httpWebResponse;
            public PaymentRequest()
            {
                _uriXml = "PlugIn.Payment.AzurePayment.Uri.Xml".appSettingValue();
            }
            public string Send(string data)
            {
                string result = string.Empty;
                var fullUriXml = string.Format("{0}/payment/ctpe", _uriXml);
                httpWebRequest = (HttpWebRequest)WebRequest.Create(fullUriXml);
                httpWebRequest.Method = "post";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";


                Stream stream = httpWebRequest.GetRequestStream();
                byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.ASCII);

                result = streamReader.ReadToEnd();
                httpWebResponse.Close();
                streamReader.Close();
                Console.WriteLine("Request  Uri :{0}", _uriXml);
                Console.WriteLine("Request  Data:{0}", data);
                Console.WriteLine("Response Data:{0}", result);
                return result;
            }
        }
        #endregion

        #region General Property
        /// <summary>
        /// Frontend
        /// </summary>
        /// <returns></returns>        
        public static string GetToken(string amount, string currency, PlugIn.Payment.Models.Request model)
        {
            var _domain = "PlugIn.Payment.Domain".appSettingValue();
            var _uriToken = "PlugIn.Payment.AzurePayment.Uri.Token".appSettingValue();
            var _uriXml = "PlugIn.Payment.AzurePayment.Uri.Xml".appSettingValue();
            var _sender = "PlugIn.Payment.AzurePayment.Sender".appSettingValue();
            var _channel = "PlugIn.Payment.AzurePayment.Channel".appSettingValue();
            var _transactionUserLogin = "PlugIn.Payment.AzurePayment.User".appSettingValue();
            var _transactionUserPwd = "PlugIn.Payment.AzurePayment.Password".appSettingValue();
            var _type = "PlugIn.Payment.AzurePayment.Type".appSettingValue();
            var _mode = "PlugIn.Payment.AzurePayment.Mode".appSettingValue();
            var _responses = "PlugIn.Payment.AzurePayment.responses".appSettingValue();
            var _token = "PlugIn.Payment.AzurePayment.Token".appSettingValue();
            var _paymentCode = "PlugIn.Payment.AzurePayment.PaymentCode".appSettingValue();
            var _paymentMemo = "PlugIn.Payment.AzurePayment.PaymentMemo".appSettingValue();

            var token = string.Empty;
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            var data = new NameValueCollection()            
            {
                { "SECURITY.SENDER"         ,_sender},
                { "USER.LOGIN"              ,_transactionUserLogin},
                { "USER.PWD"                ,_transactionUserPwd},
                { "TRANSACTION.CHANNEL"     ,_channel},
                { "TRANSACTION.MODE"        ,_mode},
                { "PAYMENT.TYPE"            ,_type},
                { "PRESENTATION.AMOUNT"     ,amount},
                { "PRESENTATION.CURRENCY"   ,currency},

                { "IDENTIFICATION.SHOPPERID"   ,_domain},
                { "IDENTIFICATION.TRANSACTIONID"   , model.TRANSACTION.ReferansID},
                { "NAME.FAMILY"   ,model.CUSTOMER.FamliyName},
                { "NAME.GIVEN"   ,model.CUSTOMER.Given},
                { "ADDRESS.STREET",model.ADRESS.Street},
                { "ADDRESS.ZIP"   ,model.ADRESS.Zip.ToString()},
                { "ADDRESS.CITY"   ,model.ADRESS.City},                
                { "ADDRESS.COUNTRY"   ,model.ADRESS.Country},

                { "CRITERION.CART.ITEM.1.NAME"   ,model.ITEMS[0].Description},
                { "CRITERION.CART.ITEM.1.PRICE"   ,model.ITEMS[0].Price.ToString(culture)},
                { "CRITERION.CART.ITEM.1.QUANTITY"   ,model.ITEMS[0].Quantity.ToString()}
               
            };
            try
            {
                using (var webClient = new WebClient())
                {
                    var fullUriToken = string.Format("{0}/frontend/GenerateToken", _uriToken);
                    var result = webClient.UploadValues(fullUriToken, data);
                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Deserialize<Dictionary<string, dynamic>>(Encoding.UTF8.GetString(result));
                    if (json.ContainsKey("transaction"))
                    {
                        token = json["transaction"]["token"];
                    }
                    else
                    {
                        token = null;
                    }
                }
            }
            catch (Exception ex)
            {
                var e = ex;
                token = null;
            }
            return token;
        }

        /// <summary>
        /// Get Uri Token
        /// </summary>
        public static string GetUriToken { get { return "PlugIn.Payment.AzurePayment.Uri.Token".appSettingValue(); } }

        public static string GetQuery(object token)
        {
            var uriToken = "PlugIn.Payment.AzurePayment.Uri.Token".appSettingValue();
            uriToken = string.Format("{0}/frontend/widget/v4/widget.js", uriToken);
            var lang = "en";
            var style = "plain";
            var result = string.Format("{0};jsessionid={1}?language={2}&style={3}", uriToken, token, lang, style);
            return result;
        }
        #endregion
    }
}