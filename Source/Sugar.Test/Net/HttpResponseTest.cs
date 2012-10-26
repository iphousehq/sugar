using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class HttpResponseTest
    {
        [Test]
        public void TestConstructor()
        {
            var response = new HttpResponse();

            Assert.IsNotNull(response.Cookies);
            Assert.AreEqual(0, response.Headers.Count);
        }

        [Test]
        public void TestToString()
        {
            var response = new HttpResponse();

            Assert.AreEqual(string.Empty, response.ToString());
        }
    }
}
