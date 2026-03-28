using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sugar.Attributes;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods to help dealing with ISO 3166 alpha-2 and alpha-3 country codes.
    /// </summary>
    public static class CountryCodeExtensions
    {
        private static readonly Dictionary<CountryCode, CountryCode3> Alpha2ToAlpha3 =
            BuildAlpha2ToAlpha3();

        private static readonly Dictionary<CountryCode3, CountryCode> Alpha3ToAlpha2 =
            Alpha2ToAlpha3.ToDictionary(kv => kv.Value, kv => kv.Key);

        /// <summary>
        /// Converts to ISO 6381 language tag.
        /// </summary>
        public static string ToIso6381(this CountryCode countryCode)
        {
            // These three are intentional non-standard overrides retained for backwards compatibility.
            switch (countryCode)
            {
                case CountryCode.AS: return "ws";
                case CountryCode.GB: return "uk";
                case CountryCode.US: return "";
                default:
                    return countryCode.ToString().ToLower();
            }
        }

        /// <summary>
        /// Converts an ISO 3166 alpha-2 country code to its alpha-3 counterpart.
        /// </summary>
        public static CountryCode3 ToAlpha3(this CountryCode alpha2)
        {
            return Alpha2ToAlpha3.TryGetValue(alpha2, out var alpha3)
                ? alpha3
                : throw new ArgumentOutOfRangeException(nameof(alpha2), alpha2, "Unknown country code");
        }

        /// <summary>
        /// Converts an ISO 3166 alpha-3 country code to its alpha-2 counterpart.
        /// </summary>
        public static CountryCode ToAlpha2(this CountryCode3 alpha3)
        {
            return Alpha3ToAlpha2.TryGetValue(alpha3, out var alpha2)
                ? alpha2
                : throw new ArgumentOutOfRangeException(nameof(alpha3), alpha3, "Unknown country code");
        }

        private static Dictionary<CountryCode, CountryCode3> BuildAlpha2ToAlpha3()
        {
            var result = new Dictionary<CountryCode, CountryCode3>();
            foreach (CountryCode c in Enum.GetValues(typeof(CountryCode)))
            {
                var field = typeof(CountryCode).GetField(c.ToString());
                if (field == null) continue;
                var attr = field.GetCustomAttribute<Alpha3Attribute>();
                if (attr != null) result[c] = attr.Alpha3;
            }
            return result;
        }
    }
}
