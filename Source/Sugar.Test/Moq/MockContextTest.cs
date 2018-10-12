using System;
using Moq;
using NUnit.Framework;

namespace Sugar.Moq
{
    [TestFixture]
    public class MockContextTest
    {
        [Test]
        public void TestMockContext()
        {
            var context = new MockContext().AddMock<ICloneable>();

            var mockedObject = context.Of<ICloneable>();

            var clone = new object();

            context.Get<ICloneable>()
                   .Setup(call => call.Clone())
                   .Returns(clone);

            var result = mockedObject.Clone();

            Assert.AreSame(clone, result);

            context.Get<ICloneable>()
                   .Verify(call => call.Clone(), Times.Once());
        }
    }
}
