using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="CurrencyCode"/> enumeration.
    /// </summary>
    public static class CurrencyCodeExtensions
    {
        /// <summary>
        /// Finds the first currency code symbol in a string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static CurrencyCode? FindCurrencyCode(this string text)
        {
            var occurrences = new List<(int Index, CurrencyCode Code)>();

            foreach (CurrencyCode code in Enum.GetValues(typeof(CurrencyCode)))
            {
                var symbol = code.ToSymbol();

                if (!string.IsNullOrEmpty(symbol))
                {
                    var index = text.IndexOf(symbol);

                    if (index > -1)
                    {
                        occurrences.Add((index, code));
                    }
                }
            }

            return occurrences.Any()
                       ? occurrences.OrderBy(o => o.Index)
                                    .Select(o => o.Code)
                                    .FirstOrDefault()
                       : (CurrencyCode?) null;
        }

        /// <summary>
        /// Convert this <see cref="CurrencyCode" /> to a symbol.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string ToSymbol(this CurrencyCode code)
        {
            switch (code)
            { 
                case CurrencyCode.AED: return "د.إ";
                case CurrencyCode.ARS: return "$";
                case CurrencyCode.AUD: return "$";
                case CurrencyCode.BDT: return "৳";
                case CurrencyCode.BOB: return "Bs";
                case CurrencyCode.BGN: return "лв";
                case CurrencyCode.BRL: return "R$";
                case CurrencyCode.CAD: return "$";
                case CurrencyCode.CHF: return "CHF";
                case CurrencyCode.CLP: return "$";
                case CurrencyCode.CNY: return "¥";
                case CurrencyCode.COP: return "$";
                case CurrencyCode.CUP: return "$";
                case CurrencyCode.CRC: return "₡";
                case CurrencyCode.CZK: return "¤";
                case CurrencyCode.DKK: return "kr";
                case CurrencyCode.DOP: return "RD$";
                case CurrencyCode.EEK: return "¤";
                case CurrencyCode.EGP: return "E£";
                case CurrencyCode.EUR: return "€";
                case CurrencyCode.GBP: return "£";
                case CurrencyCode.GTQ: return "Q";
                case CurrencyCode.HKD: return "$";
                case CurrencyCode.HNL: return "L";
                case CurrencyCode.HRK: return "kn";
                case CurrencyCode.HUF: return "Ft";
                case CurrencyCode.IDR: return "Rp";
                case CurrencyCode.ILS: return "₪";
                case CurrencyCode.INR: return "₹";
                case CurrencyCode.JOD: return "د.ا";
                case CurrencyCode.JPY: return "¥";
                case CurrencyCode.KRW: return "₩";
                case CurrencyCode.LBP: return "ل.ل";
                case CurrencyCode.LTL: return "Lt";
                case CurrencyCode.LKR: return "Rs";
                case CurrencyCode.LVL: return "Ls";
                case CurrencyCode.MXN: return "$";
                case CurrencyCode.MYR: return "RM";
                case CurrencyCode.NIO: return "C$";
                case CurrencyCode.NOK: return "kr";
                case CurrencyCode.NPR: return "Rs";
                case CurrencyCode.NZD: return "$";
                case CurrencyCode.PAB: return "B/.";
                case CurrencyCode.PEN: return "S/.";
                case CurrencyCode.PHP: return "Php";
                case CurrencyCode.PLN: return "zł";
                case CurrencyCode.PYG: return "₲";
                case CurrencyCode.RON: return "lei";
                case CurrencyCode.RUB: return "руб";
                case CurrencyCode.SAR: return "﷼";
                case CurrencyCode.SEK: return "kr";
                case CurrencyCode.SGD: return "$";
                case CurrencyCode.THB: return "฿";
                case CurrencyCode.TRY: return "TL";
                case CurrencyCode.TWD: return "NT$";
                case CurrencyCode.USD: return "$";
                case CurrencyCode.XCD: return "$";
                case CurrencyCode.UYU: return "$U";
                case CurrencyCode.VEF:
                case CurrencyCode.VEF_BLKMKT:
                case CurrencyCode.VEF_DICOM:
                case CurrencyCode.VES: return "Bs";
                case CurrencyCode.ZAR: return "R";
                case CurrencyCode.UAH: return "₴";
                case CurrencyCode.VND: return "₫";
                case CurrencyCode.MNT: return "₮";
                case CurrencyCode.MAD: return "DH";
                case CurrencyCode.BAM: return "KM";
                case CurrencyCode.UZS: return "у.е.";
                case CurrencyCode.KZT: return "KZ";
                case CurrencyCode.TTD: return "$";
                case CurrencyCode.KHR: return "\u17db";
                case CurrencyCode.XOF: return "F.CFA";
                case CurrencyCode.DZD: return "د.ج";
                case CurrencyCode.NGN: return "₦";
                case CurrencyCode.KWD: return "د.ك";
                case CurrencyCode.AFN: return "؋";
                case CurrencyCode.ALL: return "L";
                case CurrencyCode.AMD: return "֏";
                case CurrencyCode.ANG: return "ƒ";
                case CurrencyCode.AOA: return "Kz";
                case CurrencyCode.AWG: return "ƒ";
                case CurrencyCode.AZN: return "₼";
                case CurrencyCode.BBD: return "$";
                case CurrencyCode.BHD: return "ب.د";
                case CurrencyCode.BMD: return "$";
                case CurrencyCode.BND: return "$";
                case CurrencyCode.BSD: return "$";
                case CurrencyCode.BWP: return "P";
                case CurrencyCode.BYN: return "Br";
                case CurrencyCode.BZD: return "$";
                case CurrencyCode.CDF: return "FC";
                case CurrencyCode.CVE: return "$";
                case CurrencyCode.DJF: return "Fdj";
                case CurrencyCode.ERN: return "Nfk";
                case CurrencyCode.ETB: return "Br";
                case CurrencyCode.FJD: return "$";
                case CurrencyCode.FKP: return "£";
                case CurrencyCode.GEL: return "₾";
                case CurrencyCode.GHS: return "₵";
                case CurrencyCode.GIP: return "£";
                case CurrencyCode.GNF: return "FG";
                case CurrencyCode.GYD: return "$";
                case CurrencyCode.HTG: return "G";
                case CurrencyCode.IQD: return "ع.د";
                case CurrencyCode.IRR: return "﷼";
                case CurrencyCode.ISK: return "kr";
                case CurrencyCode.JMD: return "$";
                case CurrencyCode.KES: return "KSh";
                case CurrencyCode.KGS: return "с";
                case CurrencyCode.KMF: return "CF";
                case CurrencyCode.KPW: return "₩";
                case CurrencyCode.KYD: return "$";
                case CurrencyCode.LAK: return "₭";
                case CurrencyCode.LRD: return "$";
                case CurrencyCode.LSL: return "L";
                case CurrencyCode.LYD: return "ل.د";
                case CurrencyCode.MGA: return "Ar";
                case CurrencyCode.MKD: return "ден";
                case CurrencyCode.MMK: return "K";
                case CurrencyCode.MOP: return "P";
                case CurrencyCode.MRU: return "UM";
                case CurrencyCode.MUR: return "₨";
                case CurrencyCode.MVR: return "ރ";
                case CurrencyCode.MWK: return "MK";
                case CurrencyCode.MZN: return "MT";
                case CurrencyCode.NAD: return "$";
                case CurrencyCode.OMR: return "﷼";
                case CurrencyCode.PGK: return "K";
                case CurrencyCode.PKR: return "₨";
                case CurrencyCode.QAR: return "﷼";
                case CurrencyCode.RWF: return "₣";
                case CurrencyCode.SBD: return "$";
                case CurrencyCode.SCR: return "₨";
                case CurrencyCode.SDG: return "ج.س.";
                case CurrencyCode.SLL: return "Le";
                case CurrencyCode.SOS: return "Sh";
                case CurrencyCode.SSP: return "£";
                case CurrencyCode.SYP: return "£";
                case CurrencyCode.SZL: return "L";
                case CurrencyCode.TJS: return "SM";
                case CurrencyCode.TMT: return "T";
                case CurrencyCode.TND: return "د.ت";
                case CurrencyCode.TOP: return "T$";
                case CurrencyCode.TZS: return "Sh";
                case CurrencyCode.UGX: return "Sh";
                case CurrencyCode.VUV: return "Vt";
                case CurrencyCode.XAF: return "FCFA";
                case CurrencyCode.XPF: return "Fr";
                case CurrencyCode.YER: return "﷼";
                case CurrencyCode.ZMW: return "ZK";
                case CurrencyCode.ZWL: return "$";
            }

            throw new ApplicationException($"Unknown currency: {code}");
        }

        /// <summary>
        /// Convert this <see cref="CurrencyCode" /> to a HTML symbol.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string ToHtmlSymbol(this CurrencyCode code)
        {
            switch (code)
            {
                case CurrencyCode.AED: return "&#x62f;&#x2e;&#x625;";
                case CurrencyCode.ARS: return "&#36; ";
                case CurrencyCode.AUD: return "&#36; ";
                case CurrencyCode.BDT: return "&#2547; ";
                case CurrencyCode.BOB: return "Bs ";
                case CurrencyCode.BGN: return "&#1083;&#1074; ";
                case CurrencyCode.BRL: return "&#82;&#36; ";
                case CurrencyCode.CAD: return "&#36; ";
                case CurrencyCode.CHF: return "CHF ";
                case CurrencyCode.COP: return "&#36; ";
                case CurrencyCode.CRC: return "&#8353; ";
                case CurrencyCode.CLP: return "&#36; ";
                case CurrencyCode.CNY: return "&#165; ";
                case CurrencyCode.CUP: return "&#36; ";
                case CurrencyCode.CZK: return "&#75;&#269; ";
                case CurrencyCode.DKK: return "kr ";
                case CurrencyCode.DOP: return "&#36; ";
                case CurrencyCode.EEK: return "&curren; ";
                case CurrencyCode.EGP: return "E&pound; ";
                case CurrencyCode.EUR: return "&#8364; ";
                case CurrencyCode.GBP: return "&#163; ";
                case CurrencyCode.GTQ: return "Q ";
                case CurrencyCode.HKD: return "&#36; ";
                case CurrencyCode.HNL: return "L ";
                case CurrencyCode.HRK: return "&#107;&#110; ";
                case CurrencyCode.HUF: return "&#70;&#116; ";
                case CurrencyCode.IDR: return "&#82;&#112; ";
                case CurrencyCode.ILS: return "&#8362; ";
                case CurrencyCode.INR: return "&#8377;";
                case CurrencyCode.JOD: return "JOD";
                case CurrencyCode.JPY: return "&#165; ";
                case CurrencyCode.KRW: return "&#8361; ";
                case CurrencyCode.LBP: return "&#163;";
                case CurrencyCode.LTL: return "Lt ";
                case CurrencyCode.LKR: return "Rs ";
                case CurrencyCode.LVL: return "Ls ";
                case CurrencyCode.MXN: return "&#36; ";
                case CurrencyCode.MYR: return "RM ";
                case CurrencyCode.NOK: return "kr ";
                case CurrencyCode.NIO: return "&#67;&#36; ";
                case CurrencyCode.NPR: return "Rs ";
                case CurrencyCode.NZD: return "&#36; ";
                case CurrencyCode.PAB: return "B/. ";
                case CurrencyCode.PEN: return "S/. ";
                case CurrencyCode.PHP: return "Php ";
                case CurrencyCode.PLN: return "&#122;&#322; ";
                case CurrencyCode.PYG: return "&#8370; ";
                case CurrencyCode.RON: return "&#108;&#101;&#105; ";
                case CurrencyCode.RUB: return "&#1088;&#1091;&#1073; ";
                case CurrencyCode.SAR: return "﷼ ";
                case CurrencyCode.SEK: return "kr ";
                case CurrencyCode.SGD: return "&#36; ";
                case CurrencyCode.THB: return "&#3647; ";
                case CurrencyCode.TRY: return "TL ";
                case CurrencyCode.TWD: return "&#78;&#84;&#36; ";
                case CurrencyCode.USD: return "&#36; ";
                case CurrencyCode.XCD: return "&#36; ";
                case CurrencyCode.UYU: return "&#36;&#85; ";
                case CurrencyCode.VEF:
                case CurrencyCode.VEF_DICOM:
                case CurrencyCode.VEF_BLKMKT:
                case CurrencyCode.VES: return "&#66;&#115; ";
                case CurrencyCode.ZAR: return "R ";
                case CurrencyCode.UAH: return "&#8372;";
                case CurrencyCode.VND: return "&#8363;";
                case CurrencyCode.MNT: return "&#8366;";
                case CurrencyCode.MAD: return "DH";
                case CurrencyCode.BAM: return "KM";
                case CurrencyCode.UZS: return "у.е.";
                case CurrencyCode.KZT: return "KZ";
                case CurrencyCode.TTD: return "&#36;";
                case CurrencyCode.KHR: return "&#6107;";
                case CurrencyCode.XOF: return "F.CFA";
                case CurrencyCode.DZD: return "د.ج";
                case CurrencyCode.NGN: return "&#8358;";
                case CurrencyCode.KWD: return "د.ك";
                case CurrencyCode.AFN: return "&#1547;";
                case CurrencyCode.ALL: return "L";
                case CurrencyCode.AMD: return "&#1423;";
                case CurrencyCode.ANG: return "&#402;";
                case CurrencyCode.AOA: return "Kz";
                case CurrencyCode.AWG: return "&#402;";
                case CurrencyCode.AZN: return "&#8380;";
                case CurrencyCode.BBD: return "&#36;";
                case CurrencyCode.BHD: return "ب.د";
                case CurrencyCode.BMD: return "&#36;";
                case CurrencyCode.BND: return "&#36;";
                case CurrencyCode.BSD: return "&#36;";
                case CurrencyCode.BWP: return "P";
                case CurrencyCode.BYN: return "Br";
                case CurrencyCode.BZD: return "&#36;";
                case CurrencyCode.CDF: return "FC";
                case CurrencyCode.CVE: return "&#36;";
                case CurrencyCode.DJF: return "Fdj";
                case CurrencyCode.ERN: return "Nfk";
                case CurrencyCode.ETB: return "Br";
                case CurrencyCode.FJD: return "&#36;";
                case CurrencyCode.FKP: return "&#163;";
                case CurrencyCode.GEL: return "&#8382;";
                case CurrencyCode.GHS: return "&#8373;";
                case CurrencyCode.GIP: return "&#163;";
                case CurrencyCode.GNF: return "FG";
                case CurrencyCode.GYD: return "&#36;";
                case CurrencyCode.HTG: return "G";
                case CurrencyCode.IQD: return "ع.د";
                case CurrencyCode.IRR: return "&#65020;";
                case CurrencyCode.ISK: return "kr";
                case CurrencyCode.JMD: return "&#36;";
                case CurrencyCode.KES: return "KSh";
                case CurrencyCode.KGS: return "&#1089;";
                case CurrencyCode.KMF: return "CF";
                case CurrencyCode.KPW: return "&#8361;";
                case CurrencyCode.KYD: return "&#36;";
                case CurrencyCode.LAK: return "&#8365;";
                case CurrencyCode.LRD: return "&#36;";
                case CurrencyCode.LSL: return "L";
                case CurrencyCode.LYD: return "ل.د";
                case CurrencyCode.MGA: return "Ar";
                case CurrencyCode.MKD: return "&#1076;&#1077;&#1085;";
                case CurrencyCode.MMK: return "K";
                case CurrencyCode.MOP: return "P";
                case CurrencyCode.MRU: return "UM";
                case CurrencyCode.MUR: return "&#8360;";
                case CurrencyCode.MVR: return "ރ";
                case CurrencyCode.MWK: return "MK";
                case CurrencyCode.MZN: return "MT";
                case CurrencyCode.NAD: return "&#36;";
                case CurrencyCode.OMR: return "&#65020;";
                case CurrencyCode.PGK: return "K";
                case CurrencyCode.PKR: return "&#8360;";
                case CurrencyCode.QAR: return "&#65020;";
                case CurrencyCode.RWF: return "&#8355;";
                case CurrencyCode.SBD: return "&#36;";
                case CurrencyCode.SCR: return "&#8360;";
                case CurrencyCode.SDG: return "ج.س.";
                case CurrencyCode.SLL: return "Le";
                case CurrencyCode.SOS: return "Sh";
                case CurrencyCode.SSP: return "&#163;";
                case CurrencyCode.SYP: return "&#163;";
                case CurrencyCode.SZL: return "L";
                case CurrencyCode.TJS: return "SM";
                case CurrencyCode.TMT: return "T";
                case CurrencyCode.TND: return "د.ت";
                case CurrencyCode.TOP: return "T&#36;";
                case CurrencyCode.TZS: return "Sh";
                case CurrencyCode.UGX: return "Sh";
                case CurrencyCode.VUV: return "Vt";
                case CurrencyCode.XAF: return "FCFA";
                case CurrencyCode.XPF: return "Fr";
                case CurrencyCode.YER: return "&#65020;";
                case CurrencyCode.ZMW: return "ZK";
                case CurrencyCode.ZWL: return "&#36;";
            }

            throw new ApplicationException($"Unknown currency / HTML code: {code}");
        }

        /// <summary>
        /// Convert symbol to <see cref="CurrencyCode" />.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns></returns>
        public static CurrencyCode ToCurrencyCode(this string symbol)
        {
            switch (symbol)
            {
                case "د.إ": return CurrencyCode.AED;
                case "৳": return CurrencyCode.BDT;
                case "лв": return CurrencyCode.BGN;
                case "R$": return CurrencyCode.BRL;
                case "Fr.": return CurrencyCode.CHF;
                case "₡": return CurrencyCode.CRC;
                case "¤": return CurrencyCode.CZK;
                case "RD$": return CurrencyCode.DOP;
                case "E£": return CurrencyCode.EGP;
                case "€": return CurrencyCode.EUR;
                case "£": return CurrencyCode.GBP;
                case "Q": return CurrencyCode.GTQ;
                case "L": return CurrencyCode.HNL;
                case "kn": return CurrencyCode.HRK;
                case "Ft": return CurrencyCode.HUF;
                case "₹": return CurrencyCode.INR;
                case "₪": return CurrencyCode.ILS;
                case "Rp": return CurrencyCode.IDR;
                case "د.ا": return CurrencyCode.JOD;
                case "¥": return CurrencyCode.JPY;
                case "₩": return CurrencyCode.KRW;
                case "ل.ل": return CurrencyCode.LBP;
                case "Lt": return CurrencyCode.LTL;
                case "Ls": return CurrencyCode.LVL;
                case "RM": return CurrencyCode.MYR;
                case "C$": return CurrencyCode.NIO;
                case "B/.": return CurrencyCode.PAB;
                case "S/.": return CurrencyCode.PEN;
                case "Php": return CurrencyCode.PHP;
                case "zł": return CurrencyCode.PLN;
                case "₲": return CurrencyCode.PYG;
                case "lei": return CurrencyCode.RON;
                case "руб": return CurrencyCode.RUB;
                case "﷼": return CurrencyCode.SAR;
                case "kr": return CurrencyCode.SEK;
                case "฿": return CurrencyCode.THB;
                case "TL": return CurrencyCode.TRY;
                case "NT$": return CurrencyCode.TWD;
                case "$": return CurrencyCode.USD;
                case "$U": return CurrencyCode.UYU;
                case "Bs": return CurrencyCode.VEF_DICOM;
                case "R": return CurrencyCode.ZAR;
                case "₴": return CurrencyCode.UAH;
                case "₫": return CurrencyCode.VND;
                case "₮": return CurrencyCode.MNT;
                case "KM": return CurrencyCode.BAM;
                case "y.e.": return CurrencyCode.UZS;
                case "KZ": return CurrencyCode.KZT;
                case "TT$": return CurrencyCode.TTD;
                case "\u17db": return CurrencyCode.KHR;
                case "F.CFA": return CurrencyCode.XOF;
                case "د.ج": return CurrencyCode.DZD;
                case "₦": return CurrencyCode.NGN;
                case "د.ك": return CurrencyCode.KWD;
            }

            var success = Enum.TryParse(symbol, true, out CurrencyCode currency);

            if (success)
            {
                return currency;
            }

            throw new ApplicationException($"Unknown currency symbol: {symbol}");
        }

        /// <summary>
        /// Converts a country code to a currency.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">country - Could not convert country code to currency code</exception>
        /// <remarks>
        /// https://gist.github.com/HarishChaudhari/4680482#file-country-code-to-currency-code-mapping-csv
        /// </remarks>
        public static CurrencyCode ToCurrencyCode(this CountryCode country)
        {
            switch (country)
            {
                case CountryCode.AD: return CurrencyCode.EUR;
                case CountryCode.AS: return CurrencyCode.EUR;
                case CountryCode.AT: return CurrencyCode.EUR;
                case CountryCode.AU: return CurrencyCode.AUD;
                case CountryCode.BD: return CurrencyCode.BDT;
                case CountryCode.BE: return CurrencyCode.EUR;
                case CountryCode.CC: return CurrencyCode.AUD;
                case CountryCode.CK: return CurrencyCode.NZD;
                case CountryCode.CX: return CurrencyCode.AUD;
                case CountryCode.DE: return CurrencyCode.EUR;
                case CountryCode.FI: return CurrencyCode.EUR;
                case CountryCode.FR: return CurrencyCode.EUR;
                case CountryCode.GF: return CurrencyCode.EUR;
                case CountryCode.GP: return CurrencyCode.EUR;
                case CountryCode.GR: return CurrencyCode.EUR;
                case CountryCode.HM: return CurrencyCode.AUD;
                case CountryCode.KI: return CurrencyCode.AUD;
                case CountryCode.NF: return CurrencyCode.AUD;
                case CountryCode.NR: return CurrencyCode.AUD;
                case CountryCode.NU: return CurrencyCode.NZD;
                case CountryCode.NZ: return CurrencyCode.NZD;
                case CountryCode.PN: return CurrencyCode.NZD;
                case CountryCode.TK: return CurrencyCode.NZD;
                case CountryCode.TV: return CurrencyCode.AUD;
                case CountryCode.TF: return CurrencyCode.EUR;
                case CountryCode.IE: return CurrencyCode.EUR;
                case CountryCode.IT: return CurrencyCode.EUR;
                case CountryCode.LU: return CurrencyCode.EUR;
                case CountryCode.MQ: return CurrencyCode.EUR;
                case CountryCode.YT: return CurrencyCode.EUR;
                case CountryCode.MC: return CurrencyCode.EUR;
                case CountryCode.NL: return CurrencyCode.EUR;
                case CountryCode.PT: return CurrencyCode.EUR;
                case CountryCode.RE: return CurrencyCode.EUR;
                case CountryCode.WS: return CurrencyCode.EUR;
                case CountryCode.SM: return CurrencyCode.EUR;
                case CountryCode.SI: return CurrencyCode.EUR;
                case CountryCode.ES: return CurrencyCode.EUR;
                case CountryCode.VA: return CurrencyCode.EUR;
                case CountryCode.GS: return CurrencyCode.GBP;
                case CountryCode.GB: return CurrencyCode.GBP;
                case CountryCode.JE: return CurrencyCode.GBP;
                case CountryCode.IO: return CurrencyCode.USD;
                case CountryCode.GU: return CurrencyCode.USD;
                case CountryCode.MH: return CurrencyCode.USD;
                case CountryCode.FM: return CurrencyCode.USD;
                case CountryCode.MP: return CurrencyCode.USD;
                case CountryCode.PW: return CurrencyCode.USD;
                case CountryCode.PR: return CurrencyCode.USD;
                case CountryCode.TC: return CurrencyCode.USD;
                case CountryCode.US: return CurrencyCode.USD;
                case CountryCode.UM: return CurrencyCode.USD;
                case CountryCode.VG: return CurrencyCode.USD;
                case CountryCode.VI: return CurrencyCode.USD;
                case CountryCode.HK: return CurrencyCode.HKD;
                case CountryCode.CA: return CurrencyCode.CAD;
                case CountryCode.JP: return CurrencyCode.JPY;
                case CountryCode.AR: return CurrencyCode.ARS;
                case CountryCode.BT: return CurrencyCode.INR;
                case CountryCode.IN: return CurrencyCode.INR;
                case CountryCode.BV: return CurrencyCode.NOK;
                case CountryCode.NO: return CurrencyCode.NOK;
                case CountryCode.SJ: return CurrencyCode.NOK;
                case CountryCode.BR: return CurrencyCode.BRL;
                case CountryCode.BG: return CurrencyCode.BGN;
                case CountryCode.CL: return CurrencyCode.CLP;
                case CountryCode.CN: return CurrencyCode.CNY;
                case CountryCode.CO: return CurrencyCode.COP;
                case CountryCode.CR: return CurrencyCode.CRC;
                case CountryCode.HR: return CurrencyCode.HRK;
                case CountryCode.CZ: return CurrencyCode.CZK;
                case CountryCode.DK: return CurrencyCode.DKK;
                case CountryCode.FO: return CurrencyCode.DKK;
                case CountryCode.GL: return CurrencyCode.DKK;
                case CountryCode.DO: return CurrencyCode.DOP;
                case CountryCode.TL: return CurrencyCode.IDR;
                case CountryCode.ID: return CurrencyCode.IDR;
                case CountryCode.EE: return CurrencyCode.EEK;
                case CountryCode.HU: return CurrencyCode.HUF;
                case CountryCode.KR: return CurrencyCode.KRW;
                case CountryCode.LV: return CurrencyCode.LVL;
                case CountryCode.LI: return CurrencyCode.CHF;
                case CountryCode.CH: return CurrencyCode.CHF;
                case CountryCode.LT: return CurrencyCode.LTL;
                case CountryCode.MY: return CurrencyCode.MYR;
                case CountryCode.MX: return CurrencyCode.MXN;
                case CountryCode.PA: return CurrencyCode.PAB;
                case CountryCode.PE: return CurrencyCode.PEN;
                case CountryCode.PH: return CurrencyCode.PHP;
                case CountryCode.PL: return CurrencyCode.PLN;
                case CountryCode.RO: return CurrencyCode.RON;
                case CountryCode.RU: return CurrencyCode.RUB;
                case CountryCode.SG: return CurrencyCode.SGD;
                case CountryCode.ZA: return CurrencyCode.ZAR;
                case CountryCode.SE: return CurrencyCode.SEK;
                case CountryCode.TW: return CurrencyCode.TWD;
                case CountryCode.TH: return CurrencyCode.THB;
                case CountryCode.TR: return CurrencyCode.TRY;
                case CountryCode.UA: return CurrencyCode.UAH;
                case CountryCode.UY: return CurrencyCode.UYU;
                case CountryCode.VE: return CurrencyCode.VEF_DICOM;
                case CountryCode.AX: return CurrencyCode.EUR;
                case CountryCode.IM: return CurrencyCode.GBP;
                case CountryCode.ME: return CurrencyCode.EUR;
                case CountryCode.BL: return CurrencyCode.EUR;
                case CountryCode.SH: return CurrencyCode.GBP;
                case CountryCode.PM: return CurrencyCode.EUR;
                case CountryCode.LB: return CurrencyCode.LBP;
                case CountryCode.EG: return CurrencyCode.EGP;
                case CountryCode.JO: return CurrencyCode.JOD;
                case CountryCode.AE: return CurrencyCode.AED;
                case CountryCode.VN: return CurrencyCode.VND;
                case CountryCode.SA: return CurrencyCode.SAR;
                case CountryCode.LK: return CurrencyCode.LKR;
                case CountryCode.NP: return CurrencyCode.NPR;
                case CountryCode.SK: return CurrencyCode.EUR;
                case CountryCode.CY: return CurrencyCode.EUR;
                case CountryCode.MN: return CurrencyCode.MNT;
                case CountryCode.VC: return CurrencyCode.XCD;
                case CountryCode.BO: return CurrencyCode.BOB;
                case CountryCode.GT: return CurrencyCode.GTQ;
                case CountryCode.HN: return CurrencyCode.HNL;
                case CountryCode.NI: return CurrencyCode.NIO;
                case CountryCode.PY: return CurrencyCode.PYG;
                case CountryCode.MA: return CurrencyCode.MAD;
                case CountryCode.CU: return CurrencyCode.CUP;
                case CountryCode.BA: return CurrencyCode.BAM;
                case CountryCode.UZ: return CurrencyCode.UZS;
                case CountryCode.KZ: return CurrencyCode.KZT; 
                case CountryCode.IL: return CurrencyCode.ILS;
                case CountryCode.CI: return CurrencyCode.XOF;
                case CountryCode.DZ: return CurrencyCode.DZD;
                case CountryCode.NG: return CurrencyCode.NGN;
                case CountryCode.KW: return CurrencyCode.KWD;
                case CountryCode.AF: return CurrencyCode.AFN;
                case CountryCode.AL: return CurrencyCode.ALL;
                case CountryCode.AM: return CurrencyCode.AMD;
                case CountryCode.AN: return CurrencyCode.ANG;
                case CountryCode.AO: return CurrencyCode.AOA;
                case CountryCode.AW: return CurrencyCode.AWG;
                case CountryCode.AZ: return CurrencyCode.AZN;
                case CountryCode.BB: return CurrencyCode.BBD;
                case CountryCode.BH: return CurrencyCode.BHD;
                case CountryCode.BM: return CurrencyCode.BMD;
                case CountryCode.BN: return CurrencyCode.BND;
                case CountryCode.BS: return CurrencyCode.BSD;
                case CountryCode.BW: return CurrencyCode.BWP;
                case CountryCode.BY: return CurrencyCode.BYN;
                case CountryCode.BZ: return CurrencyCode.BZD;
                case CountryCode.CD: return CurrencyCode.CDF;
                case CountryCode.CF: return CurrencyCode.XAF;
                case CountryCode.CG: return CurrencyCode.XAF;
                case CountryCode.CM: return CurrencyCode.XAF;
                case CountryCode.CV: return CurrencyCode.CVE;
                case CountryCode.CW: return CurrencyCode.ANG;
                case CountryCode.DJ: return CurrencyCode.DJF;
                case CountryCode.DM: return CurrencyCode.XCD;
                case CountryCode.EC: return CurrencyCode.USD;
                case CountryCode.EH: return CurrencyCode.MAD;
                case CountryCode.ER: return CurrencyCode.ERN;
                case CountryCode.ET: return CurrencyCode.ETB;
                case CountryCode.EU: return CurrencyCode.EUR;
                case CountryCode.FJ: return CurrencyCode.FJD;
                case CountryCode.FK: return CurrencyCode.FKP;
                case CountryCode.GA: return CurrencyCode.XAF;
                case CountryCode.GD: return CurrencyCode.XCD;
                case CountryCode.GE: return CurrencyCode.GEL;
                case CountryCode.GG: return CurrencyCode.GBP;
                case CountryCode.GH: return CurrencyCode.GHS;
                case CountryCode.GI: return CurrencyCode.GIP;
                case CountryCode.GN: return CurrencyCode.GNF;
                case CountryCode.GQ: return CurrencyCode.XAF;
                case CountryCode.GW: return CurrencyCode.XOF;
                case CountryCode.GY: return CurrencyCode.GYD;
                case CountryCode.HT: return CurrencyCode.HTG;
                case CountryCode.AG: return CurrencyCode.XCD;
                case CountryCode.AI: return CurrencyCode.XCD;
                case CountryCode.IQ: return CurrencyCode.IQD;
                case CountryCode.IR: return CurrencyCode.IRR;
                case CountryCode.IS: return CurrencyCode.ISK;
                case CountryCode.JM: return CurrencyCode.JMD;
                case CountryCode.KE: return CurrencyCode.KES;
                case CountryCode.KG: return CurrencyCode.KGS;
                case CountryCode.KM: return CurrencyCode.KMF;
                case CountryCode.KN: return CurrencyCode.XCD;
                case CountryCode.KP: return CurrencyCode.KPW;
                case CountryCode.KY: return CurrencyCode.KYD;
                case CountryCode.LA: return CurrencyCode.LAK;
                case CountryCode.LC: return CurrencyCode.XCD;
                case CountryCode.LR: return CurrencyCode.LRD;
                case CountryCode.LS: return CurrencyCode.LSL;
                case CountryCode.LY: return CurrencyCode.LYD;
                case CountryCode.MF: return CurrencyCode.EUR;
                case CountryCode.MG: return CurrencyCode.MGA;
                case CountryCode.MK: return CurrencyCode.MKD;
                case CountryCode.ML: return CurrencyCode.XOF;
                case CountryCode.MM: return CurrencyCode.MMK;
                case CountryCode.MO: return CurrencyCode.MOP;
                case CountryCode.MR: return CurrencyCode.MRU;
                case CountryCode.MS: return CurrencyCode.XCD;
                case CountryCode.MU: return CurrencyCode.MUR;
                case CountryCode.MV: return CurrencyCode.MVR;
                case CountryCode.MW: return CurrencyCode.MWK;
                case CountryCode.MZ: return CurrencyCode.MZN;
                case CountryCode.NA: return CurrencyCode.NAD;
                case CountryCode.NC: return CurrencyCode.XPF;
                case CountryCode.NE: return CurrencyCode.XOF;
                case CountryCode.OM: return CurrencyCode.OMR;
                case CountryCode.PF: return CurrencyCode.XPF;
                case CountryCode.PG: return CurrencyCode.PGK;
                case CountryCode.PK: return CurrencyCode.PKR;
                case CountryCode.PS: return CurrencyCode.ILS;
                case CountryCode.QA: return CurrencyCode.QAR;
                case CountryCode.RW: return CurrencyCode.RWF;
                case CountryCode.SB: return CurrencyCode.SBD;
                case CountryCode.SC: return CurrencyCode.SCR;
                case CountryCode.SD: return CurrencyCode.SDG;
                case CountryCode.SL: return CurrencyCode.SLL;
                case CountryCode.SN: return CurrencyCode.XOF;
                case CountryCode.SO: return CurrencyCode.SOS;
                case CountryCode.SS: return CurrencyCode.SSP;
                case CountryCode.SV: return CurrencyCode.USD;
                case CountryCode.SX: return CurrencyCode.ANG;
                case CountryCode.SY: return CurrencyCode.SYP;
                case CountryCode.SZ: return CurrencyCode.SZL;
                case CountryCode.TD: return CurrencyCode.XAF;
                case CountryCode.TG: return CurrencyCode.XOF;
                case CountryCode.TJ: return CurrencyCode.TJS;
                case CountryCode.TM: return CurrencyCode.TMT;
                case CountryCode.TN: return CurrencyCode.TND;
                case CountryCode.TO: return CurrencyCode.TOP;
                case CountryCode.TT: return CurrencyCode.TTD;
                case CountryCode.TZ: return CurrencyCode.TZS;
                case CountryCode.UG: return CurrencyCode.UGX;
                case CountryCode.VU: return CurrencyCode.VUV;
                case CountryCode.WF: return CurrencyCode.XPF;
                case CountryCode.YE: return CurrencyCode.YER;
                case CountryCode.ZM: return CurrencyCode.ZMW;
                case CountryCode.ZW: return CurrencyCode.ZWL;
                case CountryCode.BJ: return CurrencyCode.XOF;

                default:
                    throw new ArgumentOutOfRangeException(nameof(country), country, "Could not convert country code to currency code");
            }
        }

        /// <summary>
        /// Returns the country that this currency is issued by.
        /// </summary>
        /// <returns></returns>
        public static CountryCode ToCountryCode(this CurrencyCode code)
        {
            switch (code)
            {
                case CurrencyCode.AED: return CountryCode.AE;
                case CurrencyCode.AUD: return CountryCode.AU;
                case CurrencyCode.BDT: return CountryCode.BD;
                case CurrencyCode.BOB: return CountryCode.BO;
                case CurrencyCode.BGN: return CountryCode.BG;
                case CurrencyCode.BRL: return CountryCode.BR;
                case CurrencyCode.CAD: return CountryCode.CA;
                case CurrencyCode.CHF: return CountryCode.CH;
                case CurrencyCode.CNY: return CountryCode.CN;
                case CurrencyCode.CZK: return CountryCode.CZ;
                case CurrencyCode.DKK: return CountryCode.DK;
                case CurrencyCode.EEK: return CountryCode.EE;
                case CurrencyCode.EGP: return CountryCode.EG;
                case CurrencyCode.EUR: return CountryCode.EU;
                case CurrencyCode.GBP: return CountryCode.GB;
                case CurrencyCode.GTQ: return CountryCode.GT;
                case CurrencyCode.HKD: return CountryCode.HK;
                case CurrencyCode.HNL: return CountryCode.HN;
                case CurrencyCode.HRK: return CountryCode.HR;
                case CurrencyCode.HUF: return CountryCode.HU;
                case CurrencyCode.IDR: return CountryCode.ID;
                case CurrencyCode.ILS: return CountryCode.IL;
                case CurrencyCode.INR: return CountryCode.IN;
                case CurrencyCode.JOD: return CountryCode.JO;
                case CurrencyCode.JPY: return CountryCode.JP;
                case CurrencyCode.KRW: return CountryCode.KR;
                case CurrencyCode.LBP: return CountryCode.LB;
                case CurrencyCode.LTL: return CountryCode.LT;
                case CurrencyCode.LKR: return CountryCode.LK;
                case CurrencyCode.LVL: return CountryCode.LV;
                case CurrencyCode.MXN: return CountryCode.MX;
                case CurrencyCode.MYR: return CountryCode.MY;
                case CurrencyCode.NIO: return CountryCode.NI;
                case CurrencyCode.NOK: return CountryCode.NO;
                case CurrencyCode.NPR: return CountryCode.NP;
                case CurrencyCode.NZD: return CountryCode.NZ;
                case CurrencyCode.PHP: return CountryCode.PH;
                case CurrencyCode.PLN: return CountryCode.PL;
                case CurrencyCode.RON: return CountryCode.RO;
                case CurrencyCode.RUB: return CountryCode.RU;
                case CurrencyCode.SEK: return CountryCode.SE;
                case CurrencyCode.SGD: return CountryCode.SG;
                case CurrencyCode.THB: return CountryCode.TH;
                case CurrencyCode.TRY: return CountryCode.TR;
                case CurrencyCode.USD: return CountryCode.US;
                case CurrencyCode.ZAR: return CountryCode.ZA;
                case CurrencyCode.ARS: return CountryCode.AR;
                case CurrencyCode.COP: return CountryCode.CO;
                case CurrencyCode.CUP: return CountryCode.CU;
                case CurrencyCode.CRC: return CountryCode.CR;
                case CurrencyCode.CLP: return CountryCode.CL;
                case CurrencyCode.DOP: return CountryCode.DO;
                case CurrencyCode.PEN: return CountryCode.PE;
                case CurrencyCode.UYU: return CountryCode.UY;
                case CurrencyCode.VEF: return CountryCode.VE;
                case CurrencyCode.VES: return CountryCode.VE;
                case CurrencyCode.VEF_BLKMKT: return CountryCode.VE;
                case CurrencyCode.VEF_DICOM: return CountryCode.VE;
                case CurrencyCode.VND: return CountryCode.VN;
                case CurrencyCode.PAB: return CountryCode.PA;
                case CurrencyCode.PYG: return CountryCode.PY;
                case CurrencyCode.TWD: return CountryCode.TW;
                case CurrencyCode.UAH: return CountryCode.UA;
                case CurrencyCode.SAR: return CountryCode.SA;
                case CurrencyCode.MNT: return CountryCode.MN;
                case CurrencyCode.XCD: return CountryCode.VC;
                case CurrencyCode.MAD: return CountryCode.MA;
                case CurrencyCode.BAM: return CountryCode.BA;
                case CurrencyCode.UZS: return CountryCode.UZ;
                case CurrencyCode.KZT: return CountryCode.KZ;
                case CurrencyCode.TTD: return CountryCode.TT;
                case CurrencyCode.KHR: return CountryCode.KH;
                case CurrencyCode.XOF: return CountryCode.CI;
                case CurrencyCode.DZD: return CountryCode.DZ;
                case CurrencyCode.NGN: return CountryCode.NG;
                case CurrencyCode.KWD: return CountryCode.KW;
                case CurrencyCode.AFN: return CountryCode.AF;
                case CurrencyCode.ALL: return CountryCode.AL;
                case CurrencyCode.AMD: return CountryCode.AM;
                case CurrencyCode.ANG: return CountryCode.AN;
                case CurrencyCode.AOA: return CountryCode.AO;
                case CurrencyCode.AWG: return CountryCode.AW;
                case CurrencyCode.AZN: return CountryCode.AZ;
                case CurrencyCode.BBD: return CountryCode.BB;
                case CurrencyCode.BHD: return CountryCode.BH;
                case CurrencyCode.BMD: return CountryCode.BM;
                case CurrencyCode.BND: return CountryCode.BN;
                case CurrencyCode.BSD: return CountryCode.BS;
                case CurrencyCode.BWP: return CountryCode.BW;
                case CurrencyCode.BYN: return CountryCode.BY;
                case CurrencyCode.BZD: return CountryCode.BZ;
                case CurrencyCode.CDF: return CountryCode.CD;
                case CurrencyCode.CVE: return CountryCode.CV;
                case CurrencyCode.DJF: return CountryCode.DJ;
                case CurrencyCode.ERN: return CountryCode.ER;
                case CurrencyCode.ETB: return CountryCode.ET;
                case CurrencyCode.FJD: return CountryCode.FJ;
                case CurrencyCode.FKP: return CountryCode.FK;
                case CurrencyCode.GEL: return CountryCode.GE;
                case CurrencyCode.GHS: return CountryCode.GH;
                case CurrencyCode.GIP: return CountryCode.GI;
                case CurrencyCode.GNF: return CountryCode.GN;
                case CurrencyCode.GYD: return CountryCode.GY;
                case CurrencyCode.HTG: return CountryCode.HT;
                case CurrencyCode.IQD: return CountryCode.IQ;
                case CurrencyCode.IRR: return CountryCode.IR;
                case CurrencyCode.ISK: return CountryCode.IS;
                case CurrencyCode.JMD: return CountryCode.JM;
                case CurrencyCode.KES: return CountryCode.KE;
                case CurrencyCode.KGS: return CountryCode.KG;
                case CurrencyCode.KMF: return CountryCode.KM;
                case CurrencyCode.KPW: return CountryCode.KP;
                case CurrencyCode.KYD: return CountryCode.KY;
                case CurrencyCode.LAK: return CountryCode.LA;
                case CurrencyCode.LRD: return CountryCode.LR;
                case CurrencyCode.LSL: return CountryCode.LS;
                case CurrencyCode.LYD: return CountryCode.LY;
                case CurrencyCode.MGA: return CountryCode.MG;
                case CurrencyCode.MKD: return CountryCode.MK;
                case CurrencyCode.MMK: return CountryCode.MM;
                case CurrencyCode.MOP: return CountryCode.MO;
                case CurrencyCode.MRU: return CountryCode.MR;
                case CurrencyCode.MUR: return CountryCode.MU;
                case CurrencyCode.MVR: return CountryCode.MV;
                case CurrencyCode.MWK: return CountryCode.MW;
                case CurrencyCode.MZN: return CountryCode.MZ;
                case CurrencyCode.NAD: return CountryCode.NA;
                case CurrencyCode.OMR: return CountryCode.OM;
                case CurrencyCode.PGK: return CountryCode.PG;
                case CurrencyCode.PKR: return CountryCode.PK;
                case CurrencyCode.QAR: return CountryCode.QA;
                case CurrencyCode.RWF: return CountryCode.RW;
                case CurrencyCode.SBD: return CountryCode.SB;
                case CurrencyCode.SCR: return CountryCode.SC;
                case CurrencyCode.SDG: return CountryCode.SD;
                case CurrencyCode.SLL: return CountryCode.SL;
                case CurrencyCode.SOS: return CountryCode.SO;
                case CurrencyCode.SSP: return CountryCode.SS;
                case CurrencyCode.SYP: return CountryCode.SY;
                case CurrencyCode.SZL: return CountryCode.SZ;
                case CurrencyCode.TJS: return CountryCode.TJ;
                case CurrencyCode.TMT: return CountryCode.TM;
                case CurrencyCode.TND: return CountryCode.TN;
                case CurrencyCode.TOP: return CountryCode.TO;
                case CurrencyCode.TZS: return CountryCode.TZ;
                case CurrencyCode.UGX: return CountryCode.UG;
                case CurrencyCode.VUV: return CountryCode.VU;
                case CurrencyCode.XAF: return CountryCode.CM;
                case CurrencyCode.XPF: return CountryCode.NC;
                case CurrencyCode.YER: return CountryCode.YE;
                case CurrencyCode.ZMW: return CountryCode.ZM;
                case CurrencyCode.ZWL: return CountryCode.ZW;
            }

            throw new ApplicationException($"Unknown currency / country code: {code}");
        }
    }
}
