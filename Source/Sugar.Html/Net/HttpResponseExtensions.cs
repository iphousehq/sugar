using System.Text;
using HtmlAgilityPack;

namespace Sugar.Net
{
    /// <summary>
    /// Extension methods for the <see cref="HttpResponse"/>.
    /// </summary>
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Returns the HTML representation of the response.
        /// </summary>
        /// <returns></returns>
        public static HtmlDocument ToHtml(this HttpResponse response)
        {
            return response.ToHtml(Encoding.UTF8);
        }

        /// <summary>
        /// Returns the HTML representation of the response.
        /// </summary>
        /// <returns></returns>
        public static HtmlDocument ToHtml(this HttpResponse response, Encoding encoding)
        {
            var document = new HtmlDocument();

            var decoded = response.ToString(encoding);

            if (!string.IsNullOrWhiteSpace(decoded))
            {
                document.LoadHtml(decoded);
            }

            return document;
        }
    }
}
