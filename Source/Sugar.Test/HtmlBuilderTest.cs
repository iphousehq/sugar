using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class HtmlBuilderTest
    {
        [Test]
        public void TestBuildParagraph()
        {
            var builder = new HtmlBuilder();

            using (builder.P())
            {                
            }

            Assert.That(builder.ToString(), Is.EqualTo("<p></p>"));
        }

        [Test]
        public void TestBuildTwoParagraphs()
        {
            var builder = new HtmlBuilder();

            using (builder.P())
            {
            }

            using (builder.P())
            {
            }

            Assert.That(builder.ToString(), Is.EqualTo("<p></p><p></p>"));
        }

        [Test]
        public void TestBuildThreeParagraphs()
        {
            var builder = new HtmlBuilder();

            using (builder.P())
            {
            }

            using (builder.P())
            {
            }

            using (builder.P())
            {
            }

            Assert.That(builder.ToString(), Is.EqualTo("<p></p><p></p><p></p>"));
        }

        [Test]
        public void TestBuildNestedParagraphs()
        {
            var builder = new HtmlBuilder();

            using (var p = builder.P())
            {
                using (p.P())
                {
                }
            }

            Assert.That(builder.ToString(), Is.EqualTo("<p><p></p></p>"));
        }

        [Test]
        public void TestBuildParagraphWithAttribute()
        {
            var builder = new HtmlBuilder();

            using (builder.P(new { name = "paragraph" }))
            {
            }

            Assert.That(builder.ToString(), Is.EqualTo(@"<p name=""paragraph""></p>"));
        }

        [Test]
        public void TestBuildParagraphWithAttributes()
        {
            var builder = new HtmlBuilder();

            using (builder.P(new { name = "paragraph", id = "para" }))
            {
            }

            Assert.That(builder.ToString(), Is.EqualTo(@"<p name=""paragraph"" id=""para""></p>"));
        }

        [Test]
        public void TestBuildParagraphMergeAttributes()
        {
            var builder = new HtmlBuilder();

            using (var p = builder.P(new { name = "paragraph" }))
            {
                p.Attribute("id", "para");
            }

            Assert.That(builder.ToString(), Is.EqualTo(@"<p name=""paragraph"" id=""para""></p>"));
        }

        [Test]
        public void TestBuildParagraphMergeTwoAttributes()
        {
            var builder = new HtmlBuilder();

            using (var p = builder.P())
            {
                p.Attribute("class", "para1");
                p.Attribute("class", "para2");
            }

            Assert.That(builder.ToString(), Is.EqualTo(@"<p class=""para1 para2""></p>"));
        }

        [Test]
        public void TestBuildParagraphMergeTwoAttributesClearsFirst()
        {
            var builder = new HtmlBuilder();

            using (var p = builder.P())
            {
                p.Attribute("class", "para1");
                p.Attribute("class", "para2", true);
            }

            Assert.That(builder.ToString(), Is.EqualTo(@"<p class=""para2""></p>"));
        }

        [Test]
        public void TestBuildParagraphMergeClass()
        {
            var builder = new HtmlBuilder();

            using (var p = builder.P())
            {
                p.Class("para1");
            }

            Assert.That(builder.ToString(), Is.EqualTo(@"<p class=""para1""></p>"));
        }


        [Test]
        public void TestBuildParagraphMergeMultipleAttributes()
        {
            var builder = new HtmlBuilder();

            using (var div = builder.Div())
            {
                using (var p = div.P())
                {
                    p.Class("para1").Id("test").For("div");
                }
            }

            Assert.That(builder.ToString(), Is.EqualTo(@"<div><p class=""para1"" id=""test"" for=""div""></p></div>"));
        }
    }
}
