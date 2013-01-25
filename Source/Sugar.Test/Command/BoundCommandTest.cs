using NUnit.Framework;

namespace Sugar.Command
{
    [TestFixture]
    public class BoundCommandTest
    {
        private class FakeCommand : BoundCommand<FakeCommand.Options>
        {
            public class Options
            {
                [Parameter("one", Required = true)]
                public string Input { get; set; }
            }

            public override int Execute(Options options)
            {
                return 0;
            }           
        }

        [Test]
        public void TestCommandExecutes()
        {
            var parameters = new ParameterParser().Parse("-one two");

            var command = new FakeCommand();

            Assert.IsTrue(command.CanExecute(parameters));
        }

        [Test]
        public void TestCommandDoesntExecutes()
        {
            var parameters = new ParameterParser().Parse("-three two");

            var command = new FakeCommand();

            Assert.IsFalse(command.CanExecute(parameters));
        }
    }
}
