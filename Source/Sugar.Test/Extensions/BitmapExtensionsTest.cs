using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class BitmapExtensionTest
    {
        private readonly string imageLocation = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples/grass.jpg");

        [Test]
        public void TestCropImage()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var resizedImage = image.CropImage(320, 200);

                Assert.That(resizedImage.Width, Is.EqualTo(320));
                Assert.That(resizedImage.Height, Is.EqualTo(200));

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestCropImageToMaximumDimension()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var resizedImage = image.CropImage(90);

                Assert.That(resizedImage.Width, Is.EqualTo(90));

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestGetMimeType()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var mime = image.GetMimeType();

                Assert.That(mime, Is.EqualTo("image/jpeg"));
            }
        }

        [Test]
        public void TestResizeImage()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var resizedImage = image.ResizeImage(320, 200);

                Assert.That(resizedImage.Width, Is.EqualTo(320));
                Assert.That(resizedImage.Height, Is.EqualTo(200));

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestResizeImageToMaximumDimension()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var resizedImage = image.ResizeImage(90);

                Assert.That(resizedImage.Width, Is.EqualTo(90));

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestToBytes()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var bytes = image.ToBytes(ImageFormat.Png);

                Assert.That(bytes.Length, Is.GreaterThan(0));;
            }
        }
    }
}
