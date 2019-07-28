namespace AppiSimo.Client.Pages.ClubDashboard.Details
{
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public abstract class DetailBaseComponent<T> : ComponentBase
        where T : Entity, new()
    {
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Inject]
        protected IGateway<T> Service { get; set; }

        protected async Task HandleValidSubmit(IDetailViewModel<T> viewModel, string uri)
        {
            if (viewModel.IsNew)
            {
                await Service.CreateAsync(viewModel.Entity);
            }
            else
            {
                await Service.UpdateAsync(viewModel.Entity);
            }

            UriHelper.NavigateTo(uri);
        }
    }
}