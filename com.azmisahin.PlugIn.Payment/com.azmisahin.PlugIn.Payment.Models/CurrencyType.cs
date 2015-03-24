using System;
namespace com.azmisahin.PlugIn.Payment.Models
{
    /// <summary>
    /// Currency Code
    /// </summary>
    [Serializable()]
    public enum CurrencyType
    {
        /// <summary>
        /// Turkish Lira
        /// </summary>
        YTL = 949,

        /// <summary>
        /// Amerikan Dolar
        /// </summary>
        USD = 840,

        /// <summary>
        /// Euro
        /// </summary>
        EUR = 978
    }
}
