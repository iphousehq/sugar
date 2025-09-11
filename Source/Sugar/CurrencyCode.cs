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
        NGN
        // ReSharper restore InconsistentNaming
    }
}
