namespace AppiSimo.Client.Pages.ClubDashboard.Details.LightDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class LightDetailComponent : DetailBaseComponent<Light>
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
            await base.HandleValidSubmit(ViewModel, "/club-dashboard/lights");
        }
    }
}