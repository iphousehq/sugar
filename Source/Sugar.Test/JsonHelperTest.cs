using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class JsonHelperTest
    {
        [Test]
        public void TestDecodeJson()
        {
            var raw = @"{ 
                            ""glossary"": { 
                                ""title"": ""example glossary""
                                }
                          }";

            var json = raw.DecodeJson();

            Assert.AreEqual("example glossary", json.glossary.title);
        }

        [Test]
        public void TestDecodeJsonWithCollections()
        {
            var raw = @"{  ""array"": [
                            {
                            ""glossary"": { 
                                ""title"": ""example glossary""
                                }
                            },
                            {
                            ""glossary"": { 
                                ""title"": ""second example glossary""
                                }
                            } ]
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
    }
}
