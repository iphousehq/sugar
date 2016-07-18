using NUnit.Framework;

namespace Sugar.Command
{
    [TestFixture]
    public class ParameterParserTest
    {
        private ParameterParser parser;

        [SetUp]
        public void TestParseRead()
        {
            parser = new ParameterParser();
        }

        [Test]
        public void TestParseParameters()
        {
            var parameters = parser.Parse("one two three");

            Assert.AreEqual(3, parameters.Count);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("two", parameters[1]);
            Assert.AreEqual("three", parameters[2]);
        }

        [Test]
        public void TestParseParametersWithQuotes()
        {
            var parameters = parser.Parse(@"one ""two three"" four");

            Assert.AreEqual(3, parameters.Count);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("two three", parameters[1]);
            Assert.AreEqual("four", parameters[2]);
        }

        [Test]
        public void TestParseParametersWithTwoQuotes()
        {
            var parameters = parser.Parse(@"one ""two three"" four ""five six""");

            Assert.AreEqual(4, parameters.Count);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("two three", parameters[1]);
            Assert.AreEqual("four", parameters[2]);
            Assert.AreEqual("five six", parameters[3]);
        }

        [Test]
        public void TestParseParametersWithQuotesAndOddCharacters()
        {
            var parameters = parser.Parse(@"""http://www.google.com""");

            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual("http://www.google.com", parameters[0]);
        }

        [Test]
        public void TestParseParametersWithNonMatchingQuotes()
        {
            var parameters = parser.Parse(@"one ""two three four");

            Assert.AreEqual(2, parameters.Count);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("two three four", parameters[1]);
        }

        [Test]
        public void TestParseParametersWithFlags()
        {
            var parameters = parser.Parse(@"-one ""two three"" --four /five");

            Assert.AreEqual(4, parameters.Count);
            Assert.AreEqual("-one", parameters[0]);
            Assert.AreEqual("two three", parameters[1]);
            Assert.AreEqual("--four", parameters[2]);
            Assert.AreEqual("/five", parameters[3]);
        }

        [Test]
        public void TestParseParametersPassesSwitches()
        {
            var parameters = parser.Parse(@"one ""two three"" four", new[] { ":" });

            Assert.AreEqual(1, parameters.Switches.Count);
            Assert.AreEqual(":", parameters.Switches[0]);
        }

        [Test]
        public void TestParseParameterPassesWithMinus()
        {
            var parameters = parser.Parse(@"""-05:00:00""");

            Assert.AreEqual(@"""-05:00:00""",  parameters[0]);
        }
    }
}
