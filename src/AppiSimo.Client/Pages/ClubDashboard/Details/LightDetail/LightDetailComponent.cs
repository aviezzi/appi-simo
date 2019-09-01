namespace AppiSimo.Client.Pages.ClubDashboard.Details.LightDetail
{
    using System;
    using System.Threading.Tasks;
    using AppiSimo.Client.Model;
    using Microsoft.AspNetCore.Components;

    public class LightDetailComponent : DetailBaseComponent<Light, LightViewModel>
    {
        protected LightDetailComponent()
            : base("/club-dashboard/lights")
        {
        }

        [Parameter] public Guid Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
            {
                var light = await Service.GetAsync(Id);
                ViewModel = new LightViewModel(light);
            }
        }
    }
}