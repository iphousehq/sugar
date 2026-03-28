using System;

namespace Sugar.Attributes
{
    /// <summary>
    /// Decorates a <see cref="Sugar.CurrencyCode"/> value with its Unicode currency symbol.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class SymbolAttribute : Attribute
    {
        public SymbolAttribute(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }
    }
}
