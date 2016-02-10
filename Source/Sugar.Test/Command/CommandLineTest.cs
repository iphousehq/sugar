using NUnit.Framework;

namespace Sugar.Command
{
    [TestFixture]
    public class CommandLineTest
    {
        private CommandLine commandLine;

        [SetUp]
        public void Setup()
        {
            commandLine = new FakeCommandLine(1, new[] { 1, 2, 3 });
        }

        [Test]
        public void TestGetCommandLine()
        {
            var results = commandLine.GetCommandLines(string.Empty);

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("-arg 1", results[1]);
            Assert.AreEqual("-arg 2", results[2]);
            Assert.AreEqual("-arg 3", results[3]);
        }

        [Test]
        public void TestIsAlreadyRunningWhenFalse()
        {
            var result = commandLine.AlreadyRunning(string.Empty);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestStripFilenameFromCommandLine()
        {
            var result = commandLine.CleanUpCommandLine("watchdog -sub sky -search 1");

            Assert.AreEqual("-sub sky -search 1", result);
        }

        [Test]
        public void TestStripFilenameFromCommandLineWithQuotes()
        {
            var result = commandLine.CleanUpCommandLine(@"""C:\Program Files\WATCHDOG\watchdog.exe"" -sub sky -search 1");

            Assert.AreEqual("-sub sky -search 1", result);
        }
    }
}