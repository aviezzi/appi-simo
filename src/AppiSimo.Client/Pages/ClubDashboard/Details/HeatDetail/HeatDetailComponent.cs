namespace AppiSimo.Client.Pages.ClubDashboard.Details.HeatDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class HeatDetailComponent : ComponentBase
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
            if (ViewModel.IsNew)
            {
                await HeatService.CreateAsync(ViewModel.Heat);
            }
            else
            {
                await HeatService.UpdateAsync(ViewModel.Heat);
            }

            UriHelper.NavigateTo("/club-dashboard/heats");
        }
    }
}