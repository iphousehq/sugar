using System;

namespace Comsec.Lib.Console
{
    /// <summary>
    /// Console class interface
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="arg">The args.</param>
        void WriteLine(string value, params object[] arg);

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="color">The color.</param>
        /// <param name="value">The value.</param>
        /// <param name="arg">The arg.</param>
        void WriteLine(string eventName, ConsoleColor color, string value, params object[] arg);

        /// <summary>
        /// Moves the cursor to line begining.
        /// </summary>
        void MoveCursorToLineBegining();

        void ClearLine();

        void WriteStatus(double percent, ConsoleColor consoleColor, string value, params object[] arg);
    }
}
