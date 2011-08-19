using NUnit.Framework;

namespace Sugar.Xml
{
    [TestFixture]
    public class XPathDocumentExtensionsTest
    {            
        [Test]
        public void TestToXPath()
        {
            var xml = @"<node><value attribute='test'>Hello World</value></node>".ToXPath();

            Assert.IsNotNull(xml);
        }

        [Test]
        public void TestGetNamespace()
        {
            var xml = @"<node xmlns=""http://localhost/test""><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetNamespace();

            Assert.AreEqual("http://localhost/test", value);
        }


        [Test]
        public void TestGetNamespaces()
        {
            var xml = @"<node xmlns:foo=""http://localhost/test1"" xmlns:bar=""http://localhost/test2""><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetNamespaces();

            Assert.AreEqual(2, value.Count);
            Assert.AreEqual("http://localhost/test2", value[0]);
            Assert.AreEqual("http://localhost/test1", value[1]);
        }

        [Test]
        public void TestGetNestedNamespaces()
        {
            var xml = @"<node xmlns:foo=""http://localhost/test1""><value xmlns:bar=""http://localhost/test2"" attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetNamespaces(2);

            Assert.AreEqual(2, value.Count);
            Assert.AreEqual("http://localhost/test1", value[0]);
            Assert.AreEqual("http://localhost/test2", value[1]);
        }

        [Test]
        public void TestGetInnerXml()
        {
            var xml = @"<node><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetInnerXml("//value");

            Assert.AreEqual("Hello World", value);
        }

        [Test]
        public void TestGetInnerXmlList()
        {
            var xml = @"<node><value>Hello World</value><value>Again</value></node>".ToXPath();

            var results = xml.GetInnerXmlList("//value");

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Hello World", results[0]);
            Assert.AreEqual("Again", results[1]);
        }

        [Test]
        public void TestGetInnerXmlWithNamespace()
        {
            var xml = @"<node xmlns=""http://localhost/test""><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetInnerXml("//value");

            Assert.AreEqual("Hello World", value);
        }

        [Test]
        public void TestGetInnerXmlWithTwoNamespaces()
        {
            var xml = @"<node xmlns=""http://localhost/test1""><node xmlns=""http://localhost/test2""><value attribute='test'>Hello World</value></node></node>".ToXPath();

            var value = xml.GetInnerXml("//value", 2);

            Assert.AreEqual("Hello World", value);
        }

        [Test]
        public void TestGetMatches()
        {
            var xml = @"<node><value>Hello World 1</value><value>Hello World 2</value></node>".ToXPath();

            var results = xml.GetMatches("//value");

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results[0].CreateNavigator().InnerXml.Contains("Hello World 1"));
            Assert.IsTrue(results[1].CreateNavigator().InnerXml.Contains("Hello World 2"));
        }

        [Test]
        public void TestGetMatchesWithNamespace()
        {
            var xml = @"<node xmlns=""http://localhost/test""><value>Hello World 1</value><value>Hello World 2</value></node>".ToXPath();

            var results = xml.GetMatches("//value");

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results[0].CreateNavigator().InnerXml.Contains("Hello World 1"));
            Assert.IsTrue(results[1].CreateNavigator().InnerXml.Contains("Hello World 2"));
        }

        [Test]
        public void TestGetAttribute()
        {
            var xml = @"<node><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetAttribute("//value", "attribute");

            Assert.AreEqual("test", value);
        }

        [Test]
        public void TestGetAttributeList()
        {
            var xml = @"<node><value attr='test'>Hello World</value><value attr='second'>Again</value></node>".ToXPath();

            var results = xml.GetAttributeList("//value", "attr");

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("test", results[0]);
            Assert.AreEqual("second", results[1]);
        }

        [Test]
        public void TestGetAttributeWithNamespace()
        {
            var xml = @"<node xmlns=""http://localhost/test""><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetAttribute("//value", "attribute");

            Assert.AreEqual("test", value);
        }
    }
}
