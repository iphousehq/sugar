using System;
using System.Collections.Generic;

namespace Sugar.Command
{
    /// <summary>
    /// Console base class that can execute <see cref="ICommand"/> instances.
    /// </summary>
    public class BaseCommandConsole : BaseConsole
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

        protected override void Main()
        {
            foreach (var command in Commands)
            {
                if (!command.CanExecute(Arguments)) continue;
                
                command.Execute(Arguments);                
            }            
        }

        public override void ShowMessage()
        {
            foreach (var command in Commands)
            {
                Console.WriteLine(command.Description);
            }
        }
    }
}
