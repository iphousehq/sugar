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
    }
}
