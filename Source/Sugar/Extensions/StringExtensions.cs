using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Sugar.Mime;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether this string contains any numeric values.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if  the given string contains any numeric values; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAnyNumeric(this string value)
        {
            return ContainsAny(value, "1234567890");
        }

        /// <summary>
        /// Determines whether this string contains non-standard characters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [contains non standard characters] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsNonStandardCharacters(this string value)
        {
            var result = false;

            if (!string.IsNullOrWhiteSpace(value))
            {
                result = value.Any(ch => char.GetUnicodeCategory(ch) == UnicodeCategory.OtherLetter);
            }

            return result;
        }

        /// <summary>
        /// Determines whether this string contains any of the characters in the given input.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified value contains any; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsAny(this string value, string input)
        {
            var result = false;

            if (!string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(value))
            {
                foreach (var @char in input)
                {
                    result = value.Contains(@char.ToString());

                    if (result) break;
                }
            }
            return result;
        }

        /// <summary>
        /// Finds the occurences of a pattern in this string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>A list of matches.</returns>
        public static List<string> FindOccurences(this string input, string pattern)
        {
            var matches = new List<string>();

            if (!string.IsNullOrWhiteSpace(input))
            {
                var bodyMatches = Regex.Matches(input, pattern);

                matches.AddRange(from Match match in bodyMatches select match.Value);
            }

            return matches;
        }

        /// <summary>
        /// Returns a collection of strings from this CSV formatted string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// Handles quoted fields, not sure how quotes are escaped within though.
        /// </remarks>
        public static IList<string> FromCsv(this string value)
        {
            return value.FromCsv<string>();
        }

        /// <summary>
        /// Returns a collection of <see cref="T" /> from this CSV formatted string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="allowEmptyResult">
        /// If set to <c>true</c> allow the function to return an empty result.
        /// If set to <c>false</c> the function will return the complete range of Enum values as a result - 
        /// this is the default behaviour.
        /// </param>
        /// <returns></returns>
        public static IList<T> FromEnumCsv<T>(this string value, bool allowEmptyResult = false) where T : struct
        {
            var results = new List<T>();

            var allValues = Enum.GetValues(typeof (T))
                                .Cast<T>()
                                .ToList();

            if (!string.IsNullOrEmpty(value))
            {
                var candidates = value.Split(",");

                foreach (var candidate in candidates)
                {
                    T status;

                    if (Enum.TryParse(candidate, true, out status))
                    {
                        if (!results.Contains(status) && allValues.Contains(status))
                        {
                            results.Add(status);
                        }
                    }
                }
            }

            // Return everything is nothing selected
            if (results.Count == 0 && !allowEmptyResult)
            {
                results = allValues;
            }

            return results;
        }

        /// <summary>
        /// Returns a collection of <see cref="T" /> from this CSV formatted string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IList<T> FromCsv<T>(this string value)
        {
            var results = new List<T>();

            if (!string.IsNullOrEmpty(value))
            {
                var current = string.Empty;
                var inQuotes = false;

                foreach (var @char in value.ToCharArray())
                {
                    if (@char == ',' && !inQuotes)
                    {
                        if (!string.IsNullOrEmpty(current))
                        {
                            var newValue = (T) Convert.ChangeType(current, typeof (T));

                            if (newValue != null) results.Add(newValue);

                            current = string.Empty;
                        } 
                    }
                    else if (@char == '"')
                    {
                        inQuotes = !inQuotes;
                    }
                    else
                    {
                        current += @char;
                    }
                }

                if (!string.IsNullOrEmpty(current))
                {
                    var newValue = (T) Convert.ChangeType(current, typeof (T));

                    if (newValue != null) results.Add(newValue);
                }
            }

            return results;
        }

        /// <summary>
        /// Gets the content type of a file from this string
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">When the mime type cannot be determined.</exception>
        public static BaseMime GetMimeType(this string filename)
        {
            var mimeTypes = MimeTypes.Generate();

            var extension = Path.GetExtension(filename);

            if (string.IsNullOrEmpty(extension)) extension = "";

            extension = extension.Replace(".", "").ToLower();

            var result = mimeTypes.FirstOrDefault(m => m.Extensions.Contains(extension));

            if (result == null)
            {
                throw new ApplicationException($"Unkown extension to get mime type for filename '{filename}'");
            }

            return result;
        }

        /// <summary>
        /// Keeps the alpha-numeric characters in this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string KeepAlphaNumeric(this string value)
        {
            return value.Keep("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");
        }

        /// <summary>
        /// Keeps the specified characters in this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="keepTheseCharacters">The characters to keep.</param>
        /// <returns></returns>
        public static string Keep(this string value, string keepTheseCharacters)
        {
            var result = string.Empty;

            if (value != null)
            {
                result = value.ToCharArray()
                    .Where(@char => keepTheseCharacters.Contains(@char.ToString()))
                    .Aggregate(result, (current, @char) => current + @char);
            }

            return result;
        }

        /// <summary>
        /// Determines whether this string is numeric.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumeric(this string value)
        {
            double temp;

            return double.TryParse(value, out temp);
        }

        /// <summary>
        /// Prepends the specified value to this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="prependWith">The prepend with.</param>
        /// <returns></returns>
        public static string Prepend(this string value, string prependWith)
        {
            var result = prependWith;

            if (!string.IsNullOrWhiteSpace(value))
            {
                result = string.Concat(result, value);
            }

            return result;
        }

        /// <summary>
        /// Creates a new string by repeating this string the specified number of times.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="times">The times.</param>
        /// <returns>System.String.</returns>
        public static string Repeat(this string value, int times)
        {
            var result = string.Empty;

            for (var i = 0; i < times; i++)
            {
                result += value;
            }

            return result;
        }

        /// <summary>
        /// Reverses this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Reverse(this string value)
        {
            var enumerator = StringInfo.GetTextElementEnumerator(value);
            var graphemes = new List<string>();

            while (enumerator.MoveNext())
            {
                graphemes.Add((string)enumerator.Current);
            }

            return string.Join("", graphemes.AsEnumerable().Reverse().ToArray());
        }

        /// <summary>
        /// Splits this string using the given seperator.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="seperator">The seperator.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static IList<string> Split(this string value, string seperator, StringSplitOptions options = StringSplitOptions.None)
        {
            var results = new List<string>();

            if (!string.IsNullOrWhiteSpace(value))
            {
                results.AddRange(value.Split(new[] { seperator }, options));
            }

            return results;
        }

        /// <summary>
        /// Determines whether this string starts with the specified value.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">The value to check if it starts with.</param>
        /// <param name="isCaseSensitive">if set to <c>true</c> [is case sensitive].</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool StartsWith(this string source, string value, bool isCaseSensitive)
        {
            var comparisonOption = isCaseSensitive ? StringComparison.CurrentCulture : StringComparison.InvariantCultureIgnoreCase;

            return source.StartsWith(value, comparisonOption);
        }

        /// <summary>
        /// Determines whether this string starts with the specified value.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">The value to check if it starts with.</param>
        /// <param name="comparisonOption">The comparison option.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool StartsWith(this string source, string value, StringComparison comparisonOption)
        {
            return source.IndexOf(value, 0, comparisonOption) == 0;
        }

        /// <summary>
        /// Returns a new string created from all the characters after the first occurence of the matching value in this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="match">The match.</param>
        /// <returns>System.String.</returns>
        public static string SubstringAfterChar(this string value, string match)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(match))
            {
                if (value.Contains(match))
                {
                    result = value.Substring(value.IndexOf(match) + match.Length);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a new string created from all the characters after the last occurence of the matching value in this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="match">The match.</param>
        /// <returns>System.String.</returns>
        public static string SubstringAfterLastChar(this string value, string match)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(match))
            {
                if (value.Contains(match))
                {
                    result = value.Substring(value.LastIndexOf(match) + match.Length);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a new string created from all the characters before the first occurence of the matching value in this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public static string SubstringBeforeChar(this string value, string match)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(match))
            {
                if (value.Contains(match))
                {
                    result = value.Substring(0, value.IndexOf(match));
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a new string created from all the characters before the last occurence of the matching value in this string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public static string SubstringBeforeLastChar(this string value, string match)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(match))
            {
                if (value.Contains(match))
                {
                    result = value.Substring(0, value.LastIndexOf(match));
                }
            }

            return result;
        }

        /// <summary>
        /// Converts this string to a byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>
        /// http://stackoverflow.com/questions/472906/net-string-to-byte-array-c-sharp
        /// </remarks>
        public static byte[] ToBytes(this string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];

            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }

        /// <summary>
        /// Converts this string into a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>SqlDateTime.MinValue when it fails to Parse the DateTime</returns>
        public static DateTime ToDateTime(this string value)
        {
            return value.ToDateTime(SqlDateTime.MinValue.Value);
        }

        /// <summary>
        /// Converts this string into a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="default">The @default value.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, DateTime @default)
        {
            var result = @default;

            if (!string.IsNullOrEmpty(value))
            {
                if (!DateTime.TryParse(value, out result))
                {
                    result = @default;
                }
            }

            return result;
        }

        /// <summary>
        /// Converts this string into a <see cref="DateTime"/> object using the specified format.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <returns>SqlDateTime.MinValue when it fails to Parse the DateTime</returns>
        public static DateTime ToDateTime(this string value, string format)
        {
            return value.ToDateTime(format, SqlDateTime.MinValue.Value);
        }

        /// <summary>
        /// Converts this string into a <see cref="DateTime"/> object using the specified format.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="default">The @default.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, string format, DateTime @default)
        {
            var result = @default;

            if (!string.IsNullOrEmpty(value))
            {
                if (!DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    result = @default;
                }
            }

            return result;
        }

        /// <summary>
        /// Convert this ISO 8601 string to a <see cref="DateTime"/>
        /// Examples: 2009-10-08T08:22:02Z, 20091008T082202
        /// </summary>
        /// <param name="value">The date time in the ISO 8601 format.</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromIso8601(this string value)
        {
            var result = value.ConvertFromIso8601();

            if (result.HasValue)
            {
                return result.Value;
            }

            throw new ApplicationException("The given date-time string was not in an ISO8061 format.");
        }

        /// <summary>
        /// Tries to convert this ISO 8601 (e.g. 20100130T235959) value to a <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="time">The time in the ISO 8601 format.</param>
        /// <returns></returns>
        public static bool TryToDateTimeFromIso8601(this string value, out DateTime time)
        {
            var result = value.ConvertFromIso8601();

            time = new DateTime();

            if (result.HasValue)
            {
                time = result.Value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts this ISO 8601 string to a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static DateTime? ConvertFromIso8601(this string value)
        {
            DateTime? result = null;

            var formats = new[]
                          {
                              "yyyy-MM-ddTHH:mm:ssK",
                              "yyyyMMddTHHmmssK",

                              "yyyy-MM-ddTHH:mm:ss",
                              "yyyyMMddTHHmmss",

                              "yyyy-MM-ddTHH:mmK",
                              "yyyyMMddTHHmmK",

                              "yyyy-MM-ddTHH:mm",
                              "yyyyMMddTHHmm",

                              "yyyy-MM-ddTHHK",
                              "yyyyMMddTHHK",

                              "yyyy-MM-ddTHH",
                              "yyyyMMddTHH",

                              "yyyy-MM-dd",
                              "yyyyMMdd"
                          };

            foreach (var format in formats)
            {
                DateTime resultForFormat;

                if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out resultForFormat))
                {
                    result = resultForFormat;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Convert this string to <see cref="double"/>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            return value.ToDouble(0);
        }

        /// <summary>
        /// Convert this string to <see cref="double"/>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="default">The @default.</param>
        /// <returns></returns>
        public static double ToDouble(this string value, double @default)
        {
            if (!string.IsNullOrEmpty(value))
            {
                double.TryParse(value, out @default);
            }

            return @default;
        }

        /// <summary>
        /// Convert this string to <see cref="int"/>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            return value.ToInt(0);
        }

        /// <summary>
        /// Convert this string to <see cref="int"/> with a default if the string is empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="default">The @default.</param>
        /// <returns></returns>
        public static int ToInt(this string value, int @default)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                int.TryParse(value, out @default);
            }

            return @default;
        }

        /// <summary>
        /// Convert this string to <see cref="long"/>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static long ToLong(this string value)
        {
            return value.ToLong(0);
        }

        /// <summary>
        /// Convert this string to <see cref="long"/> with a default if the string is empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="default">The @default.</param>
        /// <returns></returns>
        public static long ToLong(this string value, long @default)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                long.TryParse(value, out @default);
            }

            return @default;
        }

        /// <summary>
        /// Returns a MD5 hash representation of this string
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static string ToMd5(this string value, Encoding encoding = null)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                if(encoding == null) encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(value);

                bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);

                var builder = new StringBuilder();

                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2").ToLower());
                }

                result = builder.ToString();
            }

            return result;
        }

        /// <summary>
        /// Converts this mime type string to an <see cref="ImageFormat"/>
        /// </summary>
        /// <param name="mime">The MIME.</param>
        /// <returns></returns>
        public static ImageFormat ToImageFormat(this string mime)
        {
            var imageFormat = ImageFormat.Jpeg;

            var imageDecoders = ImageCodecInfo.GetImageDecoders()
                                              .Where(codec => codec.MimeType == mime);

            foreach (var codec in imageDecoders)
            {
                if (ImageFormat.Bmp.Guid == codec.FormatID) return ImageFormat.Bmp;
                if (ImageFormat.Emf.Guid == codec.FormatID) return ImageFormat.Emf;
                if (ImageFormat.Exif.Guid == codec.FormatID) return ImageFormat.Exif;
                if (ImageFormat.Gif.Guid == codec.FormatID) return ImageFormat.Gif;
                if (ImageFormat.Icon.Guid == codec.FormatID) return ImageFormat.Icon;
                if (ImageFormat.Jpeg.Guid == codec.FormatID) return ImageFormat.Jpeg;
                if (ImageFormat.MemoryBmp.Guid == codec.FormatID) return ImageFormat.MemoryBmp;
                if (ImageFormat.Png.Guid == codec.FormatID) return ImageFormat.Png;
                if (ImageFormat.Tiff.Guid == codec.FormatID) return ImageFormat.Tiff;
                if (ImageFormat.Wmf.Guid == codec.FormatID) return ImageFormat.Wmf;
            }

            return imageFormat;
        }

        /// <summary>
        /// Converts this string to Title Case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToTitleCase(this string value)
        {
            var result = string.Empty;

            if (!string.IsNullOrWhiteSpace(value))
            {
                result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
            }

            return result;
        }

        /// <summary>
        /// Trims this string to the given length.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string TrimTo(this string value, int length)
        {
            return TrimTo(value, length, String.Empty);
        }

        /// <summary>
        /// Trims this string to the given length, appending to the end to indicate that has overrun the length.
        /// e.g. 'This string is too long to...'
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="overrunIndicator">The overrun indicator.</param>
        /// <returns>System.String.</returns>
        public static string TrimTo(this string value, int length, string overrunIndicator)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > length)
                {
                    result = value.Substring(0, length - overrunIndicator.Length) + overrunIndicator;
                }
            }

            return result;
        }
    }
}
