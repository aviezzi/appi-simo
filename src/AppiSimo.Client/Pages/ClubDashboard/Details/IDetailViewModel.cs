namespace AppiSimo.Client.Pages.ClubDashboard.Details
{
    using Model;

    public interface IDetailViewModel<out T>
        where T : Entity, new()
    {
        T Entity { get; }
        bool IsNew { get; }
    }
}