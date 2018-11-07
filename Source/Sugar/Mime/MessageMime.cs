using System;

namespace Sugar.Mime
{
    /// <summary>
    /// Message MIME Type.
    /// </summary>
    public class MessageMime : BaseMime
    {
        /// <summary>
        /// Gets or sets the type of the base MIME.
        /// </summary>
        /// <value>
        /// The type of the base MIME.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public override BaseMimeType BaseMimeType
        {
            get { return BaseMimeType.Message; }
        }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Enum MimeType
        {
            get { return MessageMimeType; }
        }

        /// <summary>
        /// Gets or sets the type of the message MIME.
        /// </summary>
        /// <value>
        /// The type of the message MIME.
        /// </value>
        public MessageMimeType MessageMimeType { get; set; }
    }
}
