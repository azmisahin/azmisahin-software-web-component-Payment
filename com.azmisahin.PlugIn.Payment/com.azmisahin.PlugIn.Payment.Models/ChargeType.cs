using System;
namespace com.azmisahin.PlugIn.Payment.Models
{
    /// <summary>
    /// Payment Charge Type
    /// </summary>
    [Serializable()]
    public enum ChargeType
    {
        /// <summary>
        /// Sale
        /// </summary>
        Auth = 1,

        /// <summary>
        /// On Otorizasyon
        /// </summary>

        PreAuth = 2,
        /// <summary>
        /// Otorizasoyon
        /// </summary>
        PostAuth = 3,

        /// <summary>
        /// Credi
        /// </summary>
        Credit = 4,

        /// <summary>
        /// Iptal
        /// </summary>
        Void = 5
    }
}