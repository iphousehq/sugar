using System.Collections.Generic;

namespace Sugar
{
    public static class ToWordsExtension
    {
        private const char WordDelimiter = '\n';

        /// <summary>
        /// Split a string into words.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreQuotes">if set to <c>true</c> [ignore quotes].</param>
        /// <returns></returns>
        public static IList<string> ToWords(this string value, bool ignoreQuotes = false)
        {
            var split = new List<string>();

            var words = value.ConvertToWords();

            if(ignoreQuotes)
            {
                foreach (var word in words)
                {
                    if (word.Contains(" "))
                    {
                        split.AddRange(ToWords(word, true));
                    }
                    else
                    {
                        split.Add(word);
                    }
                }
            }
            else
            {
                split.AddRange(words);
            }

            return split;
        }

        /// <summary>
        /// Split a string into words.
        /// Words enclosed in quotes will not be split.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static IEnumerable<string> ConvertToWords(this string value)
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
