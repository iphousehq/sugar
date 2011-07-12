using NUnit.Framework;

namespace Comsec.Sugar.Xml
{
    [TestFixture]
    public class XmlMediatorTest
    {
        [Test]
        public void TestConstructor()
        {
            var xml = new XmlMediator("<node><value attribute='test'>Hello World</value></node>");

            var value = xml.GetInnerText("//value[@attribute='test']");

            Assert.AreEqual("Hello World", value);
        }

        [Test]
        public void TestConstructorWithNamespace()
        {
            var xml = new XmlMediator(@"<node xmlns:foo=""http://localhost/test""><foo:value attribute='test'>Hello World</foo:value></node>", "foo", "http://localhost/test");

            var value = xml.GetInnerText("//foo:value[@attribute='test']");

            Assert.AreEqual("Hello World", value);
        }

        [Test]
        public void TestConstructorWithoutNamespace()
        {
            var xml = new XmlMediator(@"<node xmlns:foo=""http://localhost/test""><foo:value attribute='test'>Hello World</foo:value></node>");

            var value = xml.GetInnerText("//value[@attribute='test']");

            Assert.AreEqual(string.Empty, value);
        }

        [Test]
        public void TestLoadXml()
        {
            var xml = new XmlMediator();
            
            xml.Load("<node><foo attribute='bar'>Baz</foo></node>");

            var value = xml.GetInnerText("//foo[@attribute='bar']");

            Assert.AreEqual("Baz", value);
        }
    }
}
