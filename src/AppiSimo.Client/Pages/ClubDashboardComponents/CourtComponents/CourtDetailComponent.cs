namespace AppiSimo.Client.Pages.ClubDashboardComponents.CourtComponents
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels;

    public class CourtDetailComponent : DetailComponentBase<Court, CourtViewModel>
    {
        IEnumerable<Heat> _heats;
        IEnumerable<Light> _lights;

        [Inject] IGraphQlService<Light> LightService { get; set; }
        [Inject] IGraphQlService<Heat> HeatService { get; set; }

        protected override Func<Court, CourtViewModel> BuildViewModel =>
            court => new CourtViewModel(_lights, _heats)
            {
                Entity = court
            };

        protected CourtDetailComponent()
            : base("/club-dashboard/courts")
        {
        }

        protected override async Task OnInitializedAsync()
        {
            _lights = await LightService.GetAllAsync();
            _heats = await HeatService.GetAllAsync();
        }
    }
}