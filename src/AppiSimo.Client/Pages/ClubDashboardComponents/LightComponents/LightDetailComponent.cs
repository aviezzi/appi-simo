namespace AppiSimo.Client.Pages.ClubDashboardComponents.LightComponents
{
    using Abstract;
    using Model;
    using System;
    using ViewModels;

    public class LightDetailComponent : DetailComponentBase<Light, LightViewModel>
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