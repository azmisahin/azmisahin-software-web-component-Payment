using System.Collections.Generic;
namespace com.azmisahin.PlugIn.Payment.AzurePayment.Models
{
    /// <summary>
    /// Azure Payment Response Json Model
    /// </summary>
    public class ResponseJsonModel
    {
        public class Expiry
        {
            public string month { get; set; }
            public string year { get; set; }
        }

        public class Account
        {
            public string bin { get; set; }
            public string brand { get; set; }
            public Expiry expiry { get; set; }
            public string holder { get; set; }
            public string last4Digits { get; set; }
        }

        public class Criterion
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Address
        {
            public string city { get; set; }
            public string country { get; set; }
            public string street { get; set; }
            public string zip { get; set; }
        }

        public class Contact
        {
            public string ip { get; set; }
            public string ipCountry { get; set; }
        }

        public class Customer
        {
            public Address address { get; set; }
            public Contact contact { get; set; }
        }

        public class Identification
        {
            public string shopperid { get; set; }
            public string shortId { get; set; }
            public string transactionid { get; set; }
            public string uniqueId { get; set; }
        }

        public class Clearing
        {
            public string amount { get; set; }
            public string currency { get; set; }
        }

        public class Payment
        {
            public Clearing clearing { get; set; }
            public string code { get; set; }
        }

        public class Reason
        {
            public string code { get; set; }
            public string message { get; set; }
        }

        public class Return
        {
            public string code { get; set; }
            public string message { get; set; }
        }

        public class Processing
        {
            public string code { get; set; }
            public List<object> connectorDetails { get; set; }
            public Reason reason { get; set; }
            public string result { get; set; }
            public Return @return { get; set; }
            public string timestamp { get; set; }
        }

        public class Transaction
        {
            public Account account { get; set; }
            public string channel { get; set; }
            public List<Criterion> criterions { get; set; }
            public Customer customer { get; set; }
            public Identification identification { get; set; }
            public string mode { get; set; }
            public Payment payment { get; set; }
            public Processing processing { get; set; }
            public string response { get; set; }
        }

        public class RootObject
        {
            public string token { get; set; }
            public Transaction transaction { get; set; }
        }
    }
}