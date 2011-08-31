using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Sugar.Html
{
    [TestFixture]
    public class HtmlNodeExtensionsTest
    {
        private HtmlAgilityPack.HtmlDocument document;

        [SetUp]
        public void Setup()
        {
            var filePath = Path.GetFullPath("../../Samples/node-extension.html");
            document = new HtmlAgilityPack.HtmlDocument();
            document.Load(filePath);
        }

        [Test]
        public void TestRemoveNodes()
        {
            document.DocumentNode.Descendants("div").RemoveNodes();

            var nodes = document.DocumentNode.SelectNodes(@"//div");

            Assert.IsNull(nodes);
        }

        [Test]
        public void TestRemoveNodesWithPredicate()
        {
            document.DocumentNode.Descendants("div").RemoveNodes(x => x.Id == "test");

            var nodes = document.DocumentNode.SelectNodes(@"//div");

            Assert.AreEqual(1, nodes.Count);
            Assert.AreEqual("keep", nodes.First().Id);
        }

        [Test]
        public void TestRemoveAllTags()
        {
            document.RemoveAllTags("p");

            var nodes = document.DocumentNode.SelectNodes(@"//p");

            Assert.IsNull(nodes);
        }

        [Test]
        public void TestRemoveAttribute()
        {
            var node = document.DocumentNode.SelectSingleNode("//div[@id='test']");
            node.RemoveAttribute("class");

            Assert.IsNull(node.Attributes["class"]);
        }

        [Test]
        public void TestRemoveAllAttributes()
        {
            document.RemoveAllAttributes("class");

            var nodes = document.DocumentNode.Descendants();

            Assert.IsTrue(nodes.All(x => x.Attributes["class"] == null));
        }

        [Test]
        public void TestObtainDescendantNodesAndSelf()
        {
            var node = document.DocumentNode.SelectSingleNode(@"//p[@id='self']");

            var results = node.DescendantsAndSelf("p");

            Assert.AreEqual(2, results.Count());
        }
    }
}
