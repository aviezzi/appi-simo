namespace AppiSimo.Client.Pages.ClubDashboardComponents.RateComponents
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using NodaTime;
    using System;
    using System.Collections.Generic;

    public class RatesComponent : ComponentBase
    {
        [Inject] NavigationManager UriHelper { get; set; }

        [Inject] protected ITypeConverter<LocalTime> Converter { get; set; }

        [Parameter] public ICollection<Rate> Rates { get; set; }

        protected void GoToEdit(Guid key) => UriHelper.NavigateTo($"/club-dashboard/rates/edit/{key}");

        protected void GoToCreate() => UriHelper.NavigateTo("/club-dashboard/rates/create");
    }
}