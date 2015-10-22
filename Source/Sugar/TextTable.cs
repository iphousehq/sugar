using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sugar.Extensions;

namespace Sugar
{
    /// <summary>
    /// Textual table for console applications.
    /// </summary>
    public class TextTable
    {
        private readonly int[] widths;
        private readonly List<string[]> rows;
        private readonly int maxWidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTable"/> class.
        /// </summary>
        /// <param name="headers">The headers to use for the table.</param>
        public TextTable(params object[] headers)
        {
            widths = new int[headers.Length];
            rows = new List<string[]>();

            ColumnSeperator = "  ";

            AddRow(headers);

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
        /// Gets or sets the column seperator.
        /// </summary>
        /// <value>
        /// The column seperator.
        /// </value>
        public string ColumnSeperator { get; set; }

        /// <summary>
        /// Adds a seperator to the table.
        /// </summary>
        public void AddSeperator()
        {
            AddRow("=");
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
                if (values[i] != null)
                {
                    row[i] = values[i].ToString();
                }
                else
                {
                    row[i] = string.Empty;
                }

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
                    var width = widths.Sum() + ((widths.Length - 1) * ColumnSeperator.Length);

                    if (width > maxWidth) width = maxWidth;

                    sb.AppendLine("=".Repeat(width));

                    continue;
                }

                for (int i = 0; i < row.Length; i++)
                {
                    var column = row[i];

                    if (columnBuilder.Length > 0) columnBuilder.Append(ColumnSeperator);

                    if (column.IsNumeric() || column.StartsWith("/"))
                    {
                        if (column.StartsWith("/")) column = column.Substring(1);

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

        /// <summary>
        /// Returns the table as a string array.
        /// </summary>
        /// <returns></returns>
        public IList<string> ToStringList()
        {
            return ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
