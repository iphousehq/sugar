using System;
using NUnit.Framework;

namespace Sugar.Command
{
    [TestFixture]
    public class ParameterPrinterTest
    {
        private ParameterParser parser;
        private ParameterPrinter printer;

        private class Foo
        {
            [Parameter("foo", Default = "bar")]
            public string First { get; set; }

            [Parameter(1)]
            public string Second { get; set; }
        }

        private class Bar
        {
            [Parameter("first", Required = true )]
            public string First { get; set; }
        }

        [Flag("flag")]
        private class Baz
        {
            [Parameter("one")]
            public string First { get; set; }

            [Parameter("two")]
            public int Second { get; set; }

            [Parameter("three")]
            public double Third { get; set; }

            [Parameter("four")]
            public DateTime Fourth { get; set; }
        }

        [Flag("flag")]
        private class Fizz
        {
            [Parameter("first", Required = true)]
            public string First { get; set; }
        }

        [Flag("flag", "command")]
        private class Bizz
        {
            [Flag("set")]
            public bool First { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            parser = new ParameterParser();
            printer = new ParameterPrinter();
        }

        [Test]
        public void TestPrintObject()
        {
            var results = printer.Print("-", typeof(Foo), typeof(Bar), typeof(Baz), typeof(Fizz), typeof(Bizz));

            Assert.AreEqual(5, results.Count);
            Assert.AreEqual(@"[-foo ""bar""]", results[0]);
            Assert.AreEqual(@"-first ""abc""", results[1]);
            Assert.AreEqual(@"-flag [-one ""abc""] [-two 123] [-three 123.4] [-four (DateTime)]", results[2]);
            Assert.AreEqual(@"-flag -first ""abc""", results[3]);
            Assert.AreEqual(@"-flag -command [-set]", results[4]);
        }

        [Test]
        public void TestPrintObjectsFromAssemly()
        {
            var results = printer.Print("-", typeof(Foo).Assembly, "Fizz");

            Assert.AreEqual(2, results.Count);
        }
    }
}
