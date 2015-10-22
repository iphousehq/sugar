using System.Web;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for strings to wrap calls to <see cref="HttpUtility"/>.
    /// </summary>
    public static class WebStringExtensions
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
        /// URL decodes this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string UrlDecode(this string value)
        {
            return HttpUtility.UrlDecode(value);
        }
    }
}
