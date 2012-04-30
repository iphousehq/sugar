using System;

namespace Sugar.Mime
{
    /// <summary>
    /// Audio MIME type.
    /// </summary>
    public class AudioMime : BaseMime
    {
        /// <summary>
        /// Gets or sets the type of the base MIME.
        /// </summary>
        /// <value>
        /// The type of the base MIME.
        /// </value>
        public override BaseMimeType BaseMimeType
        {
            get { return BaseMimeType.Audio; }
        }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        public override Enum MimeType
        {
            get { return AudioMimeType; }
        }

        /// <summary>
        /// Gets or sets the type of the audio MIME.
        /// </summary>
        /// <value>
        /// The type of the audio MIME.
        /// </value>
        public AudioMimeType AudioMimeType { get; set; }
    }
}