using System;
using System.IO;
using SkiaSharp;

namespace Sugar.Extensions
{
    public static class MimeTypeExtensions
    {
        /// <summary>
        /// Gets the MIME type of this bitmap image.
        /// </summary>
        /// <param name="stream">The stream to the bytes of the image.</param>
        /// <returns></returns>
        public static string GetMimeType(this Stream stream)
        {
            using var copy = new MemoryStream();

            stream.CopyTo(copy);

            copy.Flush();
            copy.Position = 0;

            // Don't pass an instance of SKBitmap to SKCodec.Create, it will return null as the SKBitmap is NOT encoded in any particular 'format'
            using var codec = SKCodec.Create(copy);

            switch (codec.EncodedFormat)
            {
                case SKEncodedImageFormat.Bmp: 
                case SKEncodedImageFormat.Gif: 
                case SKEncodedImageFormat.Ico: 
                case SKEncodedImageFormat.Jpeg: 
                case SKEncodedImageFormat.Png:
                case SKEncodedImageFormat.Webp:
                case SKEncodedImageFormat.Ktx:
                case SKEncodedImageFormat.Heif:
                case SKEncodedImageFormat.Avif:
                    return "image/" + codec.EncodedFormat.ToString().ToLower();
                case SKEncodedImageFormat.Jpegxl:
                    return "image/jxl";
                case SKEncodedImageFormat.Wbmp:
                    return "image/vnd.wap.wbmp";
                case SKEncodedImageFormat.Pkm:
                case SKEncodedImageFormat.Dng:
                default:
                    return "image/unknown";
            }
        }

        /// <summary>
        /// Converts this mime type string to an <see cref="SKEncodedImageFormat"/>
        /// </summary>
        /// <param name="mime">The MIME.</param>
        /// <returns></returns>
        public static SKEncodedImageFormat ToImageFormat(this string mime)
        {
            var values = Enum.GetValues(typeof(SKEncodedImageFormat));

            mime = mime.ToLower();

            foreach (SKEncodedImageFormat value in values)
            {
                var stringValue = value.ToString().ToLower();

                if (mime.Contains(stringValue))
                {
                    return value;
                }
            }

            if (mime == "image/jxl")
            {
                return SKEncodedImageFormat.Jpegxl;
            }
            else if(mime == "image/vnd.wap.wbmp")
            {
                return SKEncodedImageFormat.Wbmp;
            }

            throw new ArgumentOutOfRangeException(nameof(mime), mime, "Unknown image mime type");
        }
    }
}
