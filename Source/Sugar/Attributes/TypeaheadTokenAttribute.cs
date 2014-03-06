using System;

namespace Sugar.Attributes
{
    /// <summary>
    /// Provides a single word token (alternative spelling) for twitter typeahead.js.
    /// </summary>
    /// <remarks>This attribute is used on <see cref="Sugar.Country.CountryCode"/> to provide alternative spellings/abbreviations for countries. </remarks>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class TypeaheadTokenAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeaheadTokenAttribute"/> class.
        /// </summary>
        /// <param name="token">The single-word token (alternative spelling).</param>
        public TypeaheadTokenAttribute(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("Typeahead tokens must not be null or empty.", "token");
            }

            if (token.Contains(" "))
            {
                throw new ArgumentException("Typeahead tokens must be single words.", "token");
            }

            Token = token;
        }

        /// <summary>
        /// Gets or sets the alternative spellings.
        /// </summary>
        /// <value>
        /// The alternative spellings.
        /// </value>
        public string Token { get; set; }
    }
}