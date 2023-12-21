using System;
using System.Drawing.Imaging;
using NUnit.Framework;
using Sugar.Mime;

namespace Sugar.Extensions
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void TestToDateValidString()
        {
            var result = "2010-05-20 15:10:50".ToDateTime();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(05));
            Assert.That(result.Day, Is.EqualTo(20));
            Assert.That(result.Hour, Is.EqualTo(15));
            Assert.That(result.Minute, Is.EqualTo(10));
            Assert.That(result.Second, Is.EqualTo(50));
        }

        [Test]
        public void TestToDateStringInvalidValueDefaultToSqlMinTime()
        {
            var result = "bonjour".ToDateTime();

            Assert.That(result.Year, Is.EqualTo(1753));
        }

        [Test]
        public void TestToDateTimeWithCustomFormat()
        {
            var result = "23-45-59 2011_01_30".ToDateTime("HH-mm-ss yyyy_MM_dd");

            Assert.That(result.Year, Is.EqualTo(2011));
            Assert.That(result.Month, Is.EqualTo(1));
            Assert.That(result.Day, Is.EqualTo(30));
            Assert.That(result.Hour, Is.EqualTo(23));
            Assert.That(result.Minute, Is.EqualTo(45));
            Assert.That(result.Second, Is.EqualTo(59));
        }

        [Test]
        public void TestToDateTimeWithCustomFormatButIsInvalid()
        {
            var result = "bonjour".ToDateTime("HH-mm-ss yyyy_MM_dd");

            Assert.That(result.Year, Is.EqualTo(1753));
        }

        [Test]
        public void TestToDateFromIso8601()
        {
            var result = "20101231T235955+0100".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(22));
            Assert.That(result.Minute, Is.EqualTo(59));
            Assert.That(result.Second, Is.EqualTo(55));
            Assert.That(result.Millisecond, Is.EqualTo(0));

            result = "20101231T235955".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(23));
            Assert.That(result.Minute, Is.EqualTo(59));
            Assert.That(result.Second, Is.EqualTo(55));
            Assert.That(result.Millisecond, Is.EqualTo(0));

            result = "20101231T2359".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(23));
            Assert.That(result.Minute, Is.EqualTo(59));
            Assert.That(result.Second, Is.EqualTo(0));
            Assert.That(result.Millisecond, Is.EqualTo(0));

            result = "20101231T23".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(23));
            Assert.That(result.Minute, Is.EqualTo(0));
            Assert.That(result.Second, Is.EqualTo(0));
            Assert.That(result.Millisecond, Is.EqualTo(0));

            result = "20101231".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(0));
            Assert.That(result.Minute, Is.EqualTo(0));
            Assert.That(result.Second, Is.EqualTo(0));
            Assert.That(result.Millisecond, Is.EqualTo(0));
        }

        [Test]
        public void TestToDateFromIso8601WithHyphenAndSemiColon()
        {
            var result = "2010-12-31T23:59:55+01:00".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(22));
            Assert.That(result.Minute, Is.EqualTo(59));
            Assert.That(result.Second, Is.EqualTo(55));
            Assert.That(result.Millisecond, Is.EqualTo(0));

            result = "2010-12-31T23:59:55".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(23));
            Assert.That(result.Minute, Is.EqualTo(59));
            Assert.That(result.Second, Is.EqualTo(55));
            Assert.That(result.Millisecond, Is.EqualTo(0));

            result = "2010-12-31T23:59".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(23));
            Assert.That(result.Minute, Is.EqualTo(59));
            Assert.That(result.Second, Is.EqualTo(0));
            Assert.That(result.Millisecond, Is.EqualTo(0));

            result = "2010-12-31T23".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(23));
            Assert.That(result.Minute, Is.EqualTo(0));
            Assert.That(result.Second, Is.EqualTo(0));
            Assert.That(result.Millisecond, Is.EqualTo(0));

            result = "2010-12-31".ToDateTimeFromIso8601();

            Assert.That(result.Year, Is.EqualTo(2010));
            Assert.That(result.Month, Is.EqualTo(12));
            Assert.That(result.Day, Is.EqualTo(31));
            Assert.That(result.Hour, Is.EqualTo(0));
            Assert.That(result.Minute, Is.EqualTo(0));
            Assert.That(result.Second, Is.EqualTo(0));
            Assert.That(result.Millisecond, Is.EqualTo(0));
        }

        [Test]
        public void GetImageFormatFromMimeType()
        {
            var format = "image/png".ToImageFormat();

            Assert.That(format, Is.EqualTo(ImageFormat.Png));
        }

        [Test]
        public void GetImageFormatFromMimeTypeNotRecognised()
        {
            var format = "wtf".ToImageFormat();

            Assert.That(format, Is.EqualTo(ImageFormat.Jpeg));
        }

        [Test]
        public void TestSubStringEmptyString()
        {
            Assert.That(string.Empty.SubstringAfterChar("c"), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestSubStringWithNonMatchingString()
        {
            Assert.That("banana".SubstringAfterChar("c"), Is.EqualTo("banana"));
        }

        [Test]
        public void TestSubStringWithMatchingString()
        {
            Assert.That("banana".SubstringAfterChar("n"), Is.EqualTo("ana"));
        }

        [Test]
        public void TestSubStringAfterLastChar()
        {
            Assert.That("ab-ban-ba".SubstringAfterLastChar("-"), Is.EqualTo("ba"));
        }

        [Test]
        public void TestSubStringBeforeWithMatchingString()
        {
            Assert.That("banana".SubstringBeforeChar("n"), Is.EqualTo("ba"));
        }

        [Test]
        public void TestSubStringBeforeLastWithMatchingString()
        {
            Assert.That("banana".SubstringBeforeLastChar("n"), Is.EqualTo("bana"));
        }

        [Test]
        public void TestSanitiseHandlesDoubleQuotes()
        {
            Assert.That(@"""boo""", Is.EqualTo("‟boo”".Sanitise()));
        }
        [Test]
        public void TestSanitiseHandlesSingleQuotes()
        {
            Assert.That("'foo'", Is.EqualTo("‘foo’".Sanitise()));
        }

        [Test]
        public void TestSanitiseHandlesHyphens()
        {
            Assert.That("-melon -passionfruit -mangosteen", Is.EqualTo("–melon —passionfruit ―mangosteen".Sanitise()));
        }

        [Test]
        public void TestSanitiseHandlesMultipleSpaces()
        {
            Assert.That("kiwi papaya watermelon", Is.EqualTo("kiwi   papaya       watermelon".Sanitise()));
        }

        [Test]
        public void TestSanitiseTrims()
        {
            Assert.That("food", Is.EqualTo("    food  ".Sanitise()));
        }
   
        [Test]
        public void TestKeep()
        {
            Assert.That("1234".Keep("12"), Is.EqualTo("12"));
        }

        [Test]
        public void TestKeepWhenNull()
        {
            Assert.That(((string)null).Keep("12"), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestKeepAlphaNumeric()
        {
            Assert.That("100£$£&*(FOO::>?>?\"bar".KeepAlphaNumeric(), Is.EqualTo("100FOObar"));
        }

        [Test]
        public void TestContainsAny()
        {
            Assert.That("1234".ContainsAny("123"), Is.True);
            Assert.That("Hello".ContainsAny("123"), Is.False);
        }

        [Test]
        public void TestContainsAnyNumeric()
        {
            Assert.That("1234".ContainsAnyNumeric(), Is.True);
            Assert.That("Hello".ContainsAnyNumeric(), Is.False);
        }

        [Test]
        public void TestIsNumeric()
        {
            Assert.That("1234".IsNumeric(), Is.True);
            Assert.That("Hello".IsNumeric(), Is.False);
        }

        [Test]
        public void TestTrimToWhenShorterThanMax()
        {
            var result = "Bonjour".TrimTo(32);

            Assert.That(result, Is.EqualTo("Bonjour"));
        }

        [Test]
        public void TestTrimToWhenLongerThanMax()
        {
            var result = "Hello World!".TrimTo(6);

            Assert.That(result, Is.EqualTo("Hello "));
        }

        [Test]
        public void TestTrimToWhenLongerThanMaxWithOverrunIndicator()
        {
            var result = "Hello World!".TrimTo(6, "...");

            Assert.That(result, Is.EqualTo("Hel..."));
        }

        [Test]
        public void TestSplitString()
        {
            var result = "one two".Split(" ");

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo("one"));
            Assert.That(result[1], Is.EqualTo("two"));
        }

        [Test]
        public void TestSplitStringOnWordSeperator()
        {
            var result = "onethreetwothreefour".Split("three");

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo("one"));
            Assert.That(result[1], Is.EqualTo("two"));
            Assert.That(result[2], Is.EqualTo("four"));
        }

        [Test]
        public void TestSplitStringOnWordSeperatorRemovesEmptyWords()
        {
            var result = "onethreetwothreethreefour".Split("three", StringSplitOptions.RemoveEmptyEntries);

            Assert.That(result.Length, Is.EqualTo(3));
        }

        [Test]
        public void TestGetMimeType()
        {
            var mimeType = "something.jpg".GetMimeType();

            Assert.That(mimeType.BaseMimeType, Is.EqualTo(BaseMimeType.Image));
            Assert.That(mimeType.MimeType, Is.EqualTo(ImageMimeType.Jpeg));
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

            Assert.That(mimeType.BaseMimeType, Is.EqualTo(BaseMimeType.Image));
            Assert.That(mimeType.MimeType, Is.EqualTo(ImageMimeType.Jpeg));
        }

        [Test]
        public void TestToMd5()
        {
            var hash = "hello world".ToMd5();

            Assert.That(hash, Is.EqualTo("5eb63bbbe01eeed093cb22bb8f5acdc3"));
        }

        [Test]
        public void TestToTitleCase()
        {
            var result = "hello world title case".ToTitleCase();

            Assert.That(result, Is.EqualTo("Hello World Title Case"));
        }

        [Test]
        public void TestToTitleCaseWhenNull()
        {
            var result = ((string)null).ToTitleCase();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void TestReverse()
        {
            var result = "hello world".Reverse();

            Assert.That(result, Is.EqualTo("dlrow olleh"));
        }

        [Test]
        public void TestReverseWithUnicode()
        {
            var result = "Les Mise\u0301rables".Reverse();

            Assert.That(result, Is.EqualTo("selbarésiM seL"));
        }

        [Test]
        public void TestContainsNonStandardCharacterTrue()
        {
            var result = "馬".ContainsNonStandardCharacters();

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestContainsNonStandardCharacterFalse()
        {
            var result = "G".ContainsNonStandardCharacters();

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestContainsNonStandardCharacterWhenEmpty()
        {
            var result = "".ContainsNonStandardCharacters();

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestContainsNonStandardCharacterWhenNull()
        {
            string nullString = null;

            var result = nullString.ContainsNonStandardCharacters();

            Assert.That(result, Is.False);
        }

        private enum SomeEnum
        {
            [System.ComponentModel.Description("Bob Value")]
            Bob = 40,
            Thursday = 50
        }

        [Test]
        public void TestParseRemovalStatuses()
        {
            var results = "Bob".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Bob));
        }

        [Test]
        public void TestParseMultipleRemovalStatuses()
        {
            var results = "Bob,Thursday".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Bob));
            Assert.That(results[1], Is.EqualTo(SomeEnum.Thursday));
        }

        [Test]
        public void TestParseDuplicateRemovalStatuses()
        {
            var results = "Bob,Thursday,Bob".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Bob));
            Assert.That(results[1], Is.EqualTo(SomeEnum.Thursday));
        }

        [Test]
        public void TestParseInvalidRemovalStatuses()
        {
            var results = "Ducky,Thursday,Bob".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Thursday));
            Assert.That(results[1], Is.EqualTo(SomeEnum.Bob));
        }

        [Test]
        public void TestParseNumericRemovalStatuses()
        {
            var results = "40,Thursday".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Bob));
            Assert.That(results[1], Is.EqualTo(SomeEnum.Thursday));
        }

        [Test]
        public void TestParseNumericRemovalStatusesWhenOutOfRange()
        {
            var results = "400,Thursday".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Thursday));
        }

        [Test]
        public void TestParseRemovalStatusesWhenHasEmptyValues()
        {
            var results = "Thursday,,Thursday".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Thursday));
        }

        [Test]
        public void TestParseRemovalStatusesWhenHasAllEmptyValues()
        {
            var results = ",,".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Bob));
        }

        [Test]
        public void TestParseRemovalStatusesWhenHasAllEmptyString()
        {
            var results = "".FromEnumCsv<SomeEnum>();

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo(SomeEnum.Bob));
        }

        [Test]
        public void TestFromOneFieldString()
        {
            var results = "One".FromCsv();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[0], Is.EqualTo("One"));
        }

        [Test]
        public void TestFromTwoFieldString()
        {
            var results = "One,Two".FromCsv();

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo("One"));
            Assert.That(results[1], Is.EqualTo("Two"));
        }

        [Test]
        public void TestFromThreeFieldString()
        {
            var results = "One,Two,Three".FromCsv();

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0], Is.EqualTo("One"));
            Assert.That(results[1], Is.EqualTo("Two"));
            Assert.That(results[2], Is.EqualTo("Three"));
        }

        [Test]
        public void TestFromQuotedString()
        {
            var results = @"One,""Two,Three,Four"",Three".FromCsv();

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0], Is.EqualTo("One"));
            Assert.That(results[1], Is.EqualTo("Two,Three,Four"));
            Assert.That(results[2], Is.EqualTo("Three"));
        }

        [Test]
        public void TestFromCsvListOfInts()
        {
            var results = "1,2,3".FromCsv<int>();

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0], Is.EqualTo(1));
            Assert.That(results[1], Is.EqualTo(2));
            Assert.That(results[2], Is.EqualTo(3));
        }

        [Test]
        public void TestAsInt32()
        {
            Assert.That("100".ToInt(), Is.EqualTo(100));
        }

        [Test]
        public void TestAsInt32WithEmptyValue()
        {
            Assert.That("".ToInt(), Is.EqualTo(0));
        }

        [Test]
        public void TestAsInt32WithWhiteSpaceValue()
        {
            Assert.That(" ".ToInt(), Is.EqualTo(0));
        }

        [Test]
        public void TestAsInt64()
        {
            Assert.That("1000000000000000".ToLong(), Is.EqualTo(1000000000000000));
        }

        [Test]
        public void TestAsInt64WhenEmptyString()
        {
            Assert.That("".ToLong(), Is.EqualTo(0));
        }

        [Test]
        public void TestAsInt64WhenWhiteSpaceString()
        {
            Assert.That(" ".ToLong(), Is.EqualTo(0));
        }

        [Test]
        public void TestParseDateTime()
        {
            const string dateTimeValue = "2010-11-11 20:30:00";

            var dateTime = dateTimeValue.ToDateTime();

            Assert.That(dateTime, Is.EqualTo(new DateTime(2010, 11, 11, 20, 30, 00)));
        }

        [Test]
        public void TestParseDateTimeWithDefaultValue()
        {
            const string dateTimeValue = "2010-11-11 20:30:00";

            var dateTime = dateTimeValue.ToDateTime(new DateTime(1666, 9, 2, 16, 00, 00));

            Assert.That(dateTime, Is.EqualTo(new DateTime(2010, 11, 11, 20, 30, 00)));
        }

        [Test]
        public void TestParseInvalidDateTimeWithDefaultValue()
        {
            const string dateTimeValue = "2x10-11-11 20:30:00";

            var dateTime = dateTimeValue.ToDateTime(new DateTime(1666, 9, 2, 16, 00, 00));

            Assert.That(dateTime, Is.EqualTo(new DateTime(1666, 9, 2, 16, 00, 00)));
        }

        [Test]
        public void TestFindOccurencesInNullString()
        {
            var matches = ((string)null).FindOccurences(@"\d{4}");

            Assert.That(matches.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestFindOccurencesInEmptyString()
        {
            var matches = string.Empty.FindOccurences(@"\d{4}");

            Assert.That(matches.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestFindOccurencesInString()
        {
            const string input = "1234, 1235, 1236, blahblah";

            var matches = input.FindOccurences(@"\d{4}");

            Assert.That(matches.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestStartsWithAndIgnoreCase()
        {
            const string value = "Bonjour";

            var result = value.StartsWith("BON", true);
            Assert.That(result, Is.False);

            result = value.StartsWith("bon", false);
            Assert.That(result, Is.True);

            result = value.StartsWith("jour", true);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestFromIntegerArray()
        {
            var result = "1,2,3".FromCsv<int>();

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(2));
            Assert.That(result[2], Is.EqualTo(3));
        }

        [Test]
        public void TestToEmptyListOfInts()
        {
            var result = "".FromCsv<int>();

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestHashValue()
        {
            Assert.That("Test".ToMd5(), Is.EqualTo("0cbc6611f5540bd0809a388dc95a615b"));
        }

        [Test]
        public void TestHashPassword()
        {
            const string guid = "0cbc6611f5540bd0809a388dc95a615b";

            const string pass = "Hellospank" + guid;

            Assert.That(pass.ToMd5(), Is.EqualTo("cea4d691cd2dc0de878e01a86f668355"));
        }

        [Test]
        public void TestHashNull()
        {
            Assert.That(string.Empty.ToMd5(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestReplaceUnicodeEscapeSequences()
        {
            var value = "Blah blah\u0027blah \u003c\u003eblah\u003d";

            var result = value.ReplaceUnicodeEscapeSequences();

            Assert.That(result, Is.EqualTo("Blah blah'blah <>blah="));
        }

        [Test]
        public void TestExtractNumericWhenValueIsEmpty()
        {
            var result = "".ExtractNumeric();

            Assert.That(result.HasValue, Is.False);
        }

        [Test]
        public void TestExtractNumericWhenValueContainsNoNumeric()
        {
            var result = "abc".ExtractNumeric();

            Assert.That(result.HasValue, Is.True);
            Assert.That(result.Value, Is.EqualTo(0));
        }

        [Test]
        public void TestExtractNumeric()
        {
            var result = "10abc45".ExtractNumeric();

            Assert.That(result.HasValue, Is.True);
            Assert.That(result.Value, Is.EqualTo(1045));
        }
    }
}
