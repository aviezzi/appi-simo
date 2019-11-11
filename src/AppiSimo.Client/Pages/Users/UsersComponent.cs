namespace AppiSimo.Client.Pages.Users
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model.Auth;
    using NodaTime;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersComponent : ComponentBase
    {
        [Inject] IGraphQlService<Profile> ProfileService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ITypeConverter<LocalDate> LocalDateConverter { get; set; }

        protected ICollection<ProfileViewModel> Profiles { get; private set; }

        protected override async Task OnInitializedAsync() =>
            Profiles = (await ProfileService.GetAllAsync())
                .Select(p => new ProfileViewModel(LocalDateConverter)
                {
                    Entity = p
                })
                .ToList();

        protected void GoToCreate() =>
            NavigationManager.NavigateTo("user");

        protected void GoToEdit(Guid key) =>
            NavigationManager.NavigateTo($"user/{key}");
    }
}