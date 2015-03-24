using System;
namespace com.azmisahin.PlugIn.Payment.Models
{
    /// <summary>
    /// Payment Basket Product
    /// </summary>    
    [Serializable()]
    public class ProductItem
    {
        /// <summary>
        /// Prodict ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Prodict Single Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product Quantity
        /// </summary>
        public byte Quantity { get; set; }

        /// <summary>
        /// Product Code / Bar Code /  Other Code
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Product Line Total Price
        /// </summary>
        public decimal Total { get; set; }
    }
}