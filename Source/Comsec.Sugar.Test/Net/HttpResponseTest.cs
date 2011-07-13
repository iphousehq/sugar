using NUnit.Framework;

namespace Comsec.Sugar.Net
{
    [TestFixture]
    public class HttpResponseTest
    {
        [Test]
        public void TestToString()
        {
            var response = new HttpResponse();

            Assert.AreEqual(string.Empty, response.ToString());
        }
    }
}
