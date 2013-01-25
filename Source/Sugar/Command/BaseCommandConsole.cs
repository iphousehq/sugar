using System.Collections.Generic;

namespace Sugar.Command
{
    /// <summary>
    /// Console base class that can execute <see cref="ICommand"/> instances.
    /// </summary>
    public abstract class BaseCommandConsole : BaseConsole
    {
        /// <summary>
        /// Gets or sets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        public IList<ICommand> Commands { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCommandConsole"/> class.
        /// </summary>
        protected BaseCommandConsole()
        {
            Commands = new List<ICommand>();
        }

        /// <summary>
        /// Entry point for the program logic
        /// </summary>
        protected override int Main()
        {
            var exitCode = Execute();
            
            if(exitCode == (int)ExitCode.NoCommand)
            {
                Default();
            }

            return exitCode;
        }

        /// <summary>
        /// Executes the commands based upon the <see cref="BaseConsole.Arguments"/> collection.
        /// </summary>
        /// <returns>An exit code</returns>
        public int Execute()
        {
            var exitCode = (int)ExitCode.NoCommand;

            foreach (var command in Commands)
            {
                if (!command.CanExecute(Arguments)) continue;
                
                exitCode = command.Execute(Arguments);

                break;
            }

            return exitCode;
        }

        /// <summary>
        /// Method to be called if no command has been fired.
        /// </summary>
        public abstract int Default();
    }
}
