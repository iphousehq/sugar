using NUnit.Framework;

namespace Sugar.Command
{
    [TestFixture]
    public class CommandLineTest
    {
        [Test]
        public void TestAlreadyRunning()
        {
            var commandline = new CommandLine();

            // Will not match the current process name
            // Checking unexpected exception are not thrown
            var isAlreadyRunning = commandline.AlreadyRunning("foo.exe");

            Assert.That(isAlreadyRunning, Is.False);
        }
    }
}
