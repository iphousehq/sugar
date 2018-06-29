using System;
using NUnit.Framework;

namespace Sugar.Command
{
    [TestFixture]
    public class ParameterParameterBinderTest
    {
        private ParameterParser parser;

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

            [Parameter("five")]
            public DateTime? Fifth { get; set; }
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

        private abstract class Parent
        {
            [Parameter("1a")]
            public string LevelOneA { get; set; }

            [Parameter("1b")]
            public string LevelOneB { get; set; }
        }

        [Flag("flag")]
        private class Child : Parent
        {
            [Parameter("2a")]
            public string LevelTwoA { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            parser = new ParameterParser();
        }

        [Test]
        public void TestBindObject()
        {
            var parameters = parser.Parse("one two -foo first");

            var result = ParameterBinder.Bind<Foo>(parameters);

            Assert.AreEqual("first", result.First);
            Assert.AreEqual("two", result.Second);
        }

        [Test]
        public void TestBindObjectWithDefaultValues()
        {
            var parameters = parser.Parse("one two");

            var result = ParameterBinder.Bind<Foo>(parameters);

            Assert.AreEqual("bar", result.First);
        }

        [Test]
        public void TestBindObjectFailsWhenParametersRequired()
        {
            var parameters = parser.Parse("-one -two");

            var result = ParameterBinder.Bind<Bar>(parameters);

            Assert.IsNull(result);
        }

        [Test]
        public void TestBindObjectFailsWhenFlagNotSet()
        {
            var parameters = parser.Parse("-first");

            var result = ParameterBinder.Bind<Bar>(parameters);

            Assert.IsNull(result);
        }

        [Test]
        public void TestBindObjectWithCustomTypes()
        {
            var parameters = parser.Parse("-flag -one 1 -two 2 -three 3.4 -four 2008-03-08");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.AreEqual("1", result.First);
            Assert.AreEqual(2, result.Second);
            Assert.AreEqual(3.4d, result.Third);
            Assert.AreEqual(new DateTime(2008, 3, 8), result.Fourth);
        }

        [Test]
        public void TestBindObjectWithNullableDateSet()
        {
            var parameters = parser.Parse("-flag -five 2014-03-05");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.AreEqual(new DateTime(2014, 3, 5), result.Fifth.Value);
        }

        [Test]
        public void TestBindObjectWithNullableDateAndTimeSetAsIso8601()
        {
            var parameters = parser.Parse("-flag -five 2014-03-05T23:40:59");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.AreEqual(new DateTime(2014, 3, 5, 23, 40, 59), result.Fifth.Value);
        }

        [Test]
        public void TestBindObjectWithNullableDateAndTimeSetAsIso8601CompactSyntaxIgnoresValue()
        {
            var parameters = parser.Parse("-flag -five 20140305T234059");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.IsFalse(result.Fifth.HasValue);
        }

        [Test]
        public void TestBindObjectWithNullableDateNotSet()
        {
            var parameters = parser.Parse("-flag");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.AreEqual(false, result.Fifth.HasValue);
        }

        [Test]
        public void TestBindObjectWithFlags()
        {
            var parameters = parser.Parse("-flag -first 1");

            var result = ParameterBinder.Bind<Fizz>(parameters);

            Assert.AreEqual("1", result.First);
        }

        [Test]
        public void TestBindObjectWithMulitpleFlags()
        {
            var parameters = parser.Parse("-flag -command -set");

            var result = ParameterBinder.Bind<Bizz>(parameters);

            Assert.IsTrue(result.First);
        }

        [Test]
        public void TestBindObjectWithParentProperies()
        {
            var parameters = parser.Parse("-flag -1a oneA -1b oneB -2a twoA");

            var result = ParameterBinder.Bind<Child>(parameters);

            Assert.AreEqual("oneA", result.LevelOneA);
            Assert.AreEqual("oneB", result.LevelOneB);
            Assert.AreEqual("twoA", result.LevelTwoA);
        }
    }
}
