namespace AppiSimo.Client.Services
{
    using Abstract;
    using Microsoft.JSInterop;
    using Model.Auth;
    using System.Threading.Tasks;

    public class AuthService : IAuthService
    {
        IJSRuntime JsRuntime { get; }

        public AuthService(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
        }

        public Task<User> TryLoadUser() =>
            JsRuntime.InvokeAsync<User>("interop.authentication.tryLoadUser").AsTask();

        public Task SignIn() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.signIn").AsTask();

        public Task<User> SignedIn() =>
            JsRuntime.InvokeAsync<User>("interop.authentication.signedIn").AsTask();

        public Task SignOut() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.signOut").AsTask();

        Task ClearSignedInHistory() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.clearSignedInHistory").AsTask();
    }
}