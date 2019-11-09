namespace AppiSimo.Client.Factories
{
    using Abstract;
    using Model;
    using System;

    public class ViewModelFactory<TIn, TOut> : IViewModelFactory<TIn, TOut> 
        where TIn : Entity, new() 
        where TOut : ViewModelBase<TIn>
    {
        readonly IConverters _converters;
        
        public Func<IConverters, TIn, TOut> Builder { get; set; }

        public ViewModelFactory(IConverters converters)
        {
            _converters = converters;
        }

        public TOut Create(TIn entity) => 
            Builder(_converters, entity);
    }
}