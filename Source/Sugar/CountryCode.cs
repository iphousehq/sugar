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
        AX,
        /// <summary>
        /// Albania
        /// </summary>
        [Description("Albania")]
        [LanguageTag("sq")]
        [TypeaheadToken("Albania")]
        AL,
        /// <summary>
        /// Algeria
        /// </summary>
        [Description("Algeria")]
        [LanguageTag("ar-dz")]
        [TypeaheadToken("Algeria")]
        DZ,
        /// <summary>
        /// American Samoa
        /// </summary>
        [Description("American Samoa")]
        [LanguageTag("en-us")]
        [TypeaheadToken("American")]
        [TypeaheadToken("Samoa")]
        AS,
        /// <summary>
        /// Andorra
        /// </summary>
        [Description("Andorra")]
        [LanguageTag("es")]
        [TypeaheadToken("Andorra")]
        AD,
        /// <summary>
        /// Angola
        /// </summary>
        [Description("Angola")]
        [LanguageTag("pt")]
        [TypeaheadToken("Angola")]
        AO,
        /// <summary>
        /// Anguilla
        /// </summary>
        [Description("Anguilla")]
        [LanguageTag("en")]
        [TypeaheadToken("Anguilla")]
        AI,
        /// <summary>
        /// Antarctica
        /// </summary>
        [Description("Antarctica")]
        [LanguageTag("en")]
        [TypeaheadToken("Antarctica")]
        AQ,
        /// <summary>
        /// Antigua And Barbuda
        /// </summary>
        [Description("Antigua And Barbuda")]
        [LanguageTag("en")]
        [TypeaheadToken("Antigua")]
        [TypeaheadToken("Barbuda")]
        AG,
        /// <summary>
        /// Argentina (please don't delete)
        /// </summary>
        [Description("Argentina")]
        [LanguageTag("es-ar")]
        [TypeaheadToken("Argentina")]
        AR,
        /// <summary>
        /// Armenia
        /// </summary>
        [Description("Armenia")]
        [LanguageTag("hy")]
        [TypeaheadToken("Armenia")]
        AM,
        /// <summary>
        /// Aruba
        /// </summary>
        [Description("Aruba")]
        [LanguageTag("nl")]
        [TypeaheadToken("Aruba")]
        AW,
        /// <summary>
        /// Australia
        /// </summary>
        [Description("Australia")]
        [LanguageTag("en-au")]
        [TypeaheadToken("Australia")]
        AU,
        /// <summary>
        /// Austria
        /// </summary>
        [Description("Austria")]
        [LanguageTag("de-at")]
        [TypeaheadToken("Austria")]
        [TypeaheadToken("Österreich")]
        [TypeaheadToken("Oesterreich")]
        AT,
        /// <summary>
        /// Azerbaijan
        /// </summary>
        [Description("Azerbaijan")]
        [LanguageTag("de-az")]
        [TypeaheadToken("Azerbaijan")]
        AZ,
        /// <summary>
        /// Bahamas
        /// </summary>
        [Description("Bahamas")]
        [LanguageTag("en")]
        [TypeaheadToken("Bahamas")]
        BS,
        /// <summary>
        /// Bahrain
        /// </summary>
        [Description("Bahrain")]
        [LanguageTag("ar")]
        [TypeaheadToken("Bahrain")]
        BH,
        /// <summary>
        /// Bangladesh
        /// </summary>
        [Description("Bangladesh")]
        [LanguageTag("bn")]
        [TypeaheadToken("Bangladesh")]
        BD,
        /// <summary>
        /// Barbados
        /// </summary>
        [Description("Barbados")]
        [LanguageTag("en")]
        [TypeaheadToken("Barbados")]
        BB,
        /// <summary>
        /// Belarus
        /// </summary>
        [Description("Belarus")]
        [LanguageTag("be")]
        [TypeaheadToken("Belarus")]
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
        BE,
        /// <summary>
        /// Belize
        /// </summary>
        [Description("Belize")]
        [LanguageTag("en")]
        [TypeaheadToken("Belize")]
        BZ,
        /// <summary>
        /// Benin
        /// </summary>
        [Description("Benin")]
        [LanguageTag("fr")]
        [TypeaheadToken("Benin")]
        BJ,
        /// <summary>
        /// Bermuda
        /// </summary>
        [Description("Bermuda")]
        [LanguageTag("en")]
        [TypeaheadToken("Bermuda")]
        BM,
        /// <summary>
        /// Bhutan
        /// </summary>
        [Description("Bhutan")]
        [LanguageTag("dz")]
        [TypeaheadToken("Bhutan")]
        BT,
        /// <summary>
        /// Bolivia
        /// </summary>
        [Description("Bolivia")]
        [LanguageTag("es-bo")]
        [TypeaheadToken("Bolivia")]
        BO,
        /// <summary>
        /// Bosnia And Herzegovina
        /// </summary>
        [Description("Bosnia And Herzegovina")]
        [LanguageTag("bs")]
        [TypeaheadToken("Bosnia")]
        [TypeaheadToken("Herzegovina")]
        BA,
        /// <summary>
        /// Botswana
        /// </summary>
        [Description("Botswana")]
        [LanguageTag("en")]
        [TypeaheadToken("Botswana")]
        BW,
        /// <summary>
        /// Bouvet Island
        /// </summary>
        [Description("Bouvet Island")]
        [LanguageTag("no")]
        [TypeaheadToken("Bouvet")]
        [TypeaheadToken("Island")]
        BV,
        /// <summary>
        /// Brazil
        /// </summary>
        [Description("Brazil")]
        [LanguageTag("pt-br")]
        [TypeaheadToken("Brazil")]
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
        IO,
        /// <summary>
        /// Brunei Darussalam
        /// </summary>
        [Description("Brunei Darussalam")]
        [LanguageTag("ms")]
        [TypeaheadToken("Brunei")]
        [TypeaheadToken("Darussalam")]
        BN,
        /// <summary>
        /// Bulgaria
        /// </summary>
        [Description("Bulgaria")]
        [LanguageTag("bg")]
        [TypeaheadToken("Bulgaria")]
        BG,
        /// <summary>
        /// Burkina Faso
        /// </summary>
        [Description("Burkina Faso")]
        [LanguageTag("fr")]
        [TypeaheadToken("Burkina")]
        [TypeaheadToken("Faso")]
        BF,
        /// <summary>
        /// Burundi
        /// </summary>
        [Description("Burundi")]
        [LanguageTag("rn")]
        [TypeaheadToken("Burundi")]
        BI,
        /// <summary>
        /// Cambodia
        /// </summary>
        [Description("Cambodia")]
        [LanguageTag("km")]
        [TypeaheadToken("Cambodia")]
        KH,
        /// <summary>
        /// Cameroon
        /// </summary>
        [Description("Cameroon")]
        [LanguageTag("en")]
        [TypeaheadToken("Cameroon")]
        CM,
        /// <summary>
        /// Canada
        /// </summary>
        [Description("Canada")]
        [LanguageTag("en-ca")]
        [TypeaheadToken("Canada")]
        CA,
        /// <summary>
        /// Cape Verde
        /// </summary>
        [Description("Cape Verde")]
        [LanguageTag("pt")]
        [TypeaheadToken("Cape")]
        [TypeaheadToken("Verde")]
        CV,
        /// <summary>
        /// Cayman Islands
        /// </summary>
        [Description("Cayman Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Cayman")]
        [TypeaheadToken("Islands")]
        KY,
        /// <summary>
        /// Central African Republic
        /// </summary>
        [Description("Central African Republic")]
        [LanguageTag("fr")]
        [TypeaheadToken("Central")]
        [TypeaheadToken("African")]
        [TypeaheadToken("Republic")]
        CF,
        /// <summary>
        /// Chad
        /// </summary>
        [Description("Chad")]
        [LanguageTag("ar")]
        [TypeaheadToken("Chad")]
        TD,
        /// <summary>
        /// Chile
        /// </summary>
        [Description("Chile")]
        [LanguageTag("es-cl")]
        [TypeaheadToken("Chile")]
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
        CN,
        /// <summary>
        /// Christmas Island
        /// </summary>
        [Description("Christmas Island")]
        [LanguageTag("en-au")]
        [TypeaheadToken("Christmas")]
        [TypeaheadToken("Island")]
        CX,
        /// <summary>
        /// Cocos (Keeling) Islands
        /// </summary>
        [Description("Cocos (Keeling) Islands")]
        [LanguageTag("es")]
        [TypeaheadToken("Cocos")]
        [TypeaheadToken("Keeling")]
        [TypeaheadToken("Islands")]
        CC,
        /// <summary>
        /// Colombia
        /// </summary>
        [Description("Colombia")]
        [LanguageTag("es-co")]
        [TypeaheadToken("Colombia")]
        CO,
        /// <summary>
        /// Comoros
        /// </summary>
        [Description("Comoros")]
        [LanguageTag("ar")]
        [TypeaheadToken("Comoros")]
        KM,
        /// <summary>
        /// Congo
        /// </summary>
        [Description("Congo")]
        [LanguageTag("fr")]
        [TypeaheadToken("Congo")]
        CG,
        /// <summary>
        /// Congo, The Democratic Republic Of The
        /// </summary>
        [Description("Congo, The Democratic Republic Of The")]
        [LanguageTag("fr")]
        [TypeaheadToken("Congo")]
        [TypeaheadToken("Democratic")]
        [TypeaheadToken("Republic")]
        CD,
        /// <summary>
        /// Cook Islands
        /// </summary>
        [Description("Cook Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Cook")]
        [TypeaheadToken("Islands")]
        CK,
        /// <summary>
        /// Costa Rica
        /// </summary>
        [Description("Costa Rica")]
        [LanguageTag("en-sp")]
        [TypeaheadToken("Costa")]
        [TypeaheadToken("Rica")]
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
        CI,
        /// <summary>
        /// Croatia
        /// </summary>
        [Description("Croatia")]
        [LanguageTag("hr")]
        [TypeaheadToken("Croatia")]
        [TypeaheadToken("Hrvatska")]
        HR,
        /// <summary>
        /// Cuba
        /// </summary>
        [Description("Cuba")]
        [LanguageTag("es")]
        [TypeaheadToken("Cuba")]
        CU,
        /// <summary>
        /// Cyprus
        /// </summary>
        [Description("Cyprus")]
        [LanguageTag("el")]
        [TypeaheadToken("Cyprus")]
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
        CZ,
        /// <summary>
        /// Denmark
        /// </summary>
        [Description("Denmark")]
        [LanguageTag("da")]
        [TypeaheadToken("Denmark")]
        DK,
        /// <summary>
        /// Djibouti
        /// </summary>
        [Description("Djibouti")]
        [LanguageTag("ar")]
        [TypeaheadToken("Djibouti")]
        DJ,
        /// <summary>
        /// Dominica
        /// </summary>
        [Description("Dominica")]
        [LanguageTag("en")]
        [TypeaheadToken("Dominica")]
        DM,
        /// <summary>
        /// Dominican Republic
        /// </summary>
        [Description("Dominican Republic")]
        [LanguageTag("es")]
        [TypeaheadToken("Dominican")]
        [TypeaheadToken("Republic")]
        DO,
        /// <summary>
        /// Ecuador
        /// </summary>
        [Description("Ecuador")]
        [LanguageTag("es")]
        [TypeaheadToken("Ecuador")]
        EC,
        /// <summary>
        /// Egypt
        /// </summary>
        [Description("Egypt")]
        [LanguageTag("ar-eg")]
        [TypeaheadToken("Egypt")]
        EG,
        /// <summary>
        /// El Salvador
        /// </summary>
        [Description("El Salvador")]
        [LanguageTag("es")]
        [TypeaheadToken("El")]
        [TypeaheadToken("Salvador")]
        SV,
        /// <summary>
        /// Equatorial Guinea
        /// </summary>
        [Description("Equatorial Guinea")]
        [LanguageTag("pt")]
        [TypeaheadToken("Equatorial")]
        [TypeaheadToken("Guinea")]
        GQ,
        /// <summary>
        /// Eritrea
        /// </summary>
        [Description("Eritrea")]
        [LanguageTag("ar")]
        [TypeaheadToken("Eritrea")]
        ER,
        /// <summary>
        /// Estonia
        /// </summary>
        [Description("Estonia")]
        [LanguageTag("et")]
        [TypeaheadToken("Estonia")]
        [TypeaheadToken("Eesti")]
        EE,
        /// <summary>
        /// Ethiopia
        /// </summary>
        [Description("Ethiopia")]
        [LanguageTag("am")]
        [TypeaheadToken("Ethiopia")]
        ET,
        /// <summary>
        /// Europe
        /// </summary>
        [Description("Europe")]
        [LanguageTag("eo")]
        [TypeaheadToken("Europe")]
        EU,
        /// <summary>
        /// Falkland Islands (Malvinas)
        /// </summary>
        [Description("Falkland Islands (Malvinas)")]
        [LanguageTag("en")]
        [TypeaheadToken("Falkland")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("Malvinas")]
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
        FO,
        /// <summary>
        /// Fiji
        /// </summary>
        [Description("Fiji")]
        [LanguageTag("en")]
        [TypeaheadToken("Fiji")]
        FJ,
        /// <summary>
        /// Finland
        /// </summary>
        [Description("Finland")]
        [LanguageTag("fi")]
        [TypeaheadToken("Finland")]
        [TypeaheadToken("Suomi")]
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
        FR,
        /// <summary>
        /// French Guiana
        /// </summary>
        [Description("French Guiana")]
        [LanguageTag("fr")]
        [TypeaheadToken("French")]
        [TypeaheadToken("Guiana")]
        GF,
        /// <summary>
        /// French Polynesia
        /// </summary>
        [Description("French Polynesia")]
        [LanguageTag("fr")]
        [TypeaheadToken("French")]
        [TypeaheadToken("Polynesia")]
        PF,
        /// <summary>
        /// French Southern Territories
        /// </summary>
        [Description("French Southern Territories")]
        [LanguageTag("fr")]
        [TypeaheadToken("French")]
        [TypeaheadToken("Southern")]
        [TypeaheadToken("Territories")]
        TF,
        /// <summary>
        /// Gabon
        /// </summary>
        [Description("Gabon")]
        [LanguageTag("fr")]
        [TypeaheadToken("Gabon")]
        GA,
        /// <summary>
        /// Gambia
        /// </summary>
        [Description("Gambia")]
        [LanguageTag("en")]
        [TypeaheadToken("Gambia")]
        GM,
        /// <summary>
        /// Georgia
        /// </summary>
        [Description("Georgia")]
        [LanguageTag("ka")]
        [TypeaheadToken("Georgia")]
        GE,
        /// <summary>
        /// Germany
        /// </summary>
        [Description("Germany")]
        [LanguageTag("de")]
        [TypeaheadToken("Germany")]
        [TypeaheadToken("Bundesrepublik")]
        [TypeaheadToken("Deutschland")]
        DE,
        /// <summary>
        /// Ghana
        /// </summary>
        [Description("Ghana")]
        [LanguageTag("en")]
        [TypeaheadToken("Ghana")]
        GH,
        /// <summary>
        /// Gibraltar
        /// </summary>
        [Description("Gibraltar")]
        [LanguageTag("en")]
        [TypeaheadToken("Gibraltar")]
        GI,
        /// <summary>
        /// Greece
        /// </summary>
        [Description("Greece")]
        [LanguageTag("el")]
        [TypeaheadToken("Greece")]
        GR,
        /// <summary>
        /// Greenland
        /// </summary>
        [Description("Greenland")]
        [LanguageTag("da")]
        [TypeaheadToken("Greenland")]
        GL,
        /// <summary>
        /// Grenada
        /// </summary>
        [Description("Grenada")]
        [LanguageTag("en")]
        [TypeaheadToken("Grenada")]
        GD,
        /// <summary>
        /// Guadeloupe
        /// </summary>
        [Description("Guadeloupe")]
        [LanguageTag("fr")]
        [TypeaheadToken("Guadeloupe")]
        GP,
        /// <summary>
        /// Guam
        /// </summary>
        [Description("Guam")]
        [LanguageTag("en")]
        [TypeaheadToken("Guam")]
        GU,
        /// <summary>
        /// Guatemala
        /// </summary>
        [Description("Guatemala")]
        [LanguageTag("es-gt")]
        [TypeaheadToken("Guatemala")]
        GT,
        /// <summary>
        /// Guernsey
        /// </summary>
        [Description("Guernsey")]
        [LanguageTag("en")]
        [TypeaheadToken("Guernsey")]
        GG,
        /// <summary>
        /// Guinea
        /// </summary>
        [Description("Guinea")]
        [LanguageTag("fr")]
        [TypeaheadToken("Guinea")]
        GN,
        /// <summary>
        /// Guinea-Bissau
        /// </summary>
        [Description("Guinea-Bissau")]
        [LanguageTag("pt")]
        [TypeaheadToken("Guinea")]
        [TypeaheadToken("Bissau")]
        GW,
        /// <summary>
        /// Guyana
        /// </summary>
        [Description("Guyana")]
        [LanguageTag("fr")]
        [TypeaheadToken("Guyana")]
        GY,
        /// <summary>
        /// Haiti
        /// </summary>
        [Description("Haiti")]
        [LanguageTag("ht")]
        [TypeaheadToken("Haiti")]
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
        VA,
        /// <summary>
        /// Honduras
        /// </summary>
        [Description("Honduras")]
        [LanguageTag("es-hn")]
        [TypeaheadToken("Honduras")]
        HN,
        /// <summary>
        /// Hong Kong
        /// </summary>
        [Description("Hong Kong")]
        [LanguageTag("zh-hk")]
        [TypeaheadToken("Hong")]
        [TypeaheadToken("Kong")]
        HK,
        /// <summary>
        /// Hungary
        /// </summary>
        [Description("Hungary")]
        [LanguageTag("hu")]
        [TypeaheadToken("Hungary")]
        HU,
        /// <summary>
        /// Iceland
        /// </summary>
        [Description("Iceland")]
        [LanguageTag("is")]
        [TypeaheadToken("Iceland")]
        [TypeaheadToken("Island")]
        IS,
        /// <summary>
        /// India
        /// </summary>
        [Description("India")]
        [LanguageTag("hi")]
        [TypeaheadToken("India")]
        IN,
        /// <summary>
        /// Indonesia
        /// </summary>
        [Description("Indonesia")]
        [LanguageTag("id")]
        [TypeaheadToken("Indonesia")]
        ID,
        /// <summary>
        /// Iran, Islamic Republic Of
        /// </summary>
        [Description("Iran, Islamic Republic Of")]
        [LanguageTag("fa")]
        [TypeaheadToken("Iran")]
        [TypeaheadToken("Islamic")]
        [TypeaheadToken("Republic")]
        IR,
        /// <summary>
        /// Iraq
        /// </summary>
        [Description("Iraq")]
        [LanguageTag("ar-iq")]
        [TypeaheadToken("Iraq")]
        IQ,
        /// <summary>
        /// Ireland
        /// </summary>
        [Description("Ireland")]
        [LanguageTag("en-ie")]
        [TypeaheadToken("Ireland")]
        [TypeaheadToken("Éire")]
        IE,
        /// <summary>
        /// Isle of Man
        /// </summary>
        [Description("Isle of Man")]
        [LanguageTag("en")]
        [TypeaheadToken("Isle")]
        [TypeaheadToken("Man")]
        IM,
        /// <summary>
        /// Israel
        /// </summary>
        [Description("Israel")]
        [LanguageTag("heb")]
        [TypeaheadToken("Israel")]
        IL,
        /// <summary>
        /// Italy
        /// </summary>
        [Description("Italy")]
        [LanguageTag("it")]
        [TypeaheadToken("Italy")]
        [TypeaheadToken("Italia")]
        IT,
        /// <summary>
        /// Jamaica
        /// </summary>
        [Description("Jamaica")]
        [LanguageTag("en")]
        [TypeaheadToken("Jamaica")]
        JM,
        /// <summary>
        /// Japan
        /// </summary>
        [Description("Japan")]
        [LanguageTag("ja")]
        [TypeaheadToken("Japan")]
        [TypeaheadToken("Nippon")]
        [TypeaheadToken("Nihon")]
        JP,
        /// <summary>
        /// Jersey
        /// </summary>
        [Description("Jersey")]
        [LanguageTag("en")]
        [TypeaheadToken("Jersey")]
        JE,
        /// <summary>
        /// Jordan
        /// </summary>
        [Description("Jordan")]
        [LanguageTag("ar")]
        [TypeaheadToken("Jordan")]
        JO,
        /// <summary>
        /// Kazakhstan
        /// </summary>
        [Description("Kazakhstan")]
        [LanguageTag("kk")]
        [TypeaheadToken("Kazakhstan")]
        KZ,
        /// <summary>
        /// Kenya
        /// </summary>
        [Description("Kenya")]
        [LanguageTag("en")]
        [TypeaheadToken("Kenya")]
        KE,
        /// <summary>
        /// Kiribati
        /// </summary>
        [Description("Kiribati")]
        [LanguageTag("en")]
        [TypeaheadToken("Kiribati")]
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
        KP,
        /// <summary>
        /// Korea, Republic Of
        /// </summary>
        [Description("Korea, Republic Of")]
        [LanguageTag("ko")]
        [TypeaheadToken("Korea")]
        [TypeaheadToken("Republic")]
        [TypeaheadToken("South")]
        KR,
        /// <summary>
        /// Kuwait
        /// </summary>
        [Description("Kuwait")]
        [LanguageTag("ar-kw")]
        [TypeaheadToken("Kuwait")]
        KW,
        /// <summary>
        /// Kyrgyzstan
        /// </summary>
        [Description("Kyrgyzstan")]
        [LanguageTag("ky")]
        [TypeaheadToken("Kyrgyzstan")]
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
        LA,
        /// <summary>
        /// Latvia
        /// </summary>
        [Description("Latvia")]
        [LanguageTag("lv")]
        [TypeaheadToken("Latvia")]
        LV,
        /// <summary>
        /// Lebanon
        /// </summary>
        [Description("Lebanon")]
        [LanguageTag("ar-lb")]
        [TypeaheadToken("Lebanon")]
        LB,
        /// <summary>
        /// Lesotho
        /// </summary>
        [Description("Lesotho")]
        [LanguageTag("st")]
        [TypeaheadToken("Lesotho")]
        LS,
        /// <summary>
        /// Liberia
        /// </summary>
        [Description("Liberia")]
        [LanguageTag("en")]
        [TypeaheadToken("Liberia")]
        LR,
        /// <summary>
        /// Libyan Arab Jamahiriya
        /// </summary>
        [Description("Libyan Arab Jamahiriya")]
        [LanguageTag("ar")]
        [TypeaheadToken("Libyan")]
        [TypeaheadToken("Arab")]
        [TypeaheadToken("Jamahiriya")]
        LY,
        /// <summary>
        /// Liechtenstein
        /// </summary>
        [Description("Liechtenstein")]
        [LanguageTag("de-li")]
        [TypeaheadToken("Liechtenstein")]
        LI,
        /// <summary>
        /// Lithuania
        /// </summary>
        [Description("Lithuania")]
        [LanguageTag("lt")]
        [TypeaheadToken("Lithuania")]
        LT,
        /// <summary>
        /// Luxembourg
        /// </summary>
        [Description("Luxembourg")]
        [LanguageTag("de-lu")]
        [TypeaheadToken("Luxembourg")]
        LU,
        /// <summary>
        /// Macao
        /// </summary>
        [Description("Macao")]
        [LanguageTag("zn-cn")]
        [TypeaheadToken("Macao")]
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
        MK,
        /// <summary>
        /// Madagascar
        /// </summary>
        [Description("Madagascar")]
        [LanguageTag("fr")]
        [TypeaheadToken("Madagascar")]
        MG,
        /// <summary>
        /// Malawi
        /// </summary>
        [Description("Malawi")]
        [LanguageTag("en")]
        [TypeaheadToken("Malawi")]
        MW,
        /// <summary>
        /// Malaysia
        /// </summary>
        [Description("Malaysia")]
        [LanguageTag("zsm")]
        [TypeaheadToken("Malaysia")]
        MY,
        /// <summary>
        /// Maldives
        /// </summary>
        [Description("Maldives")]
        [LanguageTag("dv")]
        [TypeaheadToken("Maldives")]
        MV,
        /// <summary>
        /// Mali
        /// </summary>
        [Description("Mali")]
        [LanguageTag("fr")]
        [TypeaheadToken("Mali")]
        ML,
        /// <summary>
        /// Malta
        /// </summary>
        [Description("Malta")]
        [LanguageTag("en")]
        [TypeaheadToken("Malta")]
        MT,
        /// <summary>
        /// Marshall Islands
        /// </summary>
        [Description("Marshall Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Marshall")]
        [TypeaheadToken("Islands")]
        MH,
        /// <summary>
        /// Martinique
        /// </summary>
        [Description("Martinique")]
        [LanguageTag("fr")]
        [TypeaheadToken("Martinique")]
        MQ,
        /// <summary>
        /// Mauritania
        /// </summary>
        [Description("Mauritania")]
        [LanguageTag("ar")]
        [TypeaheadToken("Mauritania")]
        MR,
        /// <summary>
        /// Mauritius
        /// </summary>
        [Description("Mauritius")]
        [LanguageTag("en")]
        [TypeaheadToken("Mauritius")]
        [TypeaheadToken("Maurice")]
        MU,
        /// <summary>
        /// Mayotte
        /// </summary>
        [Description("Mayotte")]
        [LanguageTag("fr")]
        [TypeaheadToken("Mayotte")]
        YT,
        /// <summary>
        /// Mexico
        /// </summary>
        [Description("Mexico")]
        [LanguageTag("es-mx")]
        [TypeaheadToken("Mexico")]
        [TypeaheadToken("Mexicanos")]
        MX,
        /// <summary>
        /// Micronesia, Federated States Of
        /// </summary>
        [Description("Micronesia, Federated States Of")]
        [LanguageTag("en")]
        [TypeaheadToken("Micronesia")]
        [TypeaheadToken("Federated")]
        [TypeaheadToken("States")]
        FM,
        /// <summary>
        /// Moldova, Republic Of
        /// </summary>
        [Description("Moldova, Republic Of")]
        [LanguageTag("ro")]
        [TypeaheadToken("Moldova")]
        [TypeaheadToken("Republic")]
        MD,
        /// <summary>
        /// Monaco
        /// </summary>
        [Description("Monaco")]
        [LanguageTag("fr")]
        [TypeaheadToken("Monaco")]
        MC,
        /// <summary>
        /// Mongolia
        /// </summary>
        [Description("Mongolia")]
        [LanguageTag("mn")]
        [TypeaheadToken("Mongolia")]
        MN,
        /// <summary>
        /// Montenegro
        /// </summary>
        [Description("Montenegro")]
        [LanguageTag("sr")]
        [TypeaheadToken("Montenegro")]
        ME,
        /// <summary>
        /// Montserrat
        /// </summary>
        [Description("Montserrat")]
        [LanguageTag("en")]
        [TypeaheadToken("Montserrat")]
        MS,
        /// <summary>
        /// Morocco
        /// </summary>
        [Description("Morocco")]
        [LanguageTag("ar-ma")]
        [TypeaheadToken("Morocco")]
        MA,
        /// <summary>
        /// Mozambique
        /// </summary>
        [Description("Mozambique")]
        [LanguageTag("pt")]
        [TypeaheadToken("Mozambique")]
        MZ,
        /// <summary>
        /// Myanmar 
        /// </summary>
        [Description("Myanmar")]
        [LanguageTag("my")]
        [TypeaheadToken("Myanmar")]
        MM,
        /// <summary>
        /// Namibia
        /// </summary>
        [Description("Namibia")]
        [LanguageTag("en")]
        [TypeaheadToken("Namibia")]
        NA,
        /// <summary>
        /// Nauru
        /// </summary>
        [Description("Nauru")]
        [LanguageTag("na")]
        [TypeaheadToken("Nauru")]
        NR,
        /// <summary>
        /// Nepal
        /// </summary>
        [Description("Nepal")]
        [LanguageTag("ne")]
        [TypeaheadToken("Nepal")]
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
        NL,
        /// <summary>
        /// Netherlands Antilles
        /// </summary>
        [Description("Netherlands Antilles")]
        [LanguageTag("nl")]
        [TypeaheadToken("Netherlands")]
        [TypeaheadToken("Antilles")]
        AN,
        /// <summary>
        /// New Caledonia
        /// </summary>
        [Description("New Caledonia")]
        [LanguageTag("fr")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Caledonia")]
        NC,
        /// <summary>
        /// New Zealand
        /// </summary>
        [Description("New Zealand")]
        [LanguageTag("en-nz")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Zealand")]
        NZ,
        /// <summary>
        /// Nicaragua
        /// </summary>
        [Description("Nicaragua")]
        [LanguageTag("es-ni")]
        [TypeaheadToken("Nicaragua")]
        NI,
        /// <summary>
        /// Niger
        /// </summary>
        [Description("Niger")]
        [LanguageTag("fr")]
        [TypeaheadToken("Niger")]
        NE,
        /// <summary>
        /// Nigeria
        /// </summary>
        [Description("Nigeria")]
        [LanguageTag("en")]
        [TypeaheadToken("Nigeria")]
        NG,
        /// <summary>
        /// Niue
        /// </summary>
        [Description("Niue")]
        [LanguageTag("en")]
        [TypeaheadToken("Niue")]
        NU,
        /// <summary>
        /// Norfolk Island
        /// </summary>
        [Description("Norfolk Island")]
        [LanguageTag("en")]
        [TypeaheadToken("Norfolk")]
        [TypeaheadToken("Island")]
        NF,
        /// <summary>
        /// Northern Mariana Islands
        /// </summary>
        [Description("Northern Mariana Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Northern")]
        [TypeaheadToken("Mariana")]
        [TypeaheadToken("Islands")]
        MP,
        /// <summary>
        /// Norway
        /// </summary>
        [Description("Norway")]
        [LanguageTag("no")]
        [TypeaheadToken("Norway")]
        [TypeaheadToken("Norge")]
        [TypeaheadToken("Noreg")]
        NO,
        /// <summary>
        /// Oman
        /// </summary>
        [Description("Oman")]
        [LanguageTag("ar")]
        [TypeaheadToken("Oman")]
        OM,
        /// <summary>
        /// Pakistan
        /// </summary>
        [Description("Pakistan")]
        [LanguageTag("en")]
        [TypeaheadToken("Pakistan")]
        PK,
        /// <summary>
        /// Palau
        /// </summary>
        [Description("Palau")]
        [LanguageTag("en")]
        [TypeaheadToken("Palau")]
        PW,
        /// <summary>
        /// Palestinian Territory, Occupied
        /// </summary>
        [Description("Palestinian Territory, Occupied")]
        [LanguageTag("ar")]
        [TypeaheadToken("Palestinian")]
        [TypeaheadToken("Territory")]
        [TypeaheadToken("Occupied")]
        PS,
        /// <summary>
        /// Panama
        /// </summary>
        [Description("Panama")]
        [LanguageTag("es-pa")]
        [TypeaheadToken("Panama")]
        PA,
        /// <summary>
        /// Papua New Guinea
        /// </summary>
        [Description("Papua New Guinea")]
        [LanguageTag("en")]
        [TypeaheadToken("Papua")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Guinea")]
        PG,
        /// <summary>
        /// Paraguay
        /// </summary>
        [Description("Paraguay")]
        [LanguageTag("es-py")]
        [TypeaheadToken("Paraguay")]
        PY,
        /// <summary>
        /// Peru
        /// </summary>
        [Description("Peru")]
        [LanguageTag("es-pe")]
        [TypeaheadToken("Peru")]
        PE,
        /// <summary>
        /// Philippines
        /// </summary>
        [Description("Philippines")]
        [LanguageTag("fil")]
        [TypeaheadToken("Philippines")]
        PH,
        /// <summary>
        /// Pitcairn
        /// </summary>
        [Description("Pitcairn")]
        [LanguageTag("en")]
        [TypeaheadToken("Pitcairn")]
        PN,
        /// <summary>
        /// Poland
        /// </summary>
        [Description("Poland")]
        [LanguageTag("pl")]
        [TypeaheadToken("Poland")]
        PL,
        /// <summary>
        /// Portugal
        /// </summary>
        [Description("Portugal")]
        [LanguageTag("pt")]
        [TypeaheadToken("Portugal")]
        PT,
        /// <summary>
        /// Puerto Rico
        /// </summary>
        [Description("Puerto Rico")]
        [LanguageTag("es-pr")]
        [TypeaheadToken("Puerto")]
        [TypeaheadToken("Rico")]
        PR,
        /// <summary>
        /// Qatar
        /// </summary>
        [Description("Qatar")]
        [LanguageTag("ar-qa")]
        [TypeaheadToken("Qatar")]
        QA,
        /// <summary>
        /// Réunion
        /// </summary>
        [Description("Réunion")]
        [LanguageTag("fr")]
        [TypeaheadToken("Réunion")]
        [TypeaheadToken("Reunion")]
        [TypeaheadToken("Ile")]
        RE,
        /// <summary>
        /// Romania
        /// </summary>
        [Description("Romania")]
        [LanguageTag("ro")]
        [TypeaheadToken("Romania")]
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
        RU,
        /// <summary>
        /// Rwanda
        /// </summary>
        [Description("Rwanda")]
        [LanguageTag("en")]
        [TypeaheadToken("Rwanda")]
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

        BL,
        /// <summary>
        /// Saint Helena
        /// </summary>
        [Description("Saint Helena")]
        [LanguageTag("en")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Helena")]
        SH,
        /// <summary>
        /// Saint Kitts And Nevis
        /// </summary>
        [Description("Saint Kitts And Nevis")]
        [LanguageTag("en")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Kitts")]
        [TypeaheadToken("Nevis")]
        KN,
        /// <summary>
        /// Saint Lucia
        /// </summary>
        [Description("Saint Lucia")]
        [LanguageTag("en")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Lucia")]
        LC,
        /// <summary>
        /// Saint Martin
        /// </summary>
        [Description("Saint Martin")]
        [LanguageTag("fr")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Martin")]
        MF,
        /// <summary>
        /// Saint Pierre And Miquelon
        /// </summary>
        [Description("Saint Pierre And Miquelon")]
        [LanguageTag("fr")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Pierre")]
        [TypeaheadToken("Miquelon")]
        PM,
        /// <summary>
        /// Saint Vincent And The Grenadines
        /// </summary>
        [Description("Saint Vincent And The Grenadines")]
        [LanguageTag("en")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Vincent")]
        [TypeaheadToken("Grenadines")]
        VC,
        /// <summary>
        /// Samoa
        /// </summary>
        [Description("Samoa")]
        [LanguageTag("en")]
        [TypeaheadToken("Samoa")]
        WS,
        /// <summary>
        /// San Marino
        /// </summary>
        [Description("San Marino")]
        [LanguageTag("it")]
        [TypeaheadToken("San")]
        [TypeaheadToken("Marino")]
        SM,
        /// <summary>
        /// Sao Tome And Principe
        /// </summary>
        [Description("Sao Tome And Principe")]
        [LanguageTag("pt")]
        [TypeaheadToken("Sao")]
        [TypeaheadToken("Tome")]
        [TypeaheadToken("Principe")]
        ST,
        /// <summary>
        /// Saudi Arabia
        /// </summary>
        [Description("Saudi Arabia")]
        [LanguageTag("ar-sa")]
        [TypeaheadToken("Saudi")]
        [TypeaheadToken("Arabia")]
        SA,
        /// <summary>
        /// Senegal
        /// </summary>
        [Description("Senegal")]
        [LanguageTag("fr")]
        [TypeaheadToken("Senegal")]
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
        SC,
        /// <summary>
        /// Sierra Leone
        /// </summary>
        [Description("Sierra Leone")]
        [LanguageTag("en")]
        [TypeaheadToken("Sierra")]
        [TypeaheadToken("Leone")]
        SL,
        /// <summary>
        /// Singapore
        /// </summary>
        [Description("Singapore")]
        [LanguageTag("en")]
        [TypeaheadToken("Singapore")]
        SG,
        /// <summary>
        /// Slovakia
        /// </summary>
        [Description("Slovakia")]
        [TypeaheadToken("Slovakia")]
        SK,
        /// <summary>
        /// Slovenia
        /// </summary>
        [Description("Slovenia")]
        [LanguageTag("sl")]
        [TypeaheadToken("Slovenia")]
        SI,
        /// <summary>
        /// Solomon Islands
        /// </summary>
        [Description("Solomon Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Solomon")]
        [TypeaheadToken("Islands")]
        SB,
        /// <summary>
        /// Somalia
        /// </summary>
        [Description("Somalia")]
        [LanguageTag("so")]
        [TypeaheadToken("Somalia")]
        SO,
        /// <summary>
        /// South Africa
        /// </summary>
        [Description("South Africa")]
        [LanguageTag("en-za")]
        [TypeaheadToken("South")]
        [TypeaheadToken("Africa")]
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
        GS,
        /// <summary>
        /// Spain
        /// </summary>
        [Description("Spain")]
        [LanguageTag("es")]
        [TypeaheadToken("Spain")]
        [TypeaheadToken("España")]
        [TypeaheadToken("Espana")]
        ES,
        /// <summary>
        /// Sri Lanka
        /// </summary>
        [Description("Sri Lanka")]
        [LanguageTag("si")]
        [TypeaheadToken("Sri")]
        [TypeaheadToken("Lanka")]
        LK,
        /// <summary>
        /// Sudan
        /// </summary>
        [Description("Sudan")]
        [LanguageTag("ar")]
        [TypeaheadToken("Sudan")]
        SD,
        /// <summary>
        /// Suriname
        /// </summary>
        [Description("Suriname")]
        [LanguageTag("nl")]
        [TypeaheadToken("Suriname")]
        SR,
        /// <summary>
        /// Svalbard And Jan Mayen
        /// </summary>
        [Description("Svalbard And Jan Mayen")]
        [LanguageTag("no")]
        [TypeaheadToken("Svalbard")]
        [TypeaheadToken("Jan")]
        [TypeaheadToken("Mayen")]
        SJ,
        /// <summary>
        /// Swaziland
        /// </summary>
        [Description("Swaziland")]
        [LanguageTag("ss")]
        [TypeaheadToken("Swaziland")]
        SZ,
        /// <summary>
        /// Sweden
        /// </summary>
        [Description("Sweden")]
        [LanguageTag("sw")]
        [TypeaheadToken("Sweden")]
        [TypeaheadToken("Sverige")]
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
        SY,
        /// <summary>
        /// Taiwan, Province Of China
        /// </summary>
        [Description("Taiwan, Province Of China")]
        [LanguageTag("zh-tw")]
        [TypeaheadToken("Taiwan")]
        [TypeaheadToken("Province")]
        [TypeaheadToken("China")]
        TW,
        /// <summary>
        /// Tajikistan
        /// </summary>
        [Description("Tajikistan")]
        [LanguageTag("tg")]
        [TypeaheadToken("Tajikistan")]
        TJ,
        /// <summary>
        /// Tanzania, United Republic Of
        /// </summary>
        [Description("Tanzania, United Republic Of")]
        [LanguageTag("en")]
        [TypeaheadToken("Tanzania")]
        [TypeaheadToken("United")]
        [TypeaheadToken("Republic")]
        TZ,
        /// <summary>
        /// Thailand
        /// </summary>
        [Description("Thailand")]
        [LanguageTag("th")]
        [TypeaheadToken("Thailand")]
        TH,
        /// <summary>
        /// Timor-Leste, East Timor
        /// </summary>
        [Description("Timor-Leste, East Timor")]
        [LanguageTag("pt")]
        [TypeaheadToken("Timor")]
        [TypeaheadToken("Leste")]
        [TypeaheadToken("East")]
        TL,
        /// <summary>
        /// Togo
        /// </summary>
        [Description("Togo")]
        [LanguageTag("fr")]
        [TypeaheadToken("Togo")]
        TG,
        /// <summary>
        /// Tokelau
        /// </summary>
        [Description("Tokelau")]
        [LanguageTag("en")]
        [TypeaheadToken("Tokelau")]
        TK,
        /// <summary>
        /// Tonga
        /// </summary>
        [Description("Tonga")]
        [LanguageTag("en")]
        [TypeaheadToken("Tonga")]
        TO,
        /// <summary>
        /// Trinidad And Tobago
        /// </summary>
        [Description("Trinidad And Tobago")]
        [LanguageTag("en")]
        [TypeaheadToken("Trinidad")]
        [TypeaheadToken("Tobago")]
        TT,
        /// <summary>
        /// Tunisia
        /// </summary>
        [Description("Tunisia")]
        [LanguageTag("ar-tn")]
        [TypeaheadToken("Tunisia")]
        TN,
        /// <summary>
        /// Turkey
        /// </summary>
        [Description("Turkey")]
        [LanguageTag("tr")]
        [TypeaheadToken("Turkey")]
        [TypeaheadToken("Türkiye")]
        [TypeaheadToken("Turkiye")]
        TR,
        /// <summary>
        /// Turkmenistan
        /// </summary>
        [Description("Turkmenistan")]
        [LanguageTag("tk")]
        [TypeaheadToken("Turkmenistan")]
        TM,
        /// <summary>
        /// Turks And Caicos Islands
        /// </summary>
        [Description("Turks And Caicos Islands")]
        [LanguageTag("en")]
        [TypeaheadToken("Turks")]
        [TypeaheadToken("Caicos")]
        [TypeaheadToken("Islands")]
        TC,
        /// <summary>
        /// Tuvalu
        /// </summary>
        [Description("Tuvalu")]
        [LanguageTag("en")]
        [TypeaheadToken("Tuvalu")]
        TV,
        /// <summary>
        /// Uganda
        /// </summary>
        [Description("Uganda")]
        [LanguageTag("en")]
        [TypeaheadToken("Uganda")]
        UG,
        /// <summary>
        /// Ukraine
        /// </summary>
        [Description("Ukraine")]
        [LanguageTag("uk")]
        [TypeaheadToken("Ukraine")]
        [TypeaheadToken("Ukrayina")]
        UA,
        /// <summary>
        /// United Arab Emirates
        /// </summary>
        [Description("United Arab Emirates")]
        [LanguageTag("ar-ae")]
        [TypeaheadToken("United")]
        [TypeaheadToken("Arab")]
        [TypeaheadToken("Emirates")]
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
        UM,
        /// <summary>
        /// Uruguay
        /// </summary>
        [Description("Uruguay")]
        [LanguageTag("es-uy")]
        [TypeaheadToken("Uruguay")]
        UY,
        /// <summary>
        /// Uzbekistan
        /// </summary>
        [Description("Uzbekistan")]
        [LanguageTag("uz")]
        [TypeaheadToken("Uzbekistan")]
        UZ,
        /// <summary>
        /// Vanuatu
        /// </summary>
        [Description("Vanuatu")]
        [LanguageTag("bi")]
        [TypeaheadToken("Vanuatu")]
        VU,
        /// <summary>
        /// Venezuela
        /// </summary>
        [Description("Venezuela")]
        [LanguageTag("es-ve")]
        [TypeaheadToken("Venezuela")]
        VE,
        /// <summary>
        /// Vietnam
        /// </summary>
        [Description("Vietnam")]
        [LanguageTag("vi")]
        [TypeaheadToken("Vietnam")]
        VN,
        /// <summary>
        /// Virgin Islands, British
        /// </summary>
        [Description("Virgin Islands, British")]
        [LanguageTag("en")]
        [TypeaheadToken("Virgin")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("British")]
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
        VI,
        /// <summary>
        /// Wallis And Futuna
        /// </summary>
        [Description("Wallis And Futuna")]
        [LanguageTag("fr")]
        [TypeaheadToken("Wallis")]
        [TypeaheadToken("Futuna")]
        WF,
        /// <summary>
        /// Western Sahara
        /// </summary>
        [Description("Western Sahara")]
        [LanguageTag("es")]
        [TypeaheadToken("Western")]
        [TypeaheadToken("Sahara")]
        EH,
        /// <summary>
        /// Yemen
        /// </summary>
        [Description("Yemen")]
        [LanguageTag("ar-ye")]
        [TypeaheadToken("Yemen")]
        YE,
        /// <summary>
        /// Zambia
        /// </summary>
        [Description("Zambia")]
        [LanguageTag("en")]
        [TypeaheadToken("Zambia")]
        ZM,
        /// <summary>
        /// Zimbabwe
        /// </summary>
        [Description("Zimbabwe")]
        [LanguageTag("en")]
        [TypeaheadToken("Zimbabwe")]
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
        /// Former Yugoslavia
        /// </summary>
        [Description("Former Yugoslavia")]
        [LanguageTag("sr")]
        [TypeaheadToken("Former")]
        [TypeaheadToken("Yugoslavia")]
        FY,
        /// <summary>
        /// Global
        /// </summary>
        Global,
        /// <summary>
        /// South Sudan
        /// </summary>
        [Description("South Sudan")]
        [LanguageTag("en")]
        [TypeaheadToken("South")]
        [TypeaheadToken("Sudan")]
        [TypeaheadToken("Southern")]
        [TypeaheadToken("Republic")]
        SS,
        /// <summary>
        /// Curaçao
        /// </summary>
        [Description("Curaçao")]
        [LanguageTag("pap")]
        [TypeaheadToken("Curaçao")]
        [TypeaheadToken("Curacao")]
        CW,
        /// <summary>
        /// Sint Maarten
        /// </summary>
        [Description("Sint Maarten")]
        [LanguageTag("nl")]
        [TypeaheadToken("Sint")]
        [TypeaheadToken("Maarten")]
        [TypeaheadToken("Martin")]
        SX,
        // ReSharper restore InconsistentNaming
    }
}
