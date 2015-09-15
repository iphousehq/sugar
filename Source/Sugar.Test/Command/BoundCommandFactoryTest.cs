using System;
using System.Collections.Generic;
using NUnit.Framework;

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

        private BoundCommandFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new BoundCommandFactory();
        }

        [Test]
        public void TestResolveCommandOne()
        {
            var parameters = new Parameters("-blah -something -fake -one");

            var result = factory.GetCommandType(parameters, () => new List<Type> { typeof (FakeCommandOne.Options), typeof (FakeCommandTwo.Options) });

            Assert.AreEqual(typeof(FakeCommandOne), result);
        }

        [Test]
        public void TestResolveCommandTwo()
        {
            var parameters = new Parameters("-blah -something -fake");

            var result = factory.GetCommandType(parameters, () => new List<Type> { typeof(FakeCommandOne.Options), typeof(FakeCommandTwo.Options) });

            Assert.AreEqual(typeof(FakeCommandTwo), result);
        }
    }
}