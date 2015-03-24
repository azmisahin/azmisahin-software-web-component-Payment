using System;
using com.azmisahin.PlugIn.Payment.Models;
namespace com.azmisahin.PlugIn.Payment.AzurePayment
{
    /// <summary>
    /// Azure Payment Factory
    /// </summary>
    public class PaymentFactory : IPaymentFactory
    {
        #region Field
        private Response response;
        #endregion

        #region Ctor
        public PaymentFactory()
        {
            response = new Response();
        }
        #endregion

        #region Property

        /// <summary>
        /// Operasyon
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public override IPaymentFactory Request(Request content)
        {
            switch (content.HEADER.ChargeModel)
            {
                case ChargeModel.Xml:
                    response = new Assembly(content).ToResult;
                    break;
                case ChargeModel.ThreeD:
                    response = new Response();
                    SetThree3DReult(content);
                    break;
                case ChargeModel.Common:
                    break;
                default:
                    break;
            }

            return this;
        }

        #region Internal
        private void SetThree3DReult(Request content)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            string stringAmount = Convert.ToString(content.PAYMENT.Amount, culture);
            response.HEADER.Token = Sender.GetToken(stringAmount, content.PAYMENT.Currency.ToString(), content);
            response.HEADER.PlugIntType = PlugIntType.AzurePayment;
            response.HEADER.ChargeModel = ChargeModel.ThreeD;
            response.HEADER.Query = Sender.GetQuery(response.HEADER.Token);
            response.PROCESS.Code = "2";
            response.DETAIL.Brand = content.ACCOUNT.Brand;
        }
        #endregion

        /// <summary>
        /// Start End Response
        /// </summary>
        /// <returns></returns>
        public override Response Start()
        {
            return response;
        }
        #endregion
    }
}