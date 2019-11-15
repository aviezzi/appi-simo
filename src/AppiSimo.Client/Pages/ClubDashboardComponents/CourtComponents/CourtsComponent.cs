namespace AppiSimo.Client.Pages.ClubDashboardComponents.CourtComponents
{
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Collections.Generic;

    public class CourtsComponent : ComponentBase
    {
        [Inject] NavigationManager UriHelper { get; set; }

        [Parameter] public ICollection<Court> Courts { get; set; }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/court/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/court/create");
    }
}