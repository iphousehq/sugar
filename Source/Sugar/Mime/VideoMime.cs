using System;

namespace Sugar.Mime
{
    /// <summary>
    /// Video MIME type.
    /// </summary>
    public class VideoMime : BaseMime
    {
        /// <summary>
        /// Gets or sets the type of the base MIME.
        /// </summary>
        /// <value>
        /// The type of the base MIME.
        /// </value>
        public override BaseMimeType BaseMimeType
        {
            get { return BaseMimeType.Video; }
        }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        public override Enum MimeType
        {
            get { return VideoMimeType; }
        }

        /// <summary>
        /// Gets or sets the type of the video MIME.
        /// </summary>
        /// <value>
        /// The type of the video MIME.
        /// </value>
        public VideoMimeType VideoMimeType { get; set; }
    }
}