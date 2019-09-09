namespace AppiSimo.Client.Pages.ClubDashboard.Collections.Rates
{
    using System;
    using System.Collections.Generic;
    using AppiSimo.Client.Abstract;
    using AppiSimo.Client.Model;
    using Microsoft.AspNetCore.Components;
    using NodaTime;

    public class RatesComponent : ComponentBase
    {
        [Inject] NavigationManager UriHelper { get; set; }

        [Inject] protected ITypeConverter<LocalTime> Converter { get; set; }

        [Parameter] public ICollection<Rate> Rates { get; set; }

        protected void GoToEdit(Guid key) => UriHelper.NavigateTo($"/club-dashboard/rates/edit/{key}");

        protected void GoToCreate() => UriHelper.NavigateTo("/club-dashboard/rates/create");
    }
}