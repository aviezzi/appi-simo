using System;
using System.Threading.Tasks;
using AppiSimo.Client.Abstract;
using AppiSimo.Client.Model;
using Microsoft.AspNetCore.Components;

namespace AppiSimo.Client.Pages.ClubDashboard.Details.RateDetail
{
    public class RateDetailComponent : DetailBaseComponent<Rate, RateViewModel>
    {
        protected RateDetailComponent()
            : base("/club-dashboard/rates")
        {
        }

        [Inject] protected IConverters Converter { get; set; }

        [Parameter] Guid Id { get; set; }

        [Inject] IGateway<Court> CourtService { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var courts = await CourtService.GetAsync();

            if (Id != Guid.Empty)
            {
                var rate = await Service.GetAsync(Id);
                ViewModel = new RateViewModel(courts, rate);
            }
            else
            {
                ViewModel = new RateViewModel(courts);
            }
        }

        protected void Add()
        {
            ViewModel.AddDailyRate();
        }

        protected void Remove(Guid id)
        {
            ViewModel.RemoveDailyRate(id);
            StateHasChanged();
        }
    }
}