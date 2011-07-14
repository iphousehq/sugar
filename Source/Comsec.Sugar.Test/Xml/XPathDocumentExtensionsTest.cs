using NUnit.Framework;

namespace Comsec.Sugar.Xml
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
        public void TestGetInnerXml()
        {
            var xml = @"<node><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetInnerXml("//value");

            Assert.AreEqual("Hello World", value);

        }

        [Test]
        public void TestGetInnerXmlWithNamespace()
        {
            var xml = @"<node xmlns=""http://localhost/test""><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetInnerXml("//value");

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
    }
}
