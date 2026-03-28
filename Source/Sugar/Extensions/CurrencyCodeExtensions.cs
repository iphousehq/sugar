using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sugar.Attributes;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="CurrencyCode"/> enumeration.
    /// </summary>
    public static class CurrencyCodeExtensions
    {
        private static readonly Dictionary<CurrencyCode, string> Symbols =
            BuildLookup<SymbolAttribute>(a => a.Symbol);

        private static readonly Dictionary<CurrencyCode, string> HtmlSymbols =
            BuildLookup<HtmlSymbolAttribute>(a => a.HtmlSymbol);

        private static readonly Dictionary<CurrencyCode, CountryCode> CurrencyToCountry =
            BuildCountryLookup();

        private static readonly Dictionary<CountryCode, CurrencyCode> CountryToCurrency =
            BuildCurrencyLookup();

        // Symbol-to-currency is an explicit mapping because many currencies share the same symbol (e.g. "$").
        // The entries here define which currency "owns" each ambiguous symbol for reverse lookup.
        private static readonly Dictionary<string, CurrencyCode> SymbolToCurrency =
            new Dictionary<string, CurrencyCode>
            {
                ["د.إ"] = CurrencyCode.AED,
                ["৳"] = CurrencyCode.BDT,
                ["лв"] = CurrencyCode.BGN,
                ["R$"] = CurrencyCode.BRL,
                ["Fr."] = CurrencyCode.CHF,
                ["₡"] = CurrencyCode.CRC,
                ["¤"] = CurrencyCode.CZK,
                ["RD$"] = CurrencyCode.DOP,
                ["E£"] = CurrencyCode.EGP,
                ["€"] = CurrencyCode.EUR,
                ["£"] = CurrencyCode.GBP,
                ["Q"] = CurrencyCode.GTQ,
                ["L"] = CurrencyCode.HNL,
                ["kn"] = CurrencyCode.HRK,
                ["Ft"] = CurrencyCode.HUF,
                ["₹"] = CurrencyCode.INR,
                ["₪"] = CurrencyCode.ILS,
                ["Rp"] = CurrencyCode.IDR,
                ["د.ا"] = CurrencyCode.JOD,
                ["¥"] = CurrencyCode.JPY,
                ["₩"] = CurrencyCode.KRW,
                ["ل.ل"] = CurrencyCode.LBP,
                ["Lt"] = CurrencyCode.LTL,
                ["Ls"] = CurrencyCode.LVL,
                ["RM"] = CurrencyCode.MYR,
                ["C$"] = CurrencyCode.NIO,
                ["B/."] = CurrencyCode.PAB,
                ["S/."] = CurrencyCode.PEN,
                ["Php"] = CurrencyCode.PHP,
                ["zł"] = CurrencyCode.PLN,
                ["₲"] = CurrencyCode.PYG,
                ["lei"] = CurrencyCode.RON,
                ["руб"] = CurrencyCode.RUB,
                ["﷼"] = CurrencyCode.SAR,
                ["kr"] = CurrencyCode.SEK,
                ["฿"] = CurrencyCode.THB,
                ["TL"] = CurrencyCode.TRY,
                ["NT$"] = CurrencyCode.TWD,
                ["$"] = CurrencyCode.USD,
                ["$U"] = CurrencyCode.UYU,
                ["Bs"] = CurrencyCode.VEF_DICOM,
                ["R"] = CurrencyCode.ZAR,
                ["₴"] = CurrencyCode.UAH,
                ["₫"] = CurrencyCode.VND,
                ["₮"] = CurrencyCode.MNT,
                ["KM"] = CurrencyCode.BAM,
                ["y.e."] = CurrencyCode.UZS,
                ["KZ"] = CurrencyCode.KZT,
                ["TT$"] = CurrencyCode.TTD,
                ["\u17db"] = CurrencyCode.KHR,
                ["F.CFA"] = CurrencyCode.XOF,
                ["د.ج"] = CurrencyCode.DZD,
                ["₦"] = CurrencyCode.NGN,
                ["د.ك"] = CurrencyCode.KWD,
            };

        /// <summary>
        /// Finds the first currency code symbol in a string.
        /// </summary>
        public static CurrencyCode? FindCurrencyCode(this string text)
        {
            var occurrences = new List<(int Index, CurrencyCode Code)>();

            foreach (var kvp in Symbols)
            {
                if (!string.IsNullOrEmpty(kvp.Value))
                {
                    var index = text.IndexOf(kvp.Value, StringComparison.Ordinal);
                    if (index > -1)
                        occurrences.Add((index, kvp.Key));
                }
            }

            return occurrences.Any()
                ? occurrences.OrderBy(o => o.Index).Select(o => o.Code).FirstOrDefault()
                : (CurrencyCode?)null;
        }

        /// <summary>
        /// Converts this <see cref="CurrencyCode"/> to its Unicode symbol.
        /// </summary>
        public static string ToSymbol(this CurrencyCode code)
        {
            return Symbols.TryGetValue(code, out var s)
                ? s
                : throw new ApplicationException($"Unknown currency: {code}");
        }

        /// <summary>
        /// Converts this <see cref="CurrencyCode"/> to its HTML-encoded symbol.
        /// </summary>
        public static string ToHtmlSymbol(this CurrencyCode code)
        {
            return HtmlSymbols.TryGetValue(code, out var s)
                ? s
                : throw new ApplicationException($"Unknown currency / HTML code: {code}");
        }

        /// <summary>
        /// Converts a symbol string to a <see cref="CurrencyCode"/>.
        /// </summary>
        public static CurrencyCode ToCurrencyCode(this string symbol)
        {
            if (SymbolToCurrency.TryGetValue(symbol, out var code))
                return code;

            if (Enum.TryParse(symbol, true, out CurrencyCode parsed))
                return parsed;

            throw new ApplicationException($"Unknown currency symbol: {symbol}");
        }

        /// <summary>
        /// Converts a <see cref="CountryCode"/> to its <see cref="CurrencyCode"/>.
        /// </summary>
        public static CurrencyCode ToCurrencyCode(this CountryCode country)
        {
            return CountryToCurrency.TryGetValue(country, out var currency)
                ? currency
                : throw new ArgumentOutOfRangeException(nameof(country), country, "Could not convert country code to currency code");
        }

        /// <summary>
        /// Returns the country that this currency is issued by.
        /// </summary>
        public static CountryCode ToCountryCode(this CurrencyCode code)
        {
            return CurrencyToCountry.TryGetValue(code, out var country)
                ? country
                : throw new ApplicationException($"Unknown currency / country code: {code}");
        }

        private static Dictionary<CurrencyCode, string> BuildLookup<TAttr>(Func<TAttr, string> selector)
            where TAttr : Attribute
        {
            var result = new Dictionary<CurrencyCode, string>();
            foreach (CurrencyCode c in Enum.GetValues(typeof(CurrencyCode)))
            {
                var attr = typeof(CurrencyCode).GetField(c.ToString()).GetCustomAttribute<TAttr>();
                if (attr != null) result[c] = selector(attr);
            }
            return result;
        }

        private static Dictionary<CountryCode, CurrencyCode> BuildCurrencyLookup()
        {
            var result = new Dictionary<CountryCode, CurrencyCode>();
            foreach (CountryCode c in Enum.GetValues(typeof(CountryCode)))
            {
                var field = typeof(CountryCode).GetField(c.ToString());
                if (field == null) continue;
                var attr = field.GetCustomAttribute<CurrencyAttribute>();
                if (attr != null) result[c] = attr.Currency;
            }
            return result;
        }

        private static Dictionary<CurrencyCode, CountryCode> BuildCountryLookup()
        {
            // When multiple countries share a currency (e.g. EUR for 30+ countries), prefer the one whose
            // alpha-2 code is a prefix of the currency code (US→USD, AU→AUD). Fall back to first in enum order.
            var groups = new Dictionary<CurrencyCode, List<CountryCode>>();
            foreach (CountryCode c in Enum.GetValues(typeof(CountryCode)))
            {
                var field = typeof(CountryCode).GetField(c.ToString());
                if (field == null) continue;
                var attr = field.GetCustomAttribute<CurrencyAttribute>();
                if (attr == null) continue;
                if (!groups.ContainsKey(attr.Currency)) groups[attr.Currency] = new List<CountryCode>();
                groups[attr.Currency].Add(c);
            }

            var result = new Dictionary<CurrencyCode, CountryCode>();
            foreach (var kvp in groups)
            {
                var currencyStr = kvp.Key.ToString();
                var preferred = kvp.Value.FirstOrDefault(c =>
                    currencyStr.StartsWith(c.ToString(), StringComparison.OrdinalIgnoreCase));
                result[kvp.Key] = preferred != default ? preferred : kvp.Value[0];
            }
            return result;
        }
    }
}
