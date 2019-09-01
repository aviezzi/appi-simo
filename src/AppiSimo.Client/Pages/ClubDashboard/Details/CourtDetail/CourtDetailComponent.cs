namespace AppiSimo.Client.Pages.ClubDashboard.Details.CourtDetail
{
    using System;
    using System.Threading.Tasks;
    using AppiSimo.Client.Abstract;
    using AppiSimo.Client.Model;
    using Microsoft.AspNetCore.Components;

    public class CourtDetailComponent : DetailBaseComponent<Court, CourtViewModel>
    {
        protected CourtDetailComponent()
            : base("/club-dashboard/courts")
        {
        }

        [Inject] IGateway<Light> LightService { get; set; }

        [Inject] IGateway<Heat> HeatService { get; set; }

        [Parameter] public Guid Id { get; set; }

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