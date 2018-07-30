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

                Assert.AreEqual(320, resizedImage.Width);
                Assert.AreEqual(200, resizedImage.Height);

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestCropImageToMaximumDimension()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var resizedImage = image.CropImage(90);

                Assert.AreEqual(90, resizedImage.Width);

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestGetMimeType()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var mime = image.GetMimeType();

                Assert.AreEqual("image/jpeg", mime);
            }
        }

        [Test]
        public void TestResizeImage()
        {
            using (var image = new Bitmap(imageLocation))
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
            using (var image = new Bitmap(imageLocation))
            {
                var resizedImage = image.ResizeImage(90);

                Assert.AreEqual(90, resizedImage.Width);

                resizedImage.Dispose();
            }
        }

        [Test]
        public void TestToBytes()
        {
            using (var image = new Bitmap(imageLocation))
            {
                var bytes = image.ToBytes(ImageFormat.Png);

                Assert.Less(0, bytes.Length);
            }
        }
    }
}