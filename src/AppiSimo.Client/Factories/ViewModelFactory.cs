namespace AppiSimo.Client.Factories
{
    using Abstract;
    using Model;
    using System;

    public class ViewModelFactory<TIn, TOut> : IViewModelFactory<TIn, TOut>
        where TIn : Entity, new()
        where TOut : ViewModelBase<TIn>
    {
        public TOut ViewModel { get; set; }

        public Func<TIn, TOut, TOut> Build { get; set; }

        public TOut Create(TIn entity) => entity == default ? ViewModel : Build(entity, ViewModel);
    }
}