using com.azmisahin.PlugIn.Payment.Models;
namespace com.azmisahin.PlugIn.Payment.AzurePayment
{
    /// <summary>
    /// Azure Payment Assembly
    /// </summary>
    internal class Assembly
    {
        #region Field
        private Request content;
        private Response response;
        #endregion

        #region Ctor
        public Assembly(Request content)
        {
            this.content = content;            
            Progress();
        }
        #endregion

        #region Property
        public Response ToResult
        {
            get { return response; }
        }
        #endregion

        #region Internal

        /// <summary>
        /// Internal Progress
        /// </summary>
        private void Progress()
        {
            response = new Payment.Models.Response();
            var result = new Sender(content).Now();
            Convert(result);           
        }

        #region Convert Respons Data        
        private void Convert(Models.ResponseModel.Response model)
        {

            byte switch_on = model.Transaction.Processing.Status.code;
            switch (switch_on)
            {
                case 00: Approved(model); break;//SUCCESS*
                case 40: Decline(model); break;//NEUTRAL---------
                case 59: Wait(model); break;//WAITING_BANK*
                case 60: Decline(model); break;//REJECTED_BANK*
                case 64: Wait(model); break;//WAITING_RISK*
                case 65: Decline(model); break;//REJECTED_RISK*
                case 70: Error(model); break;//REJECTED_VALIDATION*
                case 80: Wait(model); break;//WAITING*
                case 90: Approved(model); break;//NEW*
                default:Error(model); break;
            }
        }
        private void Wait(Models.ResponseModel.Response model)
        {
            setTransaction(content.TRANSACTION.PosID, content.TRANSACTION.ReferansID);
            setProcess("2", "Wait", null, null);
            setDetail(content.ACCOUNT.Number.ToString().Substring(0, 4) + "************", content.CONTACT.Ip);
            setError(model.Transaction.Processing.Status.code.ToString(),
                string.Format(
                    "SV:{0} ResC:{1} ResV:{2} RetC:{3} RetV:{4}",
                    model.Transaction.Processing.Status.Value,
                    model.Transaction.Processing.Reason.code,
                    model.Transaction.Processing.Reason.Value,
                    model.Transaction.Processing.Return.code,
                    model.Transaction.Processing.Return.Value
                    ));
        }
        private void Error(Models.ResponseModel.Response model)
        {
            setTransaction(content.TRANSACTION.PosID, content.TRANSACTION.ReferansID);
            setProcess("-1", "Error", null, null);
            setDetail(content.ACCOUNT.Number.ToString().Substring(0, 4) + "************", content.CONTACT.Ip);
            setError(model.Transaction.Processing.Status.code.ToString(),
                string.Format(
                    "SV:{0} ResC:{1} ResV:{2} RetC:{3} RetV:{4}",
                    model.Transaction.Processing.Status.Value,
                    model.Transaction.Processing.Reason.code,
                    model.Transaction.Processing.Reason.Value,
                    model.Transaction.Processing.Return.code,
                    model.Transaction.Processing.Return.Value
                    ));
        }

        private void Decline(Models.ResponseModel.Response model)
        {
            setTransaction(content.TRANSACTION.PosID, content.TRANSACTION.ReferansID);
            setProcess("0", "Declined", null, null);
            setDetail(content.ACCOUNT.Number.ToString().Substring(0, 4) + "************", content.CONTACT.Ip);
            setError(model.Transaction.Processing.code,
                 string.Format(
                    "{0} {1} {2} {3} {4}",
                    model.Transaction.Processing.Status.Value,
                    model.Transaction.Processing.Reason.code,
                    model.Transaction.Processing.Reason.Value,
                    model.Transaction.Processing.Return.code,
                    model.Transaction.Processing.Return.Value
                    )
                );
        }

        private void Approved(Models.ResponseModel.Response model)
        {
            setTransaction(content.TRANSACTION.PosID, content.TRANSACTION.ReferansID);
            setProcess("1", "Approved", model.Transaction.Identification.TransactionID.ToString() ,model.Transaction.Identification.TransactionID.ToString());
            setDetail(content.ACCOUNT.Number.ToString().Substring(0, 4) + "************", content.CONTACT.Ip);
            setError(null, null);
        }
        #endregion

        #region Internal Set
        /// <summary>
        /// Set Transaction
        /// </summary>
        /// <param name="posID"></param>
        /// <param name="referansID"></param>
        public void setTransaction(int posID, string referansID)
        {
            response.TRANSACTION.PosID = posID;
            response.TRANSACTION.ReferansID = referansID;
        }

        /// <summary>
        /// Set Progress
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="transactionID"></param>
        /// <param name="authCode"></param>
        public void setProcess(string code, string message, string transactionID, string authCode)
        {
            response.PROCESS.Code = code;
            response.PROCESS.Message = message;
            response.PROCESS.TransactionID = transactionID;
            response.PROCESS.AuthCode = authCode;
        }

        /// <summary>
        /// Set Detail
        /// </summary>
        /// <param name="masketPan"></param>
        /// <param name="clientIP"></param>
        public void setDetail(string masketPan, string clientIP)
        {
            response.DETAIL.MasketPan = masketPan;
            response.DETAIL.ClientIP = clientIP;
        }

        /// <summary>
        /// Set Error
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public void setError(string code, string message)
        {
            response.ERROR.Code = code;
            response.ERROR.Message = message;
        } 
        #endregion

        #endregion
    }
}
