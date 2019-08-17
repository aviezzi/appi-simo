namespace AppiSimo.Client.Pages.ClubDashboard.Details
{
    using System.Threading.Tasks;
    using AppiSimo.Client.Abstract;
    using Microsoft.AspNetCore.Components;

    public abstract class DetailBaseComponent<T, TViewModel> : ComponentBase
        where T : IEntity, new()
        where TViewModel : IDetailViewModel<T>, new()
    {
        readonly string _redirectUri;

        protected DetailBaseComponent(string redirectUri)
        {
            _redirectUri = redirectUri;
        }

        [Inject] IUriHelper UriHelper { get; set; }

        [Inject] protected IGateway<T> Service { get; set; }

        protected TViewModel ViewModel { get; set; } = new TViewModel();

        protected async Task HandleValidSubmit()
        {
            if (ViewModel.IsNew)
                await Service.CreateAsync(ViewModel.Entity);
            else
                await Service.UpdateAsync(ViewModel.Entity);

            UriHelper.NavigateTo(_redirectUri);
        }
    }
}