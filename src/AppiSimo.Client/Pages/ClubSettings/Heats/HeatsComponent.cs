namespace AppiSimo.Client.Pages.ClubSettings.Heats
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class HeatsComponent : ComponentBase
    {
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Inject]
        IResourceService<Heat> HeatService { get; set; }

        protected ICollection<Heat> Heats { get; private set; }

        protected override async Task OnInitAsync()
        {
            Heats = await HeatService.GetAsync();
        }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/Heats/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/Heats/create");
    }
}