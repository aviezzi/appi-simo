namespace AppiSimo.Client.Pages.ClubDashboard.Details.LightDetail
{
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Threading.Tasks;

    public class LightDetailComponent : DetailBaseComponent<Light, LightViewModel>
    {
        [Parameter] public Guid Id { get; set; }

        protected LightDetailComponent()
            : base("/club-dashboard/lights")
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var light = await Service.GetOneAsync(Id);
                ViewModel = new LightViewModel(light);
            }
        }
    }
}