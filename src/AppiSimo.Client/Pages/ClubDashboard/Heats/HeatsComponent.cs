namespace AppiSimo.Client.Pages.ClubDashboard.Heats
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class HeatsComponent : ComponentBase
    {
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        protected ICollection<Heat> Heats { get; set; }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/heat/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/heat/create");
    }
}