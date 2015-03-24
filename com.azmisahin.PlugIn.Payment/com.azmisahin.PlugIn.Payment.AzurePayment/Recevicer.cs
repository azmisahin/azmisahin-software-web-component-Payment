using com.azmisahin.PlugIn.Payment.AzurePayment.Models;
using com.azmisahin.PlugIn.Payment.Models;
using System.Net;
using System.Web.Script.Serialization;
namespace com.azmisahin.PlugIn.Payment.AzurePayment
{
    public class Recevicer
    {
        private Response responseData;
        public Recevicer()
        {
            responseData = new Response();
        }
        public Response ResponseProccess(string token)
        {
            var _uriToken = "PlugIn.Payment.AzurePayment.Uri.Token".appSettingValue();
            string url = string.Format("{0}/frontend/GetStatus;jsessionid={1}", _uriToken, token);

            WebClient webClient = new WebClient();
            string json = webClient.DownloadString(url);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ResponseJsonModel.RootObject result = serializer.Deserialize<ResponseJsonModel.RootObject>(json);

            responseData.PROCESS.TransactionID = result.transaction.identification.uniqueId;
            responseData.PROCESS.AuthCode = result.transaction.identification.shortId;
            responseData.DETAIL.MasketPan = string.Format("{0}******{1}", result.transaction.account.bin, result.transaction.account.last4Digits);

            #region Error
            try
            {
                responseData.PROCESS.amount = result.transaction.payment.clearing.amount;
                responseData.PROCESS.currency = result.transaction.payment.clearing.currency;
            }
            catch (System.Exception)//No Pay
            {

                responseData.PROCESS.amount = "0";
            }

            #endregion

            responseData.TRANSACTION.PosID = 1;
            responseData.TRANSACTION.ReferansID = result.transaction.identification.transactionid;
            responseData.PROCESS.Code = result.transaction.processing.code;
            responseData.PROCESS.Message = result.transaction.processing.result;
            responseData.DETAIL.ClientIP = result.transaction.customer.contact.ip;
            responseData.ERROR.Code = result.transaction.processing.@return.code;
            responseData.ERROR.Message = result.transaction.processing.@return.message;

            switch (result.transaction.processing.result)
            {
                case "ACK":
                    responseData.PROCESS.Code = "1";
                    break;
                default:
                    responseData.PROCESS.Code = "-1";
                    break;
            }

            return responseData;
        }
    }
}
