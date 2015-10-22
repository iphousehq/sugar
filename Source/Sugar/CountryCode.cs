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
        [TypeaheadToken("Afghanistan")]
        AF,
        /// <summary>
        /// Aaland Aland
        /// </summary>
        [Description("Åland Islands")]
        [TypeaheadToken("Aaland")]
        [TypeaheadToken("Aland")]
        [TypeaheadToken("Åland")]
        [TypeaheadToken("Islands")]
        AX,
        /// <summary>
        /// Albania
        /// </summary>
        [Description("Albania")]
        [TypeaheadToken("Albania")]
        AL,
        /// <summary>
        /// Algeria
        /// </summary>
        [Description("Algeria")]
        [TypeaheadToken("Algeria")]
        DZ,
        /// <summary>
        /// American Samoa
        /// </summary>
        [Description("American Samoa")]
        [TypeaheadToken("American")]
        [TypeaheadToken("Samoa")]
        AS,
        /// <summary>
        /// Andorra
        /// </summary>
        [Description("Andorra")]
        [TypeaheadToken("Andorra")]
        AD,
        /// <summary>
        /// Angola
        /// </summary>
        [Description("Angola")]
        [TypeaheadToken("Angola")]
        AO,
        /// <summary>
        /// Anguilla
        /// </summary>
        [Description("Anguilla")]
        [TypeaheadToken("Anguilla")]
        AI,
        /// <summary>
        /// Antarctica
        /// </summary>
        [Description("Antarctica")]
        [TypeaheadToken("Antarctica")]
        AQ,
        /// <summary>
        /// Antigua And Barbuda
        /// </summary>
        [Description("Antigua And Barbuda")]
        [TypeaheadToken("Antigua")]
        [TypeaheadToken("Barbuda")]
        AG,
        /// <summary>
        /// Argentina (please don't delete)
        /// </summary>
        [Description("Argentina")]
        [TypeaheadToken("Argentina")]
        AR,
        /// <summary>
        /// Armenia
        /// </summary>
        [Description("Armenia")]
        [TypeaheadToken("Armenia")]
        AM,
        /// <summary>
        /// Aruba
        /// </summary>
        [Description("Aruba")]
        [TypeaheadToken("Aruba")]
        AW,
        /// <summary>
        /// Australia
        /// </summary>
        [Description("Australia")]
        [TypeaheadToken("Australia")]
        AU,
        /// <summary>
        /// Austria
        /// </summary>
        [Description("Austria")]
        [TypeaheadToken("Austria")]
        [TypeaheadToken("Österreich")]
        [TypeaheadToken("Oesterreich")]
        AT,
        /// <summary>
        /// Azerbaijan
        /// </summary>
        [Description("Azerbaijan")]
        [TypeaheadToken("Azerbaijan")]
        AZ,
        /// <summary>
        /// Bahamas
        /// </summary>
        [Description("Bahamas")]
        [TypeaheadToken("Bahamas")]
        BS,
        /// <summary>
        /// Bahrain
        /// </summary>
        [Description("Bahrain")]
        [TypeaheadToken("Bahrain")]
        BH,
        /// <summary>
        /// Bangladesh
        /// </summary>
        [Description("Bangladesh")]
        [TypeaheadToken("Bangladesh")]
        BD,
        /// <summary>
        /// Barbados
        /// </summary>
        [Description("Barbados")]
        [TypeaheadToken("Barbados")]
        BB,
        /// <summary>
        /// Belarus
        /// </summary>
        [Description("Belarus")]
        [TypeaheadToken("Belarus")]
        BY,
        /// <summary>
        /// Belgium
        /// </summary>
        [Description("Belgium")]
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
        [TypeaheadToken("Belize")]
        BZ,
        /// <summary>
        /// Benin
        /// </summary>
        [Description("Benin")]
        [TypeaheadToken("Benin")]
        BJ,
        /// <summary>
        /// Bermuda
        /// </summary>
        [Description("Bermuda")]
        [TypeaheadToken("Bermuda")]
        BM,
        /// <summary>
        /// Bhutan
        /// </summary>
        [Description("Bhutan")]
        [TypeaheadToken("Bhutan")]
        BT,
        /// <summary>
        /// Bolivia
        /// </summary>
        [Description("Bolivia")]
        [TypeaheadToken("Bolivia")]
        BO,
        /// <summary>
        /// Bosnia And Herzegovina
        /// </summary>
        [Description("Bosnia And Herzegovina")]
        [TypeaheadToken("Bosnia")]
        [TypeaheadToken("Herzegovina")]
        BA,
        /// <summary>
        /// Botswana
        /// </summary>
        [Description("Botswana")]
        [TypeaheadToken("Botswana")]
        BW,
        /// <summary>
        /// Bouvet Island
        /// </summary>
        [Description("Bouvet Island")]
        [TypeaheadToken("Bouvet")]
        [TypeaheadToken("Island")]
        BV,
        /// <summary>
        /// Brazil
        /// </summary>
        [Description("Brazil")]
        [TypeaheadToken("Brazil")]
        BR,
        /// <summary>
        /// British Indian Ocean Territory
        /// </summary>
        [Description("British Indian Ocean Territory")]
        [TypeaheadToken("British")]
        [TypeaheadToken("Indian")]
        [TypeaheadToken("Ocean")]
        [TypeaheadToken("Territory")]
        IO,
        /// <summary>
        /// Brunei Darussalam
        /// </summary>
        [Description("Brunei Darussalam")]
        [TypeaheadToken("Brunei")]
        [TypeaheadToken("Darussalam")]
        BN,
        /// <summary>
        /// Bulgaria
        /// </summary>
        [Description("Bulgaria")]
        [TypeaheadToken("Bulgaria")]
        BG,
        /// <summary>
        /// Burkina Faso
        /// </summary>
        [Description("Burkina Faso")]
        [TypeaheadToken("Burkina")]
        [TypeaheadToken("Faso")]
        BF,
        /// <summary>
        /// Burundi
        /// </summary>
        [Description("Burundi")]
        [TypeaheadToken("Burundi")]
        BI,
        /// <summary>
        /// Cambodia
        /// </summary>
        [Description("Cambodia")]
        [TypeaheadToken("Cambodia")]
        KH,
        /// <summary>
        /// Cameroon
        /// </summary>
        [Description("Cameroon")]
        [TypeaheadToken("Cameroon")]
        CM,
        /// <summary>
        /// Canada
        /// </summary>
        [Description("Canada")]
        [TypeaheadToken("Canada")]
        CA,
        /// <summary>
        /// Cape Verde
        /// </summary>
        [Description("Cape Verde")]
        [TypeaheadToken("Cape")]
        [TypeaheadToken("Verde")]
        CV,
        /// <summary>
        /// Cayman Islands
        /// </summary>
        [Description("Cayman Islands")]
        [TypeaheadToken("Cayman")]
        [TypeaheadToken("Islands")]
        KY,
        /// <summary>
        /// Central African Republic
        /// </summary>
        [Description("Central African Republic")]
        [TypeaheadToken("Central")]
        [TypeaheadToken("African")]
        [TypeaheadToken("Republic")]
        CF,
        /// <summary>
        /// Chad
        /// </summary>
        [Description("Chad")]
        [TypeaheadToken("Chad")]
        TD,
        /// <summary>
        /// Chile
        /// </summary>
        [Description("Chile")]
        [TypeaheadToken("Chile")]
        CL,
        /// <summary>
        /// China
        /// </summary>
        [Description("China")]
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
        [TypeaheadToken("Christmas")]
        [TypeaheadToken("Island")]
        CX,
        /// <summary>
        /// Cocos (Keeling) Islands
        /// </summary>
        [Description("Cocos (Keeling) Islands")]
        [TypeaheadToken("Cocos")]
        [TypeaheadToken("Keeling")]
        [TypeaheadToken("Islands")]
        CC,
        /// <summary>
        /// Colombia
        /// </summary>
        [Description("Colombia")]
        [TypeaheadToken("Colombia")]
        CO,
        /// <summary>
        /// Comoros
        /// </summary>
        [Description("Comoros")]
        [TypeaheadToken("Comoros")]
        KM,
        /// <summary>
        /// Congo
        /// </summary>
        [Description("Congo")]
        [TypeaheadToken("Congo")]
        CG,
        /// <summary>
        /// Congo, The Democratic Republic Of The
        /// </summary>
        [Description("Congo, The Democratic Republic Of The")]
        [TypeaheadToken("Congo")]
        [TypeaheadToken("Democratic")]
        [TypeaheadToken("Republic")]
        CD,
        /// <summary>
        /// Cook Islands
        /// </summary>
        [Description("Cook Islands")]
        [TypeaheadToken("Cook")]
        [TypeaheadToken("Islands")]
        CK,
        /// <summary>
        /// Costa Rica
        /// </summary>
        [Description("Costa Rica")]
        [TypeaheadToken("Costa")]
        [TypeaheadToken("Rica")]
        CR,
        /// <summary>
        /// Côte d'Ivoire
        /// </summary>
        [Description("Côte d'Ivoire")]
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
        [TypeaheadToken("Croatia")]
        [TypeaheadToken("Hrvatska")]
        HR,
        /// <summary>
        /// Cuba
        /// </summary>
        [Description("Cuba")]
        [TypeaheadToken("Cuba")]
        CU,
        /// <summary>
        /// Cyprus
        /// </summary>
        [Description("Cyprus")]
        [TypeaheadToken("Cyprus")]
        CY,
        /// <summary>
        /// Czech Republic
        /// </summary>
        [Description("Czech Republic")]
        [TypeaheadToken("Czech")]
        [TypeaheadToken("Republic")]
        [TypeaheadToken("Česká")]
        [TypeaheadToken("Ceska")]
        CZ,
        /// <summary>
        /// Denmark
        /// </summary>
        [Description("Denmark")]
        [TypeaheadToken("Danmark")]
        DK,
        /// <summary>
        /// Djibouti
        /// </summary>
        [Description("Djibouti")]
        [TypeaheadToken("Djibouti")]
        DJ,
        /// <summary>
        /// Dominica
        /// </summary>
        [Description("Dominica")]
        [TypeaheadToken("Dominica")]
        DM,
        /// <summary>
        /// Dominican Republic
        /// </summary>
        [Description("Dominican Republic")]
        [TypeaheadToken("Dominican")]
        [TypeaheadToken("Republic")]
        DO,
        /// <summary>
        /// Ecuador
        /// </summary>
        [Description("Ecuador")]
        [TypeaheadToken("Ecuador")]
        EC,
        /// <summary>
        /// Egypt
        /// </summary>
        [Description("Egypt")]
        [TypeaheadToken("Egypt")]
        EG,
        /// <summary>
        /// El Salvador
        /// </summary>
        [Description("El Salvador")]
        [TypeaheadToken("El")]
        [TypeaheadToken("Salvador")]
        SV,
        /// <summary>
        /// Equatorial Guinea
        /// </summary>
        [Description("Equatorial Guinea")]
        [TypeaheadToken("Equatorial")]
        [TypeaheadToken("Guinea")]
        GQ,
        /// <summary>
        /// Eritrea
        /// </summary>
        [Description("Eritrea")]
        [TypeaheadToken("Eritrea")]
        ER,
        /// <summary>
        /// Estonia
        /// </summary>
        [Description("Estonia")]
        [TypeaheadToken("Estonia")]
        [TypeaheadToken("Eesti")]
        EE,
        /// <summary>
        /// Ethiopia
        /// </summary>
        [Description("Ethiopia")]
        [TypeaheadToken("Ethiopia")]
        ET,
        /// <summary>
        /// Europe
        /// </summary>
        [Description("Europe")]
        [TypeaheadToken("Europe")]
        EU,
        /// <summary>
        /// Falkland Islands (Malvinas)
        /// </summary>
        [Description("Falkland Islands (Malvinas)")]
        [TypeaheadToken("Falkland")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("Malvinas")]
        FK,
        /// <summary>
        /// Faroe Islands
        /// </summary>
        [Description("Faroe Islands")]
        [TypeaheadToken("Faroe")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("Føroyar")]
        [TypeaheadToken("Færøerne")]
        FO,
        /// <summary>
        /// Fiji
        /// </summary>
        [Description("Fiji")]
        [TypeaheadToken("Fiji")]
        FJ,
        /// <summary>
        /// Finland
        /// </summary>
        [Description("Finland")]
        [TypeaheadToken("Finland")]
        [TypeaheadToken("Suomi")]
        FI,
        /// <summary>
        /// France
        /// </summary>
        [Description("France")]
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
        [TypeaheadToken("French")]
        [TypeaheadToken("Guiana")]
        GF,
        /// <summary>
        /// French Polynesia
        /// </summary>
        [Description("French Polynesia")]
        [TypeaheadToken("French")]
        [TypeaheadToken("Polynesia")]
        PF,
        /// <summary>
        /// French Southern Territories
        /// </summary>
        [Description("French Southern Territories")]
        [TypeaheadToken("French")]
        [TypeaheadToken("Southern")]
        [TypeaheadToken("Territories")]
        TF,
        /// <summary>
        /// Gabon
        /// </summary>
        [Description("Gabon")]
        [TypeaheadToken("Gabon")]
        GA,
        /// <summary>
        /// Gambia
        /// </summary>
        [Description("Gambia")]
        [TypeaheadToken("Gambia")]
        GM,
        /// <summary>
        /// Georgia
        /// </summary>
        [Description("Georgia")]
        [TypeaheadToken("Georgia")]
        GE,
        /// <summary>
        /// Germany
        /// </summary>
        [Description("Germany")]
        [TypeaheadToken("Germany")]
        [TypeaheadToken("Bundesrepublik")]
        [TypeaheadToken("Deutschland")]
        DE,
        /// <summary>
        /// Ghana
        /// </summary>
        [Description("Ghana")]
        [TypeaheadToken("Ghana")]
        GH,
        /// <summary>
        /// Gibraltar
        /// </summary>
        [Description("Gibraltar")]
        [TypeaheadToken("Gibraltar")]
        GI,
        /// <summary>
        /// Greece
        /// </summary>
        [Description("Greece")]
        [TypeaheadToken("Greece")]
        GR,
        /// <summary>
        /// Greenland
        /// </summary>
        [Description("Greenland")]
        [TypeaheadToken("Greenland")]
        GL,
        /// <summary>
        /// Grenada
        /// </summary>
        [Description("Grenada")]
        [TypeaheadToken("Grenada")]
        GD,
        /// <summary>
        /// Guadeloupe
        /// </summary>
        [Description("Guadeloupe")]
        [TypeaheadToken("Guadeloupe")]
        GP,
        /// <summary>
        /// Guam
        /// </summary>
        [Description("Guam")]
        [TypeaheadToken("Guam")]
        GU,
        /// <summary>
        /// Guatemala
        /// </summary>
        [Description("Guatemala")]
        [TypeaheadToken("Guatemala")]
        GT,
        /// <summary>
        /// Guernsey
        /// </summary>
        [Description("Guernsey")]
        [TypeaheadToken("Guernsey")]
        GG,
        /// <summary>
        /// Guinea
        /// </summary>
        [Description("Guinea")]
        [TypeaheadToken("Guinea")]
        GN,
        /// <summary>
        /// Guinea-Bissau
        /// </summary>
        [Description("Guinea-Bissau")]
        [TypeaheadToken("Guinea")]
        [TypeaheadToken("Bissau")]
        GW,
        /// <summary>
        /// Guyana
        /// </summary>
        [Description("Guyana")]
        [TypeaheadToken("Guyana")]
        GY,
        /// <summary>
        /// Haiti
        /// </summary>
        [Description("Haiti")]
        [TypeaheadToken("Haiti")]
        HT,
        /// <summary>
        /// Heard Island And Mcdonald Islands
        /// </summary>
        [Description("Heard Island And Mcdonald Islands")]
        [TypeaheadToken("Heard")]
        [TypeaheadToken("HeardMcdonald")]
        [TypeaheadToken("Island")]
        [TypeaheadToken("Islands")]
        HM,
        /// <summary>
        /// Holy See (Vatican City State)
        /// </summary>
        [Description("Holy See (Vatican City State)")]
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
        [TypeaheadToken("Honduras")]
        HN,
        /// <summary>
        /// Hong Kong
        /// </summary>
        [Description("Hong Kong")]
        [TypeaheadToken("Hong")]
        [TypeaheadToken("Kong")]
        HK,
        /// <summary>
        /// Hungary
        /// </summary>
        [Description("Hungary")]
        [TypeaheadToken("Hungary")]
        HU,
        /// <summary>
        /// Iceland
        /// </summary>
        [Description("Iceland")]
        [TypeaheadToken("Iceland")]
        [TypeaheadToken("Island")]
        IS,
        /// <summary>
        /// India
        /// </summary>
        [Description("India")]
        [TypeaheadToken("India")]
        IN,
        /// <summary>
        /// Indonesia
        /// </summary>
        [Description("Indonesia")]
        [TypeaheadToken("Indonesia")]
        ID,
        /// <summary>
        /// Iran, Islamic Republic Of
        /// </summary>
        [Description("Iran, Islamic Republic Of")]
        [TypeaheadToken("Iran")]
        [TypeaheadToken("Islamic")]
        [TypeaheadToken("Republic")]
        IR,
        /// <summary>
        /// Iraq
        /// </summary>
        [Description("Iraq")]
        [TypeaheadToken("Iraq")]
        IQ,
        /// <summary>
        /// Ireland
        /// </summary>
        [Description("Ireland")]
        [TypeaheadToken("Ireland")]
        [TypeaheadToken("Éire")]
        IE,
        /// <summary>
        /// Isle of Man
        /// </summary>
        [Description("Isle of Man")]
        [TypeaheadToken("Isle")]
        [TypeaheadToken("Man")]
        IM,
        /// <summary>
        /// Israel
        /// </summary>
        [Description("Israel")]
        [TypeaheadToken("Israel")]
        IL,
        /// <summary>
        /// Italy
        /// </summary>
        [Description("Italy")]
        [TypeaheadToken("Italy")]
        [TypeaheadToken("Italia")]
        IT,
        /// <summary>
        /// Jamaica
        /// </summary>
        [Description("Jamaica")]
        [TypeaheadToken("Jamaica")]
        JM,
        /// <summary>
        /// Japan
        /// </summary>
        [Description("Japan")]
        [TypeaheadToken("Japan")]
        [TypeaheadToken("Nippon")]
        [TypeaheadToken("Nihon")]
        JP,
        /// <summary>
        /// Jersey
        /// </summary>
        [Description("Jersey")]
        [TypeaheadToken("Jersey")]
        JE,
        /// <summary>
        /// Jordan
        /// </summary>
        [Description("Jordan")]
        [TypeaheadToken("Jordan")]
        JO,
        /// <summary>
        /// Kazakhstan
        /// </summary>
        [Description("Kazakhstan")]
        [TypeaheadToken("Kazakhstan")]
        KZ,
        /// <summary>
        /// Kenya
        /// </summary>
        [Description("Kenya")]
        [TypeaheadToken("Kenya")]
        KE,
        /// <summary>
        /// Kiribati
        /// </summary>
        [Description("Kiribati")]
        [TypeaheadToken("Kiribati")]
        KI,
        /// <summary>
        /// Korea, Democratic People'S Republic Of
        /// </summary>
        [Description("Korea, Democratic People's Republic Of")]
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
        [TypeaheadToken("Korea")]
        [TypeaheadToken("Republic")]
        [TypeaheadToken("South")]
        KR,
        /// <summary>
        /// Kuwait
        /// </summary>
        [Description("Kuwait")]
        [TypeaheadToken("Kuwait")]
        KW,
        /// <summary>
        /// Kyrgyzstan
        /// </summary>
        [Description("Kyrgyzstan")]
        [TypeaheadToken("Kyrgyzstan")]
        KG,
        /// <summary>
        /// Lao People's Democratic Republic
        /// </summary>
        [Description("Lao People's Democratic Republic")]
        [TypeaheadToken("Lao")]
        [TypeaheadToken("People's")]
        [TypeaheadToken("Democratic")]
        [TypeaheadToken("Republic")]
        LA,
        /// <summary>
        /// Latvia
        /// </summary>
        [Description("Latvia")]
        [TypeaheadToken("Latvia")]
        LV,
        /// <summary>
        /// Lebanon
        /// </summary>
        [Description("Lebanon")]
        [TypeaheadToken("Lebanon")]
        LB,
        /// <summary>
        /// Lesotho
        /// </summary>
        [Description("Lesotho")]
        [TypeaheadToken("Lesotho")]
        LS,
        /// <summary>
        /// Liberia
        /// </summary>
        [Description("Liberia")]
        [TypeaheadToken("Liberia")]
        LR,
        /// <summary>
        /// Libyan Arab Jamahiriya
        /// </summary>
        [Description("Libyan Arab Jamahiriya")]
        [TypeaheadToken("Libyan")]
        [TypeaheadToken("Arab")]
        [TypeaheadToken("Jamahiriya")]
        LY,
        /// <summary>
        /// Liechtenstein
        /// </summary>
        [Description("Liechtenstein")]
        [TypeaheadToken("Liechtenstein")]
        LI,
        /// <summary>
        /// Lithuania
        /// </summary>
        [Description("Lithuania")]
        [TypeaheadToken("Lithuania")]
        LT,
        /// <summary>
        /// Luxembourg
        /// </summary>
        [Description("Luxembourg")]
        [TypeaheadToken("Luxembourg")]
        LU,
        /// <summary>
        /// Macao
        /// </summary>
        [Description("Macao")]
        [TypeaheadToken("Macao")]
        MO,
        /// <summary>
        /// Macedonia, The Former Yugoslav Republic Of
        /// </summary>
        [Description("Macedonia, The Former Yugoslav Republic Of")]
        [TypeaheadToken("Macedonia")]
        [TypeaheadToken("Former")]
        [TypeaheadToken("Yugoslav")]
        [TypeaheadToken("Republic")]
        MK,
        /// <summary>
        /// Madagascar
        /// </summary>
        [Description("Madagascar")]
        [TypeaheadToken("Madagascar")]
        MG,
        /// <summary>
        /// Malawi
        /// </summary>
        [Description("Malawi")]
        [TypeaheadToken("Malawi")]
        MW,
        /// <summary>
        /// Malaysia
        /// </summary>
        [Description("Malaysia")]
        [TypeaheadToken("Malaysia")]
        MY,
        /// <summary>
        /// Maldives
        /// </summary>
        [Description("Maldives")]
        [TypeaheadToken("Maldives")]
        MV,
        /// <summary>
        /// Mali
        /// </summary>
        [Description("Mali")]
        [TypeaheadToken("Mali")]
        ML,
        /// <summary>
        /// Malta
        /// </summary>
        [Description("Malta")]
        [TypeaheadToken("Malta")]
        MT,
        /// <summary>
        /// Marshall Islands
        /// </summary>
        [Description("Marshall Islands")]
        [TypeaheadToken("Marshall")]
        [TypeaheadToken("Islands")]
        MH,
        /// <summary>
        /// Martinique
        /// </summary>
        [Description("Martinique")]
        [TypeaheadToken("Martinique")]
        MQ,
        /// <summary>
        /// Mauritania
        /// </summary>
        [Description("Mauritania")]
        [TypeaheadToken("Mauritania")]
        MR,
        /// <summary>
        /// Mauritius
        /// </summary>
        [Description("Mauritius")]
        [TypeaheadToken("Mauritius")]
        [TypeaheadToken("Maurice")]
        MU,
        /// <summary>
        /// Mayotte
        /// </summary>
        [Description("Mayotte")]
        [TypeaheadToken("Mayotte")]
        YT,
        /// <summary>
        /// Mexico
        /// </summary>
        [Description("Mexico")]
        [TypeaheadToken("Mexico")]
        [TypeaheadToken("Mexicanos")]
        MX,
        /// <summary>
        /// Micronesia, Federated States Of
        /// </summary>
        [Description("Micronesia, Federated States Of")]
        [TypeaheadToken("Micronesia")]
        [TypeaheadToken("Federated")]
        [TypeaheadToken("States")]
        FM,
        /// <summary>
        /// Moldova, Republic Of
        /// </summary>
        [Description("Moldova, Republic Of")]
        [TypeaheadToken("Moldova")]
        [TypeaheadToken("Republic")]
        MD,
        /// <summary>
        /// Monaco
        /// </summary>
        [Description("Monaco")]
        [TypeaheadToken("Monaco")]
        MC,
        /// <summary>
        /// Mongolia
        /// </summary>
        [Description("Mongolia")]
        [TypeaheadToken("Mongolia")]
        MN,
        /// <summary>
        /// Montenegro
        /// </summary>
        [Description("Montenegro")]
        [TypeaheadToken("Montenegro")]
        ME,
        /// <summary>
        /// Montserrat
        /// </summary>
        [Description("Montserrat")]
        [TypeaheadToken("Montserrat")]
        MS,
        /// <summary>
        /// Morocco
        /// </summary>
        [Description("Morocco")]
        [TypeaheadToken("Morocco")]
        MA,
        /// <summary>
        /// Mozambique
        /// </summary>
        [Description("Mozambique")]
        [TypeaheadToken("Mozambique")]
        MZ,
        /// <summary>
        /// Myanmar 
        /// </summary>
        [Description("Myanmar")]
        [TypeaheadToken("Myanmar")]
        MM,
        /// <summary>
        /// Namibia
        /// </summary>
        [Description("Namibia")]
        [TypeaheadToken("Namibia")]
        NA,
        /// <summary>
        /// Nauru
        /// </summary>
        [Description("Nauru")]
        [TypeaheadToken("Nauru")]
        NR,
        /// <summary>
        /// Nepal
        /// </summary>
        [Description("Nepal")]
        [TypeaheadToken("Nepal")]
        NP,
        /// <summary>
        /// Netherlands
        /// </summary>
        [Description("Netherlands")]
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
        [TypeaheadToken("Netherlands")]
        [TypeaheadToken("Antilles")]
        AN,
        /// <summary>
        /// New Caledonia
        /// </summary>
        [Description("New Caledonia")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Caledonia")]
        NC,
        /// <summary>
        /// New Zealand
        /// </summary>
        [Description("New Zealand")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Zealand")]
        NZ,
        /// <summary>
        /// Nicaragua
        /// </summary>
        [Description("Nicaragua")]
        [TypeaheadToken("Nicaragua")]
        NI,
        /// <summary>
        /// Niger
        /// </summary>
        [Description("Niger")]
        [TypeaheadToken("Niger")]
        NE,
        /// <summary>
        /// Nigeria
        /// </summary>
        [Description("Nigeria")]
        [TypeaheadToken("Nigeria")]
        NG,
        /// <summary>
        /// Niue
        /// </summary>
        [Description("Niue")]
        [TypeaheadToken("Niue")]
        NU,
        /// <summary>
        /// Norfolk Island
        /// </summary>
        [Description("Norfolk Island")]
        [TypeaheadToken("Norfolk")]
        [TypeaheadToken("Island")]
        NF,
        /// <summary>
        /// Northern Mariana Islands
        /// </summary>
        [Description("Northern Mariana Islands")]
        [TypeaheadToken("Northern")]
        [TypeaheadToken("Mariana")]
        [TypeaheadToken("Islands")]
        MP,
        /// <summary>
        /// Norway
        /// </summary>
        [Description("Norway")]
        [TypeaheadToken("Norway")]
        [TypeaheadToken("Norge")]
        [TypeaheadToken("Noreg")]
        NO,
        /// <summary>
        /// Oman
        /// </summary>
        [Description("Oman")]
        [TypeaheadToken("Oman")]
        OM,
        /// <summary>
        /// Pakistan
        /// </summary>
        [Description("Pakistan")]
        [TypeaheadToken("Pakistan")]
        PK,
        /// <summary>
        /// Palau
        /// </summary>
        [Description("Palau")]
        [TypeaheadToken("Palau")]
        PW,
        /// <summary>
        /// Palestinian Territory, Occupied
        /// </summary>
        [Description("Palestinian Territory, Occupied")]
        [TypeaheadToken("Palestinian")]
        [TypeaheadToken("Territory")]
        [TypeaheadToken("Occupied")]
        PS,
        /// <summary>
        /// Panama
        /// </summary>
        [Description("Panama")]
        [TypeaheadToken("Panama")]
        PA,
        /// <summary>
        /// Papua New Guinea
        /// </summary>
        [Description("Papua New Guinea")]
        [TypeaheadToken("Papua")]
        [TypeaheadToken("New")]
        [TypeaheadToken("Guinea")]
        PG,
        /// <summary>
        /// Paraguay
        /// </summary>
        [Description("Paraguay")]
        [TypeaheadToken("Paraguay")]
        PY,
        /// <summary>
        /// Peru
        /// </summary>
        [Description("Peru")]
        [TypeaheadToken("Peru")]
        PE,
        /// <summary>
        /// Philippines
        /// </summary>
        [Description("Philippines")]
        [TypeaheadToken("Philippines")]
        PH,
        /// <summary>
        /// Pitcairn
        /// </summary>
        [Description("Pitcairn")]
        [TypeaheadToken("Pitcairn")]
        PN,
        /// <summary>
        /// Poland
        /// </summary>
        [Description("Poland")]
        [TypeaheadToken("Poland")]
        PL,
        /// <summary>
        /// Portugal
        /// </summary>
        [Description("Portugal")]
        [TypeaheadToken("Portugal")]
        PT,
        /// <summary>
        /// Puerto Rico
        /// </summary>
        [Description("Puerto Rico")]
        [TypeaheadToken("Puerto")]
        [TypeaheadToken("Rico")]
        PR,
        /// <summary>
        /// Qatar
        /// </summary>
        [Description("Qatar")]
        [TypeaheadToken("Qatar")]
        QA,
        /// <summary>
        /// Réunion
        /// </summary>
        [Description("Réunion")]
        [TypeaheadToken("Réunion")]
        [TypeaheadToken("Reunion")]
        [TypeaheadToken("Ile")]
        RE,
        /// <summary>
        /// Romania
        /// </summary>
        [Description("Romania")]
        [TypeaheadToken("Romania")]
        RO,
        /// <summary>
        /// Russian Federation
        /// </summary>
        [Description("Russian Federation")]
        [TypeaheadToken("Russian")]
        [TypeaheadToken("Federation")]
        [TypeaheadToken("Russia")]
        [TypeaheadToken("Rossiya")]
        RU,
        /// <summary>
        /// Rwanda
        /// </summary>
        [Description("Rwanda")]
        [TypeaheadToken("Rwanda")]
        RW,
        /// <summary>
        /// Saint Barthélemy
        /// </summary>
        [Description("Saint Barthélemy")]
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
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Helena")]
        SH,
        /// <summary>
        /// Saint Kitts And Nevis
        /// </summary>
        [Description("Saint Kitts And Nevis")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Kitts")]
        [TypeaheadToken("Nevis")]
        KN,
        /// <summary>
        /// Saint Lucia
        /// </summary>
        [Description("Saint Lucia")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Lucia")]
        LC,
        /// <summary>
        /// Saint Martin
        /// </summary>
        [Description("Saint Martin")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Martin")]
        MF,
        /// <summary>
        /// Saint Pierre And Miquelon
        /// </summary>
        [Description("Saint Pierre And Miquelon")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Pierre")]
        [TypeaheadToken("Miquelon")]
        PM,
        /// <summary>
        /// Saint Vincent And The Grenadines
        /// </summary>
        [Description("Saint Vincent And The Grenadines")]
        [TypeaheadToken("Saint")]
        [TypeaheadToken("Vincent")]
        [TypeaheadToken("Grenadines")]
        VC,
        /// <summary>
        /// Samoa
        /// </summary>
        [Description("Samoa")]
        [TypeaheadToken("Samoa")]
        WS,
        /// <summary>
        /// San Marino
        /// </summary>
        [Description("San Marino")]
        [TypeaheadToken("San")]
        [TypeaheadToken("Marino")]
        SM,
        /// <summary>
        /// Sao Tome And Principe
        /// </summary>
        [Description("Sao Tome And Principe")]
        [TypeaheadToken("Sao")]
        [TypeaheadToken("Tome")]
        [TypeaheadToken("Principe")]
        ST,
        /// <summary>
        /// Saudi Arabia
        /// </summary>
        [Description("Saudi Arabia")]
        [TypeaheadToken("Saudi")]
        [TypeaheadToken("Arabia")]
        SA,
        /// <summary>
        /// Senegal
        /// </summary>
        [Description("Senegal")]
        [TypeaheadToken("Senegal")]
        SN,
        /// <summary>
        /// Serbia
        /// </summary>
        [Description("Serbia")]
        [TypeaheadToken("Serbia")]
        RS,
        /// <summary>
        /// Seychelles
        /// </summary>
        [Description("Seychelles")]
        [TypeaheadToken("Seychelles")]
        SC,
        /// <summary>
        /// Sierra Leone
        /// </summary>
        [Description("Sierra Leone")]
        [TypeaheadToken("Sierra")]
        [TypeaheadToken("Leone")]
        SL,
        /// <summary>
        /// Singapore
        /// </summary>
        [Description("Singapore")]
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
        [TypeaheadToken("Slovenia")]
        SI,
        /// <summary>
        /// Solomon Islands
        /// </summary>
        [Description("Solomon Islands")]
        [TypeaheadToken("Solomon")]
        [TypeaheadToken("Islands")]
        SB,
        /// <summary>
        /// Somalia
        /// </summary>
        [Description("Somalia")]
        [TypeaheadToken("Somalia")]
        SO,
        /// <summary>
        /// South Africa
        /// </summary>
        [Description("South Africa")]
        [TypeaheadToken("South")]
        [TypeaheadToken("Africa")]
        ZA,
        /// <summary>
        /// South Georgia And The South Sandwich Islands
        /// </summary>
        [Description("South Georgia And The South Sandwich Islands")]
        [TypeaheadToken("South")]
        [TypeaheadToken("Georgia")]
        [TypeaheadToken("Sandwich")]
        [TypeaheadToken("Islands")]
        GS,
        /// <summary>
        /// Spain
        /// </summary>
        [Description("Spain")]
        [TypeaheadToken("Spain")]
        [TypeaheadToken("España")]
        [TypeaheadToken("Espana")]
        ES,
        /// <summary>
        /// Sri Lanka
        /// </summary>
        [Description("Sri Lanka")]
        [TypeaheadToken("Sri")]
        [TypeaheadToken("Lanka")]
        LK,
        /// <summary>
        /// Sudan
        /// </summary>
        [Description("Sudan")]
        [TypeaheadToken("Sudan")]
        SD,
        /// <summary>
        /// Suriname
        /// </summary>
        [Description("Suriname")]
        [TypeaheadToken("Suriname")]
        SR,
        /// <summary>
        /// Svalbard And Jan Mayen
        /// </summary>
        [Description("Svalbard And Jan Mayen")]
        [TypeaheadToken("Svalbard")]
        [TypeaheadToken("Jan")]
        [TypeaheadToken("Mayen")]
        SJ,
        /// <summary>
        /// Swaziland
        /// </summary>
        [Description("Swaziland")]
        [TypeaheadToken("Swaziland")]
        SZ,
        /// <summary>
        /// Sweden
        /// </summary>
        [Description("Sweden")]
        [TypeaheadToken("Sweden")]
        [TypeaheadToken("Sverige")]
        SE,
        /// <summary>
        /// Switzerland
        /// </summary>
        [Description("Switzerland")]
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
        [TypeaheadToken("Syrian")]
        [TypeaheadToken("Arab")]
        [TypeaheadToken("Republic")]
        [TypeaheadToken("Syria")]
        SY,
        /// <summary>
        /// Taiwan, Province Of China
        /// </summary>
        [Description("Taiwan, Province Of China")]
        [TypeaheadToken("Taiwan")]
        [TypeaheadToken("Province")]
        [TypeaheadToken("China")]
        TW,
        /// <summary>
        /// Tajikistan
        /// </summary>
        [Description("Tajikistan")]
        [TypeaheadToken("Tajikistan")]
        TJ,
        /// <summary>
        /// Tanzania, United Republic Of
        /// </summary>
        [Description("Tanzania, United Republic Of")]
        [TypeaheadToken("Tanzania")]
        [TypeaheadToken("United")]
        [TypeaheadToken("Republic")]
        TZ,
        /// <summary>
        /// Thailand
        /// </summary>
        [Description("Thailand")]
        [TypeaheadToken("Thailand")]
        TH,
        /// <summary>
        /// Timor-Leste, East Timor
        /// </summary>
        [Description("Timor-Leste, East Timor")]
        [TypeaheadToken("Timor")]
        [TypeaheadToken("Leste")]
        [TypeaheadToken("East")]
        TL,
        /// <summary>
        /// Togo
        /// </summary>
        [Description("Togo")]
        [TypeaheadToken("Togo")]
        TG,
        /// <summary>
        /// Tokelau
        /// </summary>
        [Description("Tokelau")]
        [TypeaheadToken("Tokelau")]
        TK,
        /// <summary>
        /// Tonga
        /// </summary>
        [Description("Tonga")]
        [TypeaheadToken("Tonga")]
        TO,
        /// <summary>
        /// Trinidad And Tobago
        /// </summary>
        [Description("Trinidad And Tobago")]
        [TypeaheadToken("Trinidad")]
        [TypeaheadToken("Tobago")]
        TT,
        /// <summary>
        /// Tunisia
        /// </summary>
        [Description("Tunisia")]
        [TypeaheadToken("Tunisia")]
        TN,
        /// <summary>
        /// Turkey
        /// </summary>
        [Description("Turkey")]
        [TypeaheadToken("Turkey")]
        [TypeaheadToken("Türkiye")]
        [TypeaheadToken("Turkiye")]
        TR,
        /// <summary>
        /// Turkmenistan
        /// </summary>
        [Description("Turkmenistan")]
        [TypeaheadToken("Turkmenistan")]
        TM,
        /// <summary>
        /// Turks And Caicos Islands
        /// </summary>
        [Description("Turks And Caicos Islands")]
        [TypeaheadToken("Turks")]
        [TypeaheadToken("Caicos")]
        [TypeaheadToken("Islands")]
        TC,
        /// <summary>
        /// Tuvalu
        /// </summary>
        [Description("Tuvalu")]
        [TypeaheadToken("Tuvalu")]
        TV,
        /// <summary>
        /// Uganda
        /// </summary>
        [Description("Uganda")]
        [TypeaheadToken("Uganda")]
        UG,
        /// <summary>
        /// Ukraine
        /// </summary>
        [Description("Ukraine")]
        [TypeaheadToken("Ukraine")]
        [TypeaheadToken("Ukrayina")]
        UA,
        /// <summary>
        /// United Arab Emirates
        /// </summary>
        [Description("United Arab Emirates")]
        [TypeaheadToken("United")]
        [TypeaheadToken("Arab")]
        [TypeaheadToken("Emirates")]
        AE,
        /// <summary>
        /// United Kingdom
        /// </summary>
        [Description("United Kingdom")]
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
        [TypeaheadToken("USA")]
        [TypeaheadToken("United")]
        [TypeaheadToken("States")]
        [TypeaheadToken("America")]
        US,
        /// <summary>
        /// United States Minor Outlying Islands
        /// </summary>
        [Description("United States Minor Outlying Islands")]
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
        [TypeaheadToken("Uruguay")]
        UY,
        /// <summary>
        /// Uzbekistan
        /// </summary>
        [Description("Uzbekistan")]
        [TypeaheadToken("Uzbekistan")]
        UZ,
        /// <summary>
        /// Vanuatu
        /// </summary>
        [Description("Vanuatu")]
        [TypeaheadToken("Vanuatu")]
        VU,
        /// <summary>
        /// Venezuela
        /// </summary>
        [Description("Venezuela")]
        [TypeaheadToken("Venezuela")]
        VE,
        /// <summary>
        /// Vietnam
        /// </summary>
        [Description("Vietnam")]
        [TypeaheadToken("Vietnam")]
        VN,
        /// <summary>
        /// Virgin Islands, British
        /// </summary>
        [Description("Virgin Islands, British")]
        [TypeaheadToken("Virgin")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("British")]
        VG,
        /// <summary>
        /// Virgin Islands, U.S.
        /// </summary>
        [Description("Virgin Islands, U.S.")]
        [TypeaheadToken("Virgin")]
        [TypeaheadToken("Islands")]
        [TypeaheadToken("U.S.")]
        [TypeaheadToken("US")]
        VI,
        /// <summary>
        /// Wallis And Futuna
        /// </summary>
        [Description("Wallis And Futuna")]
        [TypeaheadToken("Wallis")]
        [TypeaheadToken("Futuna")]
        WF,
        /// <summary>
        /// Western Sahara
        /// </summary>
        [Description("Western Sahara")]
        [TypeaheadToken("Western")]
        [TypeaheadToken("Sahara")]
        EH,
        /// <summary>
        /// Yemen
        /// </summary>
        [Description("Yemen")]
        [TypeaheadToken("Yemen")]
        YE,
        /// <summary>
        /// Zambia
        /// </summary>
        [Description("Zambia")]
        [TypeaheadToken("Zambia")]
        ZM,
        /// <summary>
        /// Zimbabwe
        /// </summary>
        [Description("Zimbabwe")]
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
        [TypeaheadToken("South")]
        [TypeaheadToken("Sudan")]
        [TypeaheadToken("Southern")]
        [TypeaheadToken("Republic")]
        SS,
        /// <summary>
        /// Curaçao
        /// </summary>
        [Description("Curaçao")]
        [TypeaheadToken("Curaçao")]
        [TypeaheadToken("Curacao")]
        CW,
        /// <summary>
        /// Sint Maarten
        /// </summary>
        [Description("Sint Maarten")]
        [TypeaheadToken("Sint")]
        [TypeaheadToken("Maarten")]
        [TypeaheadToken("Martin")]
        SX,
        // ReSharper restore InconsistentNaming
    }
}
