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
        public BaseCommandConsole()
        {
            Commands = new List<ICommand>();
        }

        /// <summary>
        /// Entry point for the program logic
        /// </summary>
        protected override void Main()
        {
            if (!Execute()) Default();
        }

        /// <summary>
        /// Executes the commands based upon the <see cref="BaseConsole.Arguments"/> collection.
        /// </summary>
        /// <returns></returns>
        public bool Execute()
        {
            var fired = false;

            foreach (var command in Commands)
            {
                if (!command.CanExecute(Arguments)) continue;
                
                command.Execute(Arguments);

                fired = true;

                break;
            }
            return fired;
        }

        /// <summary>
        /// Method to be called if no command has been fired.
        /// </summary>
        public abstract void Default();
    }
}
