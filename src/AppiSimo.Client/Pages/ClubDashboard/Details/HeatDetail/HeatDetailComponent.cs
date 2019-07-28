namespace AppiSimo.Client.Pages.ClubDashboard.Details.HeatDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class HeatDetailComponent : DetailBaseComponent<Heat>
    {
        [Inject]
        IGateway<Heat> HeatService { get; set; }

        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        Guid Id { get; set; }

        protected HeatViewModel ViewModel { get; private set; } = new HeatViewModel();

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var heat = await HeatService.GetAsync(Id);
                ViewModel = new HeatViewModel(heat);
            }
        }

        protected async Task HandleValidSubmit()
        {
            await base.HandleValidSubmit(ViewModel, "/club-dashboard/heats");
        }
    }
}