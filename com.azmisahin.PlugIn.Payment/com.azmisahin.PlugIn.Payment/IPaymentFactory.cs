using com.azmisahin.PlugIn.Payment.Models;
using System.Collections.Generic;
namespace com.azmisahin.PlugIn.Payment
{
    /// <summary>
    /// Payment Factory Interface
    /// </summary>
    public abstract class IPaymentFactory
    {
        /// <summary>
        /// Payment Provider
        /// </summary>
        /// <param name="plugIntType"></param>
        /// <returns></returns>
        public abstract IPaymentFactory UsePlugInType(PlugIntType plugIntType);

        /// <summary>
        /// Charge Model
        /// </summary>
        /// <param name="chargeModel"></param>
        /// <returns></returns>
        public abstract IPaymentFactory UseChargeModel(ChargeModel chargeModel);

        /// <summary>
        /// PosID
        /// Optional
        /// </summary>
        /// <param name="posID"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetPosID(int posID);

        /// <summary>
        /// Order Referans Number
        /// Requared
        /// </summary>
        /// <param name="referansID">Min Char</param>
        /// <returns></returns>
        public abstract IPaymentFactory SetReferansID(string referansID);

        /// <summary>
        /// Payment Method
        /// </summary>
        /// <param name="chargeType"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetChargeType(ChargeType chargeType);

        /// <summary>
        /// Payment Total Amount
        /// Requared
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetAmount(decimal amount);

        /// <summary>
        /// Payment Currency 
        /// Requared
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetCurrency(CurrencyType currency);

        /// <summary>
        /// Installment Count
        /// Optional
        /// </summary>
        /// <param name="installment"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetInstallment(int installment);

        /// <summary>
        /// By Name On The Card
        /// </summary>
        /// <param name="holder"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetHolder(string holder);

        /// <summary>
        /// Card Expired Year
        /// Requared
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetYear(ushort year);

        /// <summary>
        /// Card Expired Month
        /// Requared
        /// </summary>
        /// <param name="month">String Two Char [01]</param>
        /// <returns></returns>
        public abstract IPaymentFactory SetMonth(byte month);

        /// <summary>
        /// Card Number
        /// Requared
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetNumber(ulong number);

        /// <summary>
        /// Verification [ cvv ]
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetVerification(ushort verification);

        /// <summary>
        /// Card Brand Type
        /// Optional
        /// </summary>
        /// <param name="brandType"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetBrandType(BrandType brandType);

        /// <summary>
        /// Order Familay Name
        /// Optional
        /// </summary>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetFamilyName(string familyName);

        /// <summary>
        /// Order Given Name
        /// Optional
        /// </summary>
        /// <param name="given"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetGiven(string given);

        /// <summary>
        /// Order Company
        /// Optional
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetCompany(string company);

        /// <summary>
        /// Order Salutation
        /// </summary>
        /// <param name="salutation"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetSalutation(string salutation);

        /// <summary>
        /// Order E-Mail
        /// Optional
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetEmail(string email);

        /// <summary>
        /// Client Ip Adres
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetIp(string ip);

        /// <summary>
        /// Order Phone Number
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetPhone(string phone);

        /// <summary>
        /// Order City
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetCity(string city);

        /// <summary>
        /// Order Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetCountry(string country);

        /// <summary>
        /// Order State
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetState(string state);

        /// <summary>
        /// Order Street
        /// Optional
        /// </summary>
        /// <param name="street"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetStreet(string street);

        /// <summary>
        /// Order Zip
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        public abstract IPaymentFactory SetZip(ushort zip);

        /// <summary>
        /// Order Product Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public abstract IPaymentFactory AddItem(ProductItem item);

        /// <summary>
        /// Order Product Items
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public abstract IPaymentFactory AddItems(List<ProductItem> items);

        /// <summary>
        /// Payment Start
        /// </summary>
        /// <returns></returns>
        public abstract Response Start();
    }
}