using NUnit.Framework;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    [TestFixture]
    [Parallelizable]
    public class BoundCommandTest
    {
        private class FakeCommand : BoundCommand<FakeCommand.Options>
        {
            public class Options
            {
                [Parameter("one", Required = true)]
                public string Input { get; set; }
            }

            public Options GetOptions()
            {
                return OptionsBound;
            }

            public override int Execute(Options options)
            {
                return 0;
            }           
        }

        [Test]
        public void TestSuccess()
        {
            var result = FakeCommand.Success();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestFail()
        {
            var result = FakeCommand.Fail();

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void TestCommandExecutes()
        {
            var parameters = new Parameters("foo.exe -one two");

            var command = new FakeCommand();

            command.BindParameters(parameters);

            Assert.That(command.GetOptions(), Is.Not.Null);
        }

        [Test]
        public void TestCommandDoesNotExecutesWhenRequiredParameterIsMissing()
        {
            var parameters = new Parameters("foo.exe -three two");

            var command = new FakeCommand();
            
            Assert.Throws<RequiredParameterMissingException>(() => command.BindParameters(parameters));
        }
    }
}
