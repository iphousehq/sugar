using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sugar
{
    /// <summary>
    /// To CSV extension
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns a comma seprated value representation of this list of T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="separator">The seperator.</param>
        /// <param name="lastSeparator">The last separator (is set to separator when null or empty).</param>
        /// <returns></returns>
        public static string ToCsv<T>(this IEnumerable<T> values, string separator = ",", string lastSeparator = null)
        {
            var result = new StringBuilder();

            if (values != null)
            {
                if (String.IsNullOrEmpty(lastSeparator))
                {
                    lastSeparator = separator;
                }

                var lastIndex = values.Count() - 1;
                var index = 0;

                foreach (var value in values)
                {
                    if (index == lastIndex) result.Append(lastSeparator);
                    else if (result.Length > 0) result.Append(separator);

                    result.Append(value);
                    index++;
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts a CSV string to list of <see cref="T"/> objects.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IList<T> FromCsv<T>(this string value)
        {
            var results = new List<T>();

            if (value != null)
            {
                var current = string.Empty;
                var inQuotes = false;

                foreach (var @char in value.ToCharArray())
                {
                    if (@char == ',' && !inQuotes)
                    {
                        var newValue = (T)Convert.ChangeType(current, typeof(T));

                        results.Add(newValue);

                        current = string.Empty;
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
                    var newValue = (T)Convert.ChangeType(current, typeof(T));

                    results.Add(newValue);
                }
            }

            return results;
        }

        /// <summary>
        /// Returns a collection of strings from the given CSV formatted string.
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
    }
}
