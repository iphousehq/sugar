using System;

namespace Sugar.Command.Binder
{
    /// <summary>
    /// Attribute to allow bind a command line parameter to a class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class FlagAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterAttribute"/> class.
        /// </summary>
        /// <param name="names">The names.</param>
        public FlagAttribute(params string[] names)
        {
            Names = new string[names.Length];
            names.CopyTo(Names, 0);
        }       
      
        /// <summary>
        /// Gets the names.
        /// </summary>
        public string[] Names { get; }
    }
}
