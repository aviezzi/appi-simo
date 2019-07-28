namespace AppiSimo.Client.Pages.ClubDashboard.HeatDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class HeatDetailComponent : ComponentBase
    {
        [Inject]
        IResourceService<Heat> HeatService { get; set; }

        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        Guid Id { get; set; }

        protected HeatViewModel ViewModel { get; private set; } = new HeatViewModel();

        protected override async Task OnInitAsync()
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
                await HeatService.AddAsync(ViewModel.Heat);
            }
            else
            {
                await HeatService.UpdateAsync(ViewModel.Heat);
            }

            UriHelper.NavigateTo("/club-dashboard/heats");
        }
    }
}