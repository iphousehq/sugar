using Moq;
using NUnit.Framework;
using Sugar.IO;

namespace Sugar.Configuration
{
    [TestFixture]
    public class ConfigTest
    {
        private Config config;
        private Mock<IFileService> fileService;

        [SetUp]
        public void SetUp()
        {
            fileService = new Mock<IFileService>();
            config = new Config {FileService = fileService.Object};
        }

        [Test]
        public void TestParseLines()
        {
            var results = config.Parse("test=value");

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("test", results[0].Key);
            Assert.AreEqual("value", results[0].Value);
        }

        [Test]
        public void TestParseLinesWithSection()
        {
            var results = config.Parse("[heading]\r\ntest=value");

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("heading", results[0].Section);
            Assert.AreEqual("test", results[0].Key);
            Assert.AreEqual("value", results[0].Value);
        }

        [Test]
        public void TestReadConfig()
        {
            fileService
                .Setup(call => call.ReadAllText("c:\\test.config"))
                .Returns("test=value");

            var results = config.Read("c:\\test.config");

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("test", results[0].Key);
            Assert.AreEqual("value", results[0].Value);
        }

        [Test]
        public void TestMergeConfig()
        {
            var toMerge = new Config();
            toMerge.Lines.Add(new ConfigLine { Key = "key", Value = "New Value", Section = "section" });

            config.Lines.Add(new ConfigLine { Key = "key", Value = "Old Value", Section = "section" });

            var result = config.Merge(toMerge);

            Assert.AreEqual(1, result.Lines.Count);
            Assert.AreEqual("New Value", result.Lines[0].Value);
        }

        [Test]
        public void TestMergeConfigIgnoresCase()
        {
            var toMerge = new Config();
            toMerge.Lines.Add(new ConfigLine { Key = "key", Value = "New Value", Section = "section" });

            config.Lines.Add(new ConfigLine { Key = "Key", Value = "Old Value", Section = "Section" });

            var result = config.Merge(toMerge);

            Assert.AreEqual(1, result.Lines.Count);
            Assert.AreEqual("New Value", result.Lines[0].Value);
        }

        [Test]
        public void TestGetLinesWithNoValues()
        {
            var results = Config.FromText("[heading]\r\ntest\r\nvalue\r\nlines").GetSection("heading");

            Assert.AreEqual("test", results[0].Key);
            Assert.AreEqual("value", results[1].Key);
            Assert.AreEqual("lines", results[2].Key);
        }

        [Test]
        public void TestSetConfigLine()
        {
            config = Config.FromText("");

            config.SetValue("section", "key", "value");

            Assert.AreEqual("section", config.Lines[0].Section);
            Assert.AreEqual("key", config.Lines[0].Key);
            Assert.AreEqual("value", config.Lines[0].Value);
        }

        [Test]
        public void TestSetConfigLineDoesntDuplicate()
        {
            config = Config.FromText("");

            config.SetValue("section", "key", "value1");
            config.SetValue("section", "key", "value2");

            Assert.AreEqual("section", config.Lines[0].Section);
            Assert.AreEqual("key", config.Lines[0].Key);
            Assert.AreEqual("value2", config.Lines[0].Value);
        }

        [Test]
        public void TestGetConfigLine()
        {
            config = Config.FromText("[section]\r\nkey=bob");

            var result = config.GetValue("section", "key", "default");

            Assert.AreEqual("bob", result);
        }

        [Test]
        public void TestGetConfigLineMixedCase()
        {
            config = Config.FromText("[Section]\r\nKey=bob");

            var result = config.GetValue("section", "key", "default");

            Assert.AreEqual("bob", result);
        }

        [Test]
        public void TestGetConfigLineMissing()
        {
            config = Config.FromText("[Section]\r\nNo Key=bob");

            var result = config.GetValue("section", "key", "default");

            Assert.AreEqual("default", result);
        }

        [Test]
        public void TestToString()
        {
            config = Config.FromText("");

            config.SetValue("section", "key", "default");

            var result = config.ToString();

            Assert.AreEqual("[section]\r\nkey=default\r\n", result);
        }

        [Test]
        public void TestToStringMultipleLines()
        {
            config = Config.FromText("");

            config.SetValue("section", "key1", "default");
            config.SetValue("section", "key2", "default");

            var result = config.ToString();

            Assert.AreEqual("[section]\r\nkey1=default\r\nkey2=default\r\n", result);
        }

        [Test]
        public void TestToStringMultipleSections()
        {
            config = Config.FromText("");

            config.SetValue("section1", "key1", "default");
            config.SetValue("section2", "key2", "default");

            var result = config.ToString();

            Assert.AreEqual("[section1]\r\nkey1=default\r\n\r\n[section2]\r\nkey2=default\r\n", result);
        }

        [Test]
        public void TestDeleteValue()
        {
            config = Config.FromText("");

            config.SetValue("section2", "key1", "default");
            config.SetValue("section2", "key2", "default");
            config.Delete("section2", "key1");

            var result = config.ToString();

            Assert.AreEqual("[section2]\r\nkey2=default\r\n", result);
        }
    }
}
