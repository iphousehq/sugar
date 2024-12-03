using System;
using NUnit.Framework;
using SkiaSharp;
using System.IO;

namespace Sugar.Extensions
{
    [TestFixture]
    public class MimeTypeExtensions
    {
        private readonly string imageLocation = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples/grass.jpg");

        [Test]
        public void TestGetMimeTypeFromStream()
        {
            var stream = new FileStream(imageLocation, FileMode.Open);

            var mime = stream.GetMimeType();

            Assert.That(mime, Is.EqualTo("image/jpeg"));
        }

        [Test]
        public void GetImageFormatFromMimeType()
        {
            var format = "image/png".ToImageFormat();

            Assert.That(format, Is.EqualTo(SKEncodedImageFormat.Png));
        }

        [Test]
        public void GetImageFormatFromMimeTypeNotRecognised()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "wtf".ToImageFormat());
        }

    }
}
