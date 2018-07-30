using NUnit.Framework;

namespace Sugar.Mime
{
    [TestFixture]
    public class MimeTypeTest
    {
        [Test]
        public void TestApplicationMimeType()
        {
            var mime = new ApplicationMime
                       {
                           ApplicationMimeType = ApplicationMimeType.MicrosoftWord
                       };

            var result = mime.ToString();

            Assert.AreEqual("application/msword", result);
        }

        [Test]
        public void TestAudioMimeType()
        {
            var mime = new AudioMime
                       {
                           AudioMimeType = AudioMimeType.Midi
                       };

            var result = mime.ToString();

            Assert.AreEqual("audio/midi", result);
        }

        [Test]
        public void TestImageMimeType()
        {
            var mime = new ImageMime
                       {
                           ImageMimeType = ImageMimeType.Jpeg
                       };

            var result = mime.ToString();

            Assert.AreEqual("image/jpeg", result);
        }

        [Test]
        public void TestTextMimeType()
        {
            var mime = new TextMime
                       {
                           TextMimeType = TextMimeType.Plain
                       };

            var result = mime.ToString();

            Assert.AreEqual("text/plain", result);
        }

        [Test]
        public void TestVideoMimeType()
        {
            var mime = new VideoMime
                       {
                           VideoMimeType = VideoMimeType.Avi
                       };

            var result = mime.ToString();

            Assert.AreEqual("video/avi", result);
        }
    }
}
