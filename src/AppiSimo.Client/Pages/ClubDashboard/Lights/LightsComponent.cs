namespace AppiSimo.Client.Pages.ClubDashboard.Lights
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class LightsComponent : ComponentBase
    {
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        protected ICollection<Light> Lights { get; set; }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/light/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/light/create");
    }
}