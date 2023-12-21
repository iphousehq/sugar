using NUnit.Framework;

namespace Sugar.Reflection
{
    [TestFixture]
    public class ReflectionExtensionsTest
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
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void TestSetValueUsingReflection()
        {
            var testA = new TestA();
            testA.SetValueOf<TestA, int>("testInt", 3);
            Assert.That(testA.TestInt, Is.EqualTo(3));
        }

        [Test]
        public void TestPrivateProperty()
        {
            var a = new TestA();

            Assert.That(a.PrivateSetter, Is.EqualTo(0));

            a.SetProtectedPropertyValue("PrivateSetter", 123);

            Assert.That(a.PrivateSetter, Is.EqualTo(123));
        }

        [Test]
        public void TestPropertyOnParent()
        {
            var childOfA = new ChildOfA();

            Assert.That(childOfA.PrivateSetter, Is.EqualTo(0));

            childOfA.SetProtectedPropertyValue("PrivateSetter", 123);

            Assert.That(childOfA.PrivateSetter, Is.EqualTo(123));
        }
    }
}
