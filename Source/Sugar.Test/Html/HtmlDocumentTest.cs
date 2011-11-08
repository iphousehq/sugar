﻿using NUnit.Framework;
using Sugar.Net;

namespace Sugar.Html
{
    [TestFixture]
    public class HtmlDocumentTest
    {
        [Test]
        public void TestLoadImageUrlFromHtml()
        {
            var html = Html.Load("<img src='http://www.google.com/google.jpg' alt='Google'/>");

            var urls = html.GetAttributeList("//img", "src");

            Assert.AreEqual(urls.Count, 1);
            Assert.AreEqual("http://www.google.com/google.jpg", urls[0]);
        }

        [Test]
        public void TestLoadImagesUrlFromHtml()
        {
            var html = Html.Load("<img src='http://www.google.com/google.jpg' alt='Google'/>"
                                        + "<img src='http://www.yahoo.com/yahoo.jpg' alt='Yahoo'/>");

            var urls = html.GetAttributeList("//img", "src");

            Assert.AreEqual(urls.Count, 2);
            Assert.AreEqual("http://www.google.com/google.jpg", urls[0]);
            Assert.AreEqual("http://www.yahoo.com/yahoo.jpg", urls[1]);
        }

        [Test]
        public void TestGetDocumentBaseFromRootUrlHtmlNoBaseTag()
        {
            var html = Html.Load("");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlNoBaseTag()
        {
            var html = Html.Load("");

            var url = html.GetDocumentBaseUrl("http://www.example.com/images");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithNonRootedBaseTag()
        {
            var html = Html.Load("<base href='images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://www.example.com/assets/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithNonRootedBaseTag()
        {
            var html = Html.Load("<base href='images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithSpacesWithNonRootedBaseTag()
        {
            var html = Html.Load("<base href='images' />");

            var url = html.GetDocumentBaseUrl(" http://www.example.com ");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }


        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithNonRootedBaseTagWithSpaces()
        {
            var html = Html.Load("<base href=' images ' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithRootedBaseTag()
        {
            var html = Html.Load("<base href='/images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://www.example.com/images", url.DomainWithProtocol + url.Path);
        }


        [Test]
        public void TestGetDocumentBaseFromRootedUrlHtmlWithHttpBaseTag()
        {
            var html = Html.Load("<base href='http://example.com/images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com");

            Assert.AreEqual("http://example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetDocumentBaseFromNonRootedUrlHtmlWithHttpBaseTag()
        {
            var html = Html.Load("<base href='http://example.com/images' />");

            var url = html.GetDocumentBaseUrl("http://www.example.com/assets");

            Assert.AreEqual("http://example.com/images", url.DomainWithProtocol + url.Path);
        }

        [Test]
        public void TestGetFullImageUrlHttpImageUrlRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = "http://www.example.com/image.jpg";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlRootedImageUrlRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = "/image.jpg";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlNonRootedImageUrlRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = "image.jpg";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlHttpImageUrlNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = "http://www.example.com/image.jpg";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);

            imageUrl = "HTTP://WWW.TWEED-JACKET.COM/img/HOME PAGE PHOTOS/Carron-Jacket-Waistcoat-and.jpg";

            result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("HTTP://WWW.TWEED-JACKET.COM/img/HOME PAGE PHOTOS/Carron-Jacket-Waistcoat-and.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlRootedImageUrlWithSpacesRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = " /image.jpg ";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlNonRootedImageUrlWithSpacesRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com");

            var imageUrl = " image.jpg ";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlHttpImageUrlWithSpacesNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = " http://www.example.com/image.jpg ";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlRootedImageWithSpacesUrlNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = " /image.jpg ";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlRootedImageUrlNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = "/image.jpg";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/image.jpg", result);
        }

        [Test]
        public void TestGetFullImageUrlNonRootedImageUrlNonRootedBaseUrl()
        {
            var baseUrl = new Url("http://www.example.com/assets");

            var imageUrl = "image.jpg";

            var result = Html.GetFullImageUrl(imageUrl, baseUrl);

            Assert.AreEqual("http://www.example.com/assets/image.jpg", result);
        }

        [Test]
        public void TestInnerHtml()
        {
            var document = Html.Load("<html>hello</html>");

            Assert.AreEqual("<html>hello</html>", document.GetInnerHtml());
        }

        [Test]
        public void TestInnerHtmlWithXPath()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span></html>");

            Assert.AreEqual("<b>hello</b>", document.GetInnerHtml("//p"));
        }

        [Test]
        public void TestInnerHtmlListWithXPath()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("<b>hello</b>", document.GetInnerHtmlList("//p")[0]);
            Assert.AreEqual("hi", document.GetInnerHtmlList("//p")[1]);
        }

        [Test]
        public void TestInnerText()
        {
            var document = Html.Load("<html>hello</html>");

            Assert.AreEqual("hello", document.GetInnerText());
        }

        [Test]
        public void TestInnerTextWithXPath()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span></html>");

            Assert.AreEqual("hello", document.GetInnerText("//p"));
        }

        [Test]
        public void TestInnerTextListWithXPath()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("hello", document.GetInnerTextList("//p")[0]);
            Assert.AreEqual("hi", document.GetInnerTextList("//p")[1]);
        }

        [Test]
        public void TestGetAttribute()
        {
            var document = Html.Load("<html><p><b href='value'>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("value", document.GetAttribute("//b", "href"));
        }

        [Test]
        public void TestGetAttributeList()
        {
            var document = Html.Load("<html><p><b href='value'>hello</b></p><span>world</span><p><b href='2'>hi</b></p></html>");

            Assert.AreEqual("value", document.GetAttributeList("//b", "href")[0]);
            Assert.AreEqual("2", document.GetAttributeList("//b", "href")[1]);
        }

        [Test]
        public void TestGetNodes()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("<b>hello</b>", document.GetNodes("//p")[0].GetInnerHtml());
            Assert.AreEqual("hi", document.GetNodes("//p")[1].GetInnerText());
        }

        [Test]
        public void TestContains()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.IsTrue(document.Contains("hello"));
        }
    }
}