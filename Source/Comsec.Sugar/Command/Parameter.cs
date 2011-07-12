namespace Comsec.Lib.Console
{
    /// <summary>
    /// Represents a command line argument
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        public Parameter()
        {
            Name = string.Empty;
            Value = string.Empty;
        }

        /// <summary>
        /// Gets or sets the name of the argument, e.g. "-username"
        /// This value can be blank
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the argument, e.g. "user_x".
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Value))
            {
                return Name;
            }
            else
            {
                return Name + " " + Value;
            }
        }
    }
}