namespace AppiSimo.Client.Pages.Auth.LoginBadge
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public class LoginBadgeComponent : ComponentBase
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] IAuthService AuthService { get; set; }

        protected void SignIn() => AuthService.SignIn();
        protected void SignOut() => AuthService.SignOut();
    }
}