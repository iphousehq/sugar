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
            var document = new HtmlDocument();

            var decoded = response.ToString();

            if (!string.IsNullOrWhiteSpace(decoded))
            {
                document.LoadHtml(decoded);
            }

            return document;
        }
    }
}
