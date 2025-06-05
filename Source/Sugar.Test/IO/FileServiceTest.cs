using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace Sugar.IO
{
    [TestFixture]
    public class FileServiceTest
    {
        private FileService service;

        private string oldDirectory;

        [SetUp]
        public void SetUp()
        {
            service = new FileService();

            // Set location
            oldDirectory = Environment.CurrentDirectory;
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }

        [TearDown]
        public void TearDown()
        {
            Environment.CurrentDirectory = oldDirectory;
        }

        [Test]
        public void TestGetFilenames()
        {
            Directory.SetCurrentDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Samples/Child"));

            var filenames = service.GetFilenames("*.txt");

            Assert.That(filenames.Count, Is.EqualTo(1));
            Assert.That(filenames[0].EndsWith("\\Samples\\Child\\Test.txt"), Is.True);
        }

        [Test]
        public void TestGetFilenamesTwoDeep()
        {
            Directory.SetCurrentDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Samples/Child"));

            var filenames = service.GetFilenames("*", 1);

            Assert.That(filenames.Count, Is.EqualTo(5));
            Assert.That(filenames[0].EndsWith("\\Samples\\Child\\Test.txt"), Is.True);
            Assert.That(filenames[1].EndsWith("\\Samples\\grass.jpg"), Is.True);
            Assert.That(filenames[2].EndsWith("\\Samples\\node-extension.html"), Is.True);
            Assert.That(filenames[3].EndsWith("\\Samples\\One.txt"), Is.True);
            Assert.That(filenames[4].EndsWith("\\Samples\\Two.txt"), Is.True);
        }

        [Test]
        public void TestFileIgnored()
        {
            var ignored = service.IsIgnored("c:\\test.txt", "*.txt");

            Assert.That(ignored, Is.True);
        }

        [Test]
        public void TestFileNotIgnored()
        {
            var ignored = service.IsIgnored("c:\\test.cs", "*.txt");

            Assert.That(ignored, Is.False);
        }

        [Test]
        public void TestFileIgnoredInIgnoredFolder()
        {
            var ignored = service.IsIgnored("c:\\bin\\test.txt", "*bin\\*");

            Assert.That(ignored, Is.True);
        }

        [Test]
        public void TestWriteAllBytesChecksIfExistsThenReadAllBytes()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"test.txt");

            var utf8Bytes = "hello world 👹!"u8.ToArray();

            service.WriteAllBytes(path, utf8Bytes);

            var exists = File.Exists(path);

            Assert.That(exists, Is.True);

            var readBytes = File.ReadAllBytes(path);

            Assert.That(readBytes.Length, Is.EqualTo(utf8Bytes.Length));

            Assert.That(readBytes[0], Is.EqualTo(utf8Bytes[0]));

            var decodedText = Encoding.UTF8.GetString(readBytes);

            Assert.That(decodedText, Is.EqualTo("hello world 👹!"));

            File.Delete(path);
        }
    }
}
