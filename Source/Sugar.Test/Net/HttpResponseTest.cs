using System.Collections.Generic;
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

            Assert.That(response.Cookies, Is.Not.Null);
            Assert.That(response.Headers.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestToStringOnEmptyRepsonse()
        {
            var response = new HttpResponse();

            Assert.That(response.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestToStringWithEncoding()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

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

            Assert.That(response.ToString(Encoding.GetEncoding(936)), Is.EqualTo("0\0︹策︴"));
        }

        [Test]
        [Ignore("This doesn't seem to work with .NET Core??")]
        public void TestToStringWithEncodingReadFromHeader()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var encoding = Encoding.GetEncoding(936);

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
                                       },
                               Headers = new Dictionary<string, string>
                                         {
                                             {"Content-Type", "charset=" + encoding.HeaderName}
                                         }
                           };

            Assert.That(response.ToString(), Is.EqualTo("0\0︹策︴"));
        }
    }
}
