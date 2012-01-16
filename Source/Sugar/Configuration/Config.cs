using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sugar.IO;

namespace Sugar.Configuration
{
    /// <summary>
    /// Class to wrap basic accessing of configuration files
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        public Config()
        {
            Lines = new List<ConfigLine>();
            FileService = new FileService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="lines">The lines.</param>
        public Config(IList<ConfigLine> lines) : this()
        {
            Lines = lines;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class from the given file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="fileService">The file service to use to load the configuration.</param>
        /// <returns></returns>
        public static Config FromFile(string filename, IFileService fileService = null)
        {
            var fs = fileService ?? new FileService();

            var allText = fs.ReadAllText(filename);

            return FromText(allText);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class from the given text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static Config FromText(string text)
        {
            var lines = new Config().Parse(text);

            return FromConfigLines(lines);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class from the given Config lines.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        public static Config FromConfigLines(IList<ConfigLine> lines)
        {
            return new Config(lines);
        }

        /// <summary>
        /// Gets or sets the lines.
        /// </summary>
        /// <value>
        /// The lines.
        /// </value>
        public IList<ConfigLine> Lines { get; private set; }

        /// <summary>
        /// Gets or sets the file service.
        /// </summary>
        /// <value>
        /// The file service.
        /// </value>
        public IFileService FileService { get; set; }

        /// <summary>
        /// Gets or sets the filename that this Configuration was loaded from.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string Filename { get; set; }

        /// <summary>
        /// Reads the configuration values from the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public IList<ConfigLine> Read(string filename)
        {
            var text = FileService.ReadAllText(filename);

            return Parse(text);
        }

        /// <summary>
        /// Parses the specified text for configuration entries.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public IList<ConfigLine> Parse(string text)
        {
            var results = new List<ConfigLine>();

            var lines = text.Split(Environment.NewLine);
            var section = string.Empty;

            foreach (var line in lines)
            {
                // only process lines if content
                if (string.IsNullOrWhiteSpace(line)) continue;

                // section header?
                if (line.StartsWith("["))
                {
                    section = line.SubstringAfterChar("[").SubstringBeforeLastChar("]");

                    continue;
                }

                ConfigLine result;

                if (ConfigLine.TryParse(line, out result, section: section))
                {
                    results.Add(result);
                }
            }

            return results;
        }

        /// <summary>
        /// Merges the specified to configuration into a new configuration.
        /// </summary>
        /// <param name="toMerge">To merge.</param>
        /// <returns></returns>
        public Config Merge(Config toMerge)
        {
            var config = new Config(Lines);

            foreach (var line in toMerge.Lines)
            {
                config.Remove(line);

                config.Lines.Add(line);
            }

            return config;
        }

        /// <summary>
        /// Removes the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        private void Remove(ConfigLine line)
        {
            for (var i = Lines.Count - 1; i >= 0; i--)
            {
                var candidate = Lines[i];

                if (string.Compare(line.Section, candidate.Section, true) == 0 &&
                    string.Compare(line.Key, candidate.Key, true) == 0)
                {
                    Lines.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetValue(string section, string key, string value)
        {
            var line = new ConfigLine
            {
                Section = section,
                Key = key,
                Value = value
            };

            Remove(line);

            Lines.Add(line);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="key">The key.</param>
        /// <param name="default">The @default.</param>
        public string GetValue(string section, string key, string @default)
        {
            var line = (from l
                        in Lines
                        where string.Compare(section, l.Section, true) == 0
                        && string.Compare(key, l.Key, true) == 0
                        select l).FirstOrDefault();

            return line == null ? @default : line.Value;
        }

        public IList<ConfigLine> GetSection(string name)
        {
            return Lines.Where(l => string.Compare(l.Section, name, true) == 0).ToList();
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

            var section = string.Empty;

            foreach (var line in Lines.OrderBy(l => l.Section))
            {
                if (string.Compare(section, line.Section, true) != 0)
                {
                    if (sb.Length > 0) sb.AppendLine(string.Empty);
                    sb.Append("[");
                    sb.Append(line.Section);
                    sb.AppendLine("]");

                    section = line.Section;
                }

                sb.Append(line.Key);

                if (string.IsNullOrWhiteSpace(line.Value))
                {
                    sb.AppendLine(string.Empty);
                    continue;
                }

                sb.Append("=");
                sb.AppendLine(line.Value);
            }

            return sb.ToString();
        }

        public void Write(string filename)
        {
            FileService.WriteAllText(filename, ToString());
        }

        public void Delete(string section, string key)
        {
            for (var i = Lines.Count - 1; i >= 0; i--)
            {
                var line = Lines[i];

                if (line.Section == section && line.Key == key)
                {
                    Lines.RemoveAt(i);
                }
            }
        }
    }
}
