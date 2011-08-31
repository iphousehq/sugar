using System;

namespace Sugar
{
    public static class ToDoubleExtension
    {
        public static double ToDouble(this string value)
        {
            return value.ToDouble(0);
        }

        public static double ToDouble(this string value, double @default)
        {
            var result = @default;

            if (!string.IsNullOrEmpty(value))
            {
                double temp;

                if (double.TryParse(value, out temp))
                {
                    result = Convert.ToDouble(temp);
                }
            }

            return result;
        }

    }
}
