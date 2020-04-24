using System;
using NUnit.Framework;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    [TestFixture]
    [Parallelizable]
    public class ParametersExtensionsTest
    {
        [Test]
        public void TestParseParameters()
        {
            var parameters = ParametersExtensions.ParseCommandLine("one two three");

            Assert.AreEqual(3, parameters.Count);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("two", parameters[1]);
            Assert.AreEqual("three", parameters[2]);
        }

        [Test]
        public void TestParseParametersWithQuotes()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"one ""two three"" four");

            Assert.AreEqual(3, parameters.Count);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("two three", parameters[1]);
            Assert.AreEqual("four", parameters[2]);
        }

        [Test]
        public void TestParseParametersWithTwoQuotes()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"one ""two three"" four ""five six""");

            Assert.AreEqual(4, parameters.Count);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("two three", parameters[1]);
            Assert.AreEqual("four", parameters[2]);
            Assert.AreEqual("five six", parameters[3]);
        }

        [Test]
        public void TestParseParametersWithQuotesAndOddCharacters()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"""http://www.google.com""");

            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual("http://www.google.com", parameters[0]);
        }

        [Test]
        public void TestParseParametersWithNonMatchingQuotes()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"one ""two three four");

            Assert.AreEqual(2, parameters.Count);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("two three four", parameters[1]);
        }

        [Test]
        public void TestParseParametersWithFlags()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"-one ""two three"" --four /five");

            Assert.AreEqual(4, parameters.Count);
            Assert.AreEqual("-one", parameters[0]);
            Assert.AreEqual("two three", parameters[1]);
            Assert.AreEqual("--four", parameters[2]);
            Assert.AreEqual("/five", parameters[3]);
        }

        [Test]
        public void TestParseParameterPassesWithMinus()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"""-05:00:00""");

            Assert.AreEqual(@"""-05:00:00""",  parameters[0]);
        }
    }
}
