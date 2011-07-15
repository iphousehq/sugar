using System;
using System.Web;

namespace Comsec.Sugar
{
    /// <summary>
    /// Extension methods for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// HTML Decodes this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string HtmlDecode(this string value)
        {
            return HttpUtility.HtmlDecode(value);
        }

        /// <summary>
        /// HTML Encodes this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string HtmlEncode(this string value)
        {
            return HttpUtility.HtmlEncode(value);
        }

        /// <summary>
        /// URL encodes this string
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string UrlEncode(this string value)
        {
            return HttpUtility.UrlEncode(value);
        }

        /// <summary>
        /// Determines whether the string starts with the specified value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <param name="isCaseSensitive">if set to <c>true</c> [is case sensitive].</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool StartsWith(this string source, string value, bool isCaseSensitive)
        {
            StringComparison comparisonOption = isCaseSensitive ? StringComparison.CurrentCulture : StringComparison.InvariantCultureIgnoreCase;

            return source.StartsWith(value, comparisonOption);
        }

        /// <summary>
        /// Determines whether the string starts with the specified value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <param name="conparisonOption">The conparison option.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool StartsWith(this string source, string value, StringComparison conparisonOption)
        {
            return source.IndexOf(value, 0, conparisonOption) == 0;
        }

        /// <summary>
        /// Substrings the after char.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public static string SubstringAfterChar(this string value, string match)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(match))
            {
                if (value.Contains(match))
                {
                    result = value.Substring(value.IndexOf(match) + match.Length);
                }
            }

            return result;
        }

        public static string SubstringAfterLastChar(this string value, string match)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(match))
            {
                if (value.Contains(match))
                {
                    result = value.Substring(value.LastIndexOf(match) + match.Length);
                }
            }

            return result;
        }

        /// <summary>
        /// Substrings the before char.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public static string SubstringBeforeChar(this string value, string match)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(match))
            {
                if (value.Contains(match))
                {
                    result = value.Substring(0, value.IndexOf(match));
                }
            }

            return result;
        }


        /// <summary>
        /// Substrings the before char.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public static string SubstringBeforeLastChar(this string value, string match)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(match))
            {
                if (value.Contains(match))
                {
                    result = value.Substring(0, value.LastIndexOf(match));
                }
            }

            return result;
        }

        /// <summary>
        /// Keeps the specified characters in the given value, removed the rest.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="keepTheseCharacters">The keep these characters.</param>
        /// <returns></returns>
        public static string Keep(this string value, string keepTheseCharacters)
        {
            var result = string.Empty;

            if (value != null)
            {
                foreach (var @char in value.ToCharArray())
                {
                    if (!keepTheseCharacters.Contains(@char.ToString())) continue;

                    result += @char;
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified value is numeric.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumeric(this string value)
        {
            double temp;

            return double.TryParse(value, out temp);
        }

        public static string Repeat(this string value, int times)
        {
            var result = string.Empty;

            for (var i = 0; i < times; i++)
            {
                result += value;
            }

            return result;
        }

        public static string TrimTo(this string value, int length)
        {
            return TrimTo(value, length, string.Empty);
        }

        public static string TrimTo(this string value, int length, string overrunIndicator)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > length)
                {
                    result = value.Substring(0, length - overrunIndicator.Length) + overrunIndicator;
                }
            }

            return result;
        }
    }
}
