using System.Drawing.Imaging;
using System.Linq;

namespace Sugar.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts this mime type string to an <see cref="ImageFormat"/>
        /// </summary>
        /// <param name="mime">The MIME.</param>
        /// <returns></returns>
        public static ImageFormat ToImageFormat(this string mime)
        {
            var imageFormat = ImageFormat.Jpeg;

            var imageDecoders = ImageCodecInfo.GetImageDecoders()
                .Where(codec => codec.MimeType == mime);

            foreach (var codec in imageDecoders)
            {
                if (ImageFormat.Bmp.Guid == codec.FormatID) return ImageFormat.Bmp;
                if (ImageFormat.Emf.Guid == codec.FormatID) return ImageFormat.Emf;
                if (ImageFormat.Exif.Guid == codec.FormatID) return ImageFormat.Exif;
                if (ImageFormat.Gif.Guid == codec.FormatID) return ImageFormat.Gif;
                if (ImageFormat.Icon.Guid == codec.FormatID) return ImageFormat.Icon;
                if (ImageFormat.Jpeg.Guid == codec.FormatID) return ImageFormat.Jpeg;
                if (ImageFormat.MemoryBmp.Guid == codec.FormatID) return ImageFormat.MemoryBmp;
                if (ImageFormat.Png.Guid == codec.FormatID) return ImageFormat.Png;
                if (ImageFormat.Tiff.Guid == codec.FormatID) return ImageFormat.Tiff;
                if (ImageFormat.Wmf.Guid == codec.FormatID) return ImageFormat.Wmf;
            }

            return imageFormat;
        }
    }
}
