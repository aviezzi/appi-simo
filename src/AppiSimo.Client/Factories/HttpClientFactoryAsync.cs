namespace AppiSimo.Client.Factories
{
    using Abstract;
    using Constants;
    using GraphQL.Client.Http;
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class HttpClientFactoryAsync : IFactoryAsync
    {
        readonly AuthenticationStateProvider _authenticationStateProvider;
        readonly GraphQLHttpClient _client;

        public HttpClientFactoryAsync(GraphQLHttpClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<GraphQLHttpClient> Create()
        {
            var provider = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var token = provider.User.Claims.FirstOrDefault(claim => claim.Type == CognitoClaimTypes.TokenId);

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", $"{token}");

            return _client;
        }
    }
}