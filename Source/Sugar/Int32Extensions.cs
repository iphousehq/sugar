using System;

namespace Sugar
{
    /// <summary>
    /// Extension methods for integers.
    /// </summary>
    public static class Int32Extensions
    {
        public static int AsInt32(this string value)
        {
            return value.AsInt32(0);
        }

        public static int AsInt32(this string value, int @default)
        {
            var result = @default;

            if (!string.IsNullOrEmpty(value))
            {
                int temp;

                if (int.TryParse(value, out temp))
                {
                    result = Convert.ToInt32(temp);
                }
            }

            return result;
        }
    }
}
