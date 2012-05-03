using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
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

        [Test]
        public void TestGetItemsSingleItem()
        {
            var xml = @"<node><key>This is the key!</key><value attribute='test'>Hello World</value></node>".ToXPath();

            var value = xml.GetItems("//node", x =>
            {
                var nodeXml = x.ToXPath();

                return new KeyValuePair<string, string>(
                    nodeXml.GetInnerXml("//key"),
                    nodeXml.GetInnerXml("//value"));
            });

            Assert.AreEqual(1, value.Count);
            Assert.AreEqual("This is the key!", value[0].Key);
            Assert.AreEqual("Hello World", value[0].Value);
        }

        [Test]
        public void TestGetItemsMultipleItems()
        {
            var xml = @"
<nodes>
<node><key>This is the key!</key><value attribute='test'>Hello World</value></node>
<node><key>This is also a key!</key><value attribute='test'>Hello YOU</value></node>
</nodes>"
                .ToXPath();

            var value = xml.GetItems("//node", x =>
            {
                var nodeXml = x.ToXPath();

                return new KeyValuePair<string, string>(
                    nodeXml.GetInnerXml("//key"),
                    nodeXml.GetInnerXml("//value"));
            });

            Assert.AreEqual(2, value.Count);
            Assert.AreEqual("This is the key!", value[0].Key);
            Assert.AreEqual("Hello World", value[0].Value);
            Assert.AreEqual("This is also a key!", value[1].Key);
            Assert.AreEqual("Hello YOU", value[1].Value);
        }

        [Test]
        public void TestParseXmlFeed()
        {
            var rss =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<rss xmlns:content=""http://purl.org/rss/1.0/modules/content/"" version=""2.0"">
  <channel>
    <title>Gumtree.com - rubber duck in Classifieds in London</title>
    <link>http://www.gumtree.com/all/london/rubber+duck</link>
    <description>Latest posting for rubber duck in Classifieds in London</description>
    <language>en_GB</language>
    <image>
      <title>Gumtree.com</title>
      <url>http://www.gumtree.com/images/logo.gif</url>
      <link>http://www.gumtree.com</link>
      <width>142</width>
      <height>18</height>
    </image>
    <item>
      <title>360 Operators (Rubber Duck) &amp; Shovel : East London</title>
      <link>http://www.gumtree.com/p/jobs/360-operators-rubber-duck-shovel-east-london/100588749</link>
      <content:encoded>&amp;#13;&amp;#10;360 Operators (Rubber Duck) &amp;#38; Shovel&amp;#13;&amp;#10;Location: Mitcham&amp;#13;&amp;#10;Salary: Negotiable&amp;#13;&amp;#10;&amp;#13;&amp;#10;Competent and reliable Wheeled 360 Excavator (Rubber Duck) drivers required for a Haulage and Waste Management company in East London and Essex.&amp;#13;&amp;#10;&amp;#13;&amp;#10;Must have valid CPCS or NPORS tickets&amp;#13;&amp;#10;Additional advantage including Loading Shovel, Articulated Dump Truck, Dozer and Crusher&amp;#13;&amp;#10;&amp;#13;&amp;#10;Previous experience essential.&amp;#13;&amp;#10;&amp;#13;&amp;#10;Please forward your CV ASAP to donna.m@killoughery.eu or call 0208 685 5466&amp;#13;&amp;#10;</content:encoded>
      <pubDate>Tue, 17 Apr 2012 16:31:00 GMT</pubDate>
    </item>
  </channel>
</rss>";

            var xml = rss.ToXPath();

            var items = xml.GetMatches("//item", 0);

            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("360 Operators (Rubber Duck) &amp; Shovel : East London", items[0].GetInnerXml("//title"));
        }
    }
}
