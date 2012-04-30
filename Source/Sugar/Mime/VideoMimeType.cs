using System.ComponentModel;

namespace Sugar.Mime
{
    /// <summary>
    /// Mime sub-types for video
    /// </summary>
    public enum VideoMimeType
    {
        /// <summary>
        /// AVI video
        /// </summary>
        [Description("avi")]
        Avi,

        /// <summary>
        /// MPEG video
        /// </summary>
        [Description("mpeg")]
        Mpeg,

        /// <summary>
        /// MPEG4 video
        /// </summary>
        [Description("mp4")]
        Mpeg4,

        /// <summary>
        /// Quicktime video
        /// </summary>
        [Description("quicktime")]
        Quicktime,

        /// <summary>
        /// Windows Media video
        /// </summary>
        [Description("x-ms-wmv")]
        WindowsMedia,

        /// <summary>
        /// Flash video
        /// </summary>
        [Description("x-flv")]
        Flash
    }
}