using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    /// <summary>
    /// Factory to get the a command type from the parameters passed into the console.
    /// </summary>
    public class BoundCommandFactory
    {
        /// <summary>
        /// Gets the type of the command to execute using the parameters passed into the console.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="getOptionsTypes">Lambda function to get the types of the options to examine.</param>
        /// <returns></returns>
        public Type GetCommandType(Parameters parameters, Func<IEnumerable<Type>> getOptionsTypes)
        {
            Type commandType = null;

            var types = getOptionsTypes();

            var typesWithAttributes = types.Select(t => new KeyValuePair<Type, string[]>(t, ((FlagAttribute) t.GetCustomAttribute(typeof(FlagAttribute), false)).Names));

            // Match parameters to commands with the most flags first
            typesWithAttributes = typesWithAttributes.OrderByDescending(x => x.Value.Length);

            foreach (var keyValuePair in typesWithAttributes)
            {
                var containsAllParameters = keyValuePair.Value.All(parameters.Contains);

                if (containsAllParameters)
                {
                    // Assumes that the options type is declared within the command
                    commandType = keyValuePair.Key.DeclaringType;
                    break;
                }
            }

            return commandType;
        }
    }
}