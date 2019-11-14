namespace AppiSimo.Client.Pages.ClubDashboard.Details.LightDetail
{
    using Model;
    using System;
    using ViewModels;

    public class LightDetailComponent : DetailBaseComponent<Light, LightViewModel>
    {
        protected override Func<Light, LightViewModel> BuildViewModel =>
            light => new LightViewModel
            {
                Entity = light
            };

        protected LightDetailComponent()
            : base("/club-dashboard/lights")
        {
        }
    }
}