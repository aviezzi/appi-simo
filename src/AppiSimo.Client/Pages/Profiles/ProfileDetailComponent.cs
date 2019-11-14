namespace AppiSimo.Client.Pages.Profiles
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model.Auth;
    using NodaTime;
    using System;
    using System.Threading.Tasks;
    using ViewModels;

    public class ProfileDetailComponent : ComponentBase
    {
        [Inject] IGraphQlService<Profile> ProfileService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ITypeConverter<LocalDate> LocalDateConverter { get; set; }

        [Parameter] public Guid Key { get; set; }

        protected ProfileViewModel ViewModel { get; private set; }

        protected override async Task OnParametersSetAsync() =>
            ViewModel = Key == default
                ? new ProfileViewModel(LocalDateConverter)
                : new ProfileViewModel(LocalDateConverter)
                {
                    Entity = await ProfileService.GetOneAsync(Key)
                };

        protected async Task HandleValidSubmit()
        {
            if (ViewModel.IsNew)
                await ProfileService.CreateAsync(ViewModel.Entity);
            else
                await ProfileService.UpdateAsync(ViewModel.Entity);

            NavigationManager.NavigateTo("/users");
        }
    }
}