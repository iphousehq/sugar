using System;

namespace Sugar.Attributes
{
    /// <summary>
    /// Decorates a <see cref="Sugar.CountryCode"/> value with the <see cref="Sugar.CurrencyCode"/> used in that country.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class CurrencyAttribute : Attribute
    {
        public CurrencyAttribute(CurrencyCode currency)
        {
            Currency = currency;
        }

        public CurrencyCode Currency { get; }
    }
}
