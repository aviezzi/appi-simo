namespace AppiSimo.Client.Pages.ClubDashboard.Details
{
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public abstract class DetailBaseComponent<T, TVm> : ComponentBase
        where T : Entity, new()
        where TVm : IDetailViewModel<T>, new()
    {
        readonly string _redirectUri;

        [Inject]
        IUriHelper UriHelper { get; set; }

        [Inject]
        protected IGateway<T> Service { get; set; }

        protected DetailBaseComponent(string redirectUri)
        {
            _redirectUri = redirectUri;
        }
        
        protected TVm ViewModel { get; set; } = new TVm();

        protected async Task HandleValidSubmit()
        {
            if (ViewModel.IsNew)
            {
                await Service.CreateAsync(ViewModel.Entity);
            }
            else
            {
                await Service.UpdateAsync(ViewModel.Entity);
            }

            UriHelper.NavigateTo(_redirectUri);
        }
    }
}