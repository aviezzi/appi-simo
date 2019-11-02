namespace AppiSimo.Client.Pages.ClubDashboard.Details
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public abstract class DetailBaseComponent<T, TViewModel> : ComponentBase
        where T : class, IEntity, new()
        where TViewModel : IDetailViewModel<T>, new()
    {
        readonly string _redirectUri;

        [Inject] NavigationManager UriHelper { get; set; }

        [Inject] protected IGraphQlService<T> Service { get; set; }

        protected TViewModel ViewModel { get; set; } = new TViewModel();

        protected DetailBaseComponent(string redirectUri)
        {
            _redirectUri = redirectUri;
        }

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