namespace AppiSimo.Client.Pages.Profiles
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model.Auth;
    using NodaTime;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels;

    public class ProfilesComponent : ComponentBase
    {
        [Inject] IGraphQlService<Profile> ProfileService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ITypeConverter<LocalDate> LocalDateConverter { get; set; }

        protected IEnumerable<ProfileViewModel> Profiles { get; private set; }

        protected override async Task OnInitializedAsync() =>
            Profiles = (await ProfileService.GetAllAsync())
                .Select(p => new ProfileViewModel(LocalDateConverter)
                {
                    Entity = p
                });

        protected void GoToCreate() =>
            NavigationManager.NavigateTo("user");

        protected void GoToEdit(Guid key) =>
            NavigationManager.NavigateTo($"user/{key}");
    }
}