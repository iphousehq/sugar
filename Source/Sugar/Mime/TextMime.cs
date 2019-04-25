using System;

namespace Sugar.Mime
{
    /// <summary>
    /// Text MIME type.
    /// </summary>
    public class TextMime : BaseMime
    {
        /// <summary>
        /// Gets or sets the type of the base MIME.
        /// </summary>
        /// <value>
        /// The type of the base MIME.
        /// </value>
        public override BaseMimeType BaseMimeType => BaseMimeType.Text;

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        public override Enum MimeType => TextMimeType;

        /// <summary>
        /// Gets or sets the type of the text MIME.
        /// </summary>
        /// <value>
        /// The type of the text MIME.
        /// </value>
        public TextMimeType TextMimeType { get; set; }
    }
}