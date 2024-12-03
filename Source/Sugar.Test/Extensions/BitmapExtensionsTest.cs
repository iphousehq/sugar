using System.IO;
using NUnit.Framework;
using SkiaSharp;

namespace Sugar.Extensions
{
    [TestFixture]
    public class BitmapExtensionTest
    {
        private readonly string imageLocation = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples/grass.jpg");

        [Test]
        public void TestCropImage()
        {
            using var image = SKBitmap.Decode(imageLocation);

            var resizedImage = image.CropImage(320, 200);

            Assert.That(resizedImage.Width, Is.EqualTo(320));
            Assert.That(resizedImage.Height, Is.EqualTo(200));

            resizedImage.Dispose();
        }

        [Test]
        public void TestCropImageToMaximumDimension()
        {
            using var image = SKBitmap.Decode(imageLocation);

            var resizedImage = image.CropImage(90);

            Assert.That(resizedImage.Width, Is.EqualTo(90));

            resizedImage.Dispose();
        }

        [Test]
        public void TestResizeImage()
        {
            using var image = SKBitmap.Decode(imageLocation);

            var resizedImage = image.ResizeImage(new SKSizeI(320, 200), SKSamplingOptions.Default);

            Assert.That(resizedImage.Width, Is.EqualTo(320));
            Assert.That(resizedImage.Height, Is.EqualTo(200));

            resizedImage.Dispose();
        }

        [Test]
        public void TestResizeImageToMaximumDimension()
        {
            using var image = SKBitmap.Decode(imageLocation);

            var resizedImage = image.ResizeImage(90, SKSamplingOptions.Default);

            Assert.That(resizedImage.Width, Is.EqualTo(90));

            resizedImage.Dispose();
        }

        [Test]
        public void TestToBytes()
        {
            using var image = SKBitmap.Decode(imageLocation);

            var bytes = image.ToBytes(SKEncodedImageFormat.Png, 100);

            Assert.That(bytes.Length, Is.GreaterThan(0));;
        }
    }
}
