using System;

namespace Sugar.Attributes
{
    /// <summary>
    /// Decorates a <see cref="Sugar.CurrencyCode"/> value with its HTML-encoded currency symbol.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class HtmlSymbolAttribute : Attribute
    {
        public HtmlSymbolAttribute(string htmlSymbol)
        {
            HtmlSymbol = htmlSymbol;
        }

        public string HtmlSymbol { get; }
    }
}
