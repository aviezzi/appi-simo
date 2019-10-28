using System.Threading.Tasks;
using AppiSimo.Client.Abstract;
using AppiSimo.Client.Model.Auth;
using Microsoft.JSInterop;

namespace AppiSimo.Client.Services
{
    public class AuthService : IAuthService
    {
        IJSRuntime JsRuntime { get; set; }

        public AuthService(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
            User = User.Anonymous;
        }
        
        public User User { get; private set; }

        public async Task TryLoadUser() =>
            User = await JsRuntime.InvokeAsync<User>("interop.authentication.tryLoadUser").AsTask() ?? User.Anonymous;

        public Task SignIn() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.signIn").AsTask();

        public async Task SignedIn() =>
            User = await JsRuntime.InvokeAsync<User>("interop.authentication.signedIn").AsTask();

        public Task SignOut() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.signOut").AsTask();

        Task ClearSignedInHistory() =>
            JsRuntime.InvokeVoidAsync("interop.authentication.clearSignedInHistory").AsTask();
    }
}