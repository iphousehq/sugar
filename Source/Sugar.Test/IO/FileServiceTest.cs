using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using NUnit.Framework;
using Sugar.Extensions;

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

            Assert.AreEqual(1, filenames.Count);
            Assert.IsTrue(filenames[0].EndsWith("\\Samples\\Child\\Test.txt"));
        }

        [Test]
        public void TestGetFilenamesTwoDeep()
        {
            Directory.SetCurrentDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Samples/Child"));

            var filenames = service.GetFilenames("*", 1);

            Assert.AreEqual(5, filenames.Count);
            Assert.IsTrue(filenames[0].EndsWith("\\Samples\\Child\\Test.txt"));
            Assert.IsTrue(filenames[1].EndsWith("\\Samples\\grass.jpg"));
            Assert.IsTrue(filenames[2].EndsWith("\\Samples\\node-extension.html"));
            Assert.IsTrue(filenames[3].EndsWith("\\Samples\\One.txt"));
            Assert.IsTrue(filenames[4].EndsWith("\\Samples\\Two.txt"));
        }

        [Test]
        public void TestFileIgnored()
        {
            var ignored = service.IsIgnored("c:\\test.txt", "*.txt");

            Assert.IsTrue(ignored);
        }

        [Test]
        public void TestFileNotIgnored()
        {
            var ignored = service.IsIgnored("c:\\test.cs", "*.txt");

            Assert.IsFalse(ignored);
        }

        [Test]
        public void TestFileIgnoredInIgnoredFolder()
        {
            var ignored = service.IsIgnored("c:\\bin\\test.txt", "*bin\\*");

            Assert.IsTrue(ignored);
        }

        [Test]
        public void TestWriteAllBytes()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"test.txt");
            var bytes = Encoding.ASCII.GetBytes("hello world");

            service.WriteAllBytes(path, bytes);

            var exists = File.Exists(path);

            Assert.True(exists);

            File.Delete(path);
        }
    }
}
