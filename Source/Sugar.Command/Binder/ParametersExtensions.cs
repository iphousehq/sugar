using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sugar.Command.Binder
{
    /// <summary>
    /// Parses a string array to return a argument list.
    /// </summary>
    public static class ParametersExtensions
    {
        /// <summary>
        /// Parses the specified args.
        /// </summary>
        /// <param name="args">The commandline args (usually straight from <see cref="System.Environment.CommandLine"/>).</param>
        /// <returns></returns>
        public static IList<string> ParseCommandLine(this string args)
        {
            var matches = Regex.Split(args, @"(?<!""\b[^""]*)\s+(?![^""]*\b"")");
            
            var parameters = new List<string>();

            foreach (var match in matches)
            {
                if (match.StartsWith(@"""") && !match.Substring(1).StartsWith("-"))
                {
                    var noQuote = match.Substring(1);

                    if (match.EndsWith(@""""))
                    {
                        noQuote = noQuote.Substring(0, noQuote.Length - 1);
                    }

                    parameters.Add(noQuote);
                }
                else
                {
                    parameters.Add(match);                    
                }
            }

            return parameters;
        }
    }
}