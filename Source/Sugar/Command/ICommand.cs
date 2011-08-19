namespace Sugar.Command
{
    /// <summary>
    /// Interface for a single command within a console application
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Determines whether this instance can execute with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <c>true</c> if this instance can execute the specified parameters; otherwise, <c>false</c>.
        /// </returns>
        bool CanExecute(Parameters parameters);

        /// <summary>
        /// Executes this instance with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void Execute(Parameters parameters);

        /// <summary>
        /// Gets the description of this command.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the help text associated with this command.
        /// </summary>
        string Help { get; }
    }
}
