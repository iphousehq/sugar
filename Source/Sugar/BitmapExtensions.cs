using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Sugar
{
    public static class BitmapExtension
    {
        /// <summary>
        /// Resizes the image to the maximum specified dimention whilst respecting it's aspect ratio.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="maximumDimension">The maximum dimension.</param>
        /// <returns></returns>
        public static Bitmap ResizeImage(this Image image, int maximumDimension)
        {
            int max = Math.Max(image.Height, image.Width);
            max = Math.Min(maximumDimension, max);

            float ratio = Math.Min(max / (float)image.Width, max / (float)image.Height);

            float width = ratio * image.Width;
            float height = ratio * image.Height;

            var newSize = new Size { Width = Convert.ToInt32(width), Height = Convert.ToInt32(height) };

            return image.ResizeImage(newSize);
        }

        /// <summary>
        /// Resizes the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="width">The width in pixels.</param>
        /// <param name="height">The height in pixels.</param>
        /// <returns></returns>
        public static Bitmap ResizeImage(this Image image, int width, int height)
        {
            return image.ResizeImage(new Size { Width = width, Height = height });
        }

        /// <summary>
        /// Resize the image to the specified size.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>The resized image.</returns>
        /// <remarks>This gives better results than using the Bitmap(image, size) constructor</remarks>
        public static Bitmap ResizeImage(this Image image, Size newSize)
        {
            var result = new Bitmap(newSize.Width, newSize.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            return result;  //Do not dispose of this instance! Otherwise you might end up with meaningless GDI+ error messages
        }

        /// <summary>
        /// Converts a bitmap to a byte array.
        /// </summary>
        /// <param name="image">The BMP.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns></returns>
        public static byte[] ToBytes(this Image image, ImageFormat imageFormat)
        {
            using (var imageCopy = new Bitmap(image))
            {
                using (var stream = new MemoryStream())
                {
                    imageCopy.Save(stream, imageFormat);

                    var bytes = stream.GetBuffer();

                    return bytes;
                }
            }
        }

        /// <summary>
        /// Converts a byte array (created with the Bitmap.ToBytes extension method) to a Bitmap instance.
        /// </summary>
        /// <param name="bitmapBytes">The bitmap bytes.</param>
        /// <returns>A bitmap if valid, null if not</returns>
        public static Bitmap ToBitmap(this byte[] bitmapBytes)
        {
            try
            {
                using (var memoryStream = new MemoryStream(bitmapBytes, false))
                {
                    return new Bitmap(memoryStream);
                }
            }
            catch (ExternalException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the MIME type of the bitmap image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public static string GetMimeType(this Bitmap bitmap)
        {
            foreach (var codec in ImageCodecInfo.GetImageDecoders()
                .Where(codec => codec.FormatID == bitmap.RawFormat.Guid))
            {
                return codec.MimeType;
            }

            return "image/unknown";
        }
    }
}
