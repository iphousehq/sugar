using System.IO;
using NUnit.Framework;
using SkiaSharp;

namespace Sugar.Extensions
{
    [TestFixture]
    public class BytesExtensionsTest
    {
        private readonly string imageLocation = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples/grass.jpg");

        [Test]
        public void TestToBitmapFromExtractedBytes()
        {
            using var image = SKBitmap.Decode(imageLocation);

            var bytes = image.ToBytes(SKEncodedImageFormat.Png);

            var reconstructedImage = bytes.ToBitmap();

            Assert.That(reconstructedImage.Width, Is.EqualTo(512));
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
