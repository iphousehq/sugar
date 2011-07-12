namespace Comsec.Lib.Console
{
    /// <summary>
    /// Parses a string array to return a argument list.
    /// </summary>
    public static class ParameterParser
    {
        /// <summary>
        /// Parses the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static Parameters Parse(string[] args)
        {
            var parameters = new Parameters();

            for (var i = 0; i < args.Length; i++)
            {
                var argument = new Parameter();

                var arg = args[i];

                if (arg.StartsWith("-"))
                {
                    argument.Name = arg;

                    if (i + 1 < args.Length)
                    {
                        var nextArg = args[i + 1];

                        if (!nextArg.StartsWith("-"))
                        {
                            argument.Value = nextArg;

                            i++;
                        }
                    }
                }
                else
                {
                    argument.Value = args[i];
                }

                parameters.Add(argument);
            }

            return parameters;
        }
    }
}