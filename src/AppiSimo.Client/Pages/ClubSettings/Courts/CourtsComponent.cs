namespace AppiSimo.Client.Pages.ClubSettings.Courts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class CourtsComponent : ComponentBase
    {
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Inject]
        IResourceService<Court> CourtService { get; set; }

        protected ICollection<Court> Courts { get; private set; }

        protected override async Task OnInitAsync()
        {
            Courts = await CourtService.GetAsync();
        }

        protected void GoToEdit(Guid key) =>
            UriHelper.NavigateTo($"/club-dashboard/court/edit/{key}");

        protected void GoToCreate() =>
            UriHelper.NavigateTo("/club-dashboard/court/create");
    }
}