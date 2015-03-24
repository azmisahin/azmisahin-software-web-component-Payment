using System.Collections;
namespace com.azmisahin.PlugIn.Payment
{
    /// <summary>
    /// Paymen Task
    /// </summary>
    public class PaymentTask
    {
        /// <summary>
        /// Singletion
        /// </summary>
        private static volatile PaymentFactory instance;

        /// <summary>
        /// Initalize Payment Factory
        /// </summary>
        public static IPaymentFactory Initalize
        {
            get { if (instance == null) instance = new PaymentFactory(); return instance; }
        }
    }
}