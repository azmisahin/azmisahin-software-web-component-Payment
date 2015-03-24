using com.azmisahin.PlugIn.Payment.Models;
namespace com.azmisahin.PlugIn.Payment.AzurePayment
{
    /// <summary>
    /// Azure Payment Factory Interface
    /// </summary>
    public abstract class IPaymentFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public abstract IPaymentFactory Request(Request content);

        /// <summary>
        /// Response
        /// </summary>
        /// <returns></returns>
        public abstract Response Start();
    }
}