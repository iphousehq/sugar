using System;
using System.ComponentModel;

namespace Sugar.Config
{
    /// <summary>
    /// Represents an entry in a config file.
    /// </summary>
    public class ConfigLine
    {
        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is a comment.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is comment; otherwise, <c>false</c>.
        /// </value>
        public bool IsComment { get; set; }

        /// <summary>
        /// Tries to parse the given value into a <see cref="ConfigLine"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="line">The line.</param>
        /// <param name="commentIndicator">The comment indicator.</param>
        /// <param name="section">The section.</param>
        /// <returns></returns>
        public static bool TryParse(string value, out ConfigLine line, string commentIndicator = "#", string section = "")
        {
            var result = false;

            line = null;

            // indicator valid?
            if (string.IsNullOrWhiteSpace(commentIndicator))
            {
                throw new ArgumentException("Comment indicator can't be null: " + commentIndicator);
            }

            // only process valid lines
            if (!string.IsNullOrWhiteSpace(value))
            {
                // comment?
                if (value.StartsWith(commentIndicator))
                {
                    line = new ConfigLine
                               {
                                   IsComment = true,
                                   Key = string.Empty,
                                   Value = value.Substring(commentIndicator.Length),
                                   Section = section
                               };

                    result = true;
                }
                else if (value.Contains("="))
                {
                    line = new ConfigLine
                               {
                                   Key = value.SubstringBeforeChar("="),
                                   Value = value.SubstringAfterChar("="),
                                   Section = section
                               };

                    result = true;
                }

            }

            return result;
        }
    }
}