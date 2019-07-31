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

        protected override void OnInit()
        {
            Console.WriteLine("Hello!");
            base.OnInit();
        }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-settings/rates/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-settings/rates/create");
    }
}