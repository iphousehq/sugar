using System;
using System.Collections.Generic;

namespace Sugar.Command
{
    /// <summary>
    /// Attribute to allow bind a command line parameter to a class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class FlagAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterAttribute"/> class.
        /// </summary>
        /// <param name="names">The names.</param>
        public FlagAttribute(params string[] names)
        {
            Names = new List<string>(names);
        }       
      
        /// <summary>
        /// Gets the names.
        /// </summary>
        public IList<string> Names { get; private set; }
    }
}
