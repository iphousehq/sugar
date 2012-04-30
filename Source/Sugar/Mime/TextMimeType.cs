using System.ComponentModel;

namespace Sugar.Mime
{
    /// <summary>
    /// Mime sub-types for text
    /// </summary>
    public enum TextMimeType
    {
        /// <summary>
        /// Cascading style sheet text
        /// </summary>
        [Description("css")]
        CascadingStyleSheet,

        /// <summary>
        /// Comma seperated value text
        /// </summary>
        [Description("csv")]
        CommaSeperatedValues,

        /// <summary>
        /// HTML text
        /// </summary>
        [Description("html")]
        Html,

        /// <summary>
        /// Plain text
        /// </summary>
        [Description("plain")]
        Plain,

        /// <summary>
        /// Xml text
        /// </summary>
        [Description("xml")]
        Xml
    }
}