using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sugar.Command
{
    /// <summary>
    /// Parses a string array to return a argument list.
    /// </summary>
    public class ParameterParser
    {
        /// <summary>
        /// Parses the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <param name="switches">The switches.</param>
        /// <returns></returns>
        public Parameters Parse(IEnumerable<string> args, IEnumerable<string> switches = null)
        {
            var parameters = new Parameters();

            parameters.AddRange(args);

            if (switches != null)
            {
                parameters.Switches.Clear();

                foreach (var @switch in switches)
                {
                    if (string.IsNullOrWhiteSpace(@switch)) continue;

                    parameters.Switches.Add(@switch);
                }
            }

            return parameters;
        }

        /// <summary>
        /// Parses the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <param name="switches">The switches.</param>
        /// <returns></returns>
        public Parameters Parse(string args, IEnumerable<string> switches = null)
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

            return Parse(parameters, switches);
        }
    }
}