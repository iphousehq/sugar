using System.Drawing;
using System.Drawing.Imaging;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class ByteArrayExtensionsTest
    {
        private const string ImageLocation = "../../Samples/grass.jpg";

        [Test]
        public void TestToBitmapFromExtractedBytes()
        {
            using (var image = new Bitmap(ImageLocation))
            {
                var bytes = image.ToBytes(ImageFormat.Png);

                var reconstructedImage = bytes.ToBitmap();

                Assert.AreEqual(512, reconstructedImage.Width);
            }
        }

        [Test]
        public void TestToBitmapFromEmptyBytes()
        {
            var bytes = new byte[10];

            var reconstructedImage = bytes.ToBitmap();

            Assert.IsNull(reconstructedImage);
        }

        [Test]
        public void TestToStringValue()
        {
            var bytes = "hello".ToBytes();

            var value = bytes.ToStringValue();

            Assert.AreEqual("hello", value);
        }
    }
}