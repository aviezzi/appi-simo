namespace AppiSimo.Client.Pages.ClubDashboard.Details.CourtDetail
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Threading.Tasks;

    public class CourtDetailComponent : DetailBaseComponent<Court, CourtViewModel>
    {
        [Inject] IGraphQlService<Light> LightService { get; set; }
        [Inject] IGraphQlService<Heat> HeatService { get; set; }

        [Parameter] public Guid Id { get; set; }

        protected CourtDetailComponent()
            : base("/club-dashboard/courts")
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            var lights = await LightService.GetAllAsync();
            var heats = await HeatService.GetAllAsync();

            if (Id != Guid.Empty)
            {
                var court = await Service.GetOneAsync(Id);
                ViewModel = new CourtViewModel(lights, heats, court);
            }
            else
            {
                ViewModel = new CourtViewModel(lights, heats);
            }
        }
    }
}