using System.Collections.Generic;

namespace Sugar
{
    public static class ToWordsExtension
    {
        private const char WordDelimiter = '\n';

        /// <summary>
        /// Split a string into words.
        /// This is done recursively on the result to ensure words in quotes are split.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IList<string> ToWordsRecursive(this string value)
        {
            var split = new List<string>();

            if (value.Contains(" "))
            {
                var words = value.ToWords();

                foreach (var w in words)
                {
                    split.AddRange(ToWordsRecursive(w));
                }
            }
            else
            {
                split.Add(value.ToLower());
            }

            return split;
        }

        /// <summary>
        /// Split a string into words.
        /// Words enclosed in quotes will not be split.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IList<string> ToWords(this string value)
        {
            var words = new List<char>();

            if (!string.IsNullOrEmpty(value))
            {
                var inQuoteRun = false;
                var breakAdded = false;
                var firstWordFound = false;

                foreach (var @char in value.ToCharArray())
                {
                    if (IsQuote(@char))
                    {
                        firstWordFound = true;
                        inQuoteRun = !inQuoteRun;
                    }

                    var inUnquoatedSpaceCharacterRun = !inQuoteRun && IsSpaceCharacter(@char);

                    if (!inQuoteRun && inUnquoatedSpaceCharacterRun && !breakAdded && firstWordFound)
                    {
                        words.Add(WordDelimiter);
                        breakAdded = true;
                    }

                    if (inUnquoatedSpaceCharacterRun || IsQuote(@char)) continue;

                    firstWordFound = true;
                    words.Add(@char);
                    breakAdded = false;
                }
            }

            if (words.Count >= 1 && words[words.Count - 1] == WordDelimiter)
            {
                words.RemoveAt(words.Count - 1);
            }

            return words.Count > 0 ?
                (new string(words.ToArray())).Split(WordDelimiter) :
                new string[0];
        }

        private static bool IsQuote(char @char)
        {
            return @char == '"';
        }

        private static bool IsSpaceCharacter(char @char)
        {
            return @char == ',' || @char == ';' || @char == ' ';
        }
    }
}
