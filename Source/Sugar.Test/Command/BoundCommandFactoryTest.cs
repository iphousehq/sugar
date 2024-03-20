using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    [TestFixture]
    public class BoundCommandFactoryTest
    {
        private class FakeCommandOne : BoundCommand<FakeCommandOne.Options>
        {
            [Flag("fake", "one")]
            public class Options { }

            public override int Execute(Options options)
            {
                return 0;
            }
        }

        private class FakeCommandTwo : BoundCommand<FakeCommandTwo.Options>
        {
            [Flag("fake")]
            public class Options { }

            public override int Execute(Options options)
            {
                return 0;
            }
        }

        private class FakeCommandThree : BoundCommand<FakeCommandThree.Options>
        {
            [Flag("fake", "group")]
            public class Options {}

            public override int Execute(Options options)
            {
                return 0;
            }
        }

        private class FakeCommandFour : BoundCommand<FakeCommandFour.Options>
        {
            [Flag("fake", "one", "group")]
            public class Options {}

            public override int Execute(Options options)
            {
                return 0;
            }
        }

        private class FakeCommandFive : BoundAsyncCommand<FakeCommandFive.Options>
        {
            [Flag("fake", "five")]
            public class Options { }

            public override Task<int> Execute(Options options, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(0);
            }
        }

        private BoundCommandFactory factory;

        private readonly IEnumerable<Type> availableCommandOptions = new[]
                                                                     {
                                                                         typeof(FakeCommandOne.Options),
                                                                         typeof(FakeCommandTwo.Options),
                                                                         typeof(FakeCommandThree.Options),
                                                                         typeof(FakeCommandFour.Options),
                                                                         typeof(FakeCommandFive.Options)
                                                                     };

        [SetUp]
        public void Setup()
        {
            factory = new BoundCommandFactory();
        }

        [Test]
        public void TestResolveCommandOne()
        {
            var parameters = new Parameters("foo.exe -blah -something -fake -one");

            var result = factory.GetCommandType(parameters, () => availableCommandOptions);

            Assert.That(result, Is.EqualTo(typeof(FakeCommandOne)));
        }

        [Test]
        public void TestResolveCommandTwo()
        {
            var parameters = new Parameters("foo.exe -blah -something -fake");

            var result = factory.GetCommandType(parameters, () => availableCommandOptions);

            Assert.That(result, Is.EqualTo(typeof(FakeCommandTwo)));
        }
        
        [Test]
        public void TestResolveCommandThreeWhenAnotherCommandsSharesFlags()
        {
            var parameters = new Parameters("foo.exe -fake -group");

            var result = factory.GetCommandType(parameters, () => availableCommandOptions);

            Assert.That(result, Is.EqualTo(typeof(FakeCommandThree)));
        }

        [Test]
        public void TestResolveCommandFourWhenAnotherCommandsSharesFlags()
        {
            var parameters = new Parameters("foo.exe -fake -one -group");

            var result = factory.GetCommandType(parameters, () => availableCommandOptions);

            Assert.That(result, Is.EqualTo(typeof(FakeCommandFour)));
        }

        [Test]
        public void TestResolveCommandFiveWhichIsAsync()
        {
            var parameters = new Parameters("foo.exe -fake -five");

            var result = factory.GetCommandType(parameters, () => availableCommandOptions);

            Assert.That(result, Is.EqualTo(typeof(FakeCommandFive)));
        }
    }
}
