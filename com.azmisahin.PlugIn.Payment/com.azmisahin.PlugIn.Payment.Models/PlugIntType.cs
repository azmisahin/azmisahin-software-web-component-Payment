using System;
namespace com.azmisahin.PlugIn.Payment.Models
{
    /// <summary>
    /// Payment PlugIn
    /// </summary>
    [Serializable()]
    public enum PlugIntType
    {
        /// <summary>
        /// Other Payment System
        /// </summary>
        OtherPayment = 0,
        /// <summary>
        /// Azure Payment System
        /// </summary>
        AzurePayment = 1
    }
}