using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Management;

namespace Sugar.Command
{
    /// <summary>
    /// Helps find out if another instance of the same process is already running.
    /// </summary>
    public class CommandLine
    {
        /// <summary>
        /// Gets the current process id.
        /// </summary>
        /// <returns></returns>
        public virtual int GetCurrentProcessId()
        {
            return Process.GetCurrentProcess().Id;
        }

        /// <summary>
        /// Gets the process ids of all currently running processes.
        /// </summary>
        /// <returns></returns>
        public virtual IList<int> GetProcessIds(string filename)
        {
            var results = new List<int>();

            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                if (CheckProcessFileName(process, filename))
                {
                    results.Add(process.Id);
                }
            }

            return results;
        }

        /// <summary>
        /// Checks to see if the file name of the process matches the given file name.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public bool CheckProcessFileName(Process process, string match)
        {
            var result = false;

            if (process.MainModule != null)
            {
                try
                {
                    var fileName = process.MainModule.FileName;

                    fileName = Path.GetFileName(fileName);

                    result = string.Compare(fileName, match, StringComparison.InvariantCultureIgnoreCase) == 0;
                }
                catch (PlatformNotSupportedException)
                {
                    result = false;
                }
                catch (NotSupportedException)
                {
                    result = false;
                }
                catch (Win32Exception)
                {
                    // Ignore this process - no access rights
                    result = false;
                }
                catch (InvalidOperationException)
                {
                    // Ignore this process - no access rights
                    result = false;
                }
            }
            
            return result;
        }

        /// <summary>
        /// Gets the current process's command line.
        /// </summary>
        /// <returns></returns>
        public string GetCommandLine()
        {
            return GetCommandLine(GetCurrentProcessId());
        }

        /// <summary>
        /// Gets the command line for the process with the given id.
        /// </summary>
        /// <param name="processId">The process id.</param>
        /// <returns></returns>
        public virtual string GetCommandLine(int processId)
        {
            var result = string.Empty;

            var query = $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {processId}";

            using (var searcher = new ManagementObjectSearcher(query))
            {
                foreach (var @object in searcher.Get())
                {
                    result = @object["CommandLine"] as string;

                    result = CleanUpCommandLine(result);

                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Strips the filename from the command line.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string CleanUpCommandLine(string input)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(input))
            {
                // Does the input start with a quoted path (e.g. "c:\program files\path\to\program.exe"?
                if (input.StartsWith(@""""))
                {
                    result = input;

                    // After 2nd quote
                    for (int i = 0; i < 2; i++)
                    {
                        var quoteIndex = result.IndexOf(@"""", StringComparison.Ordinal);

                        result = result.Substring(quoteIndex + 1).Trim();
                    }

                    result = result.Trim();
                }
                else
                {
                    var indexOfSpace = input.IndexOf(" ", StringComparison.Ordinal);

                    if (indexOfSpace > -1)
                    {
                        result = input.Substring(indexOfSpace + 1);
                    }                    
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the command lines for all running processes.
        /// </summary>
        /// <returns></returns>
        public IDictionary<int, string> GetCommandLines(string filename)
        {
            var results = new Dictionary<int, string>();

            var processIds = GetProcessIds(filename);

            foreach (var processId in processIds)
            {
                var commandLine = GetCommandLine(processId);

                results.Add(processId, commandLine);
            }

            return results;
        }

        /// <summary>
        /// Determines if a process with the current command line is already running.
        /// </summary>
        /// <remarks>
        /// Processes with empty command lines are always allowed.
        /// </remarks>
        /// <returns></returns>
        public bool AlreadyRunning(string filename)
        {
            var result = false;

            var currentCommandLine = GetCommandLine();
            var commandLines = GetCommandLines(filename);

            // Always allow empty args (interactive mode)
            if (string.IsNullOrEmpty(currentCommandLine))
            {
                return false;
            }

            // Check currently running command lines
            foreach (var commandLine in commandLines)
            {
                // Ignore current process
                if (commandLine.Key == GetCurrentProcessId()) continue;

                // Skip non-matching command lines
                if (string.Compare(currentCommandLine, commandLine.Value, StringComparison.OrdinalIgnoreCase) != 0) continue;

                // Already running!
                result = true;
                break;
            }

            return result;
        }
    }
}
