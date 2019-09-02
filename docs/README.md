# Payment

Payment PlugIn

Transaction Based Payment PlugIn Manager

## Charge Model

```C#
        /// <summary>
        /// Xml Transaction
        /// </summary>
        Xml     =   1,

        /// <summary>
        /// 3D Transaction
        /// </summary>
        ThreeD  =   2,

        /// <summary>
        /// Co-Payment
        /// </summary>
        Common  =   3
```

## Charge Type

```C#
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
```

## Usage

```c#
 var response = PaymentTask.Initalize
                .UsePlugInType(PlugIntType.AzurePayment)
                .UseChargeModel(ChargeModel.ThreeD)
                .SetPosID(1)
                .SetReferansID(DateTime.Now.Ticks.ToString())
                .SetChargeType(ChargeType.Auth)
                .SetAmount(0.99m)
                .SetCurrency(CurrencyType.EUR)
                .SetInstallment(0)
                .SetHolder("Jack JACKSON")
                .SetYear(2015)
                .SetMonth(10)
                .SetNumber(4012888888881881)
                .SetVerification(123)
                .SetBrandType(BrandType.VISA)
                .SetFamilyName("JACKSON")
                .SetGiven("Jack")
                .SetCompany("JACKSON")
                .SetSalutation("Mr")
                .SetEmail("Jack@JACKSON.com")
                .SetIp("888.888.001.881")
                .SetPhone("01234567890")
                .SetCity("ANTALYA")
                .SetCountry("TR")
                .SetState("MURATPASA")
                .SetStreet("ATATURK")
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

```