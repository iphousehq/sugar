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
        int Execute(Parameters parameters);
    }
}
