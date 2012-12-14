using System.Collections.Generic;

namespace Sugar.Command
{
    /// <summary>
    /// Console base class that can execute <see cref="ICommand"/> instances.
    /// </summary>
    public abstract class BaseCommandConsole : BaseConsole
    {
        /// <summary>
        /// The status returned when no commands were executed.
        /// </summary>
        protected const int NoCommandsStatus = -100;

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
        protected override void Main()
        {
            var status = Execute();
            
            if(status == NoCommandsStatus)
            {
                Default();
            }
        }

        /// <summary>
        /// Executes the commands based upon the <see cref="BaseConsole.Arguments"/> collection.
        /// </summary>
        /// <returns></returns>
        public int Execute()
        {
            var status = NoCommandsStatus;

            foreach (var command in Commands)
            {
                if (!command.CanExecute(Arguments)) continue;
                
                status = command.Execute(Arguments);

                break;
            }

            return status;
        }

        /// <summary>
        /// Method to be called if no command has been fired.
        /// </summary>
        public abstract int Default();
    }
}
