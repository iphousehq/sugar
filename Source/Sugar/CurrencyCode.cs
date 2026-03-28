using System.ComponentModel;
using Sugar.Attributes;

namespace Sugar
{
    /// <summary>
    /// ISO 4217 Currency Codes.
    /// </summary>
    public enum CurrencyCode
    {
        // ReSharper disable InconsistentNaming
        [Description("United States Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        USD,

        [Description("Yen")]
        [Symbol("¥")]
        [HtmlSymbol("&#165; ")]
        JPY,

        [Description("Bulgarian Lev")]
        [Symbol("лв")]
        [HtmlSymbol("&#1083;&#1074; ")]
        BGN,

        [Description("Czech Koruna")]
        [Symbol("¤")]
        [HtmlSymbol("&#75;&#269; ")]
        CZK,

        [Description("Danish Krone")]
        [Symbol("kr")]
        [HtmlSymbol("kr ")]
        DKK,

        [Description("Estonia Krooni")]
        [Symbol("¤")]
        [HtmlSymbol("&curren; ")]
        EEK,

        [Description("Euro")]
        [Symbol("€")]
        [HtmlSymbol("&#8364; ")]
        EUR,

        [Description("United Kingdom Pound")]
        [Symbol("£")]
        [HtmlSymbol("&#163; ")]
        GBP,

        [Description("Hungary Forint")]
        [Symbol("Ft")]
        [HtmlSymbol("&#70;&#116; ")]
        HUF,

        [Description("Lithuania Litai")]
        [Symbol("Lt")]
        [HtmlSymbol("Lt ")]
        LTL,

        [Description("Latvia Lati")]
        [Symbol("Ls")]
        [HtmlSymbol("Ls ")]
        LVL,

        [Description("Poland Zlotych")]
        [Symbol("zł")]
        [HtmlSymbol("&#122;&#322; ")]
        PLN,

        [Description("Romania New Lei")]
        [Symbol("lei")]
        [HtmlSymbol("&#108;&#101;&#105; ")]
        RON,

        [Description("Sweden Kronor")]
        [Symbol("kr")]
        [HtmlSymbol("kr ")]
        SEK,

        [Description("Switzerland Franc")]
        [Symbol("CHF")]
        [HtmlSymbol("CHF ")]
        CHF,

        [Description("Norway Krone")]
        [Symbol("kr")]
        [HtmlSymbol("kr ")]
        NOK,

        [Description("Croatia Kuna")]
        [Symbol("kn")]
        [HtmlSymbol("&#107;&#110; ")]
        HRK,

        [Description("Russia Rubles")]
        [Symbol("руб")]
        [HtmlSymbol("&#1088;&#1091;&#1073; ")]
        RUB,

        [Description("Turkey Lira")]
        [Symbol("TL")]
        [HtmlSymbol("TL ")]
        TRY,

        [Description("Australian Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        AUD,

        [Description("Brazil Reais")]
        [Symbol("R$")]
        [HtmlSymbol("&#82;&#36; ")]
        BRL,

        [Description("Canada Dollars")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        CAD,

        [Description("China Yuan Renminbi")]
        [Symbol("¥")]
        [HtmlSymbol("&#165; ")]
        CNY,

        [Description("Hong Kong Dollars")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        HKD,

        [Description("Indonesia Rupiahs")]
        [Symbol("Rp")]
        [HtmlSymbol("&#82;&#112; ")]
        IDR,

        [Description("India Rupees")]
        [Symbol("₹")]
        [HtmlSymbol("&#8377;")]
        INR,

        [Description("Korea (South) Won")]
        [Symbol("₩")]
        [HtmlSymbol("&#8361; ")]
        KRW,

        [Description("Mexico Pesos")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        MXN,

        [Description("Malaysia Ringgits")]
        [Symbol("RM")]
        [HtmlSymbol("RM ")]
        MYR,

        [Description("New Zealand Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        NZD,

        [Description("Philippines Pesos")]
        [Symbol("Php")]
        [HtmlSymbol("Php ")]
        PHP,

        [Description("Singapore Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        SGD,

        [Description("Thailand Baht")]
        [Symbol("฿")]
        [HtmlSymbol("&#3647; ")]
        THB,

        [Description("South Africa Rand")]
        [Symbol("R")]
        [HtmlSymbol("R ")]
        ZAR,

        [Description("Taiwan Dollar")]
        [Symbol("NT$")]
        [HtmlSymbol("&#78;&#84;&#36; ")]
        TWD,

        [Description("Argentine Peso")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        ARS,

        [Description("Colombian Peso")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        COP,

        [Description("Costa Rican Colon")]
        [Symbol("₡")]
        [HtmlSymbol("&#8353; ")]
        CRC,

        [Description("Chilean Peso")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        CLP,

        [Description("Dominican Peso")]
        [Symbol("RD$")]
        [HtmlSymbol("&#36; ")]
        DOP,

        [Description("Peruvian Nuevo Sol")]
        [Symbol("S/.")]
        [HtmlSymbol("S/. ")]
        PEN,

        [Description("Uruguayan Peso")]
        [Symbol("$U")]
        [HtmlSymbol("&#36;&#85; ")]
        UYU,

        [Description("Venezuelan Bolivar")]
        [Symbol("Bs")]
        [HtmlSymbol("&#66;&#115; ")]
        VEF,

        [Description("Venezuelan Bolivar (DICOM)")]
        [Symbol("Bs")]
        [HtmlSymbol("&#66;&#115; ")]
        VEF_DICOM,

        [Description("Venezuelan Bolivar (Black Market)")]
        [Symbol("Bs")]
        [HtmlSymbol("&#66;&#115; ")]
        VEF_BLKMKT,

        [Description("Panamian Balboa")]
        [Symbol("B/.")]
        [HtmlSymbol("B/. ")]
        PAB,

        [Description("Ukrainian Hryvnia")]
        [Symbol("₴")]
        [HtmlSymbol("&#8372;")]
        UAH,

        [Description("Lebanese Pound")]
        [Symbol("ل.ل")]
        [HtmlSymbol("&#163;")]
        LBP,

        [Description("Egyptian Pound")]
        [Symbol("E£")]
        [HtmlSymbol("E&pound; ")]
        EGP,

        [Description("Jordanian Dinar")]
        [Symbol("د.ا")]
        [HtmlSymbol("JOD")]
        JOD,

        [Description("United Arab Emirates dirham")]
        [Symbol("د.إ")]
        [HtmlSymbol("&#x62f;&#x2e;&#x625;")]
        AED,

        [Description("Venezuelan Bolívar Soberano")]
        [Symbol("Bs")]
        [HtmlSymbol("&#66;&#115; ")]
        VES,

        [Description("Vietnamese Dong")]
        [Symbol("₫")]
        [HtmlSymbol("&#8363;")]
        VND,

        [Description("Saudi Arabian Riyal")]
        [Symbol("﷼")]
        [HtmlSymbol("﷼ ")]
        SAR,

        [Description("Sri Lankan Rupee")]
        [Symbol("Rs")]
        [HtmlSymbol("Rs ")]
        LKR,

        [Description("Nepalese Rupee")]
        [Symbol("Rs")]
        [HtmlSymbol("Rs ")]
        NPR,

        [Description("Mongolian Tögrög")]
        [Symbol("₮")]
        [HtmlSymbol("&#8366;")]
        MNT,

        [Description("Eastern Caribbean Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        XCD,

        [Description("Bolivian Boliviano")]
        [Symbol("Bs")]
        [HtmlSymbol("Bs ")]
        BOB,

        [Description("Guatemalan Quetzal")]
        [Symbol("Q")]
        [HtmlSymbol("Q ")]
        GTQ,

        [Description("Honduran Lempira")]
        [Symbol("L")]
        [HtmlSymbol("L ")]
        HNL,

        [Description("Nicaraguan Córdoba")]
        [Symbol("C$")]
        [HtmlSymbol("&#67;&#36; ")]
        NIO,

        [Description("Paraguayan Guaraní")]
        [Symbol("₲")]
        [HtmlSymbol("&#8370; ")]
        PYG,

        [Description("Bangladeshi Taka")]
        [Symbol("৳")]
        [HtmlSymbol("&#2547; ")]
        BDT,

        [Description("Moroccan Dirham")]
        [Symbol("DH")]
        [HtmlSymbol("DH")]
        MAD,

        [Description("Cuban Peso")]
        [Symbol("$")]
        [HtmlSymbol("&#36; ")]
        CUP,

        [Description("Bosnian Mark")]
        [Symbol("KM")]
        [HtmlSymbol("KM")]
        BAM,

        [Description("Uzbekistan Som")]
        [Symbol("у.е.")]
        [HtmlSymbol("у.е.")]
        UZS,

        [Description("Kazakhstan Tenge")]
        [Symbol("KZ")]
        [HtmlSymbol("KZ")]
        KZT,

        [Description("Israeli Shekel")]
        [Symbol("₪")]
        [HtmlSymbol("&#8362; ")]
        ILS,

        [Description("Trinidad and Tobago Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        TTD,

        [Description("Cambodian Riel")]
        [Symbol("\u17db")]
        [HtmlSymbol("&#6107;")]
        KHR,

        [Description("West African CFA Franc")]
        [Symbol("F.CFA")]
        [HtmlSymbol("F.CFA")]
        XOF,

        [Description("Alegerian Dinar")]
        [Symbol("د.ج")]
        [HtmlSymbol("د.ج")]
        DZD,

        [Description("Nigerian Naira")]
        [Symbol("₦")]
        [HtmlSymbol("&#8358;")]
        NGN,

        [Description("Kuwaiti Dinar")]
        [Symbol("د.ك")]
        [HtmlSymbol("د.ك")]
        KWD,

        [Description("Afghan Afghani")]
        [Symbol("؋")]
        [HtmlSymbol("&#1547;")]
        AFN,

        [Description("Albanian Lek")]
        [Symbol("L")]
        [HtmlSymbol("L")]
        ALL,

        [Description("Armenian Dram")]
        [Symbol("֏")]
        [HtmlSymbol("&#1423;")]
        AMD,

        [Description("Netherlands Antillean Guilder")]
        [Symbol("ƒ")]
        [HtmlSymbol("&#402;")]
        ANG,

        [Description("Angolan Kwanza")]
        [Symbol("Kz")]
        [HtmlSymbol("Kz")]
        AOA,

        [Description("Aruban Florin")]
        [Symbol("ƒ")]
        [HtmlSymbol("&#402;")]
        AWG,

        [Description("Azerbaijani Manat")]
        [Symbol("₼")]
        [HtmlSymbol("&#8380;")]
        AZN,

        [Description("Barbadian Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        BBD,

        [Description("Bahraini Dinar")]
        [Symbol("ب.د")]
        [HtmlSymbol("ب.د")]
        BHD,

        [Description("Bermudian Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        BMD,

        [Description("Brunei Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        BND,

        [Description("Bahamian Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        BSD,

        [Description("Botswana Pula")]
        [Symbol("P")]
        [HtmlSymbol("P")]
        BWP,

        [Description("Belarusian Ruble")]
        [Symbol("Br")]
        [HtmlSymbol("Br")]
        BYN,

        [Description("Belize Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        BZD,

        [Description("Congolese Franc")]
        [Symbol("FC")]
        [HtmlSymbol("FC")]
        CDF,

        [Description("Cape Verdean Escudo")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        CVE,

        [Description("Djiboutian Franc")]
        [Symbol("Fdj")]
        [HtmlSymbol("Fdj")]
        DJF,

        [Description("Eritrean Nakfa")]
        [Symbol("Nfk")]
        [HtmlSymbol("Nfk")]
        ERN,

        [Description("Ethiopian Birr")]
        [Symbol("Br")]
        [HtmlSymbol("Br")]
        ETB,

        [Description("Fijian Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        FJD,

        [Description("Falkland Islands Pound")]
        [Symbol("£")]
        [HtmlSymbol("&#163;")]
        FKP,

        [Description("Georgian Lari")]
        [Symbol("₾")]
        [HtmlSymbol("&#8382;")]
        GEL,

        [Description("Ghanaian Cedi")]
        [Symbol("₵")]
        [HtmlSymbol("&#8373;")]
        GHS,

        [Description("Gibraltar Pound")]
        [Symbol("£")]
        [HtmlSymbol("&#163;")]
        GIP,

        [Description("Guinean Franc")]
        [Symbol("FG")]
        [HtmlSymbol("FG")]
        GNF,

        [Description("Guyanese Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        GYD,

        [Description("Haitian Gourde")]
        [Symbol("G")]
        [HtmlSymbol("G")]
        HTG,

        [Description("Iraqi Dinar")]
        [Symbol("ع.د")]
        [HtmlSymbol("ع.د")]
        IQD,

        [Description("Iranian Rial")]
        [Symbol("﷼")]
        [HtmlSymbol("&#65020;")]
        IRR,

        [Description("Icelandic Króna")]
        [Symbol("kr")]
        [HtmlSymbol("kr")]
        ISK,

        [Description("Jamaican Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        JMD,

        [Description("Kenyan Shilling")]
        [Symbol("KSh")]
        [HtmlSymbol("KSh")]
        KES,

        [Description("Kyrgyzstani Som")]
        [Symbol("с")]
        [HtmlSymbol("&#1089;")]
        KGS,

        [Description("Comorian Franc")]
        [Symbol("CF")]
        [HtmlSymbol("CF")]
        KMF,

        [Description("North Korean Won")]
        [Symbol("₩")]
        [HtmlSymbol("&#8361;")]
        KPW,

        [Description("Cayman Islands Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        KYD,

        [Description("Lao Kip")]
        [Symbol("₭")]
        [HtmlSymbol("&#8365;")]
        LAK,

        [Description("Liberian Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        LRD,

        [Description("Lesotho Loti")]
        [Symbol("L")]
        [HtmlSymbol("L")]
        LSL,

        [Description("Libyan Dinar")]
        [Symbol("ل.د")]
        [HtmlSymbol("ل.د")]
        LYD,

        [Description("Malagasy Ariary")]
        [Symbol("Ar")]
        [HtmlSymbol("Ar")]
        MGA,

        [Description("Macedonian Denar")]
        [Symbol("ден")]
        [HtmlSymbol("&#1076;&#1077;&#1085;")]
        MKD,

        [Description("Myanmar Kyat")]
        [Symbol("K")]
        [HtmlSymbol("K")]
        MMK,

        [Description("Macanese Pataca")]
        [Symbol("P")]
        [HtmlSymbol("P")]
        MOP,

        [Description("Mauritanian Ouguiya")]
        [Symbol("UM")]
        [HtmlSymbol("UM")]
        MRU,

        [Description("Mauritian Rupee")]
        [Symbol("₨")]
        [HtmlSymbol("&#8360;")]
        MUR,

        [Description("Maldivian Rufiyaa")]
        [Symbol("ރ")]
        [HtmlSymbol("ރ")]
        MVR,

        [Description("Malawian Kwacha")]
        [Symbol("MK")]
        [HtmlSymbol("MK")]
        MWK,

        [Description("Mozambican Metical")]
        [Symbol("MT")]
        [HtmlSymbol("MT")]
        MZN,

        [Description("Namibian Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        NAD,

        [Description("Omani Rial")]
        [Symbol("﷼")]
        [HtmlSymbol("&#65020;")]
        OMR,

        [Description("Papua New Guinean Kina")]
        [Symbol("K")]
        [HtmlSymbol("K")]
        PGK,

        [Description("Pakistani Rupee")]
        [Symbol("₨")]
        [HtmlSymbol("&#8360;")]
        PKR,

        [Description("Qatari Riyal")]
        [Symbol("﷼")]
        [HtmlSymbol("&#65020;")]
        QAR,

        [Description("Rwandan Franc")]
        [Symbol("₣")]
        [HtmlSymbol("&#8355;")]
        RWF,

        [Description("Solomon Islands Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        SBD,

        [Description("Seychellois Rupee")]
        [Symbol("₨")]
        [HtmlSymbol("&#8360;")]
        SCR,

        [Description("Sudanese Pound")]
        [Symbol("ج.س.")]
        [HtmlSymbol("ج.س.")]
        SDG,

        [Description("Sierra Leonean Leone")]
        [Symbol("Le")]
        [HtmlSymbol("Le")]
        SLL,

        [Description("Somali Shilling")]
        [Symbol("Sh")]
        [HtmlSymbol("Sh")]
        SOS,

        [Description("South Sudanese Pound")]
        [Symbol("£")]
        [HtmlSymbol("&#163;")]
        SSP,

        [Description("Syrian Pound")]
        [Symbol("£")]
        [HtmlSymbol("&#163;")]
        SYP,

        [Description("Swazi Lilangeni")]
        [Symbol("L")]
        [HtmlSymbol("L")]
        SZL,

        [Description("Tajikistani Somoni")]
        [Symbol("SM")]
        [HtmlSymbol("SM")]
        TJS,

        [Description("Turkmenistani Manat")]
        [Symbol("T")]
        [HtmlSymbol("T")]
        TMT,

        [Description("Tunisian Dinar")]
        [Symbol("د.ت")]
        [HtmlSymbol("د.ت")]
        TND,

        [Description("Tongan Paʻanga")]
        [Symbol("T$")]
        [HtmlSymbol("T&#36;")]
        TOP,

        [Description("Tanzanian Shilling")]
        [Symbol("Sh")]
        [HtmlSymbol("Sh")]
        TZS,

        [Description("Ugandan Shilling")]
        [Symbol("Sh")]
        [HtmlSymbol("Sh")]
        UGX,

        [Description("Vanuatu Vatu")]
        [Symbol("Vt")]
        [HtmlSymbol("Vt")]
        VUV,

        [Description("Central African CFA Franc")]
        [Symbol("FCFA")]
        [HtmlSymbol("FCFA")]
        XAF,

        [Description("CFP Franc")]
        [Symbol("Fr")]
        [HtmlSymbol("Fr")]
        XPF,

        [Description("Yemeni Rial")]
        [Symbol("﷼")]
        [HtmlSymbol("&#65020;")]
        YER,

        [Description("Zambian Kwacha")]
        [Symbol("ZK")]
        [HtmlSymbol("ZK")]
        ZMW,

        [Description("Zimbabwean Dollar")]
        [Symbol("$")]
        [HtmlSymbol("&#36;")]
        ZWL
        // ReSharper restore InconsistentNaming
    }
}
