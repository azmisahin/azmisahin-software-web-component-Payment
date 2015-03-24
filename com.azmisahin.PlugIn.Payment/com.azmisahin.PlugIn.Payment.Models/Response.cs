using System;
namespace com.azmisahin.PlugIn.Payment.Models
{
    /// <summary>
    /// Response Model
    /// </summary>
    [Serializable()]
    public class Response
    {
        #region Property
        public Header HEADER { get; set; }
        public Transaction TRANSACTION { get; set; }
        public Process PROCESS { get; set; }
        public Detail DETAIL { get; set; }
        public Error ERROR { get; set; }
        #endregion

        #region Ctor
        public Response()
        {
            HEADER = new Header();
            TRANSACTION = new Transaction();
            PROCESS = new Process();
            DETAIL = new Detail();
            ERROR = new Error();
        }
        #endregion

        #region Sub
        [Serializable()]
        public class Header
        {
            public ChargeModel ChargeModel { get; set; }
            public PlugIntType PlugIntType { get; set; }
            public string MerchantDomain { get; set; }
            public string Uri { get; set; }
            public object Token { get; set; }
            public string Query { get; set; }
            public Header()
            {
                PlugIntType = PlugIntType.AzurePayment;
                ChargeModel = ChargeModel.Xml;
            }
        }
        /// <summary>
        /// Transaction Model
        /// </summary>
        [Serializable()]
        public class Transaction
        {
            /// <summary>
            /// For Data...
            /// </summary>
            public int PosID { get; set; }

            /// <summary>
            /// Merchant Referans ID
            /// [ Order ID ] 
            /// or
            /// [ Generated unique order number ]
            /// </summary>
            public string ReferansID { get; set; }
        }

        /// <summary>
        /// Process Model
        /// </summary>
        [Serializable()]
        public class Process
        {
            /// <summary>
            /// [ -1 Error      ]
            /// [  0 Declined   ]
            /// [  1 Approved   ] 
            /// [  2 Secure Wait] 
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// Process Message
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// if Approved
            /// Return Provider Referans ID
            /// </summary>
            public string TransactionID { get; set; }

            /// <summary>
            /// if Approved
            /// Return Provide Authenticated Code
            /// </summary>
            public string AuthCode { get; set; }

            public string amount { get; set; }
            public string currency { get; set; }

        }

        /// <summary>
        /// Detail Model
        /// </summary>
        [Serializable()]
        public class Detail
        {
            /// <summary>
            /// Connected Client IP
            /// </summary>
            public string ClientIP { get; set; }

            /// <summary>
            /// Account Card Number
            /// [1234********1234]
            /// </summary>
            public string MasketPan { get; set; }

            /// <summary>
            /// Brand Type
            /// </summary>
            public BrandType Brand { get; set; }


        }

        /// <summary>
        /// Error Model
        /// </summary>
        [Serializable()]
        public class Error
        {
            /// <summary>
            /// Eror Code
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// Error Message
            /// </summary>
            public string Message { get; set; }
        }
        #endregion
    }
}
