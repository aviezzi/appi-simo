namespace AppiSimo.Client.Pages.Auth.LoginBadge
{
    using System;
    using System.Reactive;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using Model.Auth;

    public class LoginBadgeComponent : ComponentBase, IDisposable
    {
        IDisposable _observable;

        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] IAuthService AuthService { get; set; }

        protected User User { get; private set; }

        protected override void OnInitialized()
        {
            var observer = Observer.Create<User>(
                user =>
                {
                    User = user;
                    StateHasChanged();
                });

            _observable = AuthService.UserSubject.Subscribe(observer);
        }

        protected void SignIn() => AuthService.SignIn();
        protected void SignOut() => AuthService.SignOut();
        
        public void Dispose() => _observable?.Dispose();
    }
}