using System;
using System.Collections.Generic;
using Sugar.IO;

namespace Sugar.Config
{
    /// <summary>
    /// Class to wrap basic accesing of config files
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
        /// <param name="filename">The filename.</param>
        public Config(string filename) : this()
        {
            Lines = Read(filename);
        }

        public Config(IList<ConfigLine> lines) : this()
        {
            Lines = lines;
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

        private void Remove(ConfigLine line)
        {
            for (int i = Lines.Count - 1; i >= 0; i--)
            {
                var candidate = Lines[i];

                if (string.Compare(line.Section, candidate.Section, true) == 0 &&
                    string.Compare(line.Key, candidate.Key, true) == 0)
                {
                    Lines.RemoveAt(i);
                }
            }
        }
    }
}
