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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[1], Is.EqualTo("-arg 1"));
            Assert.That(results[2], Is.EqualTo("-arg 2"));
            Assert.That(results[3], Is.EqualTo("-arg 3"));
        }

        [Test]
        public void TestIsAlreadyRunningWhenFalse()
        {
            var result = commandLine.AlreadyRunning(string.Empty);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestStripFilenameFromCommandLine()
        {
            var result = commandLine.CleanUpCommandLine("watchdog -sub sky -search 1");

            Assert.That(result, Is.EqualTo("-sub sky -search 1"));
        }

        [Test]
        public void TestStripFilenameFromCommandLineWithQuotes()
        {
            var result = commandLine.CleanUpCommandLine(@"""C:\Program Files\WATCHDOG\watchdog.exe"" -sub sky -search 1");

            Assert.That(result, Is.EqualTo("-sub sky -search 1"));
        }
    }
}
