using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

            foreach (var optionType in getOptionsTypes())
            {
                var flagAttribute = (FlagAttribute) optionType.GetCustomAttribute(typeof (FlagAttribute), false);

                var containsAllParameters = flagAttribute.Names.All(parameters.Contains);

                if (containsAllParameters)
                {
                    // Assumes that the options type is declared within the command
                    commandType = optionType.DeclaringType;
                    break;
                }
            }

            return commandType;
        }
    }
}