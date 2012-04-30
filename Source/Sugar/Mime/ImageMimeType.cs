using System.ComponentModel;

namespace Sugar.Mime
{
    /// <summary>
    /// Mime sub-types for images
    /// </summary>
    public enum ImageMimeType
    {
        /// <summary>
        /// Bitmap image file
        /// </summary>
        [Description("bmp")]
        Bitmap,

        /// <summary>
        /// Portable Network Graphics image file
        /// </summary>
        [Description("png")]
        Png,

        /// <summary>
        /// JPEG image file
        /// </summary>
        [Description("jpeg")]
        Jpeg,

        /// <summary>
        /// TIFF image file
        /// </summary>
        [Description("tiff")]
        Tiff,

        /// <summary>
        /// SVG vector image file
        /// </summary>
        [Description("svg+xml")]
        Svg,

        /// <summary>
        /// Icon
        /// </summary>
        [Description("x-icon")]
        Icon
    }
}