using System;

namespace Sugar.Attributes
{
    /// <summary>
    /// Decorates a <see cref="Sugar.CountryCode"/> (alpha-2) value with its ISO 3166-1 alpha-3 counterpart.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class Alpha3Attribute : Attribute
    {
        public Alpha3Attribute(CountryCode3 alpha3)
        {
            Alpha3 = alpha3;
        }

        public CountryCode3 Alpha3 { get; }
    }
}
