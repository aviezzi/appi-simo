namespace AppiSimo.Client.Pages.ClubDashboardComponents.HeatComponents
{
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Collections.Generic;

    public class HeatsComponent : ComponentBase
    {
        [Inject] NavigationManager UriHelper { get; set; }

        [Parameter] public ICollection<Heat> Heats { get; set; }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/heat/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/heat/create");
    }
}