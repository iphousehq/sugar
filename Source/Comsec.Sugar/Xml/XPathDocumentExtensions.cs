using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace Comsec.Sugar.Xml
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
        public static string GetNamespace(this XPathDocument document)
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
        /// <returns></returns>
        public static IList<string> GetNamespaces(this XPathDocument document)
        {
            var results = new List<string>();

            var navigator = document.CreateNavigator();

            navigator.MoveToFollowing(XPathNodeType.Element);

            var namespaces = navigator.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);

            if (namespaces != null)
            {
                results.AddRange(namespaces.Keys.Select(key => namespaces[key]));
            }

            return results;
        }

        /// <summary>
        /// Gets the inner XML.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static string GetInnerXml(this XPathDocument document, string xpath)
        {
            var result = string.Empty;

            var iterator = GetIterator(document, xpath);

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
        /// <returns></returns>
        public static IList<string> GetInnerXmlList(this XPathDocument document, string xpath)
        {
            var results = new List<string>();

            var iterator = GetIterator(document, xpath);

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

        /// <summary>
        /// Gets a list of navigators from the given XPath.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static IList<XPathDocument> GetMatches(this XPathDocument document, string xpath)
        {
            var results = new List<XPathDocument>();

            var iterator = GetIterator(document, xpath);

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

        private static XPathNodeIterator GetIterator(XPathDocument document, string xpath)
        {
            var navigator = document.CreateNavigator();

            var @namespace = document.GetNamespace();

            var manager = new XmlNamespaceManager(navigator.NameTable);

            if (!string.IsNullOrEmpty(@namespace))
            {
                xpath = AddPrefixToXPath(xpath, "pfx");

                manager.AddNamespace("pfx", @namespace);
            }

            var iterator = navigator.Select(xpath, manager);
            return iterator;
        }
    }
}
