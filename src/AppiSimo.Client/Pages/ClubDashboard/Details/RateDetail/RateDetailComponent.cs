namespace AppiSimo.Client.Pages.ClubDashboard.Details.RateDetail
{
    using Abstract;
    using Model;
    using System;
    using ViewModels;

    public class RateDetailComponent : DetailComponentBase<Rate, RateViewModel>
    {
        protected override Func<Rate, RateViewModel> BuildViewModel =>
            rate => new RateViewModel
            {
                Entity = rate
            };

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