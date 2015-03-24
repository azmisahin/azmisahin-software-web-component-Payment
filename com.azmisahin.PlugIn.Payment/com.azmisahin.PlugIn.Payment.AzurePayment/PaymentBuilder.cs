namespace com.azmisahin.PlugIn.Payment.AzurePayment
{
    /// <summary>
    /// Azure Payment System Builder
    /// </summary>
    public class PaymentBuilder
    {
        /// <summary>
        /// Singletion
        /// </summary>
        private static volatile PaymentFactory instance;

        /// <summary>
        /// Initalize Azure Payment Factory
        /// </summary>
        public static IPaymentFactory Initalize
        {
            get { if (instance == null) instance = new PaymentFactory(); return instance; }
        }
    }
}