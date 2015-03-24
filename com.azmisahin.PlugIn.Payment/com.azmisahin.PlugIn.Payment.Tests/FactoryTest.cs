using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.azmisahin.PlugIn.Payment.Models;
namespace com.azmisahin.PlugIn.Payment.Tests
{
    [TestClass]
    public class FactoryTest
    {
        /// <summary>
        /// Three D Test
        /// </summary>
        [TestMethod]
        public void AzurePaymentThreeD()
        {
            var response = PaymentTask.Initalize
                .UsePlugInType(PlugIntType.AzurePayment)
                .UseChargeModel(ChargeModel.ThreeD)
                .SetPosID(1)
                .SetReferansID(DateTime.Now.Ticks.ToString())
                .SetChargeType(ChargeType.Auth)
                .SetAmount(0.99m)
                .SetCurrency(CurrencyType.EUR)
                .SetInstallment(0)
                .SetHolder("Azmi SAHIN")
                .SetYear(2015)
                .SetMonth(10)
                .SetNumber(4012888888881881)
                .SetVerification(123)
                .SetBrandType(BrandType.VISA)
                .SetFamilyName("SAHIN")
                .SetGiven("Azmi")
                .SetCompany("azmisahin.com")
                .SetSalutation("Mr")
                .SetEmail("azmisahin@outlook.com")
                .SetIp("207.46.147.148")
                .SetPhone("05548777858")
                .SetCity("Antalya")
                .SetCountry("TR")
                .SetState("Muratpasa")
                .SetStreet("Ataturk")
                .SetZip(07700)
                .AddItem(new ProductItem { ID = 15, Description = "Virtual Money", Price = 10, Quantity = 100, ProductCode = "VM15", Total = 100.0m })
                .Start();

            switch (response.HEADER.ChargeModel)
            {
                case ChargeModel.Xml:
                    responseWrite(response);
                    break;
                case ChargeModel.ThreeD:
                    Console.WriteLine("Query:{0} Token:{1}", response.HEADER.Query, response.HEADER.Token);
                    break;
                case ChargeModel.Common:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Response Result Code And Write
        /// </summary>
        /// <param name="response"></param>
        public void responseWrite(Response response)
        {
            switch (response.PROCESS.Code)
            {
                case "-1":
                    Console.WriteLine("Error" + Environment.NewLine);
                    Console.WriteLine("--------------------------------------------------" + Environment.NewLine);
                    Console.WriteLine(string.Format("PosID          : {0}" + Environment.NewLine, response.TRANSACTION.PosID));
                    Console.WriteLine(string.Format("ReferansID     : {0}" + Environment.NewLine, response.TRANSACTION.ReferansID));
                    Console.WriteLine(string.Format("PROCESS Code   : {0}" + Environment.NewLine, response.PROCESS.Code));
                    Console.WriteLine(string.Format("PROCESS Message: {0}" + Environment.NewLine, response.PROCESS.Message));
                    Console.WriteLine(string.Format("ClientIP       : {0}" + Environment.NewLine, response.DETAIL.ClientIP));
                    Console.WriteLine(string.Format("ERROR Code     : {0}" + Environment.NewLine, response.ERROR.Code));
                    Console.WriteLine(string.Format("ERROR Message  : {0}" + Environment.NewLine, response.ERROR.Message));
                    break;
                case "0":
                    Console.WriteLine("Declined" + Environment.NewLine);
                    Console.WriteLine("--------------------------------------------------" + Environment.NewLine);
                    Console.WriteLine(string.Format("PosID          : {0}" + Environment.NewLine, response.TRANSACTION.PosID));
                    Console.WriteLine(string.Format("ReferansID     : {0}" + Environment.NewLine, response.TRANSACTION.ReferansID));
                    Console.WriteLine(string.Format("PROCESS Code   : {0}" + Environment.NewLine, response.PROCESS.Code));
                    Console.WriteLine(string.Format("PROCESS Message: {0}" + Environment.NewLine, response.PROCESS.Message));
                    Console.WriteLine(string.Format("ClientIP       : {0}" + Environment.NewLine, response.DETAIL.ClientIP));
                    break;
                case "1":
                    Console.WriteLine("Approved" + Environment.NewLine);
                    Console.WriteLine("--------------------------------------------------" + Environment.NewLine);
                    Console.WriteLine(string.Format("PosID          : {0}" + Environment.NewLine, response.TRANSACTION.PosID));
                    Console.WriteLine(string.Format("ReferansID     : {0}" + Environment.NewLine, response.TRANSACTION.ReferansID));
                    Console.WriteLine(string.Format("PROCESS Code   : {0}" + Environment.NewLine, response.PROCESS.Code));
                    Console.WriteLine(string.Format("PROCESS Message: {0}" + Environment.NewLine, response.PROCESS.Message));
                    Console.WriteLine(string.Format("TransactionID  : {0}" + Environment.NewLine, response.PROCESS.TransactionID));
                    Console.WriteLine(string.Format("AuthCode       : {0}" + Environment.NewLine, response.PROCESS.AuthCode));
                    Console.WriteLine(string.Format("MasketPan      : {0}" + Environment.NewLine, response.DETAIL.MasketPan));
                    Console.WriteLine(string.Format("ClientIP       : {0}" + Environment.NewLine, response.DETAIL.ClientIP));
                    break;
                default:
                    Console.WriteLine("Unknow" + Environment.NewLine);
                    Console.WriteLine("--------------------------------------------------" + Environment.NewLine);
                    Console.WriteLine(string.Format("PosID          : {0}" + Environment.NewLine, response.TRANSACTION.PosID));
                    Console.WriteLine(string.Format("ReferansID     : {0}" + Environment.NewLine, response.TRANSACTION.ReferansID));
                    Console.WriteLine(string.Format("PROCESS Code   : {0}" + Environment.NewLine, response.PROCESS.Code));
                    Console.WriteLine(string.Format("PROCESS Message: {0}" + Environment.NewLine, response.PROCESS.Message));
                    Console.WriteLine(string.Format("TransactionID  : {0}" + Environment.NewLine, response.PROCESS.TransactionID));
                    Console.WriteLine(string.Format("AuthCode       : {0}" + Environment.NewLine, response.PROCESS.AuthCode));
                    Console.WriteLine(string.Format("MasketPan      : {0}" + Environment.NewLine, response.DETAIL.MasketPan));
                    Console.WriteLine(string.Format("ClientIP       : {0}" + Environment.NewLine, response.DETAIL.ClientIP));
                    Console.WriteLine(string.Format("ERROR Code     : {0}" + Environment.NewLine, response.ERROR.Code));
                    Console.WriteLine(string.Format("ERROR Message  : {0}" + Environment.NewLine, response.ERROR.Message));
                    break;
            }
        }
    }
}