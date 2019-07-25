namespace AppiSimo.Client.Pages.ClubSettings.HeatDetail
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

        protected void HandleValidSubmit()
        {
            if (ViewModel.IsNew)
            {
                HeatService.AddAsync(ViewModel.Heat);
            }
            else
            {
                HeatService.UpdateAsync(ViewModel.Heat);
            }

            UriHelper.NavigateTo("/club-dashboard/heats");
        }
    }
}