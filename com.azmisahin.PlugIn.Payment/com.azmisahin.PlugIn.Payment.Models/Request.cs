using System;
using System.Collections.Generic;
namespace com.azmisahin.PlugIn.Payment.Models
{
    /// <summary>
    /// Request Model
    /// </summary>
    [Serializable()]
    public class Request
    {
        #region Property
        public Header HEADER { get; set; }
        public Transaction TRANSACTION { get; set; }
        public Payment PAYMENT { get; set; }
        public Account ACCOUNT { get; set; }
        public Customer CUSTOMER { get; set; }
        public Contact CONTACT { get; set; }
        public Adress ADRESS { get; set; }
        public List<ProductItem> ITEMS { get; set; }
        #endregion

        #region Ctor
        public Request()
        {
            HEADER = new Header();
            TRANSACTION = new Transaction();
            PAYMENT = new Payment();
            ACCOUNT = new Account();
            CUSTOMER = new Customer();
            CONTACT = new Contact();
            ADRESS = new Adress();
            ITEMS = new List<ProductItem>();
        }
        #endregion

        #region Sub
        [Serializable()]
        public class Header
        {
            public ChargeModel ChargeModel { get; set; }
            public PlugIntType PlugIntType { get; set; }
            public string Uri { get; set; }
            public object Token { get; set; }
            public string Query { get; set; }
            public Header()
            {
                PlugIntType = PlugIntType.AzurePayment;
                ChargeModel = ChargeModel.Xml;
            }
        }
        [Serializable()]
        public class Transaction
        {
            public int PosID { get; set; }
            public string ReferansID { get; set; }
            public ChargeType ChargeType { get; set; }
        }

        [Serializable()]
        public class Payment
        {
            public decimal Amount { get; set; }
            public CurrencyType Currency { get; set; }
            public int Installment { get; set; }
        }

        [Serializable()]
        public class Account
        {
            public BrandType Brand { get; set; }
            public string Holder { get; set; }
            public ushort Year { get; set; }
            public byte Month { get; set; }
            public ulong Number { get; set; }
            public ushort Verification { get; set; }
        }

        [Serializable()]
        public class Customer
        {
            public string FamliyName { get; set; }
            public string Given { get; set; }
            public string Company { get; set; }
            public string Salutation { get; set; }
        }

        [Serializable()]
        public class Contact
        {
            public string Email { get; set; }
            public string Ip { get; set; }
            public string Phone { get; set; }
        }

        [Serializable()]
        public class Adress
        {
            public string City { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string Street { get; set; }
            public ushort Zip { get; set; }
        }
        #endregion
    }
}