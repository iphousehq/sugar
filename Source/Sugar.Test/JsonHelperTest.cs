using System;
using NUnit.Framework;
using Sugar.Json;

namespace Sugar
{
    [TestFixture]
    public class JsonHelperTest
    {
        [Test]
        public void TestDecodeJson()
        {
            const string raw = @"
{ 
    ""glossary"": 
    { 
        ""title"": ""example glossary""
    }
}";

            var json = raw.DecodeJson();

            Assert.AreEqual("example glossary", json.glossary.title);
        }

        [Test]
        public void TestDecodeJsonWithCollections()
        {
            const string raw = @"
{  
    ""array"": [        
    {
        ""glossary"": 
        { 
            ""title"": ""example glossary""
        }
    },
    {
        ""glossary"": 
        { 
            ""title"": ""second example glossary""
        }
    }]
}";

            var json = raw.DecodeJson();

            var index = 0;

            foreach (var row in json.array)
            {

                if (index == 0) Assert.AreEqual("example glossary", row.glossary.title);
                if (index == 1) Assert.AreEqual("second example glossary", row.glossary.title);

                index++;
            }
        }

        [Test]
        public void TestHasMember()
        {
            const string raw = @"
{ 
    ""glossary"": 
    { 
        ""title"": ""example glossary""
    }
}";

            var json = (DynamicJsonObject) raw.DecodeJson();

            Assert.AreEqual(true, json.HasMember("glossary"));
            Assert.AreEqual(false, json.HasMember("bob"));
        }

        [Test]
        public void TestConvertJsonToStringNull()
        {
            dynamic json = null;

            var result = JsonHelper.ConvertJsonToString(json);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void TestConvertJsonToString()
        {
            dynamic json = "test";

            var result = JsonHelper.ConvertJsonToString(json);

            Assert.AreEqual("test", result);
        }

        [Test]
        public void TestConvertJsonToIntNull()
        {
            dynamic json = null;

            var result = JsonHelper.ConvertJsonToInt(json);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestConvertJsonToInt()
        {
            dynamic json = "5";

            var result = JsonHelper.ConvertJsonToInt(json);

            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestConvertJsonToDoubleNull()
        {
            dynamic json = null;

            var result = JsonHelper.ConvertJsonToDouble(json);

            Assert.AreEqual(0.0, result);
        }

        [Test]
        public void TestConvertJsonToDouble()
        {
            dynamic json = "5.5";

            var result = JsonHelper.ConvertJsonToDouble(json);

            Assert.AreEqual(5.5, result);
        }

        [Test]
        public void TestConvertJsonToBoolNull()
        {
            dynamic json = null;

            var result = JsonHelper.ConvertJsonToBool(json);

            Assert.False(result);
        }

        [Test]
        public void TestConvertJsonToBool()
        {
            dynamic json = "True";

            var result = JsonHelper.ConvertJsonToBool(json);

            Assert.True(result);
        }

        enum Foo
        {
            Bar,
            Foobar
        }

        [Test]
        public void TestConvertJsonToEnumNull()
        {
            dynamic json = null;

            var result = JsonHelper.ConvertJsonToEnum<Foo>(json);

            Assert.AreEqual(Foo.Bar, result);
        }

        [Test]
        public void TestConvertJsonToEnumException()
        {
            dynamic json = "Barfoo";

            Assert.Throws<ApplicationException>(() => JsonHelper.ConvertJsonToEnum<Foo>(json), "Could not convert JSON value Barfoo  to enum of type Foo");
        }

        [Test]
        public void TestConvertJsonToEnum()
        {
            dynamic json = "Foobar";

            var result = JsonHelper.ConvertJsonToEnum<Foo>(json);

            Assert.AreEqual(Foo.Foobar, result);
        }
    }
}
