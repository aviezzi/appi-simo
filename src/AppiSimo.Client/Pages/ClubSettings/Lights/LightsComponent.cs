namespace AppiSimo.Client.Pages.ClubSettings.Lights
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class LightsComponent : ComponentBase
    {
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Inject]
        IResourceService<Light> LightService { get; set; }

        protected ICollection<Light> Lights { get; private set; }

        protected override async Task OnInitAsync()
        {
            Lights = await LightService.GetAsync();
        }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/light/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/light/create");
    }
}