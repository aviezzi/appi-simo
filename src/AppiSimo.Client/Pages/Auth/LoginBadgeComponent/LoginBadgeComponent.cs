namespace AppiSimo.Client.Pages.Auth.LoginBadgeComponent
{
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public class LoginBadgeComponent : ComponentBase
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }

        [Inject] protected IAuthService AuthService { get; set; }

        protected void SignIn()
        {
            //AuthService.SignIn();
        }
        
        protected override async Task OnInitializedAsync() => await AuthService.SignIn();

        protected void SignOut() => AuthService.SignOut();
    }
}