using System;
namespace com.azmisahin.PlugIn.Payment.Models
{
    /// <summary>
    /// Charge Model
    /// </summary>
    [Serializable()]
    public enum ChargeModel
    {
        /// <summary>
        /// Xml Transaction
        /// </summary>
        Xml = 1,

        /// <summary>
        /// 3D Transaction
        /// </summary>
        ThreeD = 2,

        /// <summary>
        /// Co-Payment
        /// </summary>
        Common = 3
    }
}