using System.Collections.Generic;

namespace Sugar.IO
{
    /// <summary>
    /// Wrapper interface for accessing the file system
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Gets the filenames that match the given search pattern in the
        /// current working directory.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="levelsToSearch">The number of directory levels to search.</param>
        /// <param name="directory">The directory.</param>
        /// <returns></returns>
        IList<string> GetFilenames(string pattern, int levelsToSearch = 0, string directory = "");

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        string ReadAllText(string path);

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="contents">The contents.</param>
        void WriteAllText(string path, string contents);

        /// <summary>
        /// Gets the user's profile data directory.
        /// </summary>
        /// <returns></returns>
        string GetUserDataDirectory();
    }
}
