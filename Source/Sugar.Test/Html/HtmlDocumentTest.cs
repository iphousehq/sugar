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
        public void TestGetAttributeFromRootNode()
        {
            var document = Html.Load("<html class='test'><p><b href='value'>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("test", document.GetAttribute("class"));
        }

        [Test]
        public void TestGetAttribute()
        {
            var document = Html.Load("<html><p><b href='value'>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("value", document.GetAttribute("//b", "href"));
        }

        [Test]
        public void TestGetAttributes()
        {
            var document = Html.Load("<html><p><b href='value' title='this is the title'>hello</b></p><span>world</span><p>hi</p></html>");

            var results = document.GetAttributes("//b", "href", "title");

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("value", results[0]);
            Assert.AreEqual("this is the title", results[1]);
        }

        [Test]
        public void TestGetAttributeList()
        {
            var document = Html.Load("<html><p><b href='value'>hello</b></p><span>world</span><p><b href='2'>hi</b></p></html>");

            Assert.AreEqual("value", document.GetAttributeList("//b", "href")[0]);
            Assert.AreEqual("2", document.GetAttributeList("//b", "href")[1]);
        }

        [Test]
        public void TestGetAttributesList()
        {
            var document = Html.Load("<html><p><b href='value' title='three'>hello</b></p><span>world</span><p><b href='2' title='four'>hi</b></p></html>");

            var results = document.GetAttributesList("//b", "href", "title");

            Assert.AreEqual(4, results.Count);
            Assert.AreEqual("value", results[0]);
            Assert.AreEqual("2", results[1]);
            Assert.AreEqual("three", results[2]);
            Assert.AreEqual("four", results[3]);
        }

        [Test]
        public void TestGetNodes()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("<p><b>hello</b></p>", document.GetNodes("//p")[0].GetInnerHtml());
            Assert.AreEqual("hi", document.GetNodes("//p")[1].GetInnerText());
        }

        [Test]
        public void TestGetNodesWithMultipleXpath()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            var nodes = document.GetNodes("//p", "//span");

            Assert.AreEqual(3, nodes.Count);
            Assert.AreEqual("hello", nodes[0].GetInnerText());
            Assert.AreEqual("hi", nodes[1].GetInnerText());
            Assert.AreEqual("world", nodes[2].GetInnerText());
        }

        [Test]
        public void TestGetNodesWithPartialClass()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p class='test off'>hi</p></html>");

            Assert.AreEqual("hi", document.GetNodes("//p[contains(@class,'test')]")[0].GetInnerText());
        }

        [Test]
        public void TestGetNodesGetAttributes()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p class='test'>hi</p></html>");

            Assert.AreEqual("test", document.GetNodes("//p")[1].GetAttribute("class"));
        }

        [Test]
        public void TestContains()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.IsTrue(document.Contains("hello"));
        }

        [Test]
        public void TestGetNode()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("<p><b>hello</b></p>", document.GetNode("//p").GetInnerHtml());
        }

        [Test]
        public void TestGetNodeWhenDoesntExist()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.AreEqual("", document.GetNode("//div").GetInnerHtml());
        }

        [Test]
        public void TestNodeExistsTrue()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.True(document.NodeExists("//p"));
        }

        [Test]
        public void TestNodeExistsFalse()
        {
            var document = Html.Load("<html><p><b>hello</b></p><span>world</span><p>hi</p></html>");

            Assert.False(document.NodeExists("//div"));
        }
    }
}
