namespace AppiSimo.Client.Pages.ClubDashboard.LightDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class LightDetailComponent : ComponentBase
    {
        [Inject]
        IGateway<Light> LightService { get; set; }

        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        Guid Id { get; set; }

        protected LightViewModel ViewModel { get; private set; } = new LightViewModel();

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var light = await LightService.GetAsync(Id);
                ViewModel = new LightViewModel(light);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (ViewModel.IsNew)
            {
                await LightService.CreateAsync(ViewModel.Light);
            }
            else
            {
                await LightService.UpdateAsync(ViewModel.Light);
            }

            UriHelper.NavigateTo("/club-dashboard/lights");
        }
    }
}