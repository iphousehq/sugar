using NUnit.Framework;

namespace Comsec.Sugar.Net
{
    [TestFixture]
    public class HttpRequestTest
    {
        [Test]
        public void TestAddHeader()
        {
            var request = new HttpRequest();

            request.WithHeader("test", "value");

            Assert.AreEqual("value", request.Headers["test"]);
        }
    }
}
