namespace AppiSimo.Client.Pages.ClubDashboard.Details.HeatDetail
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class HeatDetailComponent : DetailBaseComponent<Heat>
    {
        [Parameter]
        Guid Id { get; set; }

        protected HeatViewModel ViewModel { get; private set; } = new HeatViewModel();

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var heat = await Service.GetAsync(Id);
                ViewModel = new HeatViewModel(heat);
            }
        }

        protected async Task HandleValidSubmit()
        {
            await HandleValidSubmit(ViewModel, "/club-dashboard/heats");
        }
    }
}