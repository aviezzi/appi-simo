namespace AppiSimo.Client.Pages.ClubSettings.LightDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class LightDetailComponent : ComponentBase
    {
        [Inject]
        IResourceService<Light> LightService { get; set; }

        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        Guid Id { get; set; }

        protected LightViewModel ViewModel { get; private set; } = new LightViewModel();

        protected override async Task OnInitAsync()
        {
            if (Id != Guid.Empty)
            {
                var light = await LightService.GetAsync(Id);
                ViewModel = new LightViewModel(light);
                StateHasChanged();
            }
        }
        
        protected void HandleValidSubmit()
        {
            if (ViewModel.IsNew)
            {
                LightService.AddAsync(ViewModel.Light);
            }
            else
            {
                LightService.UpdateAsync(ViewModel.Light);
            }
            
            UriHelper.NavigateTo("/club-dashboard/lights");
        }
    }
}