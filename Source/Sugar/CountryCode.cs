using System.ComponentModel;
using Sugar.Attributes;

namespace Sugar
{
    /// <summary>
    /// ISO 3166-1-alpha-2 code elements.
    /// </summary>
    public enum CountryCode
    {
        // ReSharper disable InconsistentNaming

        /// <summary>
        /// Afghanistan
        /// </summary>
        [Description("Afghanistan")]
        [LanguageTag("af")]
        [TypeaheadToken("Afghanistan")]
        [Alpha3(CountryCode3.AFG)]
        [Currency(CurrencyCode.AFN)]
        AF,
        /// <summary>
        /// Aaland Aland
        /// </summary>
        [Description("Åland Islands")]
        [LanguageTag("sv")]
        [TypeaheadToken("Aaland")]
        [TypeaheadToken("Aland")]
        [TypeaheadToken("Åland")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.ALA)]
        [Currency(CurrencyCode.EUR)]
        AX,
        /// <summary>
        /// Albania
        /// </summary>
        [Description("Albania")]
        [LanguageTag("sq")]
        [TypeaheadToken("Albania")]
        [Alpha3(CountryCode3.ALB)]
        [Currency(CurrencyCode.ALL)]
        AL,
        /// <summary>
        /// Algeria
        /// </summary>
        [Description("Algeria")]
        [LanguageTag("ar-dz")]
        [TypeaheadToken("Algeria")]
        [Alpha3(CountryCode3.DZA)]
        [Currency(CurrencyCode.DZD)]
        DZ,
        /// <summary>
        /// American Samoa
        /// </summary>
        [Description("American Samoa")]
        [LanguageTag("en-us")]
        [TypeaheadToken("American")]
        [TypeaheadToken("Samoa")]
        [Alpha3(CountryCode3.ASM)]
        [Currency(CurrencyCode.EUR)]
        AS,
        /// <summary>
        /// Andorra
        /// </summary>
        [Description("Andorra")]
        [LanguageTag("es")]
        [TypeaheadToken("Andorra")]
        [Alpha3(CountryCode3.AND)]
        [Currency(CurrencyCode.EUR)]
        AD,
        /// <summary>
        /// Angola
        /// </summary>
        [Description("Angola")]
        [LanguageTag("pt")]
        [TypeaheadToken("Angola")]
        [Alpha3(CountryCode3.AGO)]
        [Currency(CurrencyCode.AOA)]
        AO,
        /// <summary>
        /// Anguilla
        /// </summary>
        [Description("Anguilla")]
        [LanguageTag("en")]
        [TypeaheadToken("Anguilla")]
        [Alpha3(CountryCode3.AIA)]
        [Currency(CurrencyCode.XCD)]
        AI,
        /// <summary>
        /// Antarctica
        /// </summary>
        [Description("Antarctica")]
        [LanguageTag("en")]
        [TypeaheadToken("Antarctica")]
        [Alpha3(CountryCode3.ATA)]
        AQ,
        /// <summary>
        /// Antigua And Barbuda
        /// </summary>
        [Description("Antigua And Barbuda")]
        [LanguageTag("en")]
        [TypeaheadToken("Antigua")]
        [TypeaheadToken("Barbuda")]
        [Alpha3(CountryCode3.ATG)]
        [Currency(CurrencyCode.XCD)]
        AG,
        /// <summary>
        /// Argentina (please don't delete)
        /// </summary>
        [Description("Argentina")]
        [LanguageTag("es-ar")]
        [TypeaheadToken("Argentina")]
        [Alpha3(CountryCode3.ARG)]
        [Currency(CurrencyCode.ARS)]
        AR,
        /// <summary>
        /// Armenia
        /// </summary>
        [Description("Armenia")]
        [LanguageTag("hy")]
        [TypeaheadToken("Armenia")]
        [Alpha3(CountryCode3.ARM)]
        [Currency(CurrencyCode.AMD)]
        AM,
        /// <summary>
        /// Aruba
        /// </summary>
        [Description("Aruba")]
        [LanguageTag("nl")]
        [TypeaheadToken("Aruba")]
        [Alpha3(CountryCode3.ABW)]
        [Currency(CurrencyCode.AWG)]
        AW,
        /// <summary>
        /// Australia
        /// </summary>
        [Description("Australia")]
        [LanguageTag("en-au")]
        [TypeaheadToken("Australia")]
        [Alpha3(CountryCode3.AUS)]
        [Currency(CurrencyCode.AUD)]
        AU,
        /// <summary>
        /// Austria
        /// </summary>
        [Description("Austria")]
        [LanguageTag("de-at")]
        [TypeaheadToken("Austria")]
        [TypeaheadToken("Österreich")]
        [TypeaheadToken("Oesterreich")]
        [Alpha3(CountryCode3.AUT)]
        [Currency(CurrencyCode.EUR)]
        AT,
        /// <summary>
        /// Azerbaijan
        /// </summary>
        [Description("Azerbaijan")]
        [LanguageTag("de-az")]
        [TypeaheadToken("Azerbaijan")]
        [Alpha3(CountryCode3.AZE)]
        [Currency(CurrencyCode.AZN)]
        AZ,
        /// <summary>
        /// Bahamas
        /// </summary>
        [Description("Bahamas")]
        [LanguageTag("en")]
        [TypeaheadToken("Bahamas")]
        [Alpha3(CountryCode3.BHS)]
        [Currency(CurrencyCode.BSD)]
        BS,
        /// <summary>
        /// Bahrain
        /// </summary>
        [Description("Bahrain")]
        [LanguageTag("ar")]
        [TypeaheadToken("Bahrain")]
        [Alpha3(CountryCode3.BHR)]
        [Currency(CurrencyCode.BHD)]
        BH,
        /// <summary>
        /// Bangladesh
        /// </summary>
        [Description("Bangladesh")]
        [LanguageTag("bn")]
        [TypeaheadToken("Bangladesh")]
        [Alpha3(CountryCode3.BGD)]
        [Currency(CurrencyCode.BDT)]
        BD,
        /// <summary>
        /// Barbados
        /// </summary>
        [Description("Barbados")]
        [LanguageTag("en")]
        [TypeaheadToken("Barbados")]
        [Alpha3(CountryCode3.BRB)]
        [Currency(CurrencyCode.BBD)]
        BB,
        /// <summary>
        /// Belarus
        /// </summary>
        [Description("Belarus")]
        [LanguageTag("be")]
        [TypeaheadToken("Belarus")]
        [Alpha3(CountryCode3.BLR)]
        [Currency(CurrencyCode.BYN)]
        BY,
        /// <summary>
        /// Belgium
        /// </summary>
        [Description("Belgium")]
        [LanguageTag("fr-be")]
        [TypeaheadToken("Belgium")]
        [TypeaheadToken("België")]
        [TypeaheadToken("Belgie")]
        [TypeaheadToken("Belgien")]
        [TypeaheadToken("Belgique")]
        [Alpha3(CountryCode3.BEL)]
        [Currency(CurrencyCode.EUR)]
        BE,
        /// <summary>
        /// Belize
        /// </summary>
        [Description("Belize")]
        [LanguageTag("en")]
        [TypeaheadToken("Belize")]
        [Alpha3(CountryCode3.BLZ)]
        [Currency(CurrencyCode.BZD)]
        BZ,
        /// <summary>
        /// Benin
        /// </summary>
        [Description("Benin")]
        [LanguageTag("fr")]
        [TypeaheadToken("Benin")]
        [Alpha3(CountryCode3.BEN)]
        [Currency(CurrencyCode.XOF)]
        BJ,
        /// <summary>
        /// Bermuda
        /// </summary>
        [Description("Bermuda")]
        [LanguageTag("en")]
        [TypeaheadToken("Bermuda")]
        [Alpha3(CountryCode3.BMU)]
        [Currency(CurrencyCode.BMD)]
        BM,
        /// <summary>
        /// Bhutan
        /// </summary>
        [Description("Bhutan")]
        [LanguageTag("dz")]
        [TypeaheadToken("Bhutan")]
        [Alpha3(CountryCode3.BTN)]
        [Currency(CurrencyCode.INR)]
        BT,
        /// <summary>
        /// Bolivia
        /// </summary>
        [Description("Bolivia")]
        [LanguageTag("es-bo")]
        [TypeaheadToken("Bolivia")]
        [Alpha3(CountryCode3.BOL)]
        [Currency(CurrencyCode.BOB)]
        BO,
        /// <summary>
        /// Bosnia And Herzegovina
        /// </summary>
        [Description("Bosnia And Herzegovina")]
        [LanguageTag("bs")]
        [TypeaheadToken("Bosnia")]
        [TypeaheadToken("Herzegovina")]
        [Alpha3(CountryCode3.BIH)]
        [Currency(CurrencyCode.BAM)]
        BA,
        /// <summary>
        /// Botswana
        /// </summary>
        [Description("Botswana")]
        [LanguageTag("en")]
        [TypeaheadToken("Botswana")]
        [Alpha3(CountryCode3.BWA)]
        [Currency(CurrencyCode.BWP)]
        BW,
        /// <summary>
        /// Bouvet Island
        /// </summary>
        [Description("Bouvet Island")]
        [LanguageTag("no")]
        [TypeaheadToken("Bouvet")]
        [TypeaheadToken("Island")]
        [Alpha3(CountryCode3.BVT)]
        [Currency(CurrencyCode.NOK)]
        BV,
        /// <summary>
        /// Brazil
        /// </summary>
        [Description("Brazil")]
        [LanguageTag("pt-br")]
        [TypeaheadToken("Brazil")]
        [Alpha3(CountryCode3.BRA)]
        [Currency(CurrencyCode.BRL)]
        BR,
        /// <summary>
        /// British Indian Ocean Territory
        /// </summary>
        [Description("British Indian Ocean Territory")]
        [LanguageTag("en")]
        [TypeaheadToken("British")]
        [TypeaheadToken("Indian")]
        [TypeaheadToken("Ocean")]
        [TypeaheadToken("Territory")]
        [Alpha3(CountryCode3.IOT)]
        [Currency(CurrencyCode.USD)]
        IO,
        /// <summary>
        /// Brunei Darussalam
        /// </summary>
        [Description("Brunei Darussalam")]
        [LanguageTag("ms")]
        [TypeaheadToken("Brunei")]
        [TypeaheadToken("Darussalam")]
        [Alpha3(CountryCode3.BRN)]
        [Currency(CurrencyCode.BND)]
        BN,
        /// <summary>
        /// Bulgaria
        /// </summary>
        [Description("Bulgaria")]
        [LanguageTag("bg")]
        [TypeaheadToken("Bulgaria")]
        [Alpha3(CountryCode3.BGR)]
        [Currency(CurrencyCode.BGN)]
        BG,
        /// <summary>
        /// Burkina Faso
        /// </summary>
        [Description("Burkina Faso")]
        [LanguageTag("fr")]
        [TypeaheadToken("Burkina")]
        [TypeaheadToken("Faso")]
        [Alpha3(CountryCode3.BFA)]
        BF,
        /// <summary>
        /// Burundi
        /// </summary>
        [Description("Burundi")]
        [LanguageTag("rn")]
        [TypeaheadToken("Burundi")]
        [Alpha3(CountryCode3.BDI)]
        BI,
        /// <summary>
        /// Cambodia
        /// </summary>
        [Description("Cambodia")]
        [LanguageTag("km")]
        [TypeaheadToken("Cambodia")]
        [Alpha3(CountryCode3.KHM)]
        KH,
        /// <summary>
        /// Cameroon
        /// </summary>
        [Description("Cameroon")]
        [LanguageTag("en")]
        [TypeaheadToken("Cameroon")]
        [Alpha3(CountryCode3.CMR)]
        [Currency(CurrencyCode.XAF)]
        CM,
        /// <summary>
        /// Canada
        /// </summary>
        [Description("Canada")]
        [LanguageTag("en-ca")]
        [TypeaheadToken("Canada")]
        [Alpha3(CountryCode3.CAN)]
        [Currency(CurrencyCode.CAD)]
        CA,
        /// <summary>
        /// Cape Verde
        /// </summary>
        [Description("Cape Verde")]
        [LanguageTag("pt")]
        [TypeaheadToken("Cape")]
        [TypeaheadToken("Verde")]
        [Alpha3(CountryCode3.CPV)]
        [Currency(CurrencyCode.CVE)]
        CV,
        /// <summary>
        /// Cayman Islands
        /// </summary>
        [Description("Cayman Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Cayman")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.CYM)]
        [Currency(CurrencyCode.KYD)]
        KY,
        /// <summary>
        /// Central African Republic
        /// </summary>
        [Description("Central African Republic")]
        [LanguageTag("fr")]
        [TypeaheadToken("Central")]
        [TypeaheadToken("African")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.CAF)]
        [Currency(CurrencyCode.XAF)]
        CF,
        /// <summary>
        /// Chad
        /// </summary>
        [Description("Chad")]
        [LanguageTag("ar")]
        [TypeaheadToken("Chad")]
        [Alpha3(CountryCode3.TCD)]
        [Currency(CurrencyCode.XAF)]
        TD,
        /// <summary>
        /// Chile
        /// </summary>
        [Description("Chile")]
        [LanguageTag("es-cl")]
        [TypeaheadToken("Chile")]
        [Alpha3(CountryCode3.CHL)]
        [Currency(CurrencyCode.CLP)]
        CL,
        /// <summary>
        /// China
        /// </summary>
        [Description("China")]
        [LanguageTag("zh-cn")]
        [TypeaheadToken("China")]
        [TypeaheadToken("Zhongguo")]
        [TypeaheadToken("Zhonghua")]
        [TypeaheadToken("Peoples")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.CHN)]
        [Currency(CurrencyCode.CNY)]
        CN,
        /// <summary>
        /// Christmas Island
        /// </summary>
        [Description("Christmas Island")]
        [LanguageTag("en-au")]
        [TypeaheadToken("Christmas")]
        [TypeaheadToken("Island")]
        [Alpha3(CountryCode3.CXR)]
        [Currency(CurrencyCode.AUD)]
        CX,
        /// <summary>
        /// Cocos (Keeling) Islands
        /// </summary>
        [Description("Cocos (Keeling) Islands")]
        [LanguageTag("es")]
        [TypeaheadToken("Cocos")]
        [TypeaheadToken("Keeling")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.CCK)]
        [Currency(CurrencyCode.AUD)]
        CC,
        /// <summary>
        /// Colombia
        /// </summary>
        [Description("Colombia")]
        [LanguageTag("es-co")]
        [TypeaheadToken("Colombia")]
        [Alpha3(CountryCode3.COL)]
        [Currency(CurrencyCode.COP)]
        CO,
        /// <summary>
        /// Comoros
        /// </summary>
        [Description("Comoros")]
        [LanguageTag("ar")]
        [TypeaheadToken("Comoros")]
        [Alpha3(CountryCode3.COM)]
        [Currency(CurrencyCode.KMF)]
        KM,
        /// <summary>
        /// Congo
        /// </summary>
        [Description("Congo")]
        [LanguageTag("fr")]
        [TypeaheadToken("Congo")]
        [Alpha3(CountryCode3.COG)]
        [Currency(CurrencyCode.XAF)]
        CG,
        /// <summary>
        /// Congo, The Democratic Republic Of The
        /// </summary>
        [Description("Congo, The Democratic Republic Of The")]
        [LanguageTag("fr")]
        [TypeaheadToken("Congo")]
        [TypeaheadToken("Democratic")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.COD)]
        [Currency(CurrencyCode.CDF)]
        CD,
        /// <summary>
        /// Cook Islands
        /// </summary>
        [Description("Cook Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Cook")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.COK)]
        [Currency(CurrencyCode.NZD)]
        CK,
        /// <summary>
        /// Costa Rica
        /// </summary>
        [Description("Costa Rica")]
        [LanguageTag("en-sp")]
        [TypeaheadToken("Costa")]
        [TypeaheadToken("Rica")]
        [Alpha3(CountryCode3.CRI)]
        [Currency(CurrencyCode.CRC)]
        CR,
        /// <summary>
        /// Côte d'Ivoire
        /// </summary>
        [Description("Côte d'Ivoire")]
        [LanguageTag("fr")]
        [TypeaheadToken("Côte")]
        [TypeaheadToken("Cote")]
        [TypeaheadToken("Coast")]
        [TypeaheadToken("Ivoire")]
        [TypeaheadToken("Ivoire")]
        [TypeaheadToken("Coast")]
        [Alpha3(CountryCode3.CIV)]
        [Currency(CurrencyCode.XOF)]
        CI,
        /// <summary>
        /// Croatia
        /// </summary>
        [Description("Croatia")]
        [LanguageTag("hr")]
        [TypeaheadToken("Croatia")]
        [TypeaheadToken("Hrvatska")]
        [Alpha3(CountryCode3.HRV)]
        [Currency(CurrencyCode.HRK)]
        HR,
        /// <summary>
        /// Cuba
        /// </summary>
        [Description("Cuba")]
        [LanguageTag("es")]
        [TypeaheadToken("Cuba")]
        [Alpha3(CountryCode3.CUB)]
        [Currency(CurrencyCode.CUP)]
        CU,
        /// <summary>
        /// Cyprus
        /// </summary>
        [Description("Cyprus")]
        [LanguageTag("el")]
        [TypeaheadToken("Cyprus")]
        [Alpha3(CountryCode3.CYP)]
        [Currency(CurrencyCode.EUR)]
        CY,
        /// <summary>
        /// Czech Republic
        /// </summary>
        [Description("Czech Republic")]
        [LanguageTag("cs")]
        [TypeaheadToken("Czech")]
        [TypeaheadToken("Republic")]
        [TypeaheadToken("Česká")]
        [TypeaheadToken("Ceska")]
        [Alpha3(CountryCode3.CZE)]
        [Currency(CurrencyCode.CZK)]
        CZ,
        /// <summary>
        /// Denmark
        /// </summary>
        [Description("Denmark")]
        [LanguageTag("da")]
        [TypeaheadToken("Denmark")]
        [Alpha3(CountryCode3.DNK)]
        [Currency(CurrencyCode.DKK)]
        DK,
        /// <summary>
        /// Djibouti
        /// </summary>
        [Description("Djibouti")]
        [LanguageTag("ar")]
        [TypeaheadToken("Djibouti")]
        [Alpha3(CountryCode3.DJI)]
        [Currency(CurrencyCode.DJF)]
        DJ,
        /// <summary>
        /// Dominica
        /// </summary>
        [Description("Dominica")]
        [LanguageTag("en")]
        [TypeaheadToken("Dominica")]
        [Alpha3(CountryCode3.DMA)]
        [Currency(CurrencyCode.XCD)]
        DM,
        /// <summary>
        /// Dominican Republic
        /// </summary>
        [Description("Dominican Republic")]
        [LanguageTag("es")]
        [TypeaheadToken("Dominican")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.DOM)]
        [Currency(CurrencyCode.DOP)]
        DO,
        /// <summary>
        /// Ecuador
        /// </summary>
        [Description("Ecuador")]
        [LanguageTag("es")]
        [TypeaheadToken("Ecuador")]
        [Alpha3(CountryCode3.ECU)]
        [Currency(CurrencyCode.USD)]
        EC,
        /// <summary>
        /// Egypt
        /// </summary>
        [Description("Egypt")]
        [LanguageTag("ar-eg")]
        [TypeaheadToken("Egypt")]
        [Alpha3(CountryCode3.EGY)]
        [Currency(CurrencyCode.EGP)]
        EG,
        /// <summary>
        /// El Salvador
        /// </summary>
        [Description("El Salvador")]
        [LanguageTag("es")]
        [TypeaheadToken("El")]
        [TypeaheadToken("Salvador")]
        [Alpha3(CountryCode3.SLV)]
        [Currency(CurrencyCode.USD)]
        SV,
        /// <summary>
        /// Equatorial Guinea
        /// </summary>
        [Description("Equatorial Guinea")]
        [LanguageTag("pt")]
        [TypeaheadToken("Equatorial")]
        [TypeaheadToken("Guinea")]
        [Alpha3(CountryCode3.GNQ)]
        [Currency(CurrencyCode.XAF)]
        GQ,
        /// <summary>
        /// Eritrea
        /// </summary>
        [Description("Eritrea")]
        [LanguageTag("ar")]
        [TypeaheadToken("Eritrea")]
        [Alpha3(CountryCode3.ERI)]
        [Currency(CurrencyCode.ERN)]
        ER,
        /// <summary>
        /// Estonia
        /// </summary>
        [Description("Estonia")]
        [LanguageTag("et")]
        [TypeaheadToken("Estonia")]
        [TypeaheadToken("Eesti")]
        [Alpha3(CountryCode3.EST)]
        [Currency(CurrencyCode.EEK)]
        EE,
        /// <summary>
        /// Ethiopia
        /// </summary>
        [Description("Ethiopia")]
        [LanguageTag("am")]
        [TypeaheadToken("Ethiopia")]
        [Alpha3(CountryCode3.ETH)]
        [Currency(CurrencyCode.ETB)]
        ET,
        /// <summary>
        /// Europe
        /// </summary>
        [Description("Europe")]
        [LanguageTag("eo")]
        [TypeaheadToken("Europe")]
        [Currency(CurrencyCode.EUR)]
        EU,
        /// <summary>
        /// Falkland Islands (Malvinas)
        /// </summary>
        [Description("Falkland Islands (Malvinas)")]
        [LanguageTag("en")]
        [TypeaheadToken("Falkland")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("Malvinas")]
        [Alpha3(CountryCode3.FLK)]
        [Currency(CurrencyCode.FKP)]
        FK,
        /// <summary>
        /// Faroe Islands
        /// </summary>
        [Description("Faroe Islands")]
        [LanguageTag("da")]
        [TypeaheadToken("Faroe")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("Føroyar")]
        [TypeaheadToken("Færøerne")]
        [Alpha3(CountryCode3.FRO)]
        [Currency(CurrencyCode.DKK)]
        FO,
        /// <summary>
        /// Fiji
        /// </summary>
        [Description("Fiji")]
        [LanguageTag("en")]
        [TypeaheadToken("Fiji")]
        [Alpha3(CountryCode3.FJI)]
        [Currency(CurrencyCode.FJD)]
        FJ,
        /// <summary>
        /// Finland
        /// </summary>
        [Description("Finland")]
        [LanguageTag("fi")]
        [TypeaheadToken("Finland")]
        [TypeaheadToken("Suomi")]
        [Alpha3(CountryCode3.FIN)]
        [Currency(CurrencyCode.EUR)]
        FI,
        /// <summary>
        /// France
        /// </summary>
        [Description("France")]
        [LanguageTag("fr")]
        [TypeaheadToken("France")]
        [TypeaheadToken("Republique")]
        [TypeaheadToken("République")]
        [TypeaheadToken("Francaise")]
        [TypeaheadToken("Française")]
        [Alpha3(CountryCode3.FRA)]
        [Currency(CurrencyCode.EUR)]
        FR,
        /// <summary>
        /// French Guiana
        /// </summary>
        [Description("French Guiana")]
        [LanguageTag("fr")]
        [TypeaheadToken("French")]
        [TypeaheadToken("Guiana")]
        [Alpha3(CountryCode3.GUF)]
        [Currency(CurrencyCode.EUR)]
        GF,
        /// <summary>
        /// French Polynesia
        /// </summary>
        [Description("French Polynesia")]
        [LanguageTag("fr")]
        [TypeaheadToken("French")]
        [TypeaheadToken("Polynesia")]
        [Alpha3(CountryCode3.PYF)]
        [Currency(CurrencyCode.XPF)]
        PF,
        /// <summary>
        /// French Southern Territories
        /// </summary>
        [Description("French Southern Territories")]
        [LanguageTag("fr")]
        [TypeaheadToken("French")]
        [TypeaheadToken("Southern")]
        [TypeaheadToken("Territories")]
        [Alpha3(CountryCode3.ATF)]
        [Currency(CurrencyCode.EUR)]
        TF,
        /// <summary>
        /// Gabon
        /// </summary>
        [Description("Gabon")]
        [LanguageTag("fr")]
        [TypeaheadToken("Gabon")]
        [Alpha3(CountryCode3.GAB)]
        [Currency(CurrencyCode.XAF)]
        GA,
        /// <summary>
        /// Gambia
        /// </summary>
        [Description("Gambia")]
        [LanguageTag("en")]
        [TypeaheadToken("Gambia")]
        [Alpha3(CountryCode3.GMB)]
        GM,
        /// <summary>
        /// Georgia
        /// </summary>
        [Description("Georgia")]
        [LanguageTag("ka")]
        [TypeaheadToken("Georgia")]
        [Alpha3(CountryCode3.GEO)]
        [Currency(CurrencyCode.GEL)]
        GE,
        /// <summary>
        /// Germany
        /// </summary>
        [Description("Germany")]
        [LanguageTag("de")]
        [TypeaheadToken("Germany")]
        [TypeaheadToken("Bundesrepublik")]
        [TypeaheadToken("Deutschland")]
        [Alpha3(CountryCode3.DEU)]
        [Currency(CurrencyCode.EUR)]
        DE,
        /// <summary>
        /// Ghana
        /// </summary>
        [Description("Ghana")]
        [LanguageTag("en")]
        [TypeaheadToken("Ghana")]
        [Alpha3(CountryCode3.GHA)]
        [Currency(CurrencyCode.GHS)]
        GH,
        /// <summary>
        /// Gibraltar
        /// </summary>
        [Description("Gibraltar")]
        [LanguageTag("en")]
        [TypeaheadToken("Gibraltar")]
        [Alpha3(CountryCode3.GIB)]
        [Currency(CurrencyCode.GIP)]
        GI,
        /// <summary>
        /// Greece
        /// </summary>
        [Description("Greece")]
        [LanguageTag("el")]
        [TypeaheadToken("Greece")]
        [Alpha3(CountryCode3.GRC)]
        [Currency(CurrencyCode.EUR)]
        GR,
        /// <summary>
        /// Greenland
        /// </summary>
        [Description("Greenland")]
        [LanguageTag("da")]
        [TypeaheadToken("Greenland")]
        [Alpha3(CountryCode3.GRL)]
        [Currency(CurrencyCode.DKK)]
        GL,
        /// <summary>
        /// Grenada
        /// </summary>
        [Description("Grenada")]
        [LanguageTag("en")]
        [TypeaheadToken("Grenada")]
        [Alpha3(CountryCode3.GRD)]
        [Currency(CurrencyCode.XCD)]
        GD,
        /// <summary>
        /// Guadeloupe
        /// </summary>
        [Description("Guadeloupe")]
        [LanguageTag("fr")]
        [TypeaheadToken("Guadeloupe")]
        [Alpha3(CountryCode3.GLP)]
        [Currency(CurrencyCode.EUR)]
        GP,
        /// <summary>
        /// Guam
        /// </summary>
        [Description("Guam")]
        [LanguageTag("en")]
        [TypeaheadToken("Guam")]
        [Alpha3(CountryCode3.GUM)]
        [Currency(CurrencyCode.USD)]
        GU,
        /// <summary>
        /// Guatemala
        /// </summary>
        [Description("Guatemala")]
        [LanguageTag("es-gt")]
        [TypeaheadToken("Guatemala")]
        [Alpha3(CountryCode3.GTM)]
        [Currency(CurrencyCode.GTQ)]
        GT,
        /// <summary>
        /// Guernsey
        /// </summary>
        [Description("Guernsey")]
        [LanguageTag("en")]
        [TypeaheadToken("Guernsey")]
        [Currency(CurrencyCode.GBP)]
        GG,
        /// <summary>
        /// Guinea
        /// </summary>
        [Description("Guinea")]
        [LanguageTag("fr")]
        [TypeaheadToken("Guinea")]
        [Alpha3(CountryCode3.GIN)]
        [Currency(CurrencyCode.GNF)]
        GN,
        /// <summary>
        /// Guinea-Bissau
        /// </summary>
        [Description("Guinea-Bissau")]
        [LanguageTag("pt")]
        [TypeaheadToken("Guinea")]
        [TypeaheadToken("Bissau")]
        [Alpha3(CountryCode3.GNB)]
        [Currency(CurrencyCode.XOF)]
        GW,
        /// <summary>
        /// Guyana
        /// </summary>
        [Description("Guyana")]
        [LanguageTag("fr")]
        [TypeaheadToken("Guyana")]
        [Alpha3(CountryCode3.GUY)]
        [Currency(CurrencyCode.GYD)]
        GY,
        /// <summary>
        /// Haiti
        /// </summary>
        [Description("Haiti")]
        [LanguageTag("ht")]
        [TypeaheadToken("Haiti")]
        [Alpha3(CountryCode3.HTI)]
        [Currency(CurrencyCode.HTG)]
        HT,
        /// <summary>
        /// Heard Island And Mcdonald Islands
        /// </summary>
        [Description("Heard Island And Mcdonald Islands")]
        [LanguageTag("en-au")]
        [TypeaheadToken("Heard")]
        [TypeaheadToken("HeardMcdonald")]
        [TypeaheadToken("Island")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.HMD)]
        [Currency(CurrencyCode.AUD)]
        HM,
        /// <summary>
        /// Holy See (Vatican City State)
        /// </summary>
        [Description("Holy See (Vatican City State)")]
        [LanguageTag("it")]
        [TypeaheadToken("Holy")]
        [TypeaheadToken("See")]
        [TypeaheadToken("Vatican")]
        [TypeaheadToken("City")]
        [TypeaheadToken("State")]
        [Alpha3(CountryCode3.VAT)]
        [Currency(CurrencyCode.EUR)]
        VA,
        /// <summary>
        /// Honduras
        /// </summary>
        [Description("Honduras")]
        [LanguageTag("es-hn")]
        [TypeaheadToken("Honduras")]
        [Alpha3(CountryCode3.HND)]
        [Currency(CurrencyCode.HNL)]
        HN,
        /// <summary>
        /// Hong Kong
        /// </summary>
        [Description("Hong Kong")]
        [LanguageTag("zh-hk")]
        [TypeaheadToken("Hong")]
        [TypeaheadToken("Kong")]
        [Alpha3(CountryCode3.HKG)]
        [Currency(CurrencyCode.HKD)]
        HK,
        /// <summary>
        /// Hungary
        /// </summary>
        [Description("Hungary")]
        [LanguageTag("hu")]
        [TypeaheadToken("Hungary")]
        [Alpha3(CountryCode3.HUN)]
        [Currency(CurrencyCode.HUF)]
        HU,
        /// <summary>
        /// Iceland
        /// </summary>
        [Description("Iceland")]
        [LanguageTag("is")]
        [TypeaheadToken("Iceland")]
        [TypeaheadToken("Island")]
        [Alpha3(CountryCode3.ISL)]
        [Currency(CurrencyCode.ISK)]
        IS,
        /// <summary>
        /// India
        /// </summary>
        [Description("India")]
        [LanguageTag("en")]
        [TypeaheadToken("India")]
        [Alpha3(CountryCode3.IND)]
        [Currency(CurrencyCode.INR)]
        IN,
        /// <summary>
        /// Indonesia
        /// </summary>
        [Description("Indonesia")]
        [LanguageTag("id")]
        [TypeaheadToken("Indonesia")]
        [Alpha3(CountryCode3.IDN)]
        [Currency(CurrencyCode.IDR)]
        ID,
        /// <summary>
        /// Iran, Islamic Republic Of
        /// </summary>
        [Description("Iran, Islamic Republic Of")]
        [LanguageTag("fa")]
        [TypeaheadToken("Iran")]
        [TypeaheadToken("Islamic")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.IRN)]
        [Currency(CurrencyCode.IRR)]
        IR,
        /// <summary>
        /// Iraq
        /// </summary>
        [Description("Iraq")]
        [LanguageTag("ar-iq")]
        [TypeaheadToken("Iraq")]
        [Alpha3(CountryCode3.IRQ)]
        [Currency(CurrencyCode.IQD)]
        IQ,
        /// <summary>
        /// Ireland
        /// </summary>
        [Description("Ireland")]
        [LanguageTag("en-ie")]
        [TypeaheadToken("Ireland")]
        [TypeaheadToken("Éire")]
        [Alpha3(CountryCode3.IRL)]
        [Currency(CurrencyCode.EUR)]
        IE,
        /// <summary>
        /// Isle of Man
        /// </summary>
        [Description("Isle of Man")]
        [LanguageTag("en")]
        [TypeaheadToken("Isle")]
        [TypeaheadToken("Man")]
        [Currency(CurrencyCode.GBP)]
        IM,
        /// <summary>
        /// Israel
        /// </summary>
        [Description("Israel")]
        [LanguageTag("heb")]
        [TypeaheadToken("Israel")]
        [Alpha3(CountryCode3.ISR)]
        [Currency(CurrencyCode.ILS)]
        IL,
        /// <summary>
        /// Italy
        /// </summary>
        [Description("Italy")]
        [LanguageTag("it")]
        [TypeaheadToken("Italy")]
        [TypeaheadToken("Italia")]
        [Alpha3(CountryCode3.ITA)]
        [Currency(CurrencyCode.EUR)]
        IT,
        /// <summary>
        /// Jamaica
        /// </summary>
        [Description("Jamaica")]
        [LanguageTag("en")]
        [TypeaheadToken("Jamaica")]
        [Alpha3(CountryCode3.JAM)]
        [Currency(CurrencyCode.JMD)]
        JM,
        /// <summary>
        /// Japan
        /// </summary>
        [Description("Japan")]
        [LanguageTag("ja")]
        [TypeaheadToken("Japan")]
        [TypeaheadToken("Nippon")]
        [TypeaheadToken("Nihon")]
        [Alpha3(CountryCode3.JPN)]
        [Currency(CurrencyCode.JPY)]
        JP,
        /// <summary>
        /// Jersey
        /// </summary>
        [Description("Jersey")]
        [LanguageTag("en")]
        [TypeaheadToken("Jersey")]
        [Currency(CurrencyCode.GBP)]
        JE,
        /// <summary>
        /// Jordan
        /// </summary>
        [Description("Jordan")]
        [LanguageTag("ar")]
        [TypeaheadToken("Jordan")]
        [Alpha3(CountryCode3.JOR)]
        [Currency(CurrencyCode.JOD)]
        JO,
        /// <summary>
        /// Kazakhstan
        /// </summary>
        [Description("Kazakhstan")]
        [LanguageTag("kk")]
        [TypeaheadToken("Kazakhstan")]
        [Alpha3(CountryCode3.KAZ)]
        [Currency(CurrencyCode.KZT)]
        KZ,
        /// <summary>
        /// Kenya
        /// </summary>
        [Description("Kenya")]
        [LanguageTag("en")]
        [TypeaheadToken("Kenya")]
        [Alpha3(CountryCode3.KEN)]
        [Currency(CurrencyCode.KES)]
        KE,
        /// <summary>
        /// Kiribati
        /// </summary>
        [Description("Kiribati")]
        [LanguageTag("en")]
        [TypeaheadToken("Kiribati")]
        [Alpha3(CountryCode3.KIR)]
        [Currency(CurrencyCode.AUD)]
        KI,
        /// <summary>
        /// Korea, Democratic People'S Republic Of
        /// </summary>
        [Description("Korea, Democratic People's Republic Of")]
        [LanguageTag("ko")]
        [TypeaheadToken("Korea")]
        [TypeaheadToken("Democratic")]
        [TypeaheadToken("People's")]
        [TypeaheadToken("Republic")]
        [TypeaheadToken("North")]
        [TypeaheadToken("Korea")]
        [Alpha3(CountryCode3.PRK)]
        [Currency(CurrencyCode.KPW)]
        KP,
        /// <summary>
        /// Korea, Republic Of
        /// </summary>
        [Description("Korea, Republic Of")]
        [LanguageTag("ko")]
        [TypeaheadToken("Korea")]
        [TypeaheadToken("Republic")]
        [TypeaheadToken("South")]
        [Alpha3(CountryCode3.KOR)]
        [Currency(CurrencyCode.KRW)]
        KR,
        /// <summary>
        /// Kuwait
        /// </summary>
        [Description("Kuwait")]
        [LanguageTag("ar-kw")]
        [TypeaheadToken("Kuwait")]
        [Alpha3(CountryCode3.KWT)]
        [Currency(CurrencyCode.KWD)]
        KW,
        /// <summary>
        /// Kyrgyzstan
        /// </summary>
        [Description("Kyrgyzstan")]
        [LanguageTag("ky")]
        [TypeaheadToken("Kyrgyzstan")]
        [Alpha3(CountryCode3.KGZ)]
        [Currency(CurrencyCode.KGS)]
        KG,
        /// <summary>
        /// Lao People's Democratic Republic
        /// </summary>
        [Description("Lao People's Democratic Republic")]
        [LanguageTag("lo")]
        [TypeaheadToken("Lao")]
        [TypeaheadToken("People's")]
        [TypeaheadToken("Democratic")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.LAO)]
        [Currency(CurrencyCode.LAK)]
        LA,
        /// <summary>
        /// Latvia
        /// </summary>
        [Description("Latvia")]
        [LanguageTag("lv")]
        [TypeaheadToken("Latvia")]
        [Alpha3(CountryCode3.LVA)]
        [Currency(CurrencyCode.LVL)]
        LV,
        /// <summary>
        /// Lebanon
        /// </summary>
        [Description("Lebanon")]
        [LanguageTag("ar-lb")]
        [TypeaheadToken("Lebanon")]
        [Alpha3(CountryCode3.LBN)]
        [Currency(CurrencyCode.LBP)]
        LB,
        /// <summary>
        /// Lesotho
        /// </summary>
        [Description("Lesotho")]
        [LanguageTag("st")]
        [TypeaheadToken("Lesotho")]
        [Alpha3(CountryCode3.LSO)]
        [Currency(CurrencyCode.LSL)]
        LS,
        /// <summary>
        /// Liberia
        /// </summary>
        [Description("Liberia")]
        [LanguageTag("en")]
        [TypeaheadToken("Liberia")]
        [Alpha3(CountryCode3.LBR)]
        [Currency(CurrencyCode.LRD)]
        LR,
        /// <summary>
        /// Libyan Arab Jamahiriya
        /// </summary>
        [Description("Libyan Arab Jamahiriya")]
        [LanguageTag("ar")]
        [TypeaheadToken("Libyan")]
        [TypeaheadToken("Arab")]
        [TypeaheadToken("Jamahiriya")]
        [Alpha3(CountryCode3.LBY)]
        [Currency(CurrencyCode.LYD)]
        LY,
        /// <summary>
        /// Liechtenstein
        /// </summary>
        [Description("Liechtenstein")]
        [LanguageTag("de-li")]
        [TypeaheadToken("Liechtenstein")]
        [Alpha3(CountryCode3.LIE)]
        [Currency(CurrencyCode.CHF)]
        LI,
        /// <summary>
        /// Lithuania
        /// </summary>
        [Description("Lithuania")]
        [LanguageTag("lt")]
        [TypeaheadToken("Lithuania")]
        [Alpha3(CountryCode3.LTU)]
        [Currency(CurrencyCode.LTL)]
        LT,
        /// <summary>
        /// Luxembourg
        /// </summary>
        [Description("Luxembourg")]
        [LanguageTag("de-lu")]
        [TypeaheadToken("Luxembourg")]
        [Alpha3(CountryCode3.LUX)]
        [Currency(CurrencyCode.EUR)]
        LU,
        /// <summary>
        /// Macao
        /// </summary>
        [Description("Macao")]
        [LanguageTag("zh-cn")]
        [TypeaheadToken("Macao")]
        [Alpha3(CountryCode3.MAC)]
        [Currency(CurrencyCode.MOP)]
        MO,
        /// <summary>
        /// Macedonia, The Former Yugoslav Republic Of
        /// </summary>
        [Description("Macedonia, The Former Yugoslav Republic Of")]
        [LanguageTag("mk")]
        [TypeaheadToken("Macedonia")]
        [TypeaheadToken("Former")]
        [TypeaheadToken("Yugoslav")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.MKD)]
        [Currency(CurrencyCode.MKD)]
        MK,
        /// <summary>
        /// Madagascar
        /// </summary>
        [Description("Madagascar")]
        [LanguageTag("fr")]
        [TypeaheadToken("Madagascar")]
        [Alpha3(CountryCode3.MDG)]
        [Currency(CurrencyCode.MGA)]
        MG,
        /// <summary>
        /// Malawi
        /// </summary>
        [Description("Malawi")]
        [LanguageTag("en")]
        [TypeaheadToken("Malawi")]
        [Alpha3(CountryCode3.MWI)]
        [Currency(CurrencyCode.MWK)]
        MW,
        /// <summary>
        /// Malaysia
        /// </summary>
        [Description("Malaysia")]
        [LanguageTag("zsm")]
        [TypeaheadToken("Malaysia")]
        [Alpha3(CountryCode3.MYS)]
        [Currency(CurrencyCode.MYR)]
        MY,
        /// <summary>
        /// Maldives
        /// </summary>
        [Description("Maldives")]
        [LanguageTag("dv")]
        [TypeaheadToken("Maldives")]
        [Alpha3(CountryCode3.MDV)]
        [Currency(CurrencyCode.MVR)]
        MV,
        /// <summary>
        /// Mali
        /// </summary>
        [Description("Mali")]
        [LanguageTag("fr")]
        [TypeaheadToken("Mali")]
        [Alpha3(CountryCode3.MLI)]
        [Currency(CurrencyCode.XOF)]
        ML,
        /// <summary>
        /// Malta
        /// </summary>
        [Description("Malta")]
        [LanguageTag("en")]
        [TypeaheadToken("Malta")]
        [Alpha3(CountryCode3.MLT)]
        MT,
        /// <summary>
        /// Marshall Islands
        /// </summary>
        [Description("Marshall Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Marshall")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.MHL)]
        [Currency(CurrencyCode.USD)]
        MH,
        /// <summary>
        /// Martinique
        /// </summary>
        [Description("Martinique")]
        [LanguageTag("fr")]
        [TypeaheadToken("Martinique")]
        [Alpha3(CountryCode3.MTQ)]
        [Currency(CurrencyCode.EUR)]
        MQ,
        /// <summary>
        /// Mauritania
        /// </summary>
        [Description("Mauritania")]
        [LanguageTag("ar")]
        [TypeaheadToken("Mauritania")]
        [Alpha3(CountryCode3.MRT)]
        [Currency(CurrencyCode.MRU)]
        MR,
        /// <summary>
        /// Mauritius
        /// </summary>
        [Description("Mauritius")]
        [LanguageTag("en")]
        [TypeaheadToken("Mauritius")]
        [TypeaheadToken("Maurice")]
        [Alpha3(CountryCode3.MUS)]
        [Currency(CurrencyCode.MUR)]
        MU,
        /// <summary>
        /// Mayotte
        /// </summary>
        [Description("Mayotte")]
        [LanguageTag("fr")]
        [TypeaheadToken("Mayotte")]
        [Alpha3(CountryCode3.MYT)]
        [Currency(CurrencyCode.EUR)]
        YT,
        /// <summary>
        /// Mexico
        /// </summary>
        [Description("Mexico")]
        [LanguageTag("es-mx")]
        [TypeaheadToken("Mexico")]
        [TypeaheadToken("Mexicanos")]
        [Alpha3(CountryCode3.MEX)]
        [Currency(CurrencyCode.MXN)]
        MX,
        /// <summary>
        /// Micronesia, Federated States Of
        /// </summary>
        [Description("Micronesia, Federated States Of")]
        [LanguageTag("en")]
        [TypeaheadToken("Micronesia")]
        [TypeaheadToken("Federated")]
        [TypeaheadToken("States")]
        [Alpha3(CountryCode3.FSM)]
        [Currency(CurrencyCode.USD)]
        FM,
        /// <summary>
        /// Moldova, Republic Of
        /// </summary>
        [Description("Moldova, Republic Of")]
        [LanguageTag("ro")]
        [TypeaheadToken("Moldova")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.MDA)]
        MD,
        /// <summary>
        /// Monaco
        /// </summary>
        [Description("Monaco")]
        [LanguageTag("fr")]
        [TypeaheadToken("Monaco")]
        [Alpha3(CountryCode3.MCO)]
        [Currency(CurrencyCode.EUR)]
        MC,
        /// <summary>
        /// Mongolia
        /// </summary>
        [Description("Mongolia")]
        [LanguageTag("mn")]
        [TypeaheadToken("Mongolia")]
        [Alpha3(CountryCode3.MNG)]
        [Currency(CurrencyCode.MNT)]
        MN,
        /// <summary>
        /// Montenegro
        /// </summary>
        [Description("Montenegro")]
        [LanguageTag("sr")]
        [TypeaheadToken("Montenegro")]
        [Currency(CurrencyCode.EUR)]
        ME,
        /// <summary>
        /// Montserrat
        /// </summary>
        [Description("Montserrat")]
        [LanguageTag("en")]
        [TypeaheadToken("Montserrat")]
        [Alpha3(CountryCode3.MSR)]
        [Currency(CurrencyCode.XCD)]
        MS,
        /// <summary>
        /// Morocco
        /// </summary>
        [Description("Morocco")]
        [LanguageTag("ar-ma")]
        [TypeaheadToken("Morocco")]
        [Alpha3(CountryCode3.MAR)]
        [Currency(CurrencyCode.MAD)]
        MA,
        /// <summary>
        /// Mozambique
        /// </summary>
        [Description("Mozambique")]
        [LanguageTag("pt")]
        [TypeaheadToken("Mozambique")]
        [Alpha3(CountryCode3.MOZ)]
        [Currency(CurrencyCode.MZN)]
        MZ,
        /// <summary>
        /// Myanmar
        /// </summary>
        [Description("Myanmar")]
        [LanguageTag("my")]
        [TypeaheadToken("Myanmar")]
        [Alpha3(CountryCode3.MMR)]
        [Currency(CurrencyCode.MMK)]
        MM,
        /// <summary>
        /// Namibia
        /// </summary>
        [Description("Namibia")]
        [LanguageTag("en")]
        [TypeaheadToken("Namibia")]
        [Alpha3(CountryCode3.NAM)]
        [Currency(CurrencyCode.NAD)]
        NA,
        /// <summary>
        /// Nauru
        /// </summary>
        [Description("Nauru")]
        [LanguageTag("na")]
        [TypeaheadToken("Nauru")]
        [Alpha3(CountryCode3.NRU)]
        [Currency(CurrencyCode.AUD)]
        NR,
        /// <summary>
        /// Nepal
        /// </summary>
        [Description("Nepal")]
        [LanguageTag("ne")]
        [TypeaheadToken("Nepal")]
        [Alpha3(CountryCode3.NPL)]
        [Currency(CurrencyCode.NPR)]
        NP,
        /// <summary>
        /// Netherlands
        /// </summary>
        [Description("Netherlands")]
        [LanguageTag("nl")]
        [TypeaheadToken("Netherlands")]
        [TypeaheadToken("Holland")]
        [TypeaheadToken("Nederland")]
        [TypeaheadToken("Pays")]
        [TypeaheadToken("Bas")]
        [Alpha3(CountryCode3.NLD)]
        [Currency(CurrencyCode.EUR)]
        NL,
        /// <summary>
        /// Netherlands Antilles
        /// </summary>
        [Description("Netherlands Antilles")]
        [LanguageTag("nl")]
        [TypeaheadToken("Netherlands")]
        [TypeaheadToken("Antilles")]
        [Alpha3(CountryCode3.ANT)]
        [Currency(CurrencyCode.ANG)]
        AN,
        /// <summary>
        /// New Caledonia
        /// </summary>
        [Description("New Caledonia")]
        [LanguageTag("fr")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Caledonia")]
        [Alpha3(CountryCode3.NCL)]
        [Currency(CurrencyCode.XPF)]
        NC,
        /// <summary>
        /// New Zealand
        /// </summary>
        [Description("New Zealand")]
        [LanguageTag("en-nz")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Zealand")]
        [Alpha3(CountryCode3.NZL)]
        [Currency(CurrencyCode.NZD)]
        NZ,
        /// <summary>
        /// Nicaragua
        /// </summary>
        [Description("Nicaragua")]
        [LanguageTag("es-ni")]
        [TypeaheadToken("Nicaragua")]
        [Alpha3(CountryCode3.NIC)]
        [Currency(CurrencyCode.NIO)]
        NI,
        /// <summary>
        /// Niger
        /// </summary>
        [Description("Niger")]
        [LanguageTag("fr")]
        [TypeaheadToken("Niger")]
        [Alpha3(CountryCode3.NER)]
        [Currency(CurrencyCode.XOF)]
        NE,
        /// <summary>
        /// Nigeria
        /// </summary>
        [Description("Nigeria")]
        [LanguageTag("en")]
        [TypeaheadToken("Nigeria")]
        [Alpha3(CountryCode3.NGA)]
        [Currency(CurrencyCode.NGN)]
        NG,
        /// <summary>
        /// Niue
        /// </summary>
        [Description("Niue")]
        [LanguageTag("en")]
        [TypeaheadToken("Niue")]
        [Alpha3(CountryCode3.NIU)]
        [Currency(CurrencyCode.NZD)]
        NU,
        /// <summary>
        /// Norfolk Island
        /// </summary>
        [Description("Norfolk Island")]
        [LanguageTag("en")]
        [TypeaheadToken("Norfolk")]
        [TypeaheadToken("Island")]
        [Alpha3(CountryCode3.NFK)]
        [Currency(CurrencyCode.AUD)]
        NF,
        /// <summary>
        /// Northern Mariana Islands
        /// </summary>
        [Description("Northern Mariana Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Northern")]
        [TypeaheadToken("Mariana")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.MNP)]
        [Currency(CurrencyCode.USD)]
        MP,
        /// <summary>
        /// Norway
        /// </summary>
        [Description("Norway")]
        [LanguageTag("no")]
        [TypeaheadToken("Norway")]
        [TypeaheadToken("Norge")]
        [TypeaheadToken("Noreg")]
        [Alpha3(CountryCode3.NOR)]
        [Currency(CurrencyCode.NOK)]
        NO,
        /// <summary>
        /// Oman
        /// </summary>
        [Description("Oman")]
        [LanguageTag("ar")]
        [TypeaheadToken("Oman")]
        [Alpha3(CountryCode3.OMN)]
        [Currency(CurrencyCode.OMR)]
        OM,
        /// <summary>
        /// Pakistan
        /// </summary>
        [Description("Pakistan")]
        [LanguageTag("en")]
        [TypeaheadToken("Pakistan")]
        [Alpha3(CountryCode3.PAK)]
        [Currency(CurrencyCode.PKR)]
        PK,
        /// <summary>
        /// Palau
        /// </summary>
        [Description("Palau")]
        [LanguageTag("en")]
        [TypeaheadToken("Palau")]
        [Alpha3(CountryCode3.PLW)]
        [Currency(CurrencyCode.USD)]
        PW,
        /// <summary>
        /// Palestinian Territory, Occupied
        /// </summary>
        [Description("Palestinian Territory, Occupied")]
        [LanguageTag("ar")]
        [TypeaheadToken("Palestinian")]
        [TypeaheadToken("Territory")]
        [TypeaheadToken("Occupied")]
        [Alpha3(CountryCode3.PSE)]
        [Currency(CurrencyCode.ILS)]
        PS,
        /// <summary>
        /// Panama
        /// </summary>
        [Description("Panama")]
        [LanguageTag("es-pa")]
        [TypeaheadToken("Panama")]
        [Alpha3(CountryCode3.PAN)]
        [Currency(CurrencyCode.PAB)]
        PA,
        /// <summary>
        /// Papua New Guinea
        /// </summary>
        [Description("Papua New Guinea")]
        [LanguageTag("en")]
        [TypeaheadToken("Papua")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Guinea")]
        [Alpha3(CountryCode3.PNG)]
        [Currency(CurrencyCode.PGK)]
        PG,
        /// <summary>
        /// Paraguay
        /// </summary>
        [Description("Paraguay")]
        [LanguageTag("es-py")]
        [TypeaheadToken("Paraguay")]
        [Alpha3(CountryCode3.PRY)]
        [Currency(CurrencyCode.PYG)]
        PY,
        /// <summary>
        /// Peru
        /// </summary>
        [Description("Peru")]
        [LanguageTag("es-pe")]
        [TypeaheadToken("Peru")]
        [Alpha3(CountryCode3.PER)]
        [Currency(CurrencyCode.PEN)]
        PE,
        /// <summary>
        /// Philippines
        /// </summary>
        [Description("Philippines")]
        [LanguageTag("fil")]
        [TypeaheadToken("Philippines")]
        [Alpha3(CountryCode3.PHL)]
        [Currency(CurrencyCode.PHP)]
        PH,
        /// <summary>
        /// Pitcairn
        /// </summary>
        [Description("Pitcairn")]
        [LanguageTag("en")]
        [TypeaheadToken("Pitcairn")]
        [Alpha3(CountryCode3.PCN)]
        [Currency(CurrencyCode.NZD)]
        PN,
        /// <summary>
        /// Poland
        /// </summary>
        [Description("Poland")]
        [LanguageTag("pl")]
        [TypeaheadToken("Poland")]
        [Alpha3(CountryCode3.POL)]
        [Currency(CurrencyCode.PLN)]
        PL,
        /// <summary>
        /// Portugal
        /// </summary>
        [Description("Portugal")]
        [LanguageTag("pt")]
        [TypeaheadToken("Portugal")]
        [Alpha3(CountryCode3.PRT)]
        [Currency(CurrencyCode.EUR)]
        PT,
        /// <summary>
        /// Puerto Rico
        /// </summary>
        [Description("Puerto Rico")]
        [LanguageTag("es-pr")]
        [TypeaheadToken("Puerto")]
        [TypeaheadToken("Rico")]
        [Alpha3(CountryCode3.PRI)]
        [Currency(CurrencyCode.USD)]
        PR,
        /// <summary>
        /// Qatar
        /// </summary>
        [Description("Qatar")]
        [LanguageTag("ar-qa")]
        [TypeaheadToken("Qatar")]
        [Alpha3(CountryCode3.QAT)]
        [Currency(CurrencyCode.QAR)]
        QA,
        /// <summary>
        /// Réunion
        /// </summary>
        [Description("Réunion")]
        [LanguageTag("fr")]
        [TypeaheadToken("Réunion")]
        [TypeaheadToken("Reunion")]
        [TypeaheadToken("Ile")]
        [Alpha3(CountryCode3.REU)]
        [Currency(CurrencyCode.EUR)]
        RE,
        /// <summary>
        /// Romania
        /// </summary>
        [Description("Romania")]
        [LanguageTag("ro")]
        [TypeaheadToken("Romania")]
        [Alpha3(CountryCode3.ROU)]
        [Currency(CurrencyCode.RON)]
        RO,
        /// <summary>
        /// Russian Federation
        /// </summary>
        [Description("Russian Federation")]
        [LanguageTag("ru")]
        [TypeaheadToken("Russian")]
        [TypeaheadToken("Federation")]
        [TypeaheadToken("Russia")]
        [TypeaheadToken("Rossiya")]
        [Alpha3(CountryCode3.RUS)]
        [Currency(CurrencyCode.RUB)]
        RU,
        /// <summary>
        /// Rwanda
        /// </summary>
        [Description("Rwanda")]
        [LanguageTag("en")]
        [TypeaheadToken("Rwanda")]
        [Alpha3(CountryCode3.RWA)]
        [Currency(CurrencyCode.RWF)]
        RW,
        /// <summary>
        /// Saint Barthélemy
        /// </summary>
        [Description("Saint Barthélemy")]
        [LanguageTag("fr")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Barthélemy")]
        [TypeaheadToken("Barthelememy")]
        [TypeaheadToken("St")]
        [TypeaheadToken("Barts")]
        [TypeaheadToken("Barth")]
        [Currency(CurrencyCode.EUR)]
        BL,
        /// <summary>
        /// Saint Helena
        /// </summary>
        [Description("Saint Helena")]
        [LanguageTag("en")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Helena")]
        [Alpha3(CountryCode3.SHN)]
        [Currency(CurrencyCode.GBP)]
        SH,
        /// <summary>
        /// Saint Kitts And Nevis
        /// </summary>
        [Description("Saint Kitts And Nevis")]
        [LanguageTag("en")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Kitts")]
        [TypeaheadToken("Nevis")]
        [Alpha3(CountryCode3.KNA)]
        [Currency(CurrencyCode.XCD)]
        KN,
        /// <summary>
        /// Saint Lucia
        /// </summary>
        [Description("Saint Lucia")]
        [LanguageTag("en")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Lucia")]
        [Alpha3(CountryCode3.LCA)]
        [Currency(CurrencyCode.XCD)]
        LC,
        /// <summary>
        /// Saint Martin
        /// </summary>
        [Description("Saint Martin")]
        [LanguageTag("fr")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Martin")]
        [Currency(CurrencyCode.EUR)]
        MF,
        /// <summary>
        /// Saint Pierre And Miquelon
        /// </summary>
        [Description("Saint Pierre And Miquelon")]
        [LanguageTag("fr")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Pierre")]
        [TypeaheadToken("Miquelon")]
        [Alpha3(CountryCode3.SPM)]
        [Currency(CurrencyCode.EUR)]
        PM,
        /// <summary>
        /// Saint Vincent And The Grenadines
        /// </summary>
        [Description("Saint Vincent And The Grenadines")]
        [LanguageTag("en")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Vincent")]
        [TypeaheadToken("Grenadines")]
        [Alpha3(CountryCode3.VCT)]
        [Currency(CurrencyCode.XCD)]
        VC,
        /// <summary>
        /// Samoa
        /// </summary>
        [Description("Samoa")]
        [LanguageTag("en")]
        [TypeaheadToken("Samoa")]
        [Alpha3(CountryCode3.WSM)]
        [Currency(CurrencyCode.EUR)]
        WS,
        /// <summary>
        /// San Marino
        /// </summary>
        [Description("San Marino")]
        [LanguageTag("it")]
        [TypeaheadToken("San")]
        [TypeaheadToken("Marino")]
        [Alpha3(CountryCode3.SMR)]
        [Currency(CurrencyCode.EUR)]
        SM,
        /// <summary>
        /// Sao Tome And Principe
        /// </summary>
        [Description("Sao Tome And Principe")]
        [LanguageTag("pt")]
        [TypeaheadToken("Sao")]
        [TypeaheadToken("Tome")]
        [TypeaheadToken("Principe")]
        [Alpha3(CountryCode3.STP)]
        ST,
        /// <summary>
        /// Saudi Arabia
        /// </summary>
        [Description("Saudi Arabia")]
        [LanguageTag("ar-sa")]
        [TypeaheadToken("Saudi")]
        [TypeaheadToken("Arabia")]
        [Alpha3(CountryCode3.SAU)]
        [Currency(CurrencyCode.SAR)]
        SA,
        /// <summary>
        /// Senegal
        /// </summary>
        [Description("Senegal")]
        [LanguageTag("fr")]
        [TypeaheadToken("Senegal")]
        [Alpha3(CountryCode3.SEN)]
        [Currency(CurrencyCode.XOF)]
        SN,
        /// <summary>
        /// Serbia
        /// </summary>
        [Description("Serbia")]
        [LanguageTag("sr")]
        [TypeaheadToken("Serbia")]
        RS,
        /// <summary>
        /// Seychelles
        /// </summary>
        [Description("Seychelles")]
        [LanguageTag("en")]
        [TypeaheadToken("Seychelles")]
        [Alpha3(CountryCode3.SYC)]
        [Currency(CurrencyCode.SCR)]
        SC,
        /// <summary>
        /// Sierra Leone
        /// </summary>
        [Description("Sierra Leone")]
        [LanguageTag("en")]
        [TypeaheadToken("Sierra")]
        [TypeaheadToken("Leone")]
        [Alpha3(CountryCode3.SLE)]
        [Currency(CurrencyCode.SLL)]
        SL,
        /// <summary>
        /// Singapore
        /// </summary>
        [Description("Singapore")]
        [LanguageTag("en")]
        [TypeaheadToken("Singapore")]
        [Alpha3(CountryCode3.SGP)]
        [Currency(CurrencyCode.SGD)]
        SG,
        /// <summary>
        /// Slovakia
        /// </summary>
        [Description("Slovakia")]
        [LanguageTag("sk")]
        [TypeaheadToken("Slovakia")]
        [Alpha3(CountryCode3.SVK)]
        [Currency(CurrencyCode.EUR)]
        SK,
        /// <summary>
        /// Slovenia
        /// </summary>
        [Description("Slovenia")]
        [LanguageTag("sl")]
        [TypeaheadToken("Slovenia")]
        [Alpha3(CountryCode3.SVN)]
        [Currency(CurrencyCode.EUR)]
        SI,
        /// <summary>
        /// Solomon Islands
        /// </summary>
        [Description("Solomon Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Solomon")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.SLB)]
        [Currency(CurrencyCode.SBD)]
        SB,
        /// <summary>
        /// Somalia
        /// </summary>
        [Description("Somalia")]
        [LanguageTag("so")]
        [TypeaheadToken("Somalia")]
        [Alpha3(CountryCode3.SOM)]
        [Currency(CurrencyCode.SOS)]
        SO,
        /// <summary>
        /// South Africa
        /// </summary>
        [Description("South Africa")]
        [LanguageTag("en-za")]
        [TypeaheadToken("South")]
        [TypeaheadToken("Africa")]
        [Alpha3(CountryCode3.ZAF)]
        [Currency(CurrencyCode.ZAR)]
        ZA,
        /// <summary>
        /// South Georgia And The South Sandwich Islands
        /// </summary>
        [Description("South Georgia And The South Sandwich Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("South")]
        [TypeaheadToken("Georgia")]
        [TypeaheadToken("Sandwich")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.SGS)]
        [Currency(CurrencyCode.GBP)]
        GS,
        /// <summary>
        /// Spain
        /// </summary>
        [Description("Spain")]
        [LanguageTag("es")]
        [TypeaheadToken("Spain")]
        [TypeaheadToken("España")]
        [TypeaheadToken("Espana")]
        [Alpha3(CountryCode3.ESP)]
        [Currency(CurrencyCode.EUR)]
        ES,
        /// <summary>
        /// Sri Lanka
        /// </summary>
        [Description("Sri Lanka")]
        [LanguageTag("si")]
        [TypeaheadToken("Sri")]
        [TypeaheadToken("Lanka")]
        [Alpha3(CountryCode3.LKA)]
        [Currency(CurrencyCode.LKR)]
        LK,
        /// <summary>
        /// Sudan
        /// </summary>
        [Description("Sudan")]
        [LanguageTag("ar")]
        [TypeaheadToken("Sudan")]
        [Alpha3(CountryCode3.SDN)]
        [Currency(CurrencyCode.SDG)]
        SD,
        /// <summary>
        /// Suriname
        /// </summary>
        [Description("Suriname")]
        [LanguageTag("nl")]
        [TypeaheadToken("Suriname")]
        [Alpha3(CountryCode3.SUR)]
        SR,
        /// <summary>
        /// Svalbard And Jan Mayen
        /// </summary>
        [Description("Svalbard And Jan Mayen")]
        [LanguageTag("no")]
        [TypeaheadToken("Svalbard")]
        [TypeaheadToken("Jan")]
        [TypeaheadToken("Mayen")]
        [Alpha3(CountryCode3.SJM)]
        [Currency(CurrencyCode.NOK)]
        SJ,
        /// <summary>
        /// Swaziland
        /// </summary>
        [Description("Swaziland")]
        [LanguageTag("ss")]
        [TypeaheadToken("Swaziland")]
        [Alpha3(CountryCode3.SWZ)]
        [Currency(CurrencyCode.SZL)]
        SZ,
        /// <summary>
        /// Sweden
        /// </summary>
        [Description("Sweden")]
        [LanguageTag("sw")]
        [TypeaheadToken("Sweden")]
        [TypeaheadToken("Sverige")]
        [Alpha3(CountryCode3.SWE)]
        [Currency(CurrencyCode.SEK)]
        SE,
        /// <summary>
        /// Switzerland
        /// </summary>
        [Description("Switzerland")]
        [LanguageTag("de-ch")]
        [TypeaheadToken("Switzerland")]
        [TypeaheadToken("Swiss")]
        [TypeaheadToken("Confederation")]
        [TypeaheadToken("Suisse")]
        [TypeaheadToken("Schweiz")]
        [TypeaheadToken("Svizzera")]
        [TypeaheadToken("Svizra")]
        [Alpha3(CountryCode3.CHE)]
        [Currency(CurrencyCode.CHF)]
        CH,
        /// <summary>
        /// Syrian Arab Republic
        /// </summary>
        [Description("Syrian Arab Republic")]
        [LanguageTag("ar-sy")]
        [TypeaheadToken("Syrian")]
        [TypeaheadToken("Arab")]
        [TypeaheadToken("Republic")]
        [TypeaheadToken("Syria")]
        [Alpha3(CountryCode3.SYR)]
        [Currency(CurrencyCode.SYP)]
        SY,
        /// <summary>
        /// Taiwan, Province Of China
        /// </summary>
        [Description("Taiwan, Province Of China")]
        [LanguageTag("zh-tw")]
        [TypeaheadToken("Taiwan")]
        [TypeaheadToken("Province")]
        [TypeaheadToken("China")]
        [Alpha3(CountryCode3.TWN)]
        [Currency(CurrencyCode.TWD)]
        TW,
        /// <summary>
        /// Tajikistan
        /// </summary>
        [Description("Tajikistan")]
        [LanguageTag("tg")]
        [TypeaheadToken("Tajikistan")]
        [Alpha3(CountryCode3.TJK)]
        [Currency(CurrencyCode.TJS)]
        TJ,
        /// <summary>
        /// Tanzania, United Republic Of
        /// </summary>
        [Description("Tanzania, United Republic Of")]
        [LanguageTag("en")]
        [TypeaheadToken("Tanzania")]
        [TypeaheadToken("United")]
        [TypeaheadToken("Republic")]
        [Alpha3(CountryCode3.TZA)]
        [Currency(CurrencyCode.TZS)]
        TZ,
        /// <summary>
        /// Thailand
        /// </summary>
        [Description("Thailand")]
        [LanguageTag("th")]
        [TypeaheadToken("Thailand")]
        [Alpha3(CountryCode3.THA)]
        [Currency(CurrencyCode.THB)]
        TH,
        /// <summary>
        /// Timor-Leste, East Timor
        /// </summary>
        [Description("Timor-Leste, East Timor")]
        [LanguageTag("pt")]
        [TypeaheadToken("Timor")]
        [TypeaheadToken("Leste")]
        [TypeaheadToken("East")]
        [Alpha3(CountryCode3.TLS)]
        [Currency(CurrencyCode.IDR)]
        TL,
        /// <summary>
        /// Togo
        /// </summary>
        [Description("Togo")]
        [LanguageTag("fr")]
        [TypeaheadToken("Togo")]
        [Alpha3(CountryCode3.TGO)]
        [Currency(CurrencyCode.XOF)]
        TG,
        /// <summary>
        /// Tokelau
        /// </summary>
        [Description("Tokelau")]
        [LanguageTag("en")]
        [TypeaheadToken("Tokelau")]
        [Alpha3(CountryCode3.TKL)]
        [Currency(CurrencyCode.NZD)]
        TK,
        /// <summary>
        /// Tonga
        /// </summary>
        [Description("Tonga")]
        [LanguageTag("en")]
        [TypeaheadToken("Tonga")]
        [Alpha3(CountryCode3.TON)]
        [Currency(CurrencyCode.TOP)]
        TO,
        /// <summary>
        /// Trinidad And Tobago
        /// </summary>
        [Description("Trinidad And Tobago")]
        [LanguageTag("en")]
        [TypeaheadToken("Trinidad")]
        [TypeaheadToken("Tobago")]
        [Alpha3(CountryCode3.TTO)]
        [Currency(CurrencyCode.TTD)]
        TT,
        /// <summary>
        /// Tunisia
        /// </summary>
        [Description("Tunisia")]
        [LanguageTag("ar-tn")]
        [TypeaheadToken("Tunisia")]
        [Alpha3(CountryCode3.TUN)]
        [Currency(CurrencyCode.TND)]
        TN,
        /// <summary>
        /// Turkey
        /// </summary>
        [Description("Turkey")]
        [LanguageTag("tr")]
        [TypeaheadToken("Turkey")]
        [TypeaheadToken("Türkiye")]
        [TypeaheadToken("Turkiye")]
        [Alpha3(CountryCode3.TUR)]
        [Currency(CurrencyCode.TRY)]
        TR,
        /// <summary>
        /// Turkmenistan
        /// </summary>
        [Description("Turkmenistan")]
        [LanguageTag("tk")]
        [TypeaheadToken("Turkmenistan")]
        [Alpha3(CountryCode3.TKM)]
        TM,
        /// <summary>
        /// Turks And Caicos Islands
        /// </summary>
        [Description("Turks And Caicos Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Turks")]
        [TypeaheadToken("Caicos")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.TCA)]
        [Currency(CurrencyCode.USD)]
        TC,
        /// <summary>
        /// Tuvalu
        /// </summary>
        [Description("Tuvalu")]
        [LanguageTag("en")]
        [TypeaheadToken("Tuvalu")]
        [Alpha3(CountryCode3.TUV)]
        [Currency(CurrencyCode.AUD)]
        TV,
        /// <summary>
        /// Uganda
        /// </summary>
        [Description("Uganda")]
        [LanguageTag("en")]
        [TypeaheadToken("Uganda")]
        [Alpha3(CountryCode3.UGA)]
        [Currency(CurrencyCode.UGX)]
        UG,
        /// <summary>
        /// Ukraine
        /// </summary>
        [Description("Ukraine")]
        [LanguageTag("uk")]
        [TypeaheadToken("Ukraine")]
        [TypeaheadToken("Ukrayina")]
        [Alpha3(CountryCode3.UKR)]
        [Currency(CurrencyCode.UAH)]
        UA,
        /// <summary>
        /// United Arab Emirates
        /// </summary>
        [Description("United Arab Emirates")]
        [LanguageTag("ar-ae")]
        [TypeaheadToken("United")]
        [TypeaheadToken("Arab")]
        [TypeaheadToken("Emirates")]
        [Alpha3(CountryCode3.ARE)]
        [Currency(CurrencyCode.AED)]
        AE,
        /// <summary>
        /// United Kingdom
        /// </summary>
        [Description("United Kingdom")]
        [LanguageTag("en-gb")]
        [TypeaheadToken("United")]
        [TypeaheadToken("Kingdom")]
        [TypeaheadToken("UK")]
        [TypeaheadToken("Great")]
        [TypeaheadToken("Britain")]
        [TypeaheadToken("England")]
        [TypeaheadToken("Wales")]
        [TypeaheadToken("Scotland")]
        [TypeaheadToken("Northern")]
        [TypeaheadToken("Ireland")]
        [Alpha3(CountryCode3.GBR)]
        [Currency(CurrencyCode.GBP)]
        GB,
        /// <summary>
        /// United States
        /// </summary>
        [Description("United States")]
        [LanguageTag("en-us")]
        [TypeaheadToken("USA")]
        [TypeaheadToken("United")]
        [TypeaheadToken("States")]
        [TypeaheadToken("America")]
        [Alpha3(CountryCode3.USA)]
        [Currency(CurrencyCode.USD)]
        US,
        /// <summary>
        /// United States Minor Outlying Islands
        /// </summary>
        [Description("United States Minor Outlying Islands")]
        [LanguageTag("en-us")]
        [TypeaheadToken("United")]
        [TypeaheadToken("States")]
        [TypeaheadToken("Minor")]
        [TypeaheadToken("Outlying")]
        [TypeaheadToken("Islands")]
        [Alpha3(CountryCode3.UMI)]
        [Currency(CurrencyCode.USD)]
        UM,
        /// <summary>
        /// Uruguay
        /// </summary>
        [Description("Uruguay")]
        [LanguageTag("es-uy")]
        [TypeaheadToken("Uruguay")]
        [Alpha3(CountryCode3.URY)]
        [Currency(CurrencyCode.UYU)]
        UY,
        /// <summary>
        /// Uzbekistan
        /// </summary>
        [Description("Uzbekistan")]
        [LanguageTag("uz")]
        [TypeaheadToken("Uzbekistan")]
        [Alpha3(CountryCode3.UZB)]
        [Currency(CurrencyCode.UZS)]
        UZ,
        /// <summary>
        /// Vanuatu
        /// </summary>
        [Description("Vanuatu")]
        [LanguageTag("bi")]
        [TypeaheadToken("Vanuatu")]
        [Alpha3(CountryCode3.VUT)]
        [Currency(CurrencyCode.VUV)]
        VU,
        /// <summary>
        /// Venezuela
        /// </summary>
        [Description("Venezuela")]
        [LanguageTag("es-ve")]
        [TypeaheadToken("Venezuela")]
        [Alpha3(CountryCode3.VEN)]
        [Currency(CurrencyCode.VEF_DICOM)]
        VE,
        /// <summary>
        /// Vietnam
        /// </summary>
        [Description("Vietnam")]
        [LanguageTag("vi")]
        [TypeaheadToken("Vietnam")]
        [Alpha3(CountryCode3.VNM)]
        [Currency(CurrencyCode.VND)]
        VN,
        /// <summary>
        /// Virgin Islands, British
        /// </summary>
        [Description("Virgin Islands, British")]
        [LanguageTag("en")]
        [TypeaheadToken("Virgin")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("British")]
        [Alpha3(CountryCode3.VGB)]
        [Currency(CurrencyCode.USD)]
        VG,
        /// <summary>
        /// Virgin Islands, U.S.
        /// </summary>
        [Description("Virgin Islands, U.S.")]
        [LanguageTag("en")]
        [TypeaheadToken("Virgin")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("U.S.")]
        [TypeaheadToken("US")]
        [Alpha3(CountryCode3.VIR)]
        [Currency(CurrencyCode.USD)]
        VI,
        /// <summary>
        /// Wallis And Futuna
        /// </summary>
        [Description("Wallis And Futuna")]
        [LanguageTag("fr")]
        [TypeaheadToken("Wallis")]
        [TypeaheadToken("Futuna")]
        [Alpha3(CountryCode3.WLF)]
        [Currency(CurrencyCode.XPF)]
        WF,
        /// <summary>
        /// Western Sahara
        /// </summary>
        [Description("Western Sahara")]
        [LanguageTag("es")]
        [TypeaheadToken("Western")]
        [TypeaheadToken("Sahara")]
        [Alpha3(CountryCode3.ESH)]
        [Currency(CurrencyCode.MAD)]
        EH,
        /// <summary>
        /// Yemen
        /// </summary>
        [Description("Yemen")]
        [LanguageTag("ar-ye")]
        [TypeaheadToken("Yemen")]
        [Alpha3(CountryCode3.YEM)]
        [Currency(CurrencyCode.YER)]
        YE,
        /// <summary>
        /// Zambia
        /// </summary>
        [Description("Zambia")]
        [LanguageTag("en")]
        [TypeaheadToken("Zambia")]
        [Alpha3(CountryCode3.ZMB)]
        [Currency(CurrencyCode.ZMW)]
        ZM,
        /// <summary>
        /// Zimbabwe
        /// </summary>
        [Description("Zimbabwe")]
        [LanguageTag("en")]
        [TypeaheadToken("Zimbabwe")]
        [Alpha3(CountryCode3.ZWE)]
        [Currency(CurrencyCode.ZWL)]
        ZW,
        /// <summary>
        /// Custom Code
        /// </summary>
        [Description("Custom Code")]
        CustomCode,
        /// <summary>
        /// Army Post Office/Fleet Post Office
        /// </summary>
        [Description("Army Post Office/Fleet Post Office")]
        [TypeaheadToken("Army")]
        [TypeaheadToken("Post")]
        [TypeaheadToken("Fleet")]
        [TypeaheadToken("Office")]
        [TypeaheadToken("APO")]
        [TypeaheadToken("FPO")]
        AA,

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown,
        /// <summary>
        /// Global
        /// </summary>
        Global,

        /// <summary>
        /// Former Yugoslavia
        /// </summary>
        [Description("Former Yugoslavia")]
        [LanguageTag("sr")]
        [TypeaheadToken("Former")]
        [TypeaheadToken("Yugoslavia")]
        FY,
        /// <summary>
        /// South Sudan
        /// </summary>
        [Description("South Sudan")]
        [LanguageTag("en")]
        [TypeaheadToken("South")]
        [TypeaheadToken("Sudan")]
        [TypeaheadToken("Southern")]
        [TypeaheadToken("Republic")]
        [Currency(CurrencyCode.SSP)]
        SS,
        /// <summary>
        /// Curaçao
        /// </summary>
        [Description("Curaçao")]
        [LanguageTag("pap")]
        [TypeaheadToken("Curaçao")]
        [TypeaheadToken("Curacao")]
        [Currency(CurrencyCode.ANG)]
        CW,
        /// <summary>
        /// Sint Maarten
        /// </summary>
        [Description("Sint Maarten")]
        [LanguageTag("nl")]
        [TypeaheadToken("Sint")]
        [TypeaheadToken("Maarten")]
        [TypeaheadToken("Martin")]
        [Currency(CurrencyCode.ANG)]
        SX,
        // ReSharper restore InconsistentNaming
    }
}
