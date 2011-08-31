using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Sugar.Html
{
    /// <summary>
    /// Extensions to Html Agility Pack node.
    /// </summary>
    public static class HtmlNodeExtensions
    {
        /// <summary>
        /// Updates the document HTML.
        /// </summary>
        /// <param name="document">The document.</param>
        public static void UpdateDocumentHtml(this HtmlAgilityPack.HtmlDocument document)
        {
            document.DocumentNode.InnerHtml = document.DocumentNode.WriteContentTo();
        }

        /// <summary>
        /// Gets all descendant nodes including this node that match the name given.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static IEnumerable<HtmlNode> DescendantsAndSelf(this HtmlNode node, string name)
        {
            return node.DescendantsAndSelf().Where(n => n.Name == name).Select(n => n);
        }

        /// <summary>
        /// Removes nodes.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        public static void RemoveNodes(this IEnumerable<HtmlNode> nodes)
        {
            var nList = nodes.ToList();
            for (var i = nList.Count - 1; i >= 0; i--)
            {
                nList[i].ParentNode.RemoveChild(nList[i]);
            }
        }

        /// <summary>
        /// Removes nodes based on a predicate.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <param name="predicate">The predicate.</param>
        public static void RemoveNodes(this IEnumerable<HtmlNode> nodes, Func<HtmlNode, bool> predicate)
        {
            RemoveNodes(nodes.Where(predicate));
        }

        /// <summary>
        /// Removes all tags with the given name from a Html document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="name">The name of the tag to remove.</param>
        public static void RemoveAllTags(this HtmlAgilityPack.HtmlDocument document, string name)
        {
            var nodes = document.DocumentNode.DescendantsAndSelf(name).ToList();
            for (var i = nodes.Count - 1; i >= 0; i--)
            {
                nodes[i].Remove();
            }
        }

        /// <summary>
        /// Removes all attributes with a given name from a Html document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="name">The name of the attribute to remove.</param>
        public static void RemoveAllAttributes(this HtmlAgilityPack.HtmlDocument document, string name)
        {
            foreach (var node in document.DocumentNode.DescendantsAndSelf())
            {
                node.RemoveAttribute(name);
            }
        }

        /// <summary>
        /// Removes an attribute from a html node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="name">The name of the attribute to remove.</param>
        public static void RemoveAttribute(this HtmlNode node, string name)
        {
            if (node.Attributes[name] != null)
            {
                node.Attributes[name].Remove();
            }
        }
    }
}
