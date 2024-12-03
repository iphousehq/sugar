using System;
using SkiaSharp;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="SKBitmap"/> objects.
    /// </summary>
    public static class BitmapExtension
    {
        /// <summary>
        /// Gets the maximum size of image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="maximumDimension">The maximum dimension.</param>
        /// <returns></returns>
        private static SKSizeI GetMaximumSizeOfImage(SKBitmap image, int maximumDimension)
        {
            var max = Math.Max(image.Height, image.Width);
            max = Math.Min(maximumDimension, max);

            var ratio = Math.Min(max / (float)image.Width, max / (float)image.Height);

            var width = ratio * image.Width;
            var height = ratio * image.Height;

            return new SKSizeI { Width = Convert.ToInt32(width), Height = Convert.ToInt32(height) };
        }

        /// <summary>
        /// Crops this image to the maximum specified dimension whilst respecting it's aspect ratio.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="maximumDimension">The maximum dimension.</param>
        /// <returns></returns>
        public static SKBitmap CropImage(this SKBitmap image, int maximumDimension)
        {
            var newSize = GetMaximumSizeOfImage(image, maximumDimension);

            return image.CropImage(newSize);
        }

        /// <summary>
        /// Crops this image to the specified width and height.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="width">The width in pixels.</param>
        /// <param name="height">The height in pixels.</param>
        /// <returns></returns>
        public static SKBitmap CropImage(this SKBitmap image, int width, int height)
        {
            return image.CropImage(new SKSizeI(width, height));
        }

        /// <summary>
        /// Crops this image to the specified size.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>The resized image.</returns>
        /// <remarks>This gives better results than using the Bitmap(image, size) constructor</remarks>
        public static SKBitmap CropImage(this SKBitmap image, SKSizeI newSize)
        {
            return image.ResizeImage(newSize, SKSamplingOptions.Default);
        }

        /// <summary>
        /// Resizes this image to the maximum specified dimension whilst respecting it's aspect ratio.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="maximumDimension">The maximum dimension.</param>
        /// <returns></returns>
        public static SKBitmap ResizeImage(this SKBitmap image, int maximumDimension, SKSamplingOptions options)
        {
            return image.ResizeImage(GetMaximumSizeOfImage(image, maximumDimension), options);
        }

        /// <summary>
        /// Resize this image to the specified size.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="newSize">The new size.</param>
        /// <param name="options">The resize options</param>
        /// <returns>The resized image.</returns>
        /// <remarks>This gives better results than using the Bitmap(image, size) constructor</remarks>
        public static SKBitmap ResizeImage(this SKBitmap image, SKSizeI newSize, SKSamplingOptions options)
        {
            return image.Resize(newSize, options);
        }
    }
}
