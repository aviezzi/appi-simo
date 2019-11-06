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
        [Inject] ITypeConverter<LocalDate> Converter { get; set; }
        [Parameter] public Guid Key { get; set; }
        
        protected UserDetailViewModel ViewModel { get; set; }
        
        protected override async Task OnParametersSetAsync()
        {
            var profile = await ProfileService.GetOneAsync(Key);
            
            Console.WriteLine($"NAME: {profile.Name}");
            
            ViewModel = new UserDetailViewModel(profile, Converter);
            StateHasChanged();
        }
        
        protected async Task HandleValidSubmit()
        {
            if (ViewModel.IsNew)
                await ProfileService.CreateAsync(ViewModel.Profile);
            else
                await ProfileService.UpdateAsync(ViewModel.Profile);

            NavigationManager.NavigateTo("/users");
        }
    }
}