namespace AppiSimo.Client.Pages.UserDetail
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model.Auth;
    using NodaTime;
    using System;
    using System.Threading.Tasks;

    public class UserDetailComponent : ComponentBase
    {
        [Inject] IGraphQlService<Profile> ProfileService{ get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        
        [Parameter] public Guid Key { get; set; }
        
        protected UserDetailViewModel ViewModel { get; private set; }
        
        protected override async Task OnParametersSetAsync()
        {
            var profile = Key == default ? new Profile() : await ProfileService.GetOneAsync(Key);
            
            ViewModel = new UserDetailViewModel(profile);
            StateHasChanged();
        }
        
        protected async Task HandleValidSubmit()
        {
            Console.WriteLine($"Name: {ViewModel.Profile.Name}");
            Console.WriteLine($"Email: {ViewModel.Profile.Email}");
            
            if (ViewModel.IsNew)
                await ProfileService.CreateAsync(ViewModel.Profile);
            else
                await ProfileService.UpdateAsync(ViewModel.Profile);

            NavigationManager.NavigateTo("/users");
        }
    }
}