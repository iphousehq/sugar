using System.ComponentModel;

namespace Sugar.Mime
{
    /// <summary>
    /// The base part of a mime type.
    /// A mime is made up of [base] / [sub]
    /// </summary>
    public enum BaseMimeType
    {
        /// <summary>
        /// Multipurpose files
        /// </summary>
        [Description("application")]
        Application,

        /// <summary>
        /// Audio files
        /// </summary>
        [Description("audio")]
        Audio,

        /// <summary>
        /// Image files
        /// </summary>
        [Description("image")]
        Image,

        /// <summary>
        /// Human-readable text and source code.
        /// </summary>
        [Description("text")]
        Text,

        /// <summary>
        /// Video files
        /// </summary>
        [Description("video")]
        Video,

        /// <summary>
        /// Messages (e.g. message/rfc822)
        /// </summary>
        [Description("message")]
        Message
    }
}