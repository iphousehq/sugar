using System;
using NUnit.Framework;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    [TestFixture]
    [Parallelizable]
    public class ParameterPrinterTest
    {
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

        [Test]
        public void TestPrintObject()
        {
            var printer = new ParameterPrinter();

            var results = printer.Print("-", typeof(Foo), typeof(Bar), typeof(Baz), typeof(Fizz), typeof(Bizz));

            Assert.That(results.Count, Is.EqualTo(5));
            Assert.That(results[0], Is.EqualTo(@"[-foo ""bar""]"));
            Assert.That(results[1], Is.EqualTo(@"-first ""abc"""));
            Assert.That(results[2], Is.EqualTo(@"-flag [-one ""abc""] [-two 123] [-three 123.4] [-four (DateTime)]"));
            Assert.That(results[3], Is.EqualTo(@"-flag -first ""abc"""));
            Assert.That(results[4], Is.EqualTo(@"-flag -command [-set]"));
        }

        [Test]
        public void TestPrintObjectsFromAssemly()
        {
            var printer = new ParameterPrinter();

            var results = printer.Print("-", typeof(Foo).Assembly, "Fizz");

            Assert.That(results.Count, Is.EqualTo(2));
        }
    }
}
