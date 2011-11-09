using System.Collections.Generic;

namespace Sugar
{
    public static class ToWordsExtension
    {
        private const char WordDelimiter = '\n';

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
