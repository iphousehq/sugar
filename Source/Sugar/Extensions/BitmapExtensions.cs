using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System;
using System.Linq;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Bitmap"/> objects.
    /// </summary>
    public static class BitmapExtension
    {
        /// <summary>
        /// Gets the maximum size of image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="maximumDimension">The maximum dimension.</param>
        /// <returns></returns>
        private static Size GetMaximumSizeOfImage(Image image, int maximumDimension)
        {
            var max = Math.Max(image.Height, image.Width);
            max = Math.Min(maximumDimension, max);

            var ratio = Math.Min(max / (float)image.Width, max / (float)image.Height);

            var width = ratio * image.Width;
            var height = ratio * image.Height;

            return new Size { Width = Convert.ToInt32(width), Height = Convert.ToInt32(height) };
        }

        /// <summary>
        /// Creates the bitmap.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="newSize">The new size.</param>
        /// <param name="cropOrResizeFunction">The crop or resize function.</param>
        /// <returns></returns>
        private static Bitmap CreateBitmap(Image image, Size newSize, Action<Image, Bitmap, Graphics> cropOrResizeFunction)
        {
            var result = new Bitmap(newSize.Width, newSize.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                cropOrResizeFunction(image, result, graphics);
            }

            return result;  //Do not dispose of this instance! Otherwise you might end up with meaningless GDI+ error messages
        }

        /// <summary>
        /// Crops this image to the maximum specified dimension whilst respecting it's aspect ratio.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="maximumDimension">The maximum dimension.</param>
        /// <returns></returns>
        public static Bitmap CropImage(this Image image, int maximumDimension)
        {
            return image.CropImage(GetMaximumSizeOfImage(image, maximumDimension));
        }

        /// <summary>
        /// Crops this image to the specified width and height.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="width">The width in pixels.</param>
        /// <param name="height">The height in pixels.</param>
        /// <returns></returns>
        public static Bitmap CropImage(this Image image, int width, int height)
        {
            return image.CropImage(new Size { Width = width, Height = height });
        }

        /// <summary>
        /// Crops this image to the specified size.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>The resized image.</returns>
        /// <remarks>This gives better results than using the Bitmap(image, size) constructor</remarks>
        public static Bitmap CropImage(this Image image, Size newSize)
        {
            return CreateBitmap(image, newSize, (i, bitmap, g) =>
                                                {
                                                    var sourceRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                                                    var destinationRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                                                    g.DrawImage(i, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                                                });
        }

        /// <summary>
        /// Gets the MIME type of this bitmap image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public static string GetMimeType(this Bitmap bitmap)
        {
            var imageDecoder = ImageCodecInfo.GetImageDecoders()
                                              .First(codec => codec.FormatID == bitmap.RawFormat.Guid);

            return imageDecoder == null ? "image/unknown" : imageDecoder.MimeType;
        }

        /// <summary>
        /// Resizes this image to the maximum specified dimension whilst respecting it's aspect ratio.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="maximumDimension">The maximum dimension.</param>
        /// <returns></returns>
        public static Bitmap ResizeImage(this Image image, int maximumDimension)
        {
            return image.ResizeImage(GetMaximumSizeOfImage(image, maximumDimension));
        }

        /// <summary>
        /// Resizes this image to the specified width and height.
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
        /// Resize this image to the specified size.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>The resized image.</returns>
        /// <remarks>This gives better results than using the Bitmap(image, size) constructor</remarks>
        public static Bitmap ResizeImage(this Image image, Size newSize)
        {
            return CreateBitmap(image, newSize, (i, bitmap, g) => g.DrawImage(i, 0, 0, bitmap.Width, bitmap.Height));
        }

        /// <summary>
        /// Converts this bitmap image to a byte array.
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
    }
}
