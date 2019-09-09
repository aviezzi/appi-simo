namespace AppiSimo.Client.Pages.ClubDashboard.Collections.Courts
{
    using System;
    using System.Collections.Generic;
    using AppiSimo.Client.Model;
    using Microsoft.AspNetCore.Components;


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