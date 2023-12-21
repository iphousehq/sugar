using System;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class TextTableTest
    {
        [Test]
        public void TestBuildTableWithOneRow()
        {
            var table = new TextTable("one", "two");

            table.AddRow("one", 1);

            var result = table.ToString().Split(Environment.NewLine);

            Assert.That(result[0], Is.EqualTo("one  two"));
            Assert.That(result[1], Is.EqualTo("one    1"));
        }

        [Test]
        public void TestBuildTableWithTwoRows()
        {
            var table = new TextTable("First", "Second");

            table.AddRow("one", 1);
            table.AddRow("one two", 123);

            var result = table.ToString().Split(Environment.NewLine);

            Assert.That(result[0], Is.EqualTo("First    Second"));
            Assert.That(result[1], Is.EqualTo("one           1"));
            Assert.That(result[2], Is.EqualTo("one two     123"));
        }

        [Test]
        public void TestBuildTableWithTwoRowsWithNull()
        {
            var table = new TextTable("One", "Two");

            table.AddRow("one");
            table.AddRow("one two", 123);

            var result = table.ToString().Split(Environment.NewLine);

            Assert.That(result[0], Is.EqualTo("One      Two"));
            Assert.That(result[1], Is.EqualTo("one"));
            Assert.That(result[2], Is.EqualTo("one two  123"));
        }

        [Test]
        public void TestBuildTableWithTwoRowsAndASeperator()
        {
            var table = new TextTable(1, 2);

            table.AddRow("one", 1);
            table.AddSeperator();
            table.AddRow("one two", 123);

            var result = table.ToStringList();

            Assert.That(result[0], Is.EqualTo("1    2"));
            Assert.That(result[1], Is.EqualTo("one        1"));
            Assert.That(result[2], Is.EqualTo("============"));
            Assert.That(result[3], Is.EqualTo("one two  123"));
        }
    }
}
