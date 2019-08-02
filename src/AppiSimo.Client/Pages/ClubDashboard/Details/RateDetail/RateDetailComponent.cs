namespace AppiSimo.Client.Pages.ClubDashboard.Details.RateDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class RateDetailComponent : DetailBaseComponent<Rate, RateViewModel>
    {
        [Parameter]
        Guid Id { get; set; }

        [Inject]
        IGateway<Court> CourtService { get; set; }

        protected RateDetailComponent()
            : base("/club-dashboard/lights")
        {
        }
        
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