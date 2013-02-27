using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Sugar.Net;

namespace Sugar.Html
{
    /// <summary>
    /// Factory class to create HtmlDocument objectd
    /// </summary>
    public static class Html
    {
        /// <summary>
        /// Loads the specified HTML and returns a HtmlDocument.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public static HtmlDocument Load(string html)
        {
            var document = new HtmlDocument();

            if (!string.IsNullOrWhiteSpace(html))
            {
                document.LoadHtml(html);
            }

            return document;
        }

        /// <summary>
        /// Gets the full image URL.
        /// </summary>
        /// <param name="imageUrl">The extracted image URL.</param>
        /// <param name="baseUrl">The document base URL.</param>
        /// <returns></returns>
        public static string GetFullImageUrl(string imageUrl, Url baseUrl)
        {
            string result;

            var cleanImageUrl = imageUrl.Trim();

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
    }

    /// <summary>
    /// Extension methods for <see cref="HtmlDocument"/> objects.
    /// </summary>
    public static class HtmlDocumentExtensions
    {
        /// <summary>
        /// Gets the inner text.
        /// </summary>
        /// <value>The inner text.</value>
        public static string GetInnerText(this HtmlDocument document)
        {
            return document.DocumentNode.InnerText;
        }

        /// <summary>
        /// Gets the inner HTML.
        /// </summary>
        /// <value>The inner HTML.</value>
        public static string GetInnerHtml(this HtmlDocument document)
        {
            return document.DocumentNode.InnerHtml;
        }

        /// <summary>
        /// Gets the attribute from the root node.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        public static string GetAttribute(this HtmlDocument document, string attributeName)
        {
            var result = string.Empty;

            if (document.DocumentNode.ChildNodes.Count > 0)
            {
                var node = document.DocumentNode.ChildNodes[0];

                result = node.GetAttributeValue(attributeName, string.Empty);
            }

            return result;
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        public static string GetAttribute(this HtmlDocument document, string xpath, string attributeName)
        {
            var result = string.Empty;

            var node = document.DocumentNode.SelectSingleNode(xpath);

            if (node != null)
            {
                result = node.GetAttributeValue(attributeName, string.Empty);
            }

            return result;
        }

        /// <summary>
        /// Gets the attribute list.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        public static IList<string> GetAttributeList(this HtmlDocument document, string xpath, string attributeName)
        {
            var results = new List<string>();

            var nodes = document.DocumentNode.SelectNodes(xpath);

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
        /// <param name="document">The document.</param>
        /// <param name="fullDocumentUri">The document URI.</param>
        /// <returns></returns>
        public static Url GetDocumentBaseUrl(this HtmlDocument document, string fullDocumentUri)
        {
            var documentUrl = new Url(fullDocumentUri);
            var domainWithProtocol = documentUrl.DomainWithProtocol;
            var path = documentUrl.Path;

            var baseUrls = document.GetAttributeList("//base", "href");

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
        /// Gets the inner text of the first node matching the given XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static string GetInnerText(this HtmlDocument document, string xpath)
        {
            var result = string.Empty;

            var node = document.DocumentNode.SelectSingleNode(xpath);

            if (node != null)
            {
                result = node.InnerText;
            }

            return result;
        }

        /// <summary>
        /// Returns a list of string representing the inner text of the nodes matching the given xpath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static IList<string> GetInnerTextList(this HtmlDocument document, string xpath)
        {
            var results = new List<string>();

            var nodes = document.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                results.AddRange(nodes.Select(node => node.InnerText));
            }

            return results;
        }

        /// <summary>
        /// Gets the inner HTML of the first node matching the given XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static string GetInnerHtml(this HtmlDocument document, string xpath)
        {
            var result = string.Empty;

            var node = document.DocumentNode.SelectSingleNode(xpath);

            if (node != null)
            {
                result = node.InnerHtml;
            }

            return result;
        }

        /// <summary>
        /// Gets the inner HTML of the nodes matchding the XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static IList<string> GetInnerHtmlList(this HtmlDocument document, string xpath)
        {
            var results = new List<string>();

            var nodes = document.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                results.AddRange(nodes.Select(node => node.InnerHtml));
            }

            return results;
        }

        /// <summary>
        /// Determines whether this instance contains the specified text.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="text">The text.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified text]; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains(this HtmlDocument document, string text)
        {
            return document.DocumentNode.InnerText.Contains(text);
        }

        /// <summary>
        /// Check if a node found using the given XPath exists.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static bool NodeExists(this HtmlDocument document, string xpath)
        {
            return document.GetNodes(xpath).Count > 0;
        }

        /// <summary>
        /// Gets a HtmlDocument object of the first node matchding the given XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static HtmlDocument GetNode(this HtmlDocument document, string xpath)
        {
            var results = document.GetNodes(xpath);

            if (results.FirstOrDefault() == null)
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(string.Empty);

                return doc;                
            }

            return results.FirstOrDefault();
        }

        /// <summary>
        /// Gets HtmlDocument objects of the nodes matchding the given XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static IList<HtmlDocument> GetNodes(this HtmlDocument document, string xpath)
        {
            var results = new List<HtmlDocument>();

            var nodes = document.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var result = new HtmlDocument();

                    result.LoadHtml(node.OuterHtml);

                    results.Add(result);
                }
            }

            return results;
        }
    }
}
