using System;
using System.Diagnostics;

namespace Comsec.Sugar.Command
{
    /// <summary>
    /// Provides core functionality for console applications
    /// </summary>
    public abstract class BaseConsole
    {
        /// <summary>
        /// Pauses if a debugger is attached.
        /// </summary>
        private static void PauseIfInDebuggerAttached()
        {
            if (!Debugger.IsAttached) return;

            Console.WriteLine("");
            Console.Write("Press any key to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Gets or sets the command line arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public Parameters Arguments { get; private set; }

        /// <summary>
        /// Runs this console application.
        /// </summary>
        public void Run(string[] args)
        {
            // Get the command line arguments
            Arguments = ParameterParser.Parse(args);

            // Check user input
            if (!Validate())
            {
                ShowMessage();

                PauseIfInDebuggerAttached();

                return;
            }

            if (Debugger.IsAttached)
            {
                Main();
            }
            else
            {
                try
                {
                    // Execute the main program logic
                    Main();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("A fatal error occured:");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("");
                    Console.WriteLine(ex.StackTrace);
                }
            }

            // Pause if in debug mode
            PauseIfInDebuggerAttached();
        }

        /// <summary>
        /// Entry point for the program logic
        /// </summary>
        protected abstract void Main();

        /// <summary>
        /// Validates the user command line parameters.
        /// </summary>
        /// <returns>true is command line parameters are correct, false if not.</returns>
        public virtual bool Validate()
        {
            return true;
        }

        /// <summary>
        /// Shows the help message about the application.
        /// </summary>
        public abstract void ShowMessage();
    }
}