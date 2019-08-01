namespace AppiSimo.Client.Pages.ClubDashboard.Details.HeatDetail
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class HeatDetailComponent : DetailBaseComponent<Heat, HeatViewModel>
    {
        [Parameter]
        Guid Id { get; set; }

        protected HeatDetailComponent()
            : base("/club-dashboard/heats")
        {
        }
        
        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var heat = await Service.GetAsync(Id);
                ViewModel = new HeatViewModel(heat);
            }
        }
    }
}