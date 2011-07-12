using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Comsec.Sugar.Xml
{
    /// <summary>
    /// Helper class to make accessing XML documents easier.
    /// </summary>
    public class XmlMediator
    {
        /// <summary>
        /// Gets the XML Document.
        /// </summary>
        public XmlDocument Document { get; private set; }

        /// <summary>
        /// Gets the XML Namespace Manager.
        /// </summary>
        public XmlNamespaceManager Manager { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlMediator"/> class.
        /// </summary>
        public XmlMediator()
        {
            Document = new XmlDocument();
            Manager = new XmlNamespaceManager(Document.NameTable);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlMediator"/> class
        /// with the given XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public XmlMediator(string xml)
        {
            Document = new XmlDocument();
            Manager = new XmlNamespaceManager(Document.NameTable);

            Document.LoadXml(xml);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlMediator"/> class
        /// with the given XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="namespacePrefix">The namespace prefix.</param>
        /// <param name="namespaceUri">The namespace URI.</param>
        public XmlMediator(string xml, string namespacePrefix, string namespaceUri)
        {
            Document = new XmlDocument();
            Manager = new XmlNamespaceManager(Document.NameTable);

            AddNamespace(namespacePrefix, namespaceUri);

            Document.LoadXml(xml);
        }

        /// <summary>
        /// Loads the XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public void Load(string xml)
        {
            Document = new XmlDocument();
            Manager = new XmlNamespaceManager(Document.NameTable);
            
            Document.LoadXml(xml);
        }

        public void AddNamespace(string prefix, string uri)
        {
            Manager.AddNamespace(prefix, uri);
        }

        public string GetInnerText(string xpath)
        {
            return GetInnerText(xpath, string.Empty);
        }

        public string GetInnerText(string xpath, string @default)
        {
            var result = @default;

            var node = Document.SelectSingleNode(xpath, Manager);

            if (node != null)
            {
                result = node.InnerText;
            }

            return result;
        }

        private XmlNodeList GetNodes(string xpath)
        {
            var nodes = Document.SelectNodes(xpath, Manager);

            return nodes;
        }

        public IList<string> GetInnerTextList(string xpath)
        {
            var result = new List<string>();

            var nodes = Document.SelectNodes(xpath, Manager);

            if (nodes != null)
            {
                result.AddRange(from XmlNode node in nodes select node.InnerText);
            }

            return result;
        }


        public IList<T> GetItems<T>(string nodeListXpath, Func<XmlNode, XmlNamespaceManager, T> itemGenerator)
        {
            var items = new List<T>();

            foreach (XmlNode node in GetNodes(nodeListXpath))
            {
                var item = itemGenerator.Invoke(node, Manager);

                items.Add(item);
            }

            return items;
        }
    }
}
