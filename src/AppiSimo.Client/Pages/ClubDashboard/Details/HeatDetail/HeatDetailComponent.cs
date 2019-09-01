namespace AppiSimo.Client.Pages.ClubDashboard.Details.HeatDetail
{
    using System;
    using System.Threading.Tasks;
    using AppiSimo.Client.Model;
    using Microsoft.AspNetCore.Components;

    public class HeatDetailComponent : DetailBaseComponent<Heat, HeatViewModel>
    {
        protected HeatDetailComponent()
            : base("/club-dashboard/heats")
        {
        }

        [Parameter] public Guid Id { get; set; }

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