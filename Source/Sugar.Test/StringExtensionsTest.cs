using System;
using System.Linq;
using NUnit.Framework;
using Sugar.Mime;

namespace Sugar
{
    [TestFixture]
    public class StringExtensionsTest
    {
#if !CLIENT
        [Test]
        public void TestHtmlDecode()
        {
            var decoded = "test&amp;&#32;".HtmlDecode();

            Assert.AreEqual("test& ", decoded);
        }

        [Test]
        public void TestHtmlDecodeNullValue()
        {
            var decoded = ((string)null).HtmlDecode();

            Assert.IsNull(decoded);
        }

        [Test]
        public void TestHtmlEncode()
        {
            var decoded = "test& ".HtmlEncode();

            Assert.AreEqual("test&amp; ", decoded);
        }

        [Test]
        public void TestHtmlEncodeNullValue()
        {
            var decoded = ((string)null).HtmlEncode();

            Assert.IsNull(decoded);
        }
#endif
        [Test]
        public void TestStartsWithAndIgnoreCase()
        {
            const string value = "Bonjour";

            var result = value.StartsWith("BON", true);
            Assert.IsFalse(result);

            result = value.StartsWith("bon", false);
            Assert.IsTrue(result);

            result = value.StartsWith("jour", true);
            Assert.IsFalse(result);
        }

        [Test]
        public void TestSubStringEmptyString()
        {
            Assert.AreEqual(string.Empty, string.Empty.SubstringAfterChar("c"));
        }

        [Test]
        public void TestSubStringWithNonMatchingString()
        {
            Assert.AreEqual("banana", "banana".SubstringAfterChar("c"));
        }

        [Test]
        public void TestSubStringWithMatchingString()
        {
            Assert.AreEqual("ana", "banana".SubstringAfterChar("n"));
        }


        [Test]
        public void TestSubStringBeforeWithMatchingString()
        {
            Assert.AreEqual("ba", "banana".SubstringBeforeChar("n"));
        }

        [Test]
        public void TestSubStringBeforeLastWithMatchingString()
        {
            Assert.AreEqual("bana", "banana".SubstringBeforeLastChar("n"));
        }


        [Test]
        public void TestSubStringAfterLastChar()
        {
            Assert.AreEqual("ba", "ab-ban-ba".SubstringAfterLastChar("-"));
        }

        [Test]
        public void TestKeep()
        {
            Assert.AreEqual("12", "1234".Keep("12"));
        }

        [Test]
        public void TestKeepWhenNull()
        {
            Assert.AreEqual(string.Empty, ((string)null).Keep("12"));
        }

        [Test]
        public void TestContainsAny()
        {
            Assert.IsTrue("1234".ContainsAny("123"));
            Assert.IsFalse("Hello".ContainsAny("123"));
        }

        [Test]
        public void TestContainsAnyNumeric()
        {
            Assert.IsTrue("1234".ContainsAnyNumeric());
            Assert.IsFalse("Hello".ContainsAnyNumeric());
        }

        [Test]
        public void TestIsNumeric()
        {
            Assert.IsTrue("1234".IsNumeric());
            Assert.IsFalse("Hello".IsNumeric());
        }

        [Test]
        public void TestTrimToWhenShorterThanMax()
        {
            var result = "Bonjour".TrimTo(32);

            Assert.AreEqual("Bonjour", result);
        }

        [Test]
        public void TestTrimToWhenLongerThanMax()
        {
            var result = "Hello World!".TrimTo(6);

            Assert.AreEqual("Hello ", result);
        }

        [Test]
        public void TestTrimToWhenLongerThanMaxWithOverrunIndicator()
        {
            var result = "Hello World!".TrimTo(6, "...");

            Assert.AreEqual("Hel...", result);
        }

        [Test]
        public void TestSplitString()
        {
            var result = "one two".Split(" ");

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("one", result[0]);
            Assert.AreEqual("two", result[1]);
        }

        [Test]
        public void TestSplitStringOnWordSeperator()
        {
            var result = "onethreetwothreefour".Split("three");

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("one", result[0]);
            Assert.AreEqual("two", result[1]);
            Assert.AreEqual("four", result[2]);
        }

        [Test]
        public void TestSplitStringOnWordSeperatorRemovesEmptyWords()
        {
            var result = "onethreetwothreethreefour".Split("three", StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void TestJoinStrings()
        {
            Assert.AreEqual("onetwo", new[] { "one", "two" }.Join());
            Assert.AreEqual("one two", new[] { "one", "two" }.Join(" "));
            Assert.AreEqual("one two", new[] { "one", "", null, "two" }.Join(" "));
            Assert.AreEqual("", new string[0].Join(" "));
            Assert.AreEqual("", ((string[])null).Join(" "));
        }

        [Test]
        public void TestJoinPhrases()
        {
            var phrases = new[] { "one", "two", "three" };

            Assert.AreEqual("one, two or three", phrases.JoinPhrases());
            Assert.AreEqual("one, two and three", phrases.JoinPhrases(lastSeperator: "and"));

            var morePhrases = new[] { "one", "two three", "four" };

            Assert.AreEqual(@"one, ""two three"" or four", morePhrases.JoinPhrases());
        }

        [Test]
        public void TestGetMimeType()
        {
            var mimeType = "something.jpg".GetMimeType();

            Assert.AreEqual(BaseMimeType.Image, mimeType.BaseMimeType);
            Assert.AreEqual(ImageMimeType.Jpeg, mimeType.MimeType);
        }

        [Test]
        public void TestGetUnkownMimeType()
        {
            Assert.Throws<ApplicationException>(() => "unkownExtention.rsfx".GetMimeType());
        }

        [Test]
        public void TestGetMimeTypeCapitalised()
        {
            var mimeType = "something.JPG".GetMimeType();

            Assert.AreEqual(BaseMimeType.Image, mimeType.BaseMimeType);
            Assert.AreEqual(ImageMimeType.Jpeg, mimeType.MimeType);
        }

        [Test]
        public void TestToMD5()
        {
            var hash = "hello world".ToMD5();

            Assert.AreEqual("5EB63BBBE01EEED093CB22BB8F5ACDC3", hash);
        }

        [Test]
        public void TestFromPascalCase()
        {
            var result = "helloWorldPascalCase".FromPascalCase();

            Assert.AreEqual("hello world pascal case", result);
        }

        [Test]
        public void TestFromPascalCaseWhenNull()
        {
            var result = ((string) null).FromPascalCase();

            Assert.AreEqual("", result);
        }
        [Test]
        public void TestToTitleCase()
        {
            var result = "hello world title case".ToTitleCase();

            Assert.AreEqual("Hello World Title Case", result);
        }

        [Test]
        public void TestToTitleCaseWhenNull()
        {
            var result = ((string)null).ToTitleCase();

            Assert.AreEqual("", result);
        }

        [Test]
        public void TestReverse()
        {
            var result = "hello world".Reverse();

            Assert.AreEqual("dlrow olleh", result);
        }

        [Test]
        public void TestToWordsNullOrEmptyString()
        {
            var words = ((string)null).ToWords();

            Assert.AreEqual(0, words.Count);

            words = string.Empty.ToWords();

            Assert.AreEqual(0, words.Count);
        }

        [Test]
        public void TestToWordsOneWord()
        {
            var words = "one".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsOneWordOneSpace()
        {
            var words = "one ".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsOneWordTwoSpaces()
        {
            var words = "one  ".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsOneWordPrefixedWithComma()
        {
            var words = ",one".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsOneWordPostfixedWithComma()
        {
            var words = "one,".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsOneWordPrefixedAndPostfixedWithCommas()
        {
            var words = ",one,".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }


        [Test]
        public void TestToWordsOneWordPrefixedWithSemicolon()
        {
            var words = ";one".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsOneWordPostfixedWithSemicolon()
        {
            var words = "one;".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsOneWordPrefixedAndPostfixedWithSemicolons()
        {
            var words = ";one;".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }


        [Test]
        public void TestToWordsOneWordPrefixedAndPostfixedWithIgnoredCharacters()
        {
            var words = " ,;one;, ".ToWords();

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsTwoWords()
        {
            var words = "one two".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestToWordsTwoWordsSeparatedWithComma()
        {
            var words = "one,two".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestToWordsTwoWordsSeparatedWithSemicolon()
        {
            var words = "one;two".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestToWordsTwoWordsSeparatedWithIgnoredCharacters()
        {
            var words = "one;;,,  two".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestToWordsTwoWordsSeparatedAndPrefixedAndSuffixedWithIgnoredCharacters()
        {
            var words = "  ,,;;one;;,,  two ; , ;,".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestToWordsTwoWordsWithQuotes()
        {
            var words = @"one ""two three""".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two three", words[1]);
        }

        [Test]
        public void TestToWordsThreeWordsWithQuotes()
        {
            var words = @"one ""two three"" four".ToWords();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two three", words[1]);
            Assert.AreEqual("four", words[2]);
        }

        [Test]
        public void TestToWordsThreeWordsWithQuotesSurroundedByIgnroedCharacters()
        {
            var words = @",; one ""two three"",; four".ToWords();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two three", words[1]);
            Assert.AreEqual("four", words[2]);
        }

        [Test]
        public void TestToWordsTwoWordsWithQuotesAndSpecialCharactersInQuotes()
        {
            var words = @"one ""two,; three""".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two,; three", words[1]);
        }

        [Test]
        public void TestToWordsTwoWordsWithQuotesAndSpecialCharactersInQuotesSurroundedByIgnroedCharacters()
        {
            var words = @",; one ""two,; three"",; ".ToWords();

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two,; three", words[1]);
        }

        [Test]
        public void TestToWordsOneWordIgnoreQuotes()
        {
            var words = @"one".ToWords(true);

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsOneWordInQuotesIgnoreQuotes()
        {
            var words = @"""one""".ToWords(true);

            Assert.AreEqual(1, words.Count);
            Assert.AreEqual("one", words[0]);
        }

        [Test]
        public void TestToWordsTwoWordsIgnoreQuotes()
        {
            var words = @"one two".ToWords(true);

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestToWordsTwoWordsInQuotesIgnoreQuotes()
        {
            var words = @"""one two""".ToWords(true);

            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
        }

        [Test]
        public void TestToWordsThreeWordsInQuotesWithExtraIgnoreQuotes()
        {
            var words = @"""one two"" three".ToWords(true);

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("one", words[0]);
            Assert.AreEqual("two", words[1]);
            Assert.AreEqual("three", words[2]);
        }

        [Test]
        public void TestToCharactersNullOrEmptyString()
        {
            var words = ((string)null).ToWords();

            Assert.AreEqual(0, words.Count);

            words = string.Empty.ToCharacters();

            Assert.AreEqual(0, words.Count);
        }

        [Test]
        public void TestToCharactersOneWord()
        {
            var words = "one".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }

        [Test]
        public void TestToCharactersOneWordOneSpace()
        {
            var words = "one ".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }

        [Test]
        public void TestToCharactersOneWordTwoSpaces()
        {
            var words = "one  ".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }

        [Test]
        public void TestToCharactersOneWordPrefixedWithComma()
        {
            var words = ",one".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }

        [Test]
        public void TestToCharactersOneWordPostfixedWithComma()
        {
            var words = "one,".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }

        [Test]
        public void TestToCharactersOneWordPrefixedAndPostfixedWithCommas()
        {
            var words = ",one,".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }


        [Test]
        public void TestToCharactersOneWordPrefixedWithSemicolon()
        {
            var words = ";one".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }

        [Test]
        public void TestToCharactersOneWordPostfixedWithSemicolon()
        {
            var words = "one;".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }

        [Test]
        public void TestToCharactersOneWordPrefixedAndPostfixedWithSemicolons()
        {
            var words = ";one;".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }


        [Test]
        public void TestToCharactersOneWordPrefixedAndPostfixedWithIgnoredCharacters()
        {
            var words = " ,;one;, ".ToCharacters();

            Assert.AreEqual(3, words.Count);
            Assert.AreEqual("o", words[0]);
            Assert.AreEqual("n", words[1]);
            Assert.AreEqual("e", words[2]);
        }

        [Test]
        public void TestContainsNonStandardCharacterTrue()
        {
            var result = "馬".ContainsNonStandardCharacters();

            Assert.True(result);
        }

        [Test]
        public void TestContainsNonStandardCharacterFalse()
        {
            var result = "G".ContainsNonStandardCharacters();

            Assert.False(result);
        }

        [Test]
        public void TestContainsNonStandardCharacterWhenEmpty()
        {
            var result = "".ContainsNonStandardCharacters();

            Assert.False(result);
        }

        [Test]
        public void TestContainsNonStandardCharacterWhenNull()
        {
            string nullString = null;

            var result = nullString.ContainsNonStandardCharacters();

            Assert.False(result);
        }
    }
}
