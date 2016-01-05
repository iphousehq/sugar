using System;

namespace Sugar.Extensions
{
    /// <summary>
    /// Enumeration of the different parts of a <see cref="TimeSpan"/>
    /// </summary>
    /// <remarks>
    /// Flaggable enums must me assigned power of 2 values!
    /// </remarks>
    [Flags]
    public enum TimeSpanPart : uint
    {
        Day  = 0,
        Hour = 1 << 0,
        Minute = 1 << 1,
        Second = 1 << 2
    }
}