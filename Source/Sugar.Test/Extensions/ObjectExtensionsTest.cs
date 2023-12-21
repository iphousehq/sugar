using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class ObjectExtensionsTest
    {
        private class Foo
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

        private class Bar
        {
            public string Name { get; set; }

            public Foo Details { get; set; }

            public Foo ThisIsNull { get; set; }

            public Bar Bob { get; set; }
        }

        private class Baz
        {
            public Baz()
            {
                Foos = new List<Foo>();
            }

            public IList<Foo> Foos { get; set; }
        }

        private class Tricky
        {
            public Tricky()
            {
                Foos = new List<Foo>();
            }

            public string Name { get; set; }

            public IList<Foo> Foos { get; set; }

            public DateTime DOB { get; set; }

            public int Age => throw new ApplicationException("oops");

            public ICollection<int> Stuff => throw new ApplicationException("oops");
        }

        [Test]
        public void TestDumpNullObject()
        {
            object nullReference = null;

            var dump = nullReference.ToDump();

            Assert.That(dump, Is.EqualTo("Object was null"));
        }

        [Test]
        public void TestDumpString()
        {
            var dump = "Hello World".ToDump();

            var lines = dump.Split(Environment.NewLine);

            Assert.That(lines[0], Is.EqualTo(@"{"));
            Assert.That(lines[1], Is.EqualTo(@"  String: ""Hello World"""));
            Assert.That(lines[2], Is.EqualTo(@"}"));
            Console.WriteLine(dump);
        }

        [Test]
        public void TestDumpInteger()
        {
            var dump = 123.ToDump();

            var lines = dump.Split(Environment.NewLine);

            Assert.That(lines[0], Is.EqualTo(@"{"));
            Assert.That(lines[1], Is.EqualTo(@"  Int32: ""123"""));
            Assert.That(lines[2], Is.EqualTo(@"}"));
            Console.WriteLine(dump);
        }

        [Test]
        public void TestDumpType()
        {
            var bar = new Bar { Name = "Tom", Details = new Foo { Name = "Bob", Age = 31 }, Bob = new Bar { Name = "Baz" } };

            var dump = bar.ToDump();

            var lines = dump.Split(Environment.NewLine);

            Console.WriteLine(dump);
            Assert.That(lines[0], Is.EqualTo(@"{"));
        }

        [Test]
        public void TestDumpEnumerable()
        {
            var bar = new Baz();
            bar.Foos.Add(new Foo { Name = "one" });
            bar.Foos.Add(null);
            bar.Foos.Add(new Foo { Name = "two" });

            var dump = bar.ToDump();

            var lines = dump.Split(Environment.NewLine);

            Console.WriteLine(dump);
            Assert.That(lines[0], Is.EqualTo(@"{"));
        }

        [Test]
        public void TestDumpIgnoreEnumerable()
        {
            var bar = new Baz();
            bar.Foos.Add(new Foo { Name = "one" });
            bar.Foos.Add(null);
            bar.Foos.Add(new Foo { Name = "two" });

            var dump = bar.ToDump(enumerate: false);

            var lines = dump.Split(Environment.NewLine);

            Console.WriteLine(dump);
            Assert.That(lines[0], Is.EqualTo(@"{"));
        }

        [Test]
        public void TestDumpErrorThrowingTypes()
        {
            var bar = new Tricky {Name = "Tricky"};
            bar.Foos.Add(new Foo { Name = "one" });
            bar.Foos.Add(null);
            bar.Foos.Add(new Foo { Name = "two" });

            var dump = bar.ToDump();

            var lines = dump.Split(Environment.NewLine);

            Console.WriteLine(dump);
            Assert.That(lines[0], Is.EqualTo(@"{"));
        }
    }
}
