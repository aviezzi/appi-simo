namespace AppiSimo.Client.Pages.ClubDashboardComponents.LightComponents
{
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Collections.Generic;

    public class LightsComponent : ComponentBase
    {
        [Inject] NavigationManager UriHelper { get; set; }

        [Parameter] public ICollection<Light> Lights { get; set; }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/light/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/light/create");
    }
}