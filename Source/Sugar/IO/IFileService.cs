using System.Collections.Generic;

namespace Sugar.IO
{
    /// <summary>
    /// Wrapper interface for accessing the file system
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Tests to see if the given file exists on disk.
        /// </summary>
        /// <param name="path">Name of the file path.</param>
        /// <returns></returns>
        bool Exists(string path);

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
        /// Gets the directory names in the given directory.
        /// </summary>
        /// <param name="pattern">The pattern to search.</param>
        /// <param name="directory">The directory to search.</param>
        /// <returns></returns>
        IList<string> GetDirectories(string pattern, string directory = "");

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

        /// <summary>
        /// Copies the specified source directory to the destination.
        /// </summary>
        /// <param name="sourceDirectory">The source directory.</param>
        /// <param name="destinationDirectoy">The destination directoy.</param>
        void Copy(string sourceDirectory, string destinationDirectoy);

        /// <summary>
        /// Deletes the specified directory and any files contained within it.
        /// </summary>
        /// <param name="directory">The directory.</param>
        void Delete(string directory);

        /// <summary>
        /// Deletes the specified directory and any files contained within it.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="recursive">if set to <c>true</c> recursively delete files and directories.</param>
        void Delete(string directory, bool recursive);

        /// <summary>
        /// Deletes the files in the specified directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="files">The files.</param>
        void Delete(string directory, params string[] files);
    }
}
