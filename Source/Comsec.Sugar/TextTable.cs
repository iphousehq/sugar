using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Comsec.Sugar
{
    /// <summary>
    /// Textual table
    /// </summary>
    public class TextTable
    {
        private int[] widths;
        private List<string[]> rows;
        private int maxWidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTable"/> class.
        /// </summary>
        /// <param name="columns">The columns.</param>
        public TextTable(int columns)
        {
            widths = new int[columns];
            rows = new List<string[]>();

            try
            {
                maxWidth = Console.WindowWidth - 1;
            }
            catch (IOException)
            {
                maxWidth = int.MaxValue;
            }
        }

        /// <summary>
        /// Adds a row to this table.
        /// </summary>
        /// <param name="values">The values.</param>
        public void AddRow(params object[] values)
        {
            var row = new string[widths.Length];

            for (var i = 0; i < values.Length; i++)
            {
                row[i] = values[i].ToString();

                if (row[i].Length > widths[i]) widths[i] = row[i].Length;
            }

            for (var i = values.Length; i < widths.Length; i++)
            {
                row[i] = string.Empty;
            }

            rows.Add(row);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var row in rows)
            {
                var columnBuilder = new StringBuilder();

                if (row[0] == "=")
                {
                    var width = widths.Sum() + (widths.Length - 1);

                    if (width > maxWidth) width = maxWidth;

                    sb.AppendLine("=".Repeat(width));

                    continue;
                }

                for (int i = 0; i < row.Length; i++)
                {
                    var column = row[i];

                    if (columnBuilder.Length > 0) columnBuilder.Append(" ");

                    if (column.IsNumeric())
                    {
                        columnBuilder.Append(column.PadLeft(widths[i]));
                    }
                    else
                    {
                        columnBuilder.Append(column.PadRight(widths[i]));
                    }
                }

                sb.AppendLine(columnBuilder.ToString().Trim().TrimTo(maxWidth, ".."));
            }

            return sb.ToString();
        }
    }
}
