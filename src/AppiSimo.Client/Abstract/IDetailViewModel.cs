namespace AppiSimo.Client.Pages.ClubDashboard.Details
{
    using AppiSimo.Client.Abstract;

    public interface IDetailViewModel<out T>
        where T : IEntity, new()
    {
        T Entity { get; }
        bool IsNew { get; }
    }
}