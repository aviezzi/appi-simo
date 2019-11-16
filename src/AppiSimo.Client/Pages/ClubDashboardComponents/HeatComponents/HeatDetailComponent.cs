namespace AppiSimo.Client.Pages.ClubDashboardComponents.HeatComponents
{
    using Abstract;
    using Model;
    using System;
    using ViewModels;

    public class HeatDetailComponent : DetailComponentBase<Heat, HeatViewModel>
    {
        private protected override Func<Heat, HeatViewModel> BuildViewModel =>
            heat => new HeatViewModel(heat);

        protected HeatDetailComponent()
            : base("/club-dashboard/heats")
        {
        }
    }
}