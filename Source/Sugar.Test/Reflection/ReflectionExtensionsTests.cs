using NUnit.Framework;

namespace Sugar.Reflection
{
    [TestFixture]
    public class ReflectionExtensionsTests
    {
        public class TestA
        {
            private int testInt = 5;

            public int TestInt
            {
                get { return testInt; }
                set { testInt = value; }
            }

            public int PrivateSetter { get; protected set; }
        }

        public class ChildOfA : TestA
        {
        }

        [Test]
        public void TestGetValueFromReflection()
        {
            var testA = new TestA();
            var result = testA.GetValueOf<TestA, int>("testInt");
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestSetValueUsingReflection()
        {
            var testA = new TestA();
            testA.SetValueOf<TestA, int>("testInt", 3);
            Assert.AreEqual(3, testA.TestInt);
        }

        [Test]
        public void TestPrivateProperty()
        {
            var a = new TestA();

            Assert.AreEqual(0, a.PrivateSetter);

            a.SetProtectedPropertyValue("PrivateSetter", 123);

            Assert.AreEqual(123, a.PrivateSetter);
        }

        [Test]
        public void TestPropertyOnParent()
        {
            var childOfA = new ChildOfA();

            Assert.AreEqual(0, childOfA.PrivateSetter);

            childOfA.SetProtectedPropertyValue("PrivateSetter", 123);

            Assert.AreEqual(123, childOfA.PrivateSetter);
        }
    }
}
