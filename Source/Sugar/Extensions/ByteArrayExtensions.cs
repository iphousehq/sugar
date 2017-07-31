using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for array of <see cref="byte"/> type.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts this byte array to a Bitmap.
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
    }
}