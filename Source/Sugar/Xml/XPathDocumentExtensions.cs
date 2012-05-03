using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace Sugar.Xml
{
    /// <summary>
    /// Extension methods for the <see cref="XPathDocument"/> class.
    /// </summary>
    public static class XPathDocumentExtensions
    {
        /// <summary>
        /// Returns an <see cref="XPathDocument"/> representation of this XML string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static XPathDocument ToXPath(this string value)
        {
            return new XPathDocument(new StringReader(value));
        }

        /// <summary>
        /// Gets the first namespace in the XML document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        public static string GetNamespace(this IXPathNavigable document)
        {
            var navigator = document.CreateNavigator();

            navigator.MoveToFollowing(XPathNodeType.Element);

            var namespaces = navigator.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);

            if (namespaces != null)
            {
                foreach (var key in namespaces.Keys)
                {
                    return namespaces[key];
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the namespaces in the XML document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="depth">The ndoe depth to search.</param>
        /// <returns></returns>
        public static IList<string> GetNamespaces(this IXPathNavigable document, int depth = 1)
        {
            var results = new List<string>();

            var navigator = document.CreateNavigator();

            while (depth > 0)
            {
                navigator.MoveToFollowing(XPathNodeType.Element);

                var namespaces = navigator.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);

                if (namespaces != null)
                {
                    var names = namespaces.Keys.Select(key => namespaces[key]);

                    foreach (var name in names.Where(name => !results.Contains(name)))
                    {
                        results.Add(name);
                    }
                }

                depth--;
            }

            return results;
        }

        /// <summary>
        /// Gets the inner XML.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="namespaceSearchDepth">The namespace search depth.</param>
        /// <returns></returns>
        public static string GetInnerXml(this IXPathNavigable document, string xpath, int namespaceSearchDepth = 1)
        {
            var result = string.Empty;

            var iterator = GetIterator(document, xpath, namespaceSearchDepth);

            if (iterator.Count > 0 && iterator.MoveNext())
            {
                if (iterator.Current != null)
                {
                    result = iterator.Current.InnerXml;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the inner XML from the matching elements.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="namespaceSearchDepth">The namespace search depth.</param>
        /// <returns></returns>
        public static IList<string> GetInnerXmlList(this IXPathNavigable document, string xpath, int namespaceSearchDepth = 1)
        {
            var results = new List<string>();

            var iterator = GetIterator(document, xpath, namespaceSearchDepth);

            if (iterator.Count > 0)
            {
                while (iterator.MoveNext())
                {
                    if (iterator.Current == null) break;

                    results.Add(iterator.Current.InnerXml);
                }
            }

            return results;
        }

        /// <summary>
        /// Gets items from the matching elements..
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="func">The function used to extract an element..</param>
        /// <param name="namespaceSearchDepth">The namespace search depth.</param>
        /// <returns></returns>
        public static IList<T> GetItems<T>(this IXPathNavigable document, string xpath, Func<string, T> func, int namespaceSearchDepth = 1)
        {
            var results = new List<T>();

            var iterator = GetIterator(document, xpath, namespaceSearchDepth);

            if(iterator.Count > 0)
            {
                while (iterator.MoveNext())
                {
                    if (iterator.Current == null) break;

                    results.Add(func.Invoke(iterator.Current.OuterXml));
                }
            }

            return results;
        }

        /// <summary>
        /// Gets the attribute from the matching XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns></returns>
        public static string GetAttribute(this IXPathNavigable document, string xpath, string attribute)
        {
            var result = string.Empty;

            var iterator = GetIterator(document, xpath);

            if (iterator.Count > 0 && iterator.MoveNext())
            {
                if (iterator.Current != null)
                {
                    result = iterator.Current.GetAttribute(attribute, string.Empty);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the attributes from the matching XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns></returns>
        public static IList<string> GetAttributeList(this IXPathNavigable document, string xpath, string attribute)
        {
            var results = new List<string>();

            var iterator = GetIterator(document, xpath);

            if (iterator.Count > 0)
            {
                while (iterator.MoveNext())
                {
                    if (iterator.Current == null) break;

                    results.Add(iterator.Current.GetAttribute(attribute, string.Empty));
                }
            }

            return results;
        }

        /// <summary>
        /// Gets a list of navigators from the given XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="namespaceSearchDepth">The namespace search depth.</param>
        /// <returns></returns>
        public static IList<XPathDocument> GetMatches(this IXPathNavigable document, string xpath, int namespaceSearchDepth = 1)
        {
            var results = new List<XPathDocument>();

            var iterator = GetIterator(document, xpath, namespaceSearchDepth);

            if (iterator.Count > 0)
            {
                while (iterator.MoveNext())
                {
                    var result = new XPathDocument(new StringReader(iterator.Current.OuterXml));

                    results.Add(result);
                }
            }

            return results;
        }

        private static XPathNodeIterator GetIterator(IXPathNavigable document, string xpath, int namespaceSearchDepth = 1)
        {
            var navigator = document.CreateNavigator();

            var namespaces = document.GetNamespaces(namespaceSearchDepth);

            var manager = new XmlNamespaceManager(navigator.NameTable);

            if (namespaces.Count > 0)
            {
                xpath = AddPrefixToXPath(xpath, "pfx");

                foreach (var ns in namespaces)
                {
                    manager.AddNamespace("pfx", ns);
                }
            }

            var iterator = navigator.Select(xpath, manager);

            return iterator;
        }

        private static string AddPrefixToXPath(string xpath, string prefix)
        {
            return System.Text.RegularExpressions.Regex.Replace(xpath, @"(^(?![A-Za-z0-9\-\.]+::)|[A-Za-z0-9\-\.]+::|[@|/])(?'Expression'[A-Za-z0-9\-\.]+)", x =>
            {
                var expressionIndex = x.Groups["Expression"].Index - x.Index;
                var before = x.Value.Substring(0, expressionIndex);
                var after = x.Value.Substring(expressionIndex, x.Value.Length - expressionIndex);

                return String.Format("{0}{1}:{2}", before, prefix, after);
            });
        }
    }
}
