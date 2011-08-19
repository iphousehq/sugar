using Moq;
using NUnit.Framework;
using Sugar.IO;

namespace Sugar.Config
{
    [TestFixture]
    public class ConfigTest : AutoMockingTest
    {
        private Config config;

        [SetUp]
        public void SetUp()
        {
            config = Create<Config>();
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
            Mock<IFileService>()
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
    }
}
