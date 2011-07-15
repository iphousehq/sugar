using NUnit.Framework;

namespace Comsec.Sugar
{
    [TestFixture]
    public class TextTableTest
    {
        [Test]
        public void TestBuildTableWithOneRow()
        {
            var table = new TextTable(2);

            table.AddRow("one", 1);

            Assert.AreEqual("one 1\r\n", table.ToString());
        }

        [Test]
        public void TestBuildTableWithTwoRows()
        {
            var table = new TextTable(2);

            table.AddRow("one", 1);
            table.AddRow("one two", 123);

            Assert.AreEqual(
@"one       1
one two 123
", table.ToString());
        }

        [Test]
        public void TestBuildTableWithTwoRowsWithNull()
        {
            var table = new TextTable(2);

            table.AddRow("one");
            table.AddRow("one two", 123);

            Assert.AreEqual(
@"one
one two 123
", table.ToString());
        }

        [Test]
        public void TestBuildTableWithTwoRowsAndASeperator()
        {
            var table = new TextTable(2);

            table.AddRow("one", 1);
            table.AddRow("=");
            table.AddRow("one two", 123);

            Assert.AreEqual(
@"one       1
===========
one two 123
", table.ToString());
        }
    }
}
