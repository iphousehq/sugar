namespace Sugar.Command
{
    public abstract class BoundCommand<T> : ICommand where T : class, new()
    {
        private T options;

        public bool CanExecute(Parameters parameters)
        {
            options = new ParameterBinder().Bind<T>(parameters);

            return options != null;
        }

        public void Execute(Parameters parameters)
        {
            Execute(options);
        }

        public abstract void Execute(T options);

        public abstract string Description { get; }

        public abstract string Help { get; }
    }
}
