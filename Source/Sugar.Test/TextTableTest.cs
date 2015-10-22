using System;
using NUnit.Framework;
using Sugar.Extensions;

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

            Assert.AreEqual("one  two", result[0]);
            Assert.AreEqual("one    1", result[1]);

        }

        [Test]
        public void TestBuildTableWithTwoRows()
        {
            var table = new TextTable("First", "Second");

            table.AddRow("one", 1);
            table.AddRow("one two", 123);

            var result = table.ToString().Split(Environment.NewLine);

            Assert.AreEqual("First    Second", result[0]);
            Assert.AreEqual("one           1", result[1]);
            Assert.AreEqual("one two     123", result[2]);
        }


        [Test]
        public void TestBuildTableWithTwoRowsWithNull()
        {
            var table = new TextTable("One", "Two");

            table.AddRow("one");
            table.AddRow("one two", 123);

            var result = table.ToString().Split(Environment.NewLine);

            Assert.AreEqual("One      Two", result[0]);
            Assert.AreEqual("one", result[1]);
            Assert.AreEqual("one two  123", result[2]);
        }

        [Test]
        public void TestBuildTableWithTwoRowsAndASeperator()
        {
            var table = new TextTable(1, 2);

            table.AddRow("one", 1);
            table.AddSeperator();
            table.AddRow("one two", 123);

            var result = table.ToStringList();

            Assert.AreEqual("1    2", result[0]);
            Assert.AreEqual("one        1", result[1]);
            Assert.AreEqual("============", result[2]);
            Assert.AreEqual("one two  123", result[3]);
        }
    }
}
