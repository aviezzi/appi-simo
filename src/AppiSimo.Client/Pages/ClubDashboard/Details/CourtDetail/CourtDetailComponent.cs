namespace AppiSimo.Client.Pages.ClubDashboard.Details.CourtDetail
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Threading.Tasks;

    public class CourtDetailComponent : DetailBaseComponent<Court, CourtViewModel>
    {
        [Inject] IGateway<Light> LightService { get; set; }

        [Inject] IGateway<Heat> HeatService { get; set; }

        [Parameter] public Guid Id { get; set; }

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