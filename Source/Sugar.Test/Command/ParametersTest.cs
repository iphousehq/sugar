using System;
using NUnit.Framework;

namespace Sugar.Command
{
    [TestFixture]
    public class ParametersTest
    {
        private ParameterParser parser;

        [SetUp]
        public void TestParseRead()
        {
            parser = new ParameterParser();
        }

        [Test]
        public void TestParametersContainsValue()
        {
            var parameters = parser.Parse("-one --two /three");

            Assert.AreEqual(true, parameters.Contains("one"));
            Assert.AreEqual(true, parameters.Contains("two"));
            Assert.AreEqual(true, parameters.Contains("three"));
            Assert.AreEqual(false, parameters.Contains("four"));
        }

        [Test]
        public void TestParametersContainsValueWithEmptyFlag()
        {
            var parameters = parser.Parse("-one two");
            parameters.Switches.Clear();

            Assert.AreEqual(false, parameters.Contains("one"));
            Assert.AreEqual(true, parameters.Contains("two"));
        }

        [Test]
        public void TestGetParameterValue()
        {
            var parameters = parser.Parse("-one two");

            Assert.AreEqual("two", parameters.AsString("one"));
        }

        [Test]
        public void TestGetParameterValueWhenDoesntExist()
        {
            var parameters = parser.Parse("-one two");

            Assert.AreEqual(string.Empty, parameters.AsString("two"));
        }

        [Test]
        public void TestGetParameterValueWhenNextValueIsFlag()
        {
            var parameters = parser.Parse("-one -two");

            Assert.AreEqual(string.Empty, parameters.AsString("one"));
        }

        [Test]
        public void TestGetParameterValueUsesDefaultValue()
        {
            var parameters = parser.Parse("-one two");

            Assert.AreEqual("default", parameters.AsString("two", "default"));
        }

        [Test]
        public void TestGetParameters()
        {
            var parameters = parser.Parse("-one two three");

            Assert.AreEqual(2, parameters.AsStrings("one").Count);
            Assert.AreEqual("two", parameters.AsStrings("one")[0]);
            Assert.AreEqual("three", parameters.AsStrings("one")[1]);
        }

        [Test]
        public void TestGetParametersWithMinusWithoutQuotes()
        {
            var parameters = parser.Parse(@"-one -three");

            Assert.AreEqual(0, parameters.AsStrings("one").Count);
        }

        [Test]
        public void TestGetParametersWithMinus()
        {
            var parameters = parser.Parse(@"-one ""-three""");

            Assert.AreEqual(1, parameters.AsStrings("one").Count);
            Assert.AreEqual(@"""-three""", parameters.AsStrings("one")[0]);
        }

        [Test]
        public void TestGetParametersWithMinusWhenQuoted()
        {
            var parameters =
                parser.Parse(
                    "\"C:\\path\\to\\prog.exe\" /one val1 /two \"-05:00:00\"");

            var value = parameters.AsString("two");

            Assert.AreEqual("\"-05:00:00\"", value);
        }

        [Test]
        public void TestGetParametersWithMinusWhenDoubleQuoted()
        {
            var parameters =
                parser.Parse(
                    "\"C:\\path\\to\\prog.exe\" /one val1 /two \"\"-05:00:00\"\"");

            var value = parameters.AsString("two");
            
            Assert.AreEqual("\"-05:00:00\"", value);
        }

        [Test]
        public void TestGetParametersUsesDefaults()
        {
            var parameters = parser.Parse("-one two three");

            Assert.AreEqual(2, parameters.AsStrings("four", new[] { "one", "two" }).Count);
        }

        [Test]
        public void TestGetParametersStopsWhenNextFlagDetected()
        {
            var parameters = parser.Parse("-one two three -four");

            Assert.AreEqual(2, parameters.AsStrings("one").Count);
            Assert.AreEqual("two", parameters.AsStrings("one")[0]);
            Assert.AreEqual("two", parameters.AsStrings("one")[0]);
        }

        [Test]
        public void TestGetParametersWhenNoFlagPrefix()
        {
            var parameters = parser.Parse("one two three four");
            parameters.Switches.Clear();

            Assert.AreEqual(3, parameters.AsStrings("one").Count);
            Assert.AreEqual("two", parameters.AsStrings("one")[0]);
            Assert.AreEqual("three", parameters.AsStrings("one")[1]);
            Assert.AreEqual("four", parameters.AsStrings("one")[2]);
        }

        [Test]
        public void TestIsFlag()
        {
            var parameters = parser.Parse("");

            Assert.AreEqual(true, parameters.IsFlag("-one"));
            Assert.AreEqual(true, parameters.IsFlag("--two"));
            Assert.AreEqual(true, parameters.IsFlag("/three"));
            Assert.AreEqual(false, parameters.IsFlag(":four"));
        }

        [Test]
        public void TestIsFlagWhenNoPrefix()
        {
            var parameters = parser.Parse("");
            parameters.Switches.Clear();

            Assert.AreEqual(true, parameters.IsFlag("one"));
        }

        [Test]
        public void TestGetInteger()
        {
            var parameters = parser.Parse("-flag 1");

            var result = parameters.AsInteger("flag");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestGetIntegerWhenNotFound()
        {
            var parameters = parser.Parse("-flag 1");

            var result = parameters.AsInteger("two");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestGetIntegerUsesDefault()
        {
            var parameters = parser.Parse("-flag 1");

            var result = parameters.AsInteger("two", 2);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void TestGetDateTime()
        {
            var parameters = parser.Parse("-flag 2001-01-01");

            var result = parameters.AsDateTime("flag");

            Assert.AreEqual(new DateTime(2001, 1, 1), result);
        }

        [Test]
        public void TestGetDateTimeWhenNotFound()
        {
            var parameters = parser.Parse("-flag 1");

            var result = parameters.AsDateTime("two");

            Assert.AreEqual(DateTime.Today, result);
        }

        [Test]
        public void TestGetDateTimeUsesDefault()
        {
            var parameters = parser.Parse("-flag 1");

            var result = parameters.AsDateTime("two", DateTime.Today.AddDays(1));

            Assert.AreEqual(DateTime.Today.AddDays(1), result);
        }

        [Test]
        public void TestGetBool()
        {
            var parameters = parser.Parse("-flag true");

            var result = parameters.AsBool("flag");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestGetBoolWhenNotFound()
        {
            var parameters = parser.Parse("-flag 1");

            var result = parameters.AsBool("two");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void TestGetBoolUsesDefault()
        {
            var parameters = parser.Parse("-flag 1");

            var result = parameters.AsBool("two", true);

            Assert.AreEqual(true, result);
        }


        [Test]
        public void TestIndexOfWhenFound()
        {
            var parameters = parser.Parse("-flag one -two");

            Assert.AreEqual(2, parameters.IndexOf("two"));
        }

        [Test]
        public void TestIndexOfWhenNotFound()
        {
            var parameters = parser.Parse("-flag one -two");

            Assert.AreEqual(-1, parameters.IndexOf("three"));
        }

        [Test]
        public void TestRemoveParameterValue()
        {
            var parameters = parser.Parse("-flag one -two");

            parameters.Remove("flag");

            Assert.AreEqual("-two", parameters.ToString());
        }

        [Test]
        public void TestRemoveParameterValues()
        {
            var parameters = parser.Parse("-flag one two three -four");

            parameters.Remove("flag");

            Assert.AreEqual("-four", parameters.ToString());
        }

        [Test]
        public void TestReplaceParameterValue()
        {
            var parameters = parser.Parse("-flag one");

            parameters.Replace("flag", "two");

            Assert.AreEqual("-flag two", parameters.ToString());
        }

        [Test]
        public void TestReplaceParameterValues()
        {
            var parameters = parser.Parse("-flag one");

            parameters.Replace("flag", "two", "three");

            Assert.AreEqual("-flag two three", parameters.ToString());
        }

        [Test]
        public void TestReplaceParameterValuesWhenDoesntExist()
        {
            var parameters = parser.Parse("-flag one");

            parameters.Replace("four", "two", "three");

            Assert.AreEqual("-flag one", parameters.ToString());
        }

        [Test]
        public void TestReplaceParameterWithNoSwitch()
        {
            var parameters = parser.Parse("flag one", new string[0]);

            parameters.Replace("flag", "three");

            Assert.AreEqual("three one", parameters.ToString());
        }

        [Test]
        public void TestAsCustomType()
        {
            var parameters = parser.Parse("-flag 123.45");

            var result = parameters.AsCustomType<double>("flag");

            Assert.AreEqual(123.45d, result);
        }

        [Test]
        public void TestAsCustomTypeFromPosition()
        {
            var parameters = parser.Parse("-flag 123.45");

            var result = parameters.AsCustomType(1, typeof(double));

            Assert.AreEqual(123.45d, result);
        }

        [Test]
        public void TestContainsValue()
        {
            var parameters = parser.Parse("-flag");

            Assert.AreEqual(true, parameters.Contains("flag"));
            Assert.AreEqual(false, parameters.Contains("boat"));
        }

        [Test]
        public void TestContainsAllValues()
        {
            var parameters = parser.Parse("-flag -another");

            Assert.AreEqual(true, parameters.ContainsAny("flag", "another"));
            Assert.AreEqual(false, parameters.ContainsAny("boat", "another", "flag"));
        }

        [Test]
        public void TestHasValue()
        {
            var parameters = parser.Parse("-flag red -boat -fish");

            Assert.AreEqual(true, parameters.HasValue("flag"));
            Assert.AreEqual(false, parameters.HasValue("boat"));
            Assert.AreEqual(false, parameters.HasValue("dog"));
        }

        [Test]
        public void TestHasValueWithNoPrefix()
        {
            var parameters = parser.Parse("flag red boat fish", new[] { "" });

            Assert.AreEqual(true, parameters.HasValue("flag"));
            Assert.AreEqual(true, parameters.HasValue("boat"));
            Assert.AreEqual(false, parameters.HasValue("fish"));
        }

        [Test]
        public void TestToStringWithQuotedParameter()
        {
            var parameters = parser.Parse(@"flag ""red boat""", new[] { "" }).ToString();

            Assert.AreEqual(@"flag ""red boat""", parameters);
        }
    }
}
