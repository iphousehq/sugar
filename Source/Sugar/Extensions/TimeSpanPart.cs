using System;

namespace Sugar.Extensions
{
    /// <summary>
    /// Enumeration of the different parts of a <see cref="TimeSpan"/>
    /// </summary>
    [Flags]
    public enum TimeSpanPart
    {
        Day,
        Hour,
        Minute,
        Second
    }
}