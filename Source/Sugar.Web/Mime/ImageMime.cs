using System;

namespace Sugar.Mime
{
    /// <summary>
    /// Image MIME type.
    /// </summary>
    public class ImageMime : BaseMime
    {
        /// <summary>
        /// Gets or sets the type of the base MIME.
        /// </summary>
        /// <value>
        /// The type of the base MIME.
        /// </value>
        public override BaseMimeType BaseMimeType
        {
            get { return BaseMimeType.Image; }
        }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        public override Enum MimeType
        {
            get { return ImageMimeType; }
        }

        /// <summary>
        /// Gets or sets the type of the image MIME.
        /// </summary>
        /// <value>
        /// The type of the image MIME.
        /// </value>
        public ImageMimeType ImageMimeType { get; set; }
    }
}