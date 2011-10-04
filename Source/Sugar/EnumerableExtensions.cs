using System;
using System.Collections.Generic;
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
        /// <param name="seperator">The seperator.</param>
        /// <returns></returns>
        public static string ToCsv<T>(this IEnumerable<T> values, string seperator = ",")
        {
            var result = new StringBuilder();

            if (values != null)
            {
                foreach (var value in values)
                {
                    if (result.Length > 0) result.Append(seperator);

                    result.Append(value);
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
