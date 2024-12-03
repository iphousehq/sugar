using System;
using System.IO;
using SkiaSharp;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for array of <see cref="byte"/> type.
    /// </summary>
    public static class BytesExtensions
    {
        /// <summary>
        /// Encodes this bitmap to the specified <see cref="imageFormat"/> and returns bytes.
        /// </summary>
        /// <param name="image">The BMP.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="quality">The image quality (defaults to 100)</param>
        /// <returns></returns>
        public static byte[] ToBytes(this SKBitmap image, SKEncodedImageFormat imageFormat, int quality = 100)
        {
            try
            {
                var data = image.Encode(imageFormat, quality);

                return data.ToArray();
            }
            catch (Exception)
            {
                return [];
            }
        }

        /// <summary>
        /// Converts this byte array to a Bitmap.
        /// </summary>
        /// <param name="bitmapBytes">The bitmap bytes.</param>
        /// <returns>A bitmap if valid, null if not</returns>
        public static SKBitmap ToBitmap(this byte[] bitmapBytes)
        {
            try
            {
                using var memoryStream = new MemoryStream(bitmapBytes, false);
                
                return SKBitmap.Decode(memoryStream);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}