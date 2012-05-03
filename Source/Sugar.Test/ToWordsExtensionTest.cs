using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class ToWordsExtensionTest
    {
        [Test]
        public void TestNullOrEmptyString()
        {
            var words = ((string)null).ToWords();

            Assert.AreEqual(0, words.Count);

            words = string.Empty.ToWords();

            Assert.AreEqual(0, words.Count);
        }

        [Test]
        public void TestOneWord()
        {
            var words = "one".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestOneWordOneSpace()
        {
            var words = "one ".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestOneWordTwoSpaces()
        {
            var words = "one  ".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestOneWordPrefixedWithComma()
        {
            var words = ",one".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestOneWordPostfixedWithComma()
        {
            var words = "one,".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestOneWordPrefixedAndPostfixedWithCommas()
        {
            var words = "one,".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }


        [Test]
        public void TestOneWordPrefixedWithSemicolon()
        {
            var words = ";one".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestOneWordPostfixedWithSemicolon()
        {
            var words = "one;".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestOneWordPrefixedAndPostfixedWithSemicolons()
        {
            var words = ";one;".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }


        [Test]
        public void TestOneWordPrefixedAndPostfixedWithIgnoredCharacters()
        {
            var words = " ,;one;, ".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestTwoWords()
        {
            var words = "one two".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestTwoWordsSeparatedWithComma()
        {
            var words = "one,two".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestTwoWordsSeparatedWithSemicolon()
        {
            var words = "one;two".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestTwoWordsSeparatedWithIgnoredCharacters()
        {
            var words = "one;;,,  two".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestTwoWordsSeparatedAndPrefixedAndSuffixedWithIgnoredCharacters()
        {
            var words = "  ,,;;one;;,,  two ; , ;,".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestTwoWordsWithQuotes()
        {
            var words = @"one ""two three""".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two three", words[1]);
        }

        [Test]
        public void TestThreeWordsWithQuotes()
        {
            var words = @"one ""two three"" four".ToWords();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two three", words[1]);
            Assert.AreEqual("four", words[2]);
        }

        [Test]
        public void TestThreeWordsWithQuotesSurroundedByIgnroedCharacters()
        {
            var words = @",; one ""two three"",; four".ToWords();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two three", words[1]);
            Assert.AreEqual("four", words[2]);
        }

        [Test]
        public void TestTwoWordsWithQuotesAndSpecialCharactersInQuotes()
        {
            var words = @"one ""two,; three""".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two,; three", words[1]);
        }

        [Test]
        public void TestTwoWordsWithQuotesAndSpecialCharactersInQuotesSurroundedByIgnroedCharacters()
        {
            var words = @",; one ""two,; three"",; ".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two,; three", words[1]);
        }

        [Test]
        public void TestResursiveSingleWord()
        {
            var words = @"one".ToWordsRecursive();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestResursiveSingleWordInQuotes()
        {
            var words = @"""one""".ToWordsRecursive();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestResursiveMultipleWords()
        {
            var words = @"one two".ToWordsRecursive();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestResursiveMultipleWordsInQuotes()
        {
            var words = @"""one two""".ToWordsRecursive();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestResursiveMultipleWordsInQuotesWithExtra()
        {
            var words = @"""one two"" three".ToWordsRecursive();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
            Assert.AreEqual("three", words[2]);
        }

        
    }
}
