namespace AppiSimo.Client.Pages.ClubDashboard.Details.RateDetail
{
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Threading.Tasks;

    public class RateDetailComponent : DetailBaseComponent<Rate, RateViewModel>
    {
        [Parameter] public Guid Id { get; set; }

        protected RateDetailComponent()
            : base("/club-dashboard/rates")
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var rate = await Service.GetOneAsync(Id);
                ViewModel = new RateViewModel(rate);
            }
        }

        protected void Add() => ViewModel.AddDailyRate();

        protected void Remove(Guid id)
        {
            ViewModel.RemoveDailyRate(id);
            StateHasChanged();
        }
    }
}