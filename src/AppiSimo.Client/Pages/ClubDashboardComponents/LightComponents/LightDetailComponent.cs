namespace AppiSimo.Client.Pages.ClubDashboardComponents.LightComponents
{
    using Abstract;
    using Model;
    using System;
    using ViewModels;

    public class LightDetailComponent : DetailComponentBase<Light, LightViewModel>
    {
        private protected override Func<Light, LightViewModel> BuildViewModel => light => new LightViewModel(light);

        protected LightDetailComponent()
            : base("/club-dashboard/lights")
        {
        }
    }
}