namespace com.azmisahin.PlugIn.Payment.AzurePayment.Models
{
    /// <summary>
    /// Azure Payment Request Model
    /// </summary>
    public class RequestModel
    {
        /// <summary>
        /// Request Root
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Request
        {
            private RequestHeader headerField;
            private RequestTransaction transactionField;
            private decimal versionField;

            /// <summary>
            /// Header
            /// </summary>
            public RequestHeader Header
            {
                get
                {
                    return this.headerField;
                }
                set
                {
                    this.headerField = value;
                }
            }

            /// <summary>
            /// Transaction
            /// </summary>
            public RequestTransaction Transaction
            {
                get
                {
                    return this.transactionField;
                }
                set
                {
                    this.transactionField = value;
                }
            }

            /// <summary>
            /// version
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }
        }

        /// <summary>
        /// Request Header
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestHeader
        {
            private RequestHeaderSecurity securityField;

            /// <summary>
            /// Securtiy
            /// </summary>
            public RequestHeaderSecurity Security
            {
                get
                {
                    return this.securityField;
                }
                set
                {
                    this.securityField = value;
                }
            }
        }

        /// <summary>
        /// Request Header Securty
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestHeaderSecurity
        {
            private string senderField;
            private string typeField;
            private string tokenField;

            /// <summary>
            /// Sender
            /// Alphanumeric 32 
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sender
            {
                get
                {
                    return this.senderField;
                }
                set
                {
                    this.senderField = value;
                }
            }

            /// <summary>
            /// type
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }

            /// <summary>
            /// token
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string token
            {
                get
                {
                    return this.tokenField;
                }
                set
                {
                    this.tokenField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransaction
        {
            private RequestTransactionIdentification identificationField;
            private RequestTransactionUser userField;
            private RequestTransactionPayment paymentField;
            private RequestTransactionRecurrence recurrenceField;
            private RequestTransactionAccount accountField;
            private RequestTransactionCustomer customerField;
            private string modeField;
            private string channelField;
            private string responseField;

            /// <summary>
            /// Identification
            /// </summary>
            public RequestTransactionIdentification Identification
            {
                get
                {
                    return this.identificationField;
                }
                set
                {
                    this.identificationField = value;
                }
            }

            /// <summary>
            /// user
            /// </summary>
            public RequestTransactionUser User
            {
                get
                {
                    return this.userField;
                }
                set
                {
                    this.userField = value;
                }
            }

            /// <summary>
            /// Payment
            /// </summary>
            public RequestTransactionPayment Payment
            {
                get
                {
                    return this.paymentField;
                }
                set
                {
                    this.paymentField = value;
                }
            }

            public RequestTransactionRecurrence Recurrence
            {
                get
                {
                    return this.recurrenceField;
                }
                set
                {
                    this.recurrenceField = value;
                }
            }

            /// <summary>
            /// Account
            /// </summary>
            public RequestTransactionAccount Account
            {
                get
                {
                    return this.accountField;
                }
                set
                {
                    this.accountField = value;
                }
            }

            /// <summary>
            /// Customer
            /// </summary>
            public RequestTransactionCustomer Customer
            {
                get
                {
                    return this.customerField;
                }
                set
                {
                    this.customerField = value;
                }
            }

            /// <summary>
            /// mode
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string mode
            {
                get
                {
                    return this.modeField;
                }
                set
                {
                    this.modeField = value;
                }
            }

            /// <summary>
            /// chanel
            /// Alphanumeric 32 
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string channel
            {
                get
                {
                    return this.channelField;
                }
                set
                {
                    this.channelField = value;
                }
            }

            /// <summary>
            /// response
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string response
            {
                get
                {
                    return this.responseField;
                }
                set
                {
                    this.responseField = value;
                }
            }
        }

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionRecurrence
        {

            private string modeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string mode
            {
                get
                {
                    return this.modeField;
                }
                set
                {
                    this.modeField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Identification
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionIdentification
        {
            private string transactionIDField;

            /// <summary>
            /// Transaction ID
            /// Alphanumeric 0.256 [Optional]
            /// </summary>
            public string TransactionID
            {
                get
                {
                    return this.transactionIDField;
                }
                set
                {
                    this.transactionIDField = value;
                }
            }

            private string referenceIDField;

            /// <summary>
            /// ReferenceID
            /// Alphanumeric 32
            /// </summary>
            public string ReferenceID
            {
                get
                {
                    return this.referenceIDField;
                }
                set
                {
                    this.referenceIDField = value;
                }
            }

            private string shopperIDField;

            /// <summary>
            /// ShopperID
            /// Alphanumeric 0.256 [ Optional ]
            /// </summary>
            public string ShopperID
            {
                get
                {
                    return this.shopperIDField;
                }
                set
                {
                    this.shopperIDField = value;
                }
            }

            private string invoiceIDField;

            /// <summary>
            /// InvoiceID
            /// Alphanumeric 0..256 [ Optional ]
            /// </summary>
            public string InvoiceID
            {
                get
                {
                    return this.invoiceIDField;
                }
                set
                {
                    this.invoiceIDField = value;
                }
            }

            private string bulkdIDField;

            /// <summary>
            /// BulkdID
            /// Alphanumeric 0..64 [ Ooptional ]
            /// </summary>
            public string BulkdID
            {
                get
                {
                    return this.bulkdIDField;
                }
                set
                {
                    this.bulkdIDField = value;
                }
            }


        }

        /// <summary>
        /// Request Transaction User
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionUser
        {
            private string loginField;
            private string pwdField;

            /// <summary>
            /// login
            /// Alphanumeric 32
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string login
            {
                get
                {
                    return this.loginField;
                }
                set
                {
                    this.loginField = value;
                }
            }

            /// <summary>
            /// pwd
            /// Alphanumeric 5..32 
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pwd
            {
                get
                {
                    return this.pwdField;
                }
                set
                {
                    this.pwdField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Payment
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionPayment
        {
            private string memoField;
            private RequestTransactionPaymentPresentation presentationField;
            private string codeField;

            /// <summary>
            /// Memo
            /// </summary>
            public string Memo
            {
                get
                {
                    return this.memoField;
                }
                set
                {
                    this.memoField = value;
                }
            }

            /// <summary>
            /// Presentation
            /// </summary>
            public RequestTransactionPaymentPresentation Presentation
            {
                get
                {
                    return this.presentationField;
                }
                set
                {
                    this.presentationField = value;
                }
            }

            /// <summary>
            /// code
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string code
            {
                get
                {
                    return this.codeField;
                }
                set
                {
                    this.codeField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Payment Presentation
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionPaymentPresentation
        {
            private decimal amountField;
            private string currencyField;
            private string usageField;

            /// <summary>
            /// Amount [1..10,2 ]
            /// #0.00 
            /// </summary>
            public decimal Amount
            {
                get
                {
                    return this.amountField;
                }
                set
                {
                    this.amountField = value;
                }
            }

            /// <summary>
            /// Currency
            /// Alpha 3
            /// </summary>
            public string Currency
            {
                get
                {
                    return this.currencyField;
                }
                set
                {
                    this.currencyField = value;
                }
            }

            /// <summary>
            /// Usage
            /// Alphanumeric  0..128 
            /// Provides the dynamic part of the descriptor, which appears on the end customer’s statement. Enables the end customer to associate the transaction on the statement to the online transaction
            /// </summary>
            public string Usage
            {
                get
                {
                    return this.usageField;
                }
                set
                {
                    this.usageField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Account
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionAccount
        {
            private ulong numberField;
            private string holderField;
            private string brandField;
            private ushort yearField;
            private byte monthField;
            private ushort verificationField;

            private RequestTransactionAccountExpiry expiryField;
            public RequestTransactionAccountExpiry Expiry
            {
                get
                {
                    return this.expiryField;
                }
                set
                {
                    this.expiryField = value;
                }
            }

            /// <summary>
            /// Number
            /// </summary>
            public ulong Number
            {
                get
                {
                    return this.numberField;
                }
                set
                {
                    this.numberField = value;
                }
            }

            /// <summary>
            /// Holder
            /// </summary>
            public string Holder
            {
                get
                {
                    return this.holderField;
                }
                set
                {
                    this.holderField = value;
                }
            }

            /// <summary>
            /// Brand
            /// </summary>
            public string Brand
            {
                get
                {
                    return this.brandField;
                }
                set
                {
                    this.brandField = value;
                }
            }

            /// <summary>
            /// Year
            /// </summary>
            public ushort Year
            {
                get
                {
                    return this.yearField;
                }
                set
                {
                    this.yearField = value;
                }
            }

            /// <summary>
            /// Month
            /// </summary>
            public byte Month
            {
                get
                {
                    return this.monthField;
                }
                set
                {
                    this.monthField = value;
                }
            }

            /// <summary>
            /// Verification
            /// </summary>
            public ushort Verification
            {
                get
                {
                    return this.verificationField;
                }
                set
                {
                    this.verificationField = value;
                }
            }
        }

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionAccountExpiry
        {

            private byte monthField;

            private ushort yearField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte month
            {
                get
                {
                    return this.monthField;
                }
                set
                {
                    this.monthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort year
            {
                get
                {
                    return this.yearField;
                }
                set
                {
                    this.yearField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Customer
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionCustomer
        {
            private RequestTransactionCustomerName nameField;
            private RequestTransactionCustomerContact contactField;
            private RequestTransactionCustomerAddress addressField;
            private RequestTransactionCustomerDetails detailsField;

            /// <summary>
            /// Name
            /// </summary>
            public RequestTransactionCustomerName Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <summary>
            /// Contact
            /// </summary>
            public RequestTransactionCustomerContact Contact
            {
                get
                {
                    return this.contactField;
                }
                set
                {
                    this.contactField = value;
                }
            }

            /// <summary>
            /// Address
            /// </summary>
            public RequestTransactionCustomerAddress Address
            {
                get
                {
                    return this.addressField;
                }
                set
                {
                    this.addressField = value;
                }
            }

            /// <summary>
            /// Details
            /// </summary>
            public RequestTransactionCustomerDetails Details
            {
                get
                {
                    return this.detailsField;
                }
                set
                {
                    this.detailsField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Customer Name
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionCustomerName
        {
            private string familyField;
            private string givenField;
            private string companyField;
            private string salutationField;
            private object titleField;

            /// <summary>
            /// Family
            /// </summary>
            public string Family
            {
                get
                {
                    return this.familyField;
                }
                set
                {
                    this.familyField = value;
                }
            }

            /// <summary>
            /// Given
            /// </summary>
            public string Given
            {
                get
                {
                    return this.givenField;
                }
                set
                {
                    this.givenField = value;
                }
            }

            /// <summary>
            /// Company
            /// </summary>
            public string Company
            {
                get
                {
                    return this.companyField;
                }
                set
                {
                    this.companyField = value;
                }
            }

            /// <summary>
            /// Salutation
            /// </summary>
            public string Salutation
            {
                get
                {
                    return this.salutationField;
                }
                set
                {
                    this.salutationField = value;
                }
            }

            /// <summary>
            /// Title
            /// </summary>
            public object Title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Customer Contact
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionCustomerContact
        {
            private string emailField;
            private string ipField;
            private string phoneField;

            /// <summary>
            /// Email
            /// </summary>
            public string Email
            {
                get
                {
                    return this.emailField;
                }
                set
                {
                    this.emailField = value;
                }
            }

            /// <summary>
            /// Ip
            /// </summary>
            public string Ip
            {
                get
                {
                    return this.ipField;
                }
                set
                {
                    this.ipField = value;
                }
            }

            /// <summary>
            /// Phone
            /// </summary>
            public string Phone
            {
                get
                {
                    return this.phoneField;
                }
                set
                {
                    this.phoneField = value;
                }
            }
        }

        /// <summary>
        /// Reuqest
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionCustomerAddress
        {
            private string cityField;
            private string countryField;
            private string stateField;
            private string streetField;
            private ushort zipField;

            /// <summary>
            /// City
            /// </summary>
            public string City
            {
                get
                {
                    return this.cityField;
                }
                set
                {
                    this.cityField = value;
                }
            }

            /// <summary>
            /// Country
            /// </summary>
            public string Country
            {
                get
                {
                    return this.countryField;
                }
                set
                {
                    this.countryField = value;
                }
            }

            /// <summary>
            /// State
            /// </summary>
            public string State
            {
                get
                {
                    return this.stateField;
                }
                set
                {
                    this.stateField = value;
                }
            }

            /// <summary>
            /// Street
            /// </summary>
            public string Street
            {
                get
                {
                    return this.streetField;
                }
                set
                {
                    this.streetField = value;
                }
            }

            /// <summary>
            /// Zip
            /// </summary>
            public ushort Zip
            {
                get
                {
                    return this.zipField;
                }
                set
                {
                    this.zipField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Customer Details
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionCustomerDetails
        {
            private RequestTransactionCustomerDetailsIdentity identityField;

            /// <summary>
            /// Identity
            /// </summary>
            public RequestTransactionCustomerDetailsIdentity Identity
            {
                get
                {
                    return this.identityField;
                }
                set
                {
                    this.identityField = value;
                }
            }
        }

        /// <summary>
        /// Request Transaction Customer Details Identity
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RequestTransactionCustomerDetailsIdentity
        {
            private string paperField;
            private string valueField;

            /// <summary>
            /// paper
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string paper
            {
                get
                {
                    return this.paperField;
                }
                set
                {
                    this.paperField = value;
                }
            }

            /// <summary>
            /// Value
            /// </summary>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }
    }
}