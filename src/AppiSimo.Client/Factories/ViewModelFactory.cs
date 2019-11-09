namespace AppiSimo.Client.Factories
{
    using Abstract;
    using Model;

    public class ViewModelFactory<TIn, TOut> : IViewModelFactory<TIn, TOut>
        where TIn : Entity, new()
        where TOut : ViewModelBase<TIn>, new()
    {
        readonly IConverters _converters;

        public ViewModelFactory(IConverters converters)
        {
            _converters = converters;
        }

        public TOut Create(TIn entity = default) =>
            new TOut
            {
                Entity = entity == default ? new TIn() : entity,
                Converters = _converters
            };
    }
}