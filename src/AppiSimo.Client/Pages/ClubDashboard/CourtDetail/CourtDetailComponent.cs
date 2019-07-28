namespace AppiSimo.Client.Pages.ClubDashboard.CourtDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class CourtDetailComponent : ComponentBase
    {
        [Inject]
        IResourceService<Light> LightService { get; set; }

        [Inject]
        IResourceService<Heat> HeatService { get; set; }

        [Inject]
        IResourceService<Court> CourtService { get; set; }

        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        Guid Id { get; set; }

        protected CourtViewModel ViewModel { get; private set; } = new CourtViewModel();

        protected override async Task OnInitAsync()
        {
            var lights = await LightService.GetAsync();
            var heats = await HeatService.GetAsync();
            
            if (Id != Guid.Empty)
            {
                var court = await CourtService.GetAsync(Id);

                ViewModel = new CourtViewModel(lights, heats, court);
            }
            
            ViewModel = new CourtViewModel(lights, heats);
        }

        protected async Task HandleValidSubmit()
        {
            if (ViewModel.IsNew)
            {
                await CourtService.AddAsync(ViewModel.Court);
            }
            else
            {
                await CourtService.UpdateAsync(ViewModel.Court);
            }

            UriHelper.NavigateTo("/club-dashboard/courts");
        }
    }
}