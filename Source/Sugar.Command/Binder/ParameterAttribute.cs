using System;

namespace Sugar.Command.Binder
{
    /// <summary>
    /// Attribute to allow bind a command line parameter to a class
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ParameterAttribute : Attribute
    {
        private string name;
        private int position;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ParameterAttribute(string name)
        {
            this.name = name;
            position = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterAttribute"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public ParameterAttribute(int position)
        {
            this.position = position;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ParameterAttribute"/> is required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if required; otherwise, <c>false</c>.
        /// </value>
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>
        /// The default.
        /// </value>
        public string Default { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has name.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has name; otherwise, <c>false</c>.
        /// </value>
        public bool HasName => !string.IsNullOrWhiteSpace(name);

        /// <summary>
        /// Gets a value indicating whether this instance has position.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has position; otherwise, <c>false</c>.
        /// </value>
        public bool HasPosition => position > -1;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns></returns>
        public int GetPosition()
        {
            return position;
        }
    }
}
