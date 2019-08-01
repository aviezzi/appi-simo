namespace AppiSimo.Client.Pages.ClubDashboard.Details.CourtDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class CourtDetailComponent : DetailBaseComponent<Court, CourtViewModel>
    {
        [Inject]
        IGateway<Light> LightService { get; set; }

        [Inject]
        IGateway<Heat> HeatService { get; set; }

        [Parameter]
        Guid Id { get; set; }

        protected CourtDetailComponent()
            : base("/club-dashboard/courts")
        {
        }

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
    }
}