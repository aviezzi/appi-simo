namespace AppiSimo.Client.Abstract
{
    using Model;

    public interface IViewModelFactory<in TIn, out TOut>
        where TIn: Entity, new()
        where TOut: ViewModelBase<TIn>
    {
        TOut Create(TIn entity = default);
    }
}