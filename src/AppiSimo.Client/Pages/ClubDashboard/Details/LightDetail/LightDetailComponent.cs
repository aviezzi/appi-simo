namespace AppiSimo.Client.Pages.ClubDashboard.Details.LightDetail
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class LightDetailComponent : DetailBaseComponent<Light>
    {
        [Parameter]
        Guid Id { get; set; }

        protected LightViewModel ViewModel { get; private set; } = new LightViewModel();

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var light = await Service.GetAsync(Id);
                ViewModel = new LightViewModel(light);
            }
        }

        protected async Task HandleValidSubmit()
        {
            await HandleValidSubmit(ViewModel, "/club-dashboard/lights");
        }
    }
}