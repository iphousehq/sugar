using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Sugar.IO
{
    /// <summary>
    /// Service to encapsulate access to the file system
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Gets the filenames that match the given search pattern in the
        /// current working directory.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="levelsToSearch">The number of directory levels to search.</param>
        /// <param name="directory">The directory.</param>
        /// <returns></returns>
        public IList<string> GetFilenames(string pattern, int levelsToSearch = 0, string directory = "")
        {
            // Search from current working directory by default
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = Environment.CurrentDirectory;
            }

            var filenames = new List<string>();

            filenames.AddRange(Directory.GetFiles(directory, pattern));

            if (levelsToSearch > 0)
            {
                var info = Directory.GetParent(directory);

                if (info != null)
                {
                    filenames.AddRange(GetFilenames(pattern, --levelsToSearch, info.FullName));
                }
            }

            return filenames;
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="contents">The contents.</param>
        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        public bool IsIgnored(string filename, string pattern)
        {
            pattern = "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";

            var regex = new Regex(pattern);

            return regex.IsMatch(filename);
        }
    }
}
