namespace AppiSimo.Client.Services
{
    using System;
    using System.Reactive.Subjects;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.JSInterop;
    using Model.Auth;

    public class AuthService : IAuthService, IDisposable
    {
        public AuthService(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
            UserSubject = new BehaviorSubject<User>(User.Anonymous);
        }

        IJSRuntime JsRuntime { get; }
        public BehaviorSubject<User> UserSubject { get; }

        public async Task TryLoadUser()
        {
            var user = await JsRuntime.InvokeAsync<User>("interop.authentication.tryLoadUser").AsTask() ??
                       User.Anonymous;
            UserSubject.OnNext(user);
        }

        public Task SignIn() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.signIn").AsTask();

        public async Task SignedIn()
        {
            var user = await JsRuntime.InvokeAsync<User>("interop.authentication.signedIn").AsTask() ?? User.Anonymous;
            UserSubject.OnNext(user);
        }

        public Task SignOut() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.signOut").AsTask();

        public void Dispose()
        {
            UserSubject?.Dispose();
        }

        Task ClearSignedInHistory() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.clearSignedInHistory").AsTask();
    }
}