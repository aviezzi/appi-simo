namespace AppiSimo.Client.Pages.ClubDashboard.Details.HeatDetail
{
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Threading.Tasks;

    public class HeatDetailComponent : DetailBaseComponent<Heat, HeatViewModel>
    {
        [Parameter] public Guid Id { get; set; }

        protected HeatDetailComponent()
            : base("/club-dashboard/heats")
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var heat = await Service.GetOneAsync(Id);
                ViewModel = new HeatViewModel(heat);
            }
        }
    }
}