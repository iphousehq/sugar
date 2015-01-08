using System.Collections.Generic;
using CsQuery;
using Sugar.Net;

namespace Sugar.CsQuery
{
    /// <summary>
    /// Extension methods for CsQuery object.
    /// </summary>
    public static class CsQueryExtensions
    {
        /// <summary>
        /// Gets the all the attributes of a given name from the nodes in the CsQuery object.
        /// </summary>
        /// <param name="csQuery">The cs query.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns></returns>
        public static IList<string> GetAttributes(this CQ csQuery, string attribute)
        {
            var attributes = new List<string>();

            foreach (var node in csQuery)
            {
                var partial = CQ.Create(node);

                attributes.Add(partial.Attr(attribute));
            }

            return attributes;
        }

        /// <summary>
        /// Gets the base URL for this HTML document, based on the full document URI passed in.
        /// </summary>
        /// <param name="csQuery">The cs query.</param>
        /// <param name="fullDocumentUri">The document URI.</param>
        /// <returns></returns>
        public static Url GetDocumentBaseUrl(this CQ csQuery, string fullDocumentUri)
        {
            var documentUrl = new Url(fullDocumentUri);
            var domainWithProtocol = documentUrl.DomainWithProtocol;
            var path = documentUrl.Path;

            var baseUrls = csQuery["base"].GetAttributes("href");

            if (baseUrls.Count == 0)
            {
                return new Url(domainWithProtocol + path);
            }

            string baseUrl = baseUrls[baseUrls.Count - 1].Trim();

            if (baseUrl.StartsWith("http", false))
            {
                return new Url(baseUrl);
            }

            if (baseUrl.StartsWith("/"))
            {
                return new Url(domainWithProtocol + baseUrl);
            }

            return new Url(domainWithProtocol + path + "/" + baseUrl);
        }
    }
}
