namespace AppiSimo.Client.Pages.ClubDashboardComponents.RateComponents
{
    using Abstract;
    using Model;
    using System;
    using ViewModels;

    public class RateDetailComponent : DetailComponentBase<Rate, RateViewModel>
    {
        private protected override Func<Rate, RateViewModel> BuildViewModel =>
            rate => new RateViewModel(rate);

        protected RateDetailComponent()
            : base("/club-dashboard/rates")
        {
        }

        protected void Add() => ViewModel.AddDailyRate();

        protected void Remove(Guid id)
        {
            ViewModel.RemoveDailyRate(id);
            StateHasChanged();
        }
    }
}