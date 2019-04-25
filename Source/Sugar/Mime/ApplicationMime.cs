using System;

namespace Sugar.Mime
{
    /// <summary>
    /// Application MIME type.
    /// </summary>
    public class ApplicationMime : BaseMime
    {
        /// <summary>
        /// Gets or sets the type of the base MIME.
        /// </summary>
        /// <value>
        /// The type of the base MIME.
        /// </value>
        public override BaseMimeType BaseMimeType => BaseMimeType.Application;

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        public override Enum MimeType => ApplicationMimeType;

        /// <summary>
        /// Gets or sets the type of the application MIME.
        /// </summary>
        /// <value>
        /// The type of the application MIME.
        /// </value>
        public ApplicationMimeType ApplicationMimeType { get; set; }
    }
}