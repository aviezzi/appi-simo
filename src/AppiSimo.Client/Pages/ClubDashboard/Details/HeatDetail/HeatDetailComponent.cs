namespace AppiSimo.Client.Pages.ClubDashboard.Details.HeatDetail
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using ViewModels;

    public class HeatDetailComponent : DetailBaseComponent<Heat, HeatViewModel>
    {
        [Inject] IGraphQlService<Heat> HeatService { get; set; }

        protected override Func<Heat, HeatViewModel> BuildViewModel =>
            heat => new HeatViewModel
            {
                Entity = heat
            };

        protected HeatDetailComponent()
            : base("/club-dashboard/heats")
        {
        }
    }
}