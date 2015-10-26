using System;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
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
            var result = "20/05/2010 15:10:50".ToDateTime();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(05, result.Month);
            Assert.AreEqual(20, result.Day);
            Assert.AreEqual(15, result.Hour);
            Assert.AreEqual(10, result.Minute);
            Assert.AreEqual(50, result.Second);
        }

        [Test]
        public void TestToDateStringInvalidValueDefaultToSqlMinTime()
        {
            var result = "bonjour".ToDateTime();

            Assert.AreEqual(1753, result.Year);
        }

        [Test]
        public void TestToDateTimeWithCustomFormat()
        {
            var result = "23-45-59 2011_01_30".ToDateTime("HH-mm-ss yyyy_MM_dd");

            Assert.AreEqual(2011, result.Year);
            Assert.AreEqual(1, result.Month);
            Assert.AreEqual(30, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(45, result.Minute);
            Assert.AreEqual(59, result.Second);
        }

        [Test]
        public void TestToDateTimeWithCustomFormatButIsInvalid()
        {
            var result = "bonjour".ToDateTime("HH-mm-ss yyyy_MM_dd");

            Assert.AreEqual(1753, result.Year);
        }

        [Test]
        public void TestToDateFromIso8601()
        {
            var result = "20101231T235955+0100".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(22, result.Hour);
            Assert.AreEqual(59, result.Minute);
            Assert.AreEqual(55, result.Second);
            Assert.AreEqual(0, result.Millisecond);

            result = "20101231T235955".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(59, result.Minute);
            Assert.AreEqual(55, result.Second);
            Assert.AreEqual(0, result.Millisecond);

            result = "20101231T2359".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(59, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);

            result = "20101231T23".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);

            result = "20101231".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(0, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);
        }

        [Test]
        public void TestToDateFromIso8601WithHyphenAndSemiColon()
        {
            var result = "2010-12-31T23:59:55+01:00".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(22, result.Hour);
            Assert.AreEqual(59, result.Minute);
            Assert.AreEqual(55, result.Second);
            Assert.AreEqual(0, result.Millisecond);

            result = "2010-12-31T23:59:55".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(59, result.Minute);
            Assert.AreEqual(55, result.Second);
            Assert.AreEqual(0, result.Millisecond);

            result = "2010-12-31T23:59".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(59, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);

            result = "2010-12-31T23".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);

            result = "2010-12-31".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(0, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);
        }

        [Test]
        public void GetImageFormatFromMimeType()
        {
            var format = "image/png".ToImageFormat();

            Assert.AreEqual(ImageFormat.Png, format);
        }

        [Test]
        public void GetImageFormatFromMimeTypeNotRecognised()
        {
            var format = "wtf".ToImageFormat();

            Assert.AreEqual(ImageFormat.Jpeg, format);
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
        public void TestKeepAlphaNumeric()
        {
            Assert.AreEqual("100FOObar", "100£$£&*(FOO::>?>?\"bar".KeepAlphaNumeric());
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

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("one", result[0]);
            Assert.AreEqual("two", result[1]);
        }

        [Test]
        public void TestSplitStringOnWordSeperator()
        {
            var result = "onethreetwothreefour".Split("three");

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("one", result[0]);
            Assert.AreEqual("two", result[1]);
            Assert.AreEqual("four", result[2]);
        }

        [Test]
        public void TestSplitStringOnWordSeperatorRemovesEmptyWords()
        {
            var result = "onethreetwothreethreefour".Split("three", StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(3, result.Count);
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
        public void TestToMd5()
        {
            var hash = "hello world".ToMd5();

            Assert.AreEqual("5eb63bbbe01eeed093cb22bb8f5acdc3", hash);
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
        public void TestReverseWithUnicode()
        {
            var result = "Les Mise\u0301rables".Reverse();

            Assert.AreEqual("selbarésiM seL", result);
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

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(SomeEnum.Bob, results[0]);
        }

        [Test]
        public void TestParseMultipleRemovalStatuses()
        {
            var results = "Bob,Thursday".FromEnumCsv<SomeEnum>();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(SomeEnum.Bob, results[0]);
            Assert.AreEqual(SomeEnum.Thursday, results[1]);
        }

        [Test]
        public void TestParseDuplicateRemovalStatuses()
        {
            var results = "Bob,Thursday,Bob".FromEnumCsv<SomeEnum>();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(SomeEnum.Bob, results[0]);
            Assert.AreEqual(SomeEnum.Thursday, results[1]);
        }

        [Test]
        public void TestParseInvalidRemovalStatuses()
        {
            var results = "Ducky,Thursday,Bob".FromEnumCsv<SomeEnum>();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(SomeEnum.Thursday, results[0]);
            Assert.AreEqual(SomeEnum.Bob, results[1]);
        }

        [Test]
        public void TestParseNumericRemovalStatuses()
        {
            var results = "40,Thursday".FromEnumCsv<SomeEnum>();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(SomeEnum.Bob, results[0]);
            Assert.AreEqual(SomeEnum.Thursday, results[1]);
        }

        [Test]
        public void TestParseNumericRemovalStatusesWhenOutOfRange()
        {
            var results = "400,Thursday".FromEnumCsv<SomeEnum>();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(SomeEnum.Thursday, results[0]);
        }

        [Test]
        public void TestParseRemovalStatusesWhenHasEmptyValues()
        {
            var results = "Thursday,,Thursday".FromEnumCsv<SomeEnum>();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(SomeEnum.Thursday, results[0]);
        }

        [Test]
        public void TestParseRemovalStatusesWhenHasAllEmptyValues()
        {
            var results = ",,".FromEnumCsv<SomeEnum>();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(SomeEnum.Bob, results[0]);
        }

        [Test]
        public void TestParseRemovalStatusesWhenHasAllEmptyString()
        {
            var results = "".FromEnumCsv<SomeEnum>();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(SomeEnum.Bob, results[0]);
        }

        [Test]
        public void TestFromOneFieldString()
        {
            var results = "One".FromCsv();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("One", results[0]);
        }

        [Test]
        public void TestFromTwoFieldString()
        {
            var results = "One,Two".FromCsv();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("One", results[0]);
            Assert.AreEqual("Two", results[1]);
        }

        [Test]
        public void TestFromThreeFieldString()
        {
            var results = "One,Two,Three".FromCsv();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("One", results[0]);
            Assert.AreEqual("Two", results[1]);
            Assert.AreEqual("Three", results[2]);
        }

        [Test]
        public void TestFromQuotedString()
        {
            var results = @"One,""Two,Three,Four"",Three".FromCsv();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("One", results[0]);
            Assert.AreEqual("Two,Three,Four", results[1]);
            Assert.AreEqual("Three", results[2]);
        }

        [Test]
        public void TestFromCsvListOfInts()
        {
            var results = "1,2,3".FromCsv<int>();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(1, results[0]);
            Assert.AreEqual(2, results[1]);
            Assert.AreEqual(3, results[2]);
        }

        [Test]
        public void TestAsInt32()
        {
            Assert.AreEqual(100, "100".ToInt());
        }

        [Test]
        public void TestAsInt32WithEmptyValue()
        {
            Assert.AreEqual(0, "".ToInt());
        }

        [Test]
        public void TestAsInt32WithWhiteSpaceValue()
        {
            Assert.AreEqual(0, " ".ToInt());
        }

        [Test]
        public void TestAsInt64()
        {
            Assert.AreEqual(1000000000000000, "1000000000000000".ToLong());
        }

        [Test]
        public void TestAsInt64WhenEmptyString()
        {
            Assert.AreEqual(0, "".ToLong());
        }

        [Test]
        public void TestAsInt64WhenWhiteSpaceString()
        {
            Assert.AreEqual(0, " ".ToLong());
        }

        [Test]
        public void TestToBytes()
        {
            var bytes = "Hello World!".ToBytes();

            Assert.AreEqual(24, bytes.Length);
        }

        [Test]
        public void TestParseDateTime()
        {
            const string dateTimeValue = "2010-11-11 20:30:00";

            var dateTime = dateTimeValue.ToDateTime();

            Assert.AreEqual(new DateTime(2010, 11, 11, 20, 30, 00), dateTime);
        }

        [Test]
        public void TestParseDateTimeWithDefaultValue()
        {
            const string dateTimeValue = "2010-11-11 20:30:00";

            var dateTime = dateTimeValue.ToDateTime(new DateTime(1666, 9, 2, 16, 00, 00));

            Assert.AreEqual(new DateTime(2010, 11, 11, 20, 30, 00), dateTime);
        }

        [Test]
        public void TestParseInvalidDateTimeWithDefaultValue()
        {
            const string dateTimeValue = "2x10-11-11 20:30:00";

            var dateTime = dateTimeValue.ToDateTime(new DateTime(1666, 9, 2, 16, 00, 00));

            Assert.AreEqual(new DateTime(1666, 9, 2, 16, 00, 00), dateTime);
        }

        [Test]
        public void TestFindOccurencesInNullString()
        {
            var matches = ((string)null).FindOccurences(@"\d{4}");

            Assert.AreEqual(0, matches.Count);
        }

        [Test]
        public void TestFindOccurencesInEmptyString()
        {
            var matches = string.Empty.FindOccurences(@"\d{4}");

            Assert.AreEqual(0, matches.Count);
        }

        [Test]
        public void TestFindOccurencesInString()
        {
            const string input = "1234, 1235, 1236, blahblah";

            var matches = input.FindOccurences(@"\d{4}");

            Assert.AreEqual(3, matches.Count);
        }

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
        public void TestFromIntegerArray()
        {
            var result = "1,2,3".FromCsv<int>();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
        }

        [Test]
        public void TestToEmptyListOfInts()
        {
            var result = "".FromCsv<int>();

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void TestHashValue()
        {
            Assert.AreEqual("0cbc6611f5540bd0809a388dc95a615b", "Test".ToMd5());
        }

        [Test]
        public void TestHashPassword()
        {
            const string guid = "0cbc6611f5540bd0809a388dc95a615b";

            const string pass = "Hellospank" + guid;

            Assert.AreEqual("cea4d691cd2dc0de878e01a86f668355", pass.ToMd5());
        }

        [Test]
        public void TestHashNull()
        {
            Assert.AreEqual(string.Empty, string.Empty.ToMd5());
        }
    }
}
