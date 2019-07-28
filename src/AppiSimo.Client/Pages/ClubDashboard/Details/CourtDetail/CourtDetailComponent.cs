namespace AppiSimo.Client.Pages.ClubDashboard.Details.CourtDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class CourtDetailComponent : DetailBaseComponent<Court>
    {
        [Inject]
        IGateway<Light> LightService { get; set; }

        [Inject]
        IGateway<Heat> HeatService { get; set; }

        [Parameter]
        Guid Id { get; set; }

        protected CourtViewModel ViewModel { get; private set; } = new CourtViewModel();

        protected override async Task OnParametersSetAsync()
        {
            var lights = await LightService.GetAsync();
            var heats = await HeatService.GetAsync();

            if (Id != Guid.Empty)
            {
                var court = await Service.GetAsync(Id);
                ViewModel = new CourtViewModel(lights, heats, court);
            }
            else
            {
                ViewModel = new CourtViewModel(lights, heats);
            }
        }

        protected async Task HandleValidSubmit()
        {
            await HandleValidSubmit(ViewModel, "/club-dashboard/courts");
        }
    }
}