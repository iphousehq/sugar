using System.Collections.Generic;
using System.Linq;
using Sugar.Net;

namespace Sugar.Html
{
    public class HtmlDocument
    {
        private HtmlAgilityPack.HtmlDocument htmlDocument;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlDocument"/> class.
        /// </summary>
        public HtmlDocument()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlDocument"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        public HtmlDocument(string html)
        {
            LoadHtml(html);
        }

        /// <summary>
        /// Gets the inner text.
        /// </summary>
        /// <value>The inner text.</value>
        public string InnerText
        {
            get { return htmlDocument.DocumentNode.InnerText; }
        }

        /// <summary>
        /// Gets the inner HTML.
        /// </summary>
        /// <value>The inner HTML.</value>
        public string InnerHtml
        {
            get { return htmlDocument.DocumentNode.InnerHtml; }
        }

        /// <summary>
        /// Loads the HTML.
        /// </summary>
        /// <param name="html">The HTML.</param>
        public void LoadHtml(string html)
        {
            htmlDocument = new HtmlAgilityPack.HtmlDocument();

            if (!string.IsNullOrEmpty(html))
            {
                htmlDocument.LoadHtml(html);
            }
        }

        /// <summary>
        /// Gets the attribute list.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        public IList<string> GetAttributeList(string xpath, string attributeName)
        {
            var results = new List<string>();

            var nodes = htmlDocument.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var attribute = node.GetAttributeValue(attributeName, string.Empty);

                    if (!string.IsNullOrEmpty(attribute))
                    {
                        results.Add(attribute);
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Gets the base URL for this HTML document, based on the full document URI passed in.
        /// </summary>
        /// <param name="fullDocumentUri">The document URI.</param>
        /// <returns></returns>
        public Url GetDocumentBaseUrl(string fullDocumentUri)
        {
            var documentUrl = new Url(fullDocumentUri);
            var domainWithProtocol = documentUrl.DomainWithProtocol;
            var path = documentUrl.Path;

            var baseUrls = GetAttributeList("//base", "href");

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

        /// <summary>
        /// Gets the full image URL.
        /// </summary>
        /// <param name="imageUrl">The extracted image URL.</param>
        /// <param name="baseUrl">The document base URL.</param>
        /// <returns></returns>
        public static string GetFullImageUrl(string imageUrl, Url baseUrl)
        {
            string result = imageUrl;

            string cleanImageUrl = imageUrl.Trim();

            if (cleanImageUrl.StartsWith("http", false))
            {
                result = cleanImageUrl;
            }
            else if (cleanImageUrl.StartsWith("/"))
            {
                result = baseUrl.DomainWithProtocol + cleanImageUrl;
            }
            else if (baseUrl.Path.EndsWith("/"))
            {
                result = baseUrl.DomainWithProtocol + baseUrl.Path + cleanImageUrl;
            }
            else
            {
                result = baseUrl.DomainWithProtocol + baseUrl.Path + "/" + cleanImageUrl;
            }

            return result;
        }

        /// <summary>
        /// Returns a list of string representing the inner text of the nodes matching the given xpath.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public IList<string> GetNodeListInnerText(string xpath)
        {
            var results = new List<string>();

            var nodes = htmlDocument.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                results.AddRange(nodes.Select(node => node.InnerText));
            }

            return results;
        }

        /// <summary>
        /// Determines whether this instance contains the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified text]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string text)
        {
            return htmlDocument.DocumentNode.InnerText.Contains(text);
        }

        public IList<HtmlDocument> GetDocumentNodes(string xpath)
        {
            var documents = new List<HtmlDocument>();

            var nodes = htmlDocument.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var document = new HtmlDocument(node.InnerHtml);

                    documents.Add(document);
                }
            }

            return documents;
        }

        public string GetInnerText(string xpath)
        {
            var result = string.Empty;

            var node = htmlDocument.DocumentNode.SelectSingleNode(xpath);

            if (node != null)
            {
                result = node.InnerText;
            }

            return result;
        }

        public string GetAttributeValue(string xpath, string attributeName)
        {
            var result = string.Empty;

            var node = htmlDocument.DocumentNode.SelectSingleNode(xpath);

            if (node != null)
            {
                result = node.GetAttributeValue(attributeName, string.Empty);
            }

            return result;
        }

        public string GetInnerHtml(string xpath)
        {
            var result = string.Empty;

            var node = htmlDocument.DocumentNode.SelectSingleNode(xpath);

            if (node != null)
            {
                result = node.InnerHtml;
            }

            return result;
        }

        public IList<string> GetInnerHtmlList(string xpath)
        {
            var results = new List<string>();

            var nodes = htmlDocument.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                results.AddRange(nodes.Select(node => node.InnerHtml));
            }

            return results;
        }
    }
}
