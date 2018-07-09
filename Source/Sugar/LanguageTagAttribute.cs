using System;

namespace Sugar
{
    /// <summary>
    /// Attribute to decorate a class or enum value with an IETF langage tag (e.g. "en-GB", "en-CA", "en"...).
    /// https://en.wikipedia.org/wiki/IETF_language_tag
    /// https://www.andiamo.co.uk/resources/iso-language-codes
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class LanguageTagAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageTagAttribute"/> class.
        /// </summary>
        /// <param name="languageTag">The language tag.</param>
        public LanguageTagAttribute(string languageTag)
        {
            Tag = languageTag;
        }

        /// <summary>
        /// Gets or sets the language tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; set; }
    }
}
