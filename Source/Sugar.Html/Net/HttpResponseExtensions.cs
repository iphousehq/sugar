using System.Text;
using CsQuery;

namespace Sugar.Net
{
    /// <summary>
    /// Extension methods for the <see cref="HttpResponse"/>.
    /// </summary>
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Returns the Cs Queru representation of the response.
        /// </summary>
        /// <returns></returns>
        public static CQ ToCsQuery(this HttpResponse response)
        {
            return response.ToCsQuery(Encoding.UTF8);
        }

        /// <summary>
        /// Returns the HTML representation of the response.
        /// </summary>
        /// <returns></returns>
        public static CQ ToCsQuery(this HttpResponse response, Encoding encoding)
        {
            var html = response.ToString(encoding);

            return CQ.Create(html, HtmlParsingMode.Document);
        }
    }
}
