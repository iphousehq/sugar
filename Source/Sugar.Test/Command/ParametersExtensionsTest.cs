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

            Assert.That(parameters.Count, Is.EqualTo(3));
            Assert.That(parameters[0], Is.EqualTo("one"));
            Assert.That(parameters[1], Is.EqualTo("two"));
            Assert.That(parameters[2], Is.EqualTo("three"));
        }

        [Test]
        public void TestParseParametersWithQuotes()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"one ""two three"" four");

            Assert.That(parameters.Count, Is.EqualTo(3));
            Assert.That(parameters[0], Is.EqualTo("one"));
            Assert.That(parameters[1], Is.EqualTo("two three"));
            Assert.That(parameters[2], Is.EqualTo("four"));
        }

        [Test]
        public void TestParseParametersWithTwoQuotes()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"one ""two three"" four ""five six""");

            Assert.That(parameters.Count, Is.EqualTo(4));
            Assert.That(parameters[0], Is.EqualTo("one"));
            Assert.That(parameters[1], Is.EqualTo("two three"));
            Assert.That(parameters[2], Is.EqualTo("four"));
            Assert.That(parameters[3], Is.EqualTo("five six"));
        }

        [Test]
        public void TestParseParametersWithQuotesAndOddCharacters()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"""http://www.google.com""");

            Assert.That(parameters.Count, Is.EqualTo(1));
            Assert.That(parameters[0], Is.EqualTo("http://www.google.com"));
        }

        [Test]
        public void TestParseParametersWithNonMatchingQuotes()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"one ""two three four");

            Assert.That(parameters.Count, Is.EqualTo(2));
            Assert.That(parameters[0], Is.EqualTo("one"));
            Assert.That(parameters[1], Is.EqualTo("two three four"));
        }

        [Test]
        public void TestParseParametersWithFlags()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"-one ""two three"" --four /five");

            Assert.That(parameters.Count, Is.EqualTo(4));
            Assert.That(parameters[0], Is.EqualTo("-one"));
            Assert.That(parameters[1], Is.EqualTo("two three"));
            Assert.That(parameters[2], Is.EqualTo("--four"));
            Assert.That(parameters[3], Is.EqualTo("/five"));
        }

        [Test]
        public void TestParseParameterPassesWithMinus()
        {
            var parameters = ParametersExtensions.ParseCommandLine(@"""-05:00:00""");

            Assert.That(parameters[0], Is.EqualTo(@"""-05:00:00"""));
        }
    }
}
