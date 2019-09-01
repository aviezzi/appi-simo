namespace AppiSimo.Client.Pages.ClubDashboard.Collections.Heats
{
    using System;
    using System.Collections.Generic;
    using AppiSimo.Client.Model;
    using Microsoft.AspNetCore.Components;

    public class HeatsComponent : ComponentBase
    {
        [Inject] IUriHelper UriHelper { get; set; }

        [Parameter] public ICollection<Heat> Heats { get; set; }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/heat/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/heat/create");
    }
}