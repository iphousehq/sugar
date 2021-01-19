using System.Collections.Generic;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    /// <summary>
    /// Provides core functionality for console applications
    /// </summary>
    public abstract class BaseConsole
    {
        /// <summary>
        /// Gets or sets the command line arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public Parameters Arguments { get; private set; }

        /// <summary>
        /// Runs this console application.
        /// </summary>
        /// <param name="parameters">The CLI parameters wrapper.</param>
        /// <returns>The exit code (0 for success)</returns>
        public int Run(Parameters parameters)
        {
            Arguments = parameters;

            // Check user input
            var exitCode = Main();

            return exitCode;
        }

        /// <summary>
        /// Sets the console arguments.
        /// </summary>
        /// <param name="parameters">The CLI parameters wrapper.</param>
        protected void SetArguments(Parameters parameters)
        {
            Arguments = new Parameters(parameters);
        }

        /// <summary>
        /// Sets the console arguments.
        /// </summary>
        /// <param name="args">The arguments (including the executable name).</param>
        /// <param name="switches">The command switches, e.g. a leading "-", "--" or "/".</param>
        protected void SetArguments(string args, IList<string> switches)
        {
            Arguments = new Parameters(args, switches);
        }

        /// <summary>
        /// Entry point for the program logic
        /// </summary>
        /// <returns>The exit code (0 for success)</returns>
        protected abstract int Main();

        /// <summary>
        /// Validates the user command line parameters.
        /// </summary>
        /// <returns>true is command line parameters are correct, false if not.</returns>
        public virtual bool Validate()
        {
            return true;
        }
    }
}
