namespace Sugar.Command
{
    public abstract class BoundCommand<T> : ICommand where T : class, new()
    {
        protected T OptionsBound;

        public virtual bool CanExecute(Parameters parameters)
        {
            OptionsBound = new ParameterBinder().Bind<T>(parameters);

            return OptionsBound != null;
        }

        public void Execute(Parameters parameters)
        {
            Execute(OptionsBound);
        }

        public abstract void Execute(T options);

        public abstract string Description { get; }

        public abstract string Help { get; }
    }
}
