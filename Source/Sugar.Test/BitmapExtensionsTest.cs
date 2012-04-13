using System.Drawing;
using System.Drawing.Imaging;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class BitmapExtensionTest
    {
        private const string ImageLocation = "../../Samples/grass.jpg";

        [Test]
        public void TestImageResize()
        {
            using (var image = new Bitmap(ImageLocation))
            {
                var resizedImage = image.ResizeImage(320, 200);

                Assert.AreEqual(320, resizedImage.Width);
                Assert.AreEqual(200, resizedImage.Height);

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestResizeImageToMaximumDimension()
        {
            using (var image = new Bitmap(ImageLocation))
            {
                var resizedImage = image.ResizeImage(90);

                Assert.AreEqual(90, resizedImage.Width);

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestGetBytesFromBitmap()
        {
            using (var image = new Bitmap(ImageLocation))
            {
                var bytes = image.ToBytes(ImageFormat.Png);

                Assert.Less(0, bytes.Length);
            }
        }

        [Test]
        public void TestCreateBitmapFromExtractedBytes()
        {
            using (var image = new Bitmap(ImageLocation))
            {
                var bytes = image.ToBytes(ImageFormat.Png);

                var reconstructedImage = bytes.ToBitmap();

                Assert.AreEqual(512, reconstructedImage.Width);
            }
        }

        [Test]
        public void TestCreateBitmapFromEmptyBytes()
        {
            var bytes = new byte[10];

            var reconstructedImage = bytes.ToBitmap();

            Assert.IsNull(reconstructedImage);
        }

        [Test]
        public void TestGetMimeType()
        {
            using (var image = new Bitmap(ImageLocation))
            {
                var mime = image.GetMimeType();

                Assert.AreEqual("image/jpeg", mime);
            }
        }

        [Test]
        public void GetImageFormatFromMimeType()
        {
            var format = "image/png".GetImageFormatFromMimeType();

            Assert.AreEqual(ImageFormat.Png, format);
        }

        [Test]
        public void GetImageFormatFromMimeTypeNotRecognised()
        {
            var format = "wtf".GetImageFormatFromMimeType();

            Assert.AreEqual(ImageFormat.Jpeg, format);
        }
    }
}
