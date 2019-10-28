namespace AppiSimo.Client.Abstract
{
    public interface IDetailViewModel<out T>
        where T : IEntity, new()
    {
        T Entity { get; }
        bool IsNew { get; }
    }
}