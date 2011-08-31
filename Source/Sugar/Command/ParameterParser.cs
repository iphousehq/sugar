using System.Collections.Generic;
using System.Linq;
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
            var matches = Regex
                .Matches(args, @"\""(?<match>.*)""|(?<match>[^\s""]+)")
                .Cast<Match>()
                .Select(m => m.Groups["match"].Value)
                .ToList();

            return Parse(matches, switches);
        }
    }
}