using System;
using System.Collections.Generic;
using com.azmisahin.PlugIn.Payment.Models;
using com.azmisahin.PlugIn.Payment.AzurePayment;
namespace com.azmisahin.PlugIn.Payment
{
    /// <summary>
    /// Payment Factory
    /// </summary>
    public class PaymentFactory : IPaymentFactory
    {
        #region Field
        private Request request;
        #endregion

        #region Ctor
        public PaymentFactory()
        {
            request = new Request();
        }
        #endregion

        #region Property Set
        public override IPaymentFactory UsePlugInType(PlugIntType plugIntType)
        {
            this.request.HEADER.PlugIntType = plugIntType;
            return this;
        }
        public override IPaymentFactory UseChargeModel(ChargeModel chargeModel)
        {
            this.request.HEADER.ChargeModel = chargeModel;
            return this;
        }
        public override IPaymentFactory SetPosID(int posID)
        {
            request.TRANSACTION.PosID = posID;
            return this;
        }
        public override IPaymentFactory SetReferansID(string referansID)
        {
            request.TRANSACTION.ReferansID = referansID;
            return this;
        }
        public override IPaymentFactory SetChargeType(ChargeType chargeType)
        {
            request.TRANSACTION.ChargeType = chargeType;
            return this;
        }
        public override IPaymentFactory SetAmount(decimal amount)
        {
            request.PAYMENT.Amount = amount;
            return this;
        }
        public override IPaymentFactory SetCurrency(CurrencyType currency)
        {
            request.PAYMENT.Currency = currency;
            return this;
        }
        public override IPaymentFactory SetInstallment(int installment)
        {
            request.PAYMENT.Installment = installment;
            return this;
        }
        public override IPaymentFactory SetHolder(string holder)
        {
            request.ACCOUNT.Holder = holder;
            return this;
        }
        public override IPaymentFactory SetYear(ushort year)
        {
            request.ACCOUNT.Year = year;
            return this;
        }
        public override IPaymentFactory SetMonth(byte month)
        {
            request.ACCOUNT.Month = month;
            return this;
        }
        public override IPaymentFactory SetNumber(ulong number)
        {
            request.ACCOUNT.Number = number;
            return this;
        }
        public override IPaymentFactory SetVerification(ushort verification)
        {
            request.ACCOUNT.Verification = verification;
            return this;
        }
        public override IPaymentFactory SetBrandType(BrandType brandType)
        {
            request.ACCOUNT.Brand = brandType;
            return this;
        }
        public override IPaymentFactory SetFamilyName(string familyName)
        {
            request.CUSTOMER.FamliyName = familyName;
            return this;
        }
        public override IPaymentFactory SetGiven(string given)
        {
            request.CUSTOMER.Given = given;
            return this;
        }
        public override IPaymentFactory SetCompany(string company)
        {
            request.CUSTOMER.Company = company;
            return this;
        }
        public override IPaymentFactory SetSalutation(string salutation)
        {
            request.CUSTOMER.Salutation = salutation;
            return this;
        }
        public override IPaymentFactory SetEmail(string email)
        {
            request.CONTACT.Email = email;
            return this;
        }
        public override IPaymentFactory SetIp(string ip)
        {
            request.CONTACT.Ip = ip;
            return this;
        }
        public override IPaymentFactory SetPhone(string phone)
        {
            request.CONTACT.Phone = phone;
            return this;
        }
        public override IPaymentFactory SetCity(string city)
        {
            request.ADRESS.City = city;
            return this;
        }
        public override IPaymentFactory SetCountry(string country)
        {
            request.ADRESS.Country = country;
            return this;
        }
        public override IPaymentFactory SetState(string state)
        {
            request.ADRESS.State = state;
            return this;
        }
        public override IPaymentFactory SetStreet(string street)
        {
            request.ADRESS.Street = street;
            return this;
        }
        public override IPaymentFactory SetZip(ushort zip)
        {
            request.ADRESS.Zip = zip;
            return this;
        }
        public override IPaymentFactory AddItem(ProductItem item)
        {
            request.ITEMS.Add(item);
            return this;
        }

        public override IPaymentFactory AddItems(List<ProductItem> items)
        {
            request.ITEMS.AddRange(items);
            return this;
        }
        #endregion

        #region Property Get
        public override Response Start()
        {
            Validate();
            Response response;
            switch (request.HEADER.PlugIntType)
            {
                case PlugIntType.AzurePayment:
                    response = PaymentBuilder
                        .Initalize
                        .Request(request)
                        .Start();
                    break;
                case PlugIntType.OtherPayment:
                    response = PaymentBuilder
                        .Initalize
                        .Request(request)
                        .Start();
                    break;
                default:
                    response = new Response();
                    break;
            }
            Log(request, response);
            return response;
        }
        #endregion

        #region Internal
        /// <summary>
        /// Start Before Validate And Complated
        /// </summary>
        private void Validate()
        {
            if (string.IsNullOrEmpty(request.CONTACT.Ip)) request.CONTACT.Ip = request.CONTACT.Ip = Extensions.GetUserIP;
        }

        /// <summary>
        /// Dump Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        private void Log(Request request, Response response)
        {
            string name = DateTime.Now.Ticks + ".data";
            com.azmisahin.Extensions.Binary<com.azmisahin.PlugIn.Payment.Models.Data> binary = new com.azmisahin.Extensions.Binary<com.azmisahin.PlugIn.Payment.Models.Data>();
            com.azmisahin.PlugIn.Payment.Models.Data factorys = new com.azmisahin.PlugIn.Payment.Models.Data { Request = request, Response = response };
            var domainFull = AppDomain.CurrentDomain.BaseDirectory + name;
            binary.writeDataFile(factorys, domainFull);
        }
        #endregion
    }
}