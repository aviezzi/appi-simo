namespace AppiSimo.Client.Factories
{
    using Abstract;
    using Model;
    using System;

    public class ViewModelFactory<TIn, TOut> : IViewModelFactory<TIn, TOut>
        where TIn : Entity, new()
        where TOut : ViewModelBase<TIn>, new()
    {

        public TOut Create(TIn entity = default) => 
            new TOut {Entity = entity == default ? new TIn() : entity};
    }
}