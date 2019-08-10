namespace AppiSimo.Client.Pages.ClubDashboard.Collections.Rates
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class RatesComponent : ComponentBase
    {
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        protected ICollection<Rate> Rates { get; set; }
        
        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/rates/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/rates/create");
    }
}