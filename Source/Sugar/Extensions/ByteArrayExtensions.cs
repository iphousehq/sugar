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

        /// <summary>
        /// Converts this byte array to a string (without any encoding convertion!).
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        /// <remarks>
        /// http://stackoverflow.com/questions/472906/net-string-to-byte-array-c-sharp
        /// </remarks>
        public static string ToStringValue(this byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];

            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);

            return new string(chars);
        }
    }
}