using System;
using NUnit.Framework;

namespace Sugar.Configuration
{
    [TestFixture]
    public class ConfigLineTest
    {
        [Test]
        public void TestParseConfigLine()
        {
            const string input = "test=value";

            ConfigLine line;

            var result = ConfigLine.TryParse(input, out line);

            Assert.IsTrue(result);
            Assert.AreEqual("test", line.Key);
            Assert.AreEqual("value", line.Value);
            Assert.IsFalse(line.IsComment);
        }

        [Test]
        public void TestParseConfigLineWhenAComnent()
        {
            const string input = "#comment";

            ConfigLine line;

            var result = ConfigLine.TryParse(input, out line);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, line.Key);
            Assert.AreEqual("comment", line.Value);
            Assert.IsTrue(line.IsComment);
        }

        [Test]
        public void TestParseConfigLineWhenAComnentWithDifferentIndicator()
        {
            const string input = @"//comment";

            ConfigLine line;

            var result = ConfigLine.TryParse(input, out line, @"//");

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, line.Key);
            Assert.AreEqual("comment", line.Value);
            Assert.IsTrue(line.IsComment);
        }


        [Test]
        public void TestParseConfigLineWhenAComnentWithInvalidIndicator()
        {
            const string input = @"//comment";

            ConfigLine line;

            Assert.Throws<ArgumentException>(() => ConfigLine.TryParse(input, out line, ""));
        }

        [Test]
        public void TestParseConfigLineSetSectionName()
        {
            const string input = "test=value";

            ConfigLine line;

            ConfigLine.TryParse(input, out line, section: "Main");

            Assert.AreEqual("Main", line.Section);
        }

        [Test]
        public void TestParseConfigLineWithEqualsInValue()
        {
            const string input = "test=value=something";

            ConfigLine line;

            ConfigLine.TryParse(input, out line);

            Assert.AreEqual("value=something", line.Value);
        }

        [Test]
        public void TestParseConfigLineWithNoEqualsInValue()
        {
            const string input = "test value is here";

            ConfigLine line;

            ConfigLine.TryParse(input, out line);

            Assert.AreEqual("test value is here", line.Key);
            Assert.AreEqual("", line.Value);
        }
    }
}
