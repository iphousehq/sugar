using System;
using System.Linq;
using NUnit.Framework;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    [TestFixture]
    [Parallelizable]
    public class ParametersTest
    {
        [Test]
        public void TestDirectory()
        {
            var result = Parameters.Directory;

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void TestFilename()
        {
            var parameters = new Parameters("foo.exe -bar");

            Assert.That(parameters.Filename, Is.EqualTo("foo.exe"));

            Assert.That(parameters.Count, Is.EqualTo(1));
            Assert.That(parameters[0], Is.EqualTo("-bar"));
        }

        [Test]
        public void TestCopyConstructorIsCalledByCloneMethod()
        {
            var original = new Parameters("foo.exe -bar", new[] {"-", "["});

            var copy = (Parameters) original.Clone();

            Assert.That(copy, Is.Not.SameAs(original));
            
            Assert.That(copy.Switches.Count(), Is.EqualTo(2));
            Assert.That(copy.Switches.First(), Is.EqualTo("-"));
            Assert.That(copy.Switches.Skip(1).First(), Is.EqualTo("["));

            Assert.That(copy.Filename, Is.EqualTo("foo.exe"));

            Assert.That(copy.Count, Is.EqualTo(1));
            Assert.That(copy[0], Is.EqualTo("-bar"));
        }

        [Test]
        public void TestParametersContainsValue()
        {
            var parameters = new Parameters("foo.exe -one --two /three four");

            Assert.That(parameters.Contains("one"), Is.EqualTo(true));
            Assert.That(parameters.Contains("two"), Is.EqualTo(true));
            Assert.That(parameters.Contains("three"), Is.EqualTo(true));
            Assert.That(parameters.Contains("four"), Is.EqualTo(false));
        }

        [Test]
        public void TestParametersContainsValueWithEmptyFlag()
        {
            var parameters = new Parameters("foo.exe -one two", new string[0]);
            
            Assert.That(parameters.Contains("one"), Is.EqualTo(false));
            Assert.That(parameters.Contains("two"), Is.EqualTo(true));
        }

        [Test]
        public void TestGetParameterValue()
        {
            var parameters = new Parameters("foo.exe -one two");

            Assert.That(parameters.AsString("one"), Is.EqualTo("two"));
        }

        [Test]
        public void TestGetParameterValueWhenDoesNotExist()
        {
            var parameters = new Parameters("foo.exe -one two");

            var result = parameters.AsString("two");

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestGetParameterValueWhenNextValueIsFlag()
        {
            var parameters = new Parameters("foo.exe -one -two");

            Assert.That(parameters.AsString("one"), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestGetParameterValueUsesDefaultValue()
        {
            var parameters = new Parameters("foo.exe -one two");

            Assert.That(parameters.AsString("two", "default"), Is.EqualTo("default"));
        }

        [Test]
        public void TestGetParameters()
        {
            var parameters = new Parameters("foo.exe -one two three");

            Assert.That(parameters.AsStrings("one").Count, Is.EqualTo(2));
            Assert.That(parameters.AsStrings("one")[0], Is.EqualTo("two"));
            Assert.That(parameters.AsStrings("one")[1], Is.EqualTo("three"));
        }

        [Test]
        public void TestGetParametersWithMinusWithoutQuotes()
        {
            var parameters = new Parameters("foo.exe -one -three");

            Assert.That(parameters.AsStrings("one").Count, Is.EqualTo(0));
        }

        [Test]
        public void TestGetParametersWithMinus()
        {
            var parameters = new Parameters(@"foo.exe -one ""-three""");

            Assert.That(parameters.AsStrings("one").Count, Is.EqualTo(1));
            Assert.That(parameters.AsStrings("one")[0], Is.EqualTo(@"""-three"""));
        }

        [Test]
        public void TestGetParametersWithMinusWhenQuoted()
        {
            var parameters = new Parameters("\"C:\\path\\to\\prog.exe\" /one val1 /two \"-05:00:00\"");

            var value = parameters.AsString("two");

            Assert.That(value, Is.EqualTo("\"-05:00:00\""));
        }

        [Test]
        public void TestGetParametersWithMinusWhenDoubleQuoted()
        {
            var parameters = new Parameters("\"C:\\path\\to\\prog.exe\" /one val1 /two \"\"-05:00:00\"\"");

            var value = parameters.AsString("two");

            Assert.That(value, Is.EqualTo("\"-05:00:00\""));
        }

        [Test]
        public void TestGetParametersUsesDefaults()
        {
            var parameters = new Parameters("foo.exe -one two three");

            Assert.That(parameters.AsStrings("four", "one", "two").Count, Is.EqualTo(2));
        }

        [Test]
        public void TestGetParametersStopsWhenNextFlagDetected()
        {
            var parameters = new Parameters("foo.exe -one two three -four");

            Assert.That(parameters.AsStrings("one").Count, Is.EqualTo(2));
            Assert.That(parameters.AsStrings("one")[0], Is.EqualTo("two"));
            Assert.That(parameters.AsStrings("one")[0], Is.EqualTo("two"));
        }

        [Test]
        public void TestGetParametersWhenNoFlagPrefix()
        {
            var parameters = new Parameters("foo.exe one two three four", Array.Empty<string>());

            Assert.That(parameters.AsStrings("one").Count, Is.EqualTo(3));
            Assert.That(parameters.AsStrings("one")[0], Is.EqualTo("two"));
            Assert.That(parameters.AsStrings("one")[1], Is.EqualTo("three"));
            Assert.That(parameters.AsStrings("one")[2], Is.EqualTo("four"));
        }

        [Test]
        public void TestIsFlag()
        {
            var parameters = new Parameters("");

            Assert.That(parameters.IsFlag("-one"), Is.EqualTo(true));
            Assert.That(parameters.IsFlag("--two"), Is.EqualTo(true));
            Assert.That(parameters.IsFlag("/three"), Is.EqualTo(true));
            Assert.That(parameters.IsFlag(":four"), Is.EqualTo(false));
        }

        [Test]
        public void TestIsFlagWhenNoPrefix()
        {
            var parameters = new Parameters("", Array.Empty<string>());

            Assert.That(parameters.IsFlag("one"), Is.EqualTo(true));
        }

        [Test]
        public void TestGetInteger()
        {
            var parameters = new Parameters("foo.exe -flag 1");

            var result = parameters.AsInteger("flag");

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestGetIntegerWhenNotFound()
        {
            var parameters = new Parameters("foo.exe -flag 1");

            var result = parameters.AsInteger("two");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestGetIntegerUsesDefault()
        {
            var parameters = new Parameters("foo.exe -flag 1");

            var result = parameters.AsInteger("two", 2);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void TestGetDateTime()
        {
            var parameters = new Parameters("foo.exe -flag 2001-01-01");

            var result = parameters.AsDateTime("flag");

            Assert.That(result, Is.EqualTo(new DateTime(2001, 1, 1)));
        }

        [Test]
        public void TestGetDateTimeWhenNotFound()
        {
            var parameters = new Parameters("foo.exe -flag 1");

            var result = parameters.AsDateTime("two");

            Assert.That(result, Is.EqualTo(DateTime.Today));
        }

        [Test]
        public void TestGetDateTimeUsesDefault()
        {
            var parameters = new Parameters("foo.exe -flag 1");

            var result = parameters.AsDateTime("two", DateTime.Today.AddDays(1));

            Assert.That(result, Is.EqualTo(DateTime.Today.AddDays(1)));
        }

        [Test]
        public void TestGetBool()
        {
            var parameters = new Parameters("foo.exe -flag true");

            var result = parameters.AsBool("flag");

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestGetBoolWhenNotFound()
        {
            var parameters = new Parameters("foo.exe -flag 1");

            var result = parameters.AsBool("two");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestGetBoolUsesDefault()
        {
            var parameters = new Parameters("foo.exe -flag 1");

            var result = parameters.AsBool("two", true);

            Assert.That(result, Is.EqualTo(true));
        }


        [Test]
        public void TestIndexOfWhenFound()
        {
            var parameters = new Parameters("foo.exe -flag one -two");

            Assert.That(parameters.IndexOf("two"), Is.EqualTo(2));
        }

        [Test]
        public void TestIndexOfWhenNotFound()
        {
            var parameters = new Parameters("foo.exe -flag one -two");

            Assert.That(parameters.IndexOf("three"), Is.EqualTo(-1));
        }

        [Test]
        public void TestRemoveParameterValue()
        {
            var parameters = new Parameters("foo.exe -flag one -two");

            parameters.Remove("flag");

            Assert.That(parameters.ToString(), Is.EqualTo("-two"));
        }

        [Test]
        public void TestRemoveParameterValues()
        {
            var parameters = new Parameters("foo.exe -flag one two three -four");

            parameters.Remove("flag");

            Assert.That(parameters.ToString(), Is.EqualTo("-four"));
        }

        [Test]
        public void TestReplaceParameterValue()
        {
            var parameters = new Parameters("foo.exe -flag one");

            parameters.Replace("flag", "two");

            Assert.That(parameters.ToString(), Is.EqualTo("-flag two"));
        }

        [Test]
        public void TestReplaceParameterValues()
        {
            var parameters = new Parameters("foo.exe -flag one");

            parameters.Replace("flag", "two", "three");

            Assert.That(parameters.ToString(), Is.EqualTo("-flag two three"));
        }

        [Test]
        public void TestReplaceParameterValuesWhenDoesntExist()
        {
            var parameters = new Parameters("foo.exe -flag one");

            parameters.Replace("four", "two", "three");

            Assert.That(parameters.ToString(), Is.EqualTo("-flag one"));
        }

        [Test]
        public void TestReplaceParameterWithNoSwitch()
        {
            var parameters = new Parameters("foo.exe flag one", new string[0]);

            parameters.Replace("flag", "three");

            Assert.That(parameters.ToString(), Is.EqualTo("three one"));
        }

        [Test]
        public void TestAsCustomType()
        {
            var parameters = new Parameters("foo.exe -flag 123.45");

            var result = parameters.AsCustomType<double>("flag");

            Assert.That(result, Is.EqualTo(123.45d));
        }

        [Test]
        public void TestAsCustomTypeFromPosition()
        {
            var parameters = new Parameters("foo.exe -flag 123.45");

            var result = parameters.AsCustomType(1, typeof(double));

            Assert.That(result, Is.EqualTo(123.45d));
        }

        [Test]
        public void TestContainsValue()
        {
            var parameters = new Parameters("foo.exe -flag");

            Assert.That(parameters.Contains("flag"), Is.EqualTo(true));
            Assert.That(parameters.Contains("boat"), Is.EqualTo(false));
        }

        [Test]
        public void TestContainsAllValues()
        {
            var parameters = new Parameters("foo.exe -flag -another");

            Assert.That(parameters.ContainsAny("flag", "another"), Is.EqualTo(true));
            Assert.That(parameters.ContainsAny("boat", "another", "flag"), Is.EqualTo(false));
        }

        [Test]
        public void TestHasValue()
        {
            var parameters = new Parameters("foo.exe -flag red -boat -fish");

            Assert.That(parameters.HasValue("flag"), Is.EqualTo(true));
            Assert.That(parameters.HasValue("boat"), Is.EqualTo(false));
            Assert.That(parameters.HasValue("dog"), Is.EqualTo(false));
        }

        [Test]
        public void TestToStringWithQuotedParameter()
        {
            var parameters = new Parameters(@"foo.exe flag ""red boat""", new[] { "" }).ToString();

            Assert.That(parameters, Is.EqualTo(@"flag ""red boat"""));
        }
    }
}
