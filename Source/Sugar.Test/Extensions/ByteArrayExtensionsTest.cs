using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class ByteArrayExtensionsTest
    {
        private readonly string imageLocation = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples/grass.jpg");

        [Test]
        public void TestToBitmapFromExtractedBytes()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var bytes = image.ToBytes(ImageFormat.Png);

                var reconstructedImage = bytes.ToBitmap();

                Assert.That(reconstructedImage.Width, Is.EqualTo(512));
            }
        }

        [Test]
        public void TestToBitmapFromEmptyBytes()
        {
            var bytes = new byte[10];

            var reconstructedImage = bytes.ToBitmap();

            Assert.That(reconstructedImage, Is.Null);
        }
    }
}
