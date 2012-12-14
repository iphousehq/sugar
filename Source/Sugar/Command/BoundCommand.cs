namespace Sugar.Command
{
    public abstract class BoundCommand<T> : ICommand where T : class, new()
    {
        protected T OptionsBound;

        /// <summary>
        /// Gets the OK status.
        /// </summary>
        /// <value>
        /// The OK status.
        /// </value>
        protected int OkStatus
        {
            get { return BaseConsole.OkStatus; }
        }

        /// <summary>
        /// Gets the general error status.
        /// </summary>
        /// <value>
        /// The general error status.
        /// </value>
        protected int GeneralErrorStatus
        {
            get { return BaseConsole.GeneralErrorStatus; }
        }

        public virtual bool CanExecute(Parameters parameters)
        {
            OptionsBound = new ParameterBinder().Bind<T>(parameters);

            return OptionsBound != null;
        }

        public int Execute(Parameters parameters)
        {
            return Execute(OptionsBound);
        }

        public abstract int Execute(T options);
    }
}
