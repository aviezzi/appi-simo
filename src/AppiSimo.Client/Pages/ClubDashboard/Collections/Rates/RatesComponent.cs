using System;
using System.Collections.Generic;
using AppiSimo.Client.Abstract;
using AppiSimo.Client.Model;
using Microsoft.AspNetCore.Components;

namespace AppiSimo.Client.Pages.ClubDashboard.Collections.Rates
{
    public class RatesComponent : ComponentBase
    {
        [Inject] IUriHelper UriHelper { get; set; }

        [Inject] protected IConverters Converters { get; set; }

        [Parameter] protected ICollection<Rate> Rates { get; set; }

        protected void GoToEdit(Guid key) => UriHelper.NavigateTo($"/club-dashboard/rates/edit/{key}");

        protected void GoToCreate() => UriHelper.NavigateTo("/club-dashboard/rates/create");
    }
}