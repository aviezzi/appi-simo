namespace AppiSimo.Client.Pages.Users
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model.Auth;
    using System;
    using System.Threading.Tasks;

    public class UserDetailComponent : ComponentBase
    {
        [Inject] IGraphQlService<Profile> ProfileService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IViewModelFactory<Profile, ProfileViewModel> ViewModelFactory { get; set; }

        [Parameter] public Guid Key { get; set; }

        protected ProfileViewModel ViewModel { get; private set; }

        protected override async Task OnParametersSetAsync() =>
            ViewModel = Key == default
                ? ViewModelFactory.Create()
                : ViewModelFactory.Create(await ProfileService.GetOneAsync(Key));

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