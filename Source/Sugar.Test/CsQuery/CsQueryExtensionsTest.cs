using CsQuery;
using NUnit.Framework;

namespace Sugar.CsQuery
{
    [TestFixture]
    public class CsQueryExtensionsTest
    {
        [Test]
        public void TestGetAttributes()
        {
            var cq = CQ.Create("<html><p><b href='value'>hello</b></p><span>world</span><p><b href='2'>hi</b></p></html>");

            var results = cq["b"].GetAttributes("href");

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("value", results[0]);
            Assert.AreEqual("2", results[1]);
        }

        [Test]
        public void TestGetDocumentBaseFromRootUrlHtmlNoBaseTag()
        {
            var cq = CQ.Create("");

            var url = cq.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlNoBaseTag()
        {
            var cq = CQ.Create("");

            var url = cq.GetDocumentBaseUrl("http://www.example.com/images");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithNonRootedBaseTag()
        {
            var cq = CQ.Create("<base href='images' />");

            var url = cq.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://www.example.com/assets/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithNonRootedBaseTag()
        {
            var cq = CQ.Create("<base href='images' />");

            var url = cq.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithSpacesWithNonRootedBaseTag()
        {
            var cq = CQ.Create("<base href='images' />");

            var url = cq.GetDocumentBaseUrl(" http://www.example.com ");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }


        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithNonRootedBaseTagWithSpaces()
        {
            var cq = CQ.Create("<base href=' images ' />");

            var url = cq.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithRootedBaseTag()
        {
            var cq = CQ.Create("<base href='/images' />");

            var url = cq.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }


        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithHttpBaseTag()
        {
            var html = CQ.Create("<base href='http://example.com/images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithHttpBaseTag()
        {
            var cq = CQ.Create("<base href='http://example.com/images' />");

            var url = cq.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithHttpBaseTagNull()
        {
            var cq = CQ.Create("<base href='' />");

            var url = cq.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/", url.DomainWithProtocol + url.Path);
        }
    }
}
