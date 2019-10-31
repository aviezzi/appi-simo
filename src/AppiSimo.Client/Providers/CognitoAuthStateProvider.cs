namespace AppiSimo.Client.Providers
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Model.Auth;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CognitoAuthStateProvider : AuthenticationStateProvider
    {
        readonly IAuthService _authService;
        readonly NavigationManager _manager;

        public CognitoAuthStateProvider(IAuthService authService, NavigationManager manager)
        {
            _authService = authService;
            _manager = manager;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = (_manager.Uri.Contains("signed-in")
                           ? await _authService.SignedIn()
                           : await _authService.TryLoadUser()) ?? User.Anonymous;

            var principal = user == User.Anonymous
                ? new ClaimsPrincipal()
                : new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Profile.Name)
                }, "Cognito authentication type"));

            return new AuthenticationState(principal);
        }
    }
}