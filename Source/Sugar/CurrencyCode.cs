using System.ComponentModel;
using System.Security.Cryptography;

namespace Sugar
{
    /// <summary>
    /// ISO 4217 Currency Codes.
    /// </summary>
    public enum CurrencyCode
    {
        // ReSharper disable InconsistentNaming
        [Description("United States Dollar")]
        USD,
        [Description("Yen")]
        JPY,
        [Description("Bulgarian Lev")]
        BGN,
        [Description("Czech Koruna")]
        CZK,
        [Description("Danish Krone")]
        DKK,
        [Description("Estonia Krooni")]
        EEK,
        [Description("Euro")]
        EUR,
        [Description("United Kingdom Pound")]
        GBP,
        [Description("Hungary Forint")]
        HUF,
        [Description("Lithuania Litai")]
        LTL,
        [Description("Latvia Lati")]
        LVL,
        [Description("Poland Zlotych")]
        PLN,
        [Description("Romania New Lei")]
        RON,
        [Description("Sweden Kronor")]
        SEK,
        [Description("Switzerland Franc")]
        CHF,
        [Description("Norway Krone")]
        NOK,
        [Description("Croatia Kuna")]
        HRK,
        [Description("Russia Rubles")]
        RUB,
        [Description("Turkey Lira")]
        TRY,
        [Description("Australian Dollar")]
        AUD,
        [Description("Brazil Reais")]
        BRL,
        [Description("Canada Dollars")]
        CAD,
        [Description("China Yuan Renminbi")]
        CNY,
        [Description("Hong Kong Dollars")]
        HKD,
        [Description("Indonesia Rupiahs")]
        IDR,
        [Description("India Rupees")]
        INR,
        [Description("Korea (South) Won")]
        KRW,
        [Description("Mexico Pesos")]
        MXN,
        [Description("Malaysia Ringgits")]
        MYR,
        [Description("New Zealand Dollar")]
        NZD,
        [Description("Philippines Pesos")]
        PHP,
        [Description("Singapore Dollar")]
        SGD,
        [Description("Thailand Baht")]
        THB,
        [Description("South Africa Rand")]
        ZAR,
        [Description("Taiwan Dollar")]
        TWD,
        [Description("Argentine Peso")]
        ARS,
        [Description("Colombian Peso")]
        COP,
        [Description("Costa Rican Colon")]
        CRC,
        [Description("Chilean Peso")]
        CLP,
        [Description("Dominican Peso")]
        DOP,
        [Description("Peruvian Nuevo Sol")]
        PEN,
        [Description("Uruguayan Peso")]
        UYU,
        [Description("Venezuelan Bolivar")]
        VEF,
        [Description("Venezuelan Bolivar (DICOM)")]
        VEF_DICOM,
        [Description("Venezuelan Bolivar (Black Market)")]
        VEF_BLKMKT,
        [Description("Panamian Balboa")]
        PAB,
        [Description("Ukrainian Hryvnia")]
        UAH,
        [Description("Lebanese Pound")]
        LBP,
        [Description("Egyptian Pound")]
        EGP,
        [Description("Jordanian Dinar")]
        JOD,
        [Description("United Arab Emirates dirham")]
        AED,
        [Description("Venezuelan Bolívar Soberano")]
        VES,
        [Description("Vietnamese Dong")]
        VND,
        [Description("Saudi Arabian Riyal")]
        SAR,
        [Description("Sri Lankan Rupee")]
        LKR,
        [Description("Nepalese Rupee")]
        NPR,
        [Description("Mongolian Tögrög")]
        MNT,
        [Description("Eastern Caribbean Dollar")]
        XCD,
        [Description("Bolivian Boliviano")]
        BOB,
        [Description("Guatemalan Quetzal")]
        GTQ,
        [Description("Honduran Lempira")]
        HNL,
        [Description("Nicaraguan Córdoba")]
        NIO,
        [Description("Paraguayan Guaraní")]
        PYG,
        [Description("Bangladeshi Taka")]
        BDT,
        [Description("Moroccan Dirham")]
        MAD,
        [Description("Cuban Peso")]
        CUP,
        [Description("Bosnian Mark")]
        BAM,
        [Description("Uzbekistan Som")]
        UZS,
        [Description("Kazakhstan Tenge")]
        KZT,
        [Description("Israeli Shekel")]
        ILS,
        [Description("Trinidad and Tobago Dollar")]
        TTD,
        [Description("Cambodian Riel")]
        KHR,
        [Description("West African CFA Franc")]
        XOF,
        [Description("Alegerian Dinar")]
        DZD,
        [Description("Nigerian Naira")]
        NGN,
        [Description("Kuwaiti Dinar")]
        KWD,
        [Description("Afghan Afghani")]
        AFN,
        [Description("Albanian Lek")]
        ALL,
        [Description("Armenian Dram")]
        AMD,
        [Description("Netherlands Antillean Guilder")]
        ANG,
        [Description("Angolan Kwanza")]
        AOA,
        [Description("Aruban Florin")]
        AWG,
        [Description("Azerbaijani Manat")]
        AZN,
        [Description("Barbadian Dollar")]
        BBD,
        [Description("Bahraini Dinar")]
        BHD,
        [Description("Bermudian Dollar")]
        BMD,
        [Description("Brunei Dollar")]
        BND,
        [Description("Bahamian Dollar")]
        BSD,
        [Description("Botswana Pula")]
        BWP,
        [Description("Belarusian Ruble")]
        BYN,
        [Description("Belize Dollar")]
        BZD,
        [Description("Congolese Franc")]
        CDF,
        [Description("Cape Verdean Escudo")]
        CVE,
        [Description("Djiboutian Franc")]
        DJF,
        [Description("Eritrean Nakfa")]
        ERN,
        [Description("Ethiopian Birr")]
        ETB,
        [Description("Fijian Dollar")]
        FJD,
        [Description("Falkland Islands Pound")]
        FKP,
        [Description("Georgian Lari")]
        GEL,
        [Description("Ghanaian Cedi")]
        GHS,
        [Description("Gibraltar Pound")]
        GIP,
        [Description("Guinean Franc")]
        GNF,
        [Description("Guyanese Dollar")]
        GYD,
        [Description("Haitian Gourde")]
        HTG,
        [Description("Iraqi Dinar")]
        IQD,
        [Description("Iranian Rial")]
        IRR,
        [Description("Icelandic Króna")]
        ISK,
        [Description("Jamaican Dollar")]
        JMD,
        [Description("Kenyan Shilling")]
        KES,
        [Description("Kyrgyzstani Som")]
        KGS,
        [Description("Comorian Franc")]
        KMF,
        [Description("North Korean Won")]
        KPW,
        [Description("Cayman Islands Dollar")]
        KYD,
        [Description("Lao Kip")]
        LAK,
        [Description("Liberian Dollar")]
        LRD,
        [Description("Lesotho Loti")]
        LSL,
        [Description("Libyan Dinar")]
        LYD,
        [Description("Malagasy Ariary")]
        MGA,
        [Description("Macedonian Denar")]
        MKD,
        [Description("Myanmar Kyat")]
        MMK,
        [Description("Macanese Pataca")]
        MOP,
        [Description("Mauritanian Ouguiya")]
        MRU,
        [Description("Mauritian Rupee")]
        MUR,
        [Description("Maldivian Rufiyaa")]
        MVR,
        [Description("Malawian Kwacha")]
        MWK,
        [Description("Mozambican Metical")]
        MZN,
        [Description("Namibian Dollar")]
        NAD,
        [Description("Omani Rial")]
        OMR,
        [Description("Papua New Guinean Kina")]
        PGK,
        [Description("Pakistani Rupee")]
        PKR,
        [Description("Qatari Riyal")]
        QAR,
        [Description("Rwandan Franc")]
        RWF,
        [Description("Solomon Islands Dollar")]
        SBD,
        [Description("Seychellois Rupee")]
        SCR,
        [Description("Sudanese Pound")]
        SDG,
        [Description("Sierra Leonean Leone")]
        SLL,
        [Description("Somali Shilling")]
        SOS,
        [Description("South Sudanese Pound")]
        SSP,
        [Description("Syrian Pound")]
        SYP,
        [Description("Swazi Lilangeni")]
        SZL,
        [Description("Tajikistani Somoni")]
        TJS,
        [Description("Turkmenistani Manat")]
        TMT,
        [Description("Tunisian Dinar")]
        TND,
        [Description("Tongan Paʻanga")]
        TOP,
        [Description("Tanzanian Shilling")]
        TZS,
        [Description("Ugandan Shilling")]
        UGX,
        [Description("Vanuatu Vatu")]
        VUV,
        [Description("Central African CFA Franc")]
        XAF,
        [Description("CFP Franc")]
        XPF,
        [Description("Yemeni Rial")]
        YER,
        [Description("Zambian Kwacha")]
        ZMW,
        [Description("Zimbabwean Dollar")]
        ZWL
        // ReSharper restore InconsistentNaming
    }
}
