namespace com.azmisahin.PlugIn.Payment.AzurePayment.Models
{
    /// <summary>
    /// Auzre Payment Response Model
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Response
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Response
        {
            private ResponseTransaction transactionField;
            private decimal versionField;

            /// <summary>
            /// Transaction
            /// </summary>
            public ResponseTransaction Transaction
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
        /// Response Transaction
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ResponseTransaction
        {
            private ResponseTransactionIdentification identificationField;
            private ResponseTransactionPayment paymentField;
            private ResponseTransactionProcessing processingField;
            private string modeField;
            private string channelField;
            private string responseField;

            /// <summary>
            /// Identification
            /// </summary>
            public ResponseTransactionIdentification Identification
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
            /// Payment
            /// </summary>
            public ResponseTransactionPayment Payment
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

            /// <summary>
            /// Processing
            /// </summary>
            public ResponseTransactionProcessing Processing
            {
                get
                {
                    return this.processingField;
                }
                set
                {
                    this.processingField = value;
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
            /// channel
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

        /// <summary>
        /// Response Transaction Identification
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ResponseTransactionIdentification
        {
            private string uniqueIDField;

            /// <summary>
            /// UniqueID
            /// Alphanumeric  32
            /// Only ID where the uniqueness within the system is absolutely guaranteed. Has to be used for all automated matching and reference purposes.             
            /// </summary>
            public string UniqueID
            {
                get
                {
                    return this.uniqueIDField;
                }
                set
                {
                    this.uniqueIDField = value;
                }
            }

            private string shortIDField;

            /// <summary>
            /// ShortID 
            /// Numeric / Dots [14]
            /// ID which is used for manual entry and search purposes. The likelihood for uniqueness is very high, but not guaranteed. TransactionID 
            /// </summary>
            public string ShortID
            {
                get
                {
                    return this.shortIDField;
                }
                set
                {
                    this.shortIDField = value;
                }
            }

            private string transactionIDField;

            /// <summary>
            /// Transaction ID
            /// Alphanumeric 0..256 [Optional]
            /// ID assigned by the merchant. Uniqueness in the system or even just within the channel is not being checked at all. InvoiceID 
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

            private string invoiceIDField;

            /// <summary>
            /// InvoiceID 
            /// Alphanumeric [0..256] [ Optional ]
            /// ID assigned by the merchant to assign it to a certain invoice. Typically this invoice ID is the ID the merchant also communicates to the shopper for a certain invoice. 
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

            private string shopperIDField;

            /// <summary>
            /// ShopperID 
            /// Alphanumeric [0..256] [ Optional ]
            /// ID assigned by the merchant to assign it to a certain shopper. Typically the user ID or customer ID of the shopper within the merchant’s shop system provided here. It can be used to search for all transactions of one shopper in the analysis backend tool. 
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

            private string referenceIDField;

            /// <summary>
            /// ReferenceID 
            /// Alphanumeric [32] [ Cond. Mandatory ]
            /// References to the Unique ID of another transaction.Only needed for the submission of following transaction types: Capture, Reversal and Refund.Chargeback and Deposit transactions contain the Reference ID in the response message.
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

            private string bulkIDField;

            /// <summary>
            /// BulkID 
            /// Alphanumeric [0..64] [ Optional  ]
            /// ID assigned by the merchant. It can be used to mark transactions with a common field which logically belong together, e.g. all transactions sent in on a given date by sending in the date as the bulk id.   
            /// </summary>
            public string BulkID
            {
                get
                {
                    return this.bulkIDField;
                }
                set
                {
                    this.bulkIDField = value;
                }
            }

        }

        /// <summary>
        /// Response Transaction Payment
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ResponseTransactionPayment
        {
            private string codeField;

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
        /// Response Transaction Processing
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ResponseTransactionProcessing
        {
            private string timestampField;
            private string resultField;
            private ResponseTransactionProcessingStatus statusField;
            private ResponseTransactionProcessingReason reasonField;
            private ResponseTransactionProcessingReturn returnField;
            private string infoMessageField;
            private string codeField;

            /// <summary>
            /// Timestamp
            /// </summary>
            public string Timestamp
            {
                get
                {
                    return this.timestampField;
                }
                set
                {
                    this.timestampField = value;
                }
            }

            /// <summary>
            /// Result
            /// </summary>
            public string Result
            {
                get
                {
                    return this.resultField;
                }
                set
                {
                    this.resultField = value;
                }
            }

            /// <summary>
            /// Status
            /// </summary>
            public ResponseTransactionProcessingStatus Status
            {
                get
                {
                    return this.statusField;
                }
                set
                {
                    this.statusField = value;
                }
            }

            /// <summary>
            /// Reason
            /// </summary>
            public ResponseTransactionProcessingReason Reason
            {
                get
                {
                    return this.reasonField;
                }
                set
                {
                    this.reasonField = value;
                }
            }

            /// <summary>
            /// Response Transaction Processing Return
            /// </summary>
            public ResponseTransactionProcessingReturn Return
            {
                get
                {
                    return this.returnField;
                }
                set
                {
                    this.returnField = value;
                }
            }

            /// <summary>
            /// Info Message
            /// </summary>
            public string InfoMessage
            {
                get
                {
                    return this.infoMessageField;
                }
                set
                {
                    this.infoMessageField = value;
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
        /// Response Transaction Processing Status
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ResponseTransactionProcessingStatus
        {
            private byte codeField;
            private string valueField;

            /// <summary>
            /// code
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte code
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

        /// <summary>
        /// Response Transaction Processing Reason
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ResponseTransactionProcessingReason
        {
            private byte codeField;
            private string valueField;

            /// <summary>
            /// code
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte code
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

        /// <summary>
        /// Response Transaction Processing Return
        /// </summary>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ResponseTransactionProcessingReturn
        {
            private string codeField;
            private string valueField;

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