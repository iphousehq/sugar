using NUnit.Framework;
using Sugar.Net;

namespace Sugar.Html
{
    [TestFixture]
    public class HtmlDocumentTest
    {
        [Test]
        public void TestLoadImageUrlFromHtml()
        {
            var html = new HtmlDocument("<img src='http://www.google.com/google.jpg' alt='Google'/>");

            var urls = html.GetAttributeList("//img", "src");

            Assert.AreEqual(urls.Count, 1);
            Assert.AreEqual("http://www.google.com/google.jpg", urls[0]);
        }

        [Test]
        public void TestLoadImagesUrlFromHtml()
        {
            var html = new HtmlDocument("<img src='http://www.google.com/google.jpg' alt='Google'/>"
                                        + "<img src='http://www.yahoo.com/yahoo.jpg' alt='Yahoo'/>");

            var urls = html.GetAttributeList("//img", "src");

            Assert.AreEqual(urls.Count, 2);
            Assert.AreEqual("http://www.google.com/google.jpg", urls[0]);
            Assert.AreEqual("http://www.yahoo.com/yahoo.jpg", urls[1]);
        }

        [Test]
        public void TestGetDocumentBaseFromRootUrlHtmlNoBaseTag()
        {
            var html = new HtmlDocument("");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlNoBaseTag()
        {
            var html = new HtmlDocument("");

            var url = html.GetDocumentBaseUrl("http://www.example.com/images");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithNonRootedBaseTag()
        {
            var html = new HtmlDocument("<base href='images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://www.example.com/assets/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithNonRootedBaseTag()
        {
            var html = new HtmlDocument("<base href='images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithSpacesWithNonRootedBaseTag()
        {
            var html = new HtmlDocument("<base href='images' />");

            var url = html.GetDocumentBaseUrl(" http://www.example.com ");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }


        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithNonRootedBaseTagWithSpaces()
        {
            var html = new HtmlDocument("<base href=' images ' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithRootedBaseTag()
        {
            var html = new HtmlDocument("<base href='/images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }


        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithHttpBaseTag()
        {
            var html = new HtmlDocument("<base href='http://example.com/images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithHttpBaseTag()
        {
            var html = new HtmlDocument("<base href='http://example.com/images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetFullImageUrlHttpImageUrlRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = "http://www.example.com/image.jpg";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlRootedImageUrlRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = "/image.jpg";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlNonRootedImageUrlRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = "image.jpg";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlHttpImageUrlNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = "http://www.example.com/image.jpg";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);

            imageUrl = "HTTP://WWW.TWEED-JACKET.COM/img/HOME PAGE PHOTOS/Carron-Jacket-Waistcoat-and.jpg";

            result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("HTTP://WWW.TWEED-JACKET.COM/img/HOME PAGE PHOTOS/Carron-Jacket-Waistcoat-and.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlRootedImageUrlWithSpacesRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = " /image.jpg ";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlNonRootedImageUrlWithSpacesRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = " image.jpg ";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlHttpImageUrlWithSpacesNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = " http://www.example.com/image.jpg ";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlRootedImageWithSpacesUrlNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = " /image.jpg ";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlRootedImageUrlNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = "/image.jpg";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlNonRootedImageUrlNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = "image.jpg";

            var result = HtmlDocument.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/assets/image.jpg", result);
        }
    }
}
