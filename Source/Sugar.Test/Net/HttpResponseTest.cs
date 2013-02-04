using System.Text;
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
        public void TestToStringOnEmptyRepsonse()
        {
            var response = new HttpResponse();

            Assert.AreEqual(string.Empty, response.ToString());
        }

        [Test]
        public void TestToStringWithEncoding()
        {
            var response = new HttpResponse
                               {
                                   Bytes = new byte[]
                                               {
                                                   0x30,
                                                   0x00,
                                                   0xA6,
                                                   0xE2,
                                                   0xB2,
                                                   0xDF,
                                                   0xA6,
                                                   0xF5
                                               }
                               };

            Assert.AreEqual("0\0︹策︴", response.ToString(Encoding.GetEncoding(936)));
        }
    }
}
