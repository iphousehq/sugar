using System.Threading.Tasks;
using Sugar.Command.Binder;

namespace Sugar.Command
{
    /// <summary>
    /// Interface for a single command within a console application
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <returns></returns>
        Task<int> Execute();

        /// <summary>
        /// Binds the parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void BindParameters(Parameters parameters);
    }
}
