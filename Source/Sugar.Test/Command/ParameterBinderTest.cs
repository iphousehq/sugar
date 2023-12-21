using System;
using NUnit.Framework;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    [TestFixture]
    [Parallelizable]
    public class ParameterParameterBinderTest
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

        public enum FooBarEnum
        {
            Foo,
            Bar
        }

        public class FooBarEnumOptions
        {
            [Parameter("fooBarEnum")]
            public FooBarEnum FooBarEnum { get; set; }
        }

        [Flag("flag")]
        public class FooBarNullableEnumOptions
        {
            [Parameter("fooBarNullableEnum")]
            public FooBarEnum? FooBarNullableEnum { get; set; }
        }

        [Test]
        public void TestBindEnum()
        {
            var parameters = new Parameters("-fooBarEnum Foo");

            var result = ParameterBinder.Bind<FooBarEnumOptions>(parameters);

            Assert.That(result.FooBarEnum, Is.EqualTo(FooBarEnum.Foo));
        }

        [Test]
        public void TestBindNullableEnumWithStringParameter()
        {
            var parameters = new Parameters("-flag -fooBarNullableEnum Foo");

            var result = ParameterBinder.Bind<FooBarNullableEnumOptions>(parameters);

            Assert.That(result.FooBarNullableEnum, Is.EqualTo(FooBarEnum.Foo));
        }


        [Test]
        public void TestBindNullableEnumWithIntParameter()
        {
            var parameters = new Parameters("-flag -fooBarNullableEnum 0");

            var result = ParameterBinder.Bind<FooBarNullableEnumOptions>(parameters);

            Assert.That(result.FooBarNullableEnum, Is.EqualTo(FooBarEnum.Foo));
        }

        [Test]
        public void TestBindNullableEnumWithNullParameter()
        {
            var parameters = new Parameters("-flag -fooBarNullableEnum");

            var result = ParameterBinder.Bind<FooBarNullableEnumOptions>(parameters);

            Assert.That(result.FooBarNullableEnum, Is.EqualTo(null));
        }

        [Test]
        public void TestBindObject()
        {
            var parameters = new Parameters("foo.exe one two -foo first");

            var result = ParameterBinder.Bind<Foo>(parameters);

            Assert.That(result.First, Is.EqualTo("first"));
            Assert.That(result.Second, Is.EqualTo("two"));
        }

        [Test]
        public void TestBindObjectWithDefaultValues()
        {
            var parameters = new Parameters("");

            var result = ParameterBinder.Bind<Foo>(parameters);

            Assert.That(result.First, Is.EqualTo("bar"));
        }

        [Test]
        public void TestBindThrowsExceptionWhenRequiredParameterIsMissing()
        {
            var parameters = new Parameters("-one -two");

            Assert.Throws<RequiredParameterMissingException>(() => ParameterBinder.Bind<Bar>(parameters), "Required parameter \"first\" missing or without corresponding value");
        }

        [Test]
        public void TestBindThrowsExceptionWhenRequiredParameterHasNoValue()
        {
            var parameters = new Parameters("-first");
            
            Assert.Throws<RequiredParameterMissingException>(() => ParameterBinder.Bind<Bar>(parameters), "Required parameter \"first\" missing or without corresponding value");
        }

        [Test]
        public void TestBindObjectWithRequiredValue()
        {
            var parameters = new Parameters("foo.exe -first value");

            var result = ParameterBinder.Bind<Bar>(parameters);

            Assert.That(result.First, Is.EqualTo("value"));
        }

        [Test]
        public void TestBindObjectWithCustomTypes()
        {
            var parameters = new Parameters("-flag -one 1 -two 2 -three 3.4 -four 2008-03-08");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.That(result.First, Is.EqualTo("1"));
            Assert.That(result.Second, Is.EqualTo(2));
            Assert.That(result.Third, Is.EqualTo(3.4d));
            Assert.That(result.Fourth, Is.EqualTo(new DateTime(2008, 3, 8)));
        }

        [Test]
        public void TestBindObjectWithNullableDateSet()
        {
            var parameters = new Parameters("-flag -five 2014-03-05");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.That(result.Fifth.Value, Is.EqualTo(new DateTime(2014, 3, 5)));
        }

        [Test]
        public void TestBindObjectWithNullableDateAndTimeSetAsIso8601()
        {
            var parameters = new Parameters("-flag -five 2014-03-05T23:40:59");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.That(result.Fifth.Value, Is.EqualTo(new DateTime(2014, 3, 5, 23, 40, 59)));
        }

        [Test]
        public void TestBindObjectWithNullableDateAndTimeSetAsIso8601CompactSyntaxIgnoresValue()
        {
            var parameters = new Parameters("-flag -five 20140305T234059");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.That(result.Fifth.HasValue, Is.False);
        }

        [Test]
        public void TestBindObjectWithNullableDateNotSet()
        {
            var parameters = new Parameters("-flag");

            var result = ParameterBinder.Bind<Baz>(parameters);

            Assert.That(result.Fifth.HasValue, Is.EqualTo(false));
        }

        [Test]
        public void TestBindObjectWithFlags()
        {
            var parameters = new Parameters("-flag -first 1");

            var result = ParameterBinder.Bind<Fizz>(parameters);

            Assert.That(result.First, Is.EqualTo("1"));
        }

        [Test]
        public void TestBindObjectWithMulitpleFlags()
        {
            var parameters = new Parameters("-flag -command -set");

            var result = ParameterBinder.Bind<Bizz>(parameters);

            Assert.That(result.First, Is.True);
        }

        [Test]
        public void TestBindObjectWithParentProperies()
        {
            var parameters = new Parameters("-flag -1a oneA -1b oneB -2a twoA");

            var result = ParameterBinder.Bind<Child>(parameters);

            Assert.That(result.LevelOneA, Is.EqualTo("oneA"));
            Assert.That(result.LevelOneB, Is.EqualTo("oneB"));
            Assert.That(result.LevelTwoA, Is.EqualTo("twoA"));
        }
    }
}
