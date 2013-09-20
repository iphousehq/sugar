using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sugar.IO
{
    /// <summary>
    /// Service to encapsulate access to the file system
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Tests to see if the given file exists on disk.
        /// </summary>
        /// <param name="path">Name of the file path.</param>
        /// <returns></returns>
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

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
        /// Gets the directory names in the given directory.
        /// </summary>
        /// <param name="pattern">The pattern to search.</param>
        /// <param name="directory">The directory to search.</param>
        /// <returns></returns>
        public IList<string> GetDirectories(string pattern, string directory = "")
        {
            // Search from current working directory by default
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = Environment.CurrentDirectory;
            }

            var filenames = new List<string>();

            filenames.AddRange(Directory.GetDirectories(directory, pattern));

            return filenames;
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string ReadAllText(string path)
        {
            var result = string.Empty;

            if (File.Exists(path))
            {
                result = File.ReadAllText(path);
            }

            return result;
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

        /// <summary>
        /// Gets the user's profile data directory.
        /// </summary>
        /// <returns></returns>
        public string GetUserDataDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        /// <summary>
        /// Copies the specified source directory to the destination.
        /// </summary>
        /// <param name="sourceDirectory">The source directory.</param>
        /// <param name="destinationDirectoy">The destination directoy.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Copy(string sourceDirectory, string destinationDirectoy)
        {
            var files = GetFilenames("*", directory: sourceDirectory);

            foreach (var file in files)
            {
                var filename = Path.GetFileName(file);

                if (string.IsNullOrEmpty(filename)) continue;

                var destination = Path.Combine(destinationDirectoy, filename);

                File.Copy(file, destination);
            }
        }

        /// <summary>
        /// Deletes the specified directory and any files contained within it.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(string directory)
        {
            Delete(directory, false);            
        }

        /// <summary>
        /// Deletes the specified directory and any files contained within it.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="recursive">if set to <c>true</c> recursively delete files and directories.</param>
        public void Delete(string directory, bool recursive)
        {
            var files = GetFilenames("*", directory: directory).ToArray();

            Delete(directory, files);

            // Recursively delete sub directories
            var subDirectories = GetDirectories("*", directory);

            if (recursive)
            {
                foreach (var subDirectory in subDirectories)
                {
                    Delete(subDirectory, true);
                }

                Directory.Delete(directory);
            }
            else if (subDirectories.Count == 0)
            {
                Directory.Delete(directory);                
            }
        }

        /// <summary>
        /// Deletes the files in the specified directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="files">The files.</param>
        public void Delete(string directory, params string[] files)
        {
            foreach (var file in files)
            {
                string filename;

                if (!Path.IsPathRooted(file))
                {
                    filename = Path.Combine(directory, file);
                }
                else
                {
                    filename = file;
                }

                File.Delete(filename);
            }            
        }

        /// <summary>
        /// Determines whether the specified filename is ignored.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>
        ///   <c>true</c> if the specified filename is ignored; otherwise, <c>false</c>.
        /// </returns>
        public bool IsIgnored(string filename, string pattern)
        {
            pattern = "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";

            var regex = new Regex(pattern);

            return regex.IsMatch(filename);
        }
    }
}
