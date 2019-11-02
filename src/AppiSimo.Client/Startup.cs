namespace AppiSimo.Client
{
    using Abstract;
    using Builders;
    using Converters;
    using Factories;
    using GraphQL.Client.Http;
    using Microsoft.AspNetCore.Blazor.Http;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Model;
    using Providers;
    using Services;
    using System;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConverters, ConvertersMap>();
            services.AddSingleton(provider => provider.GetService<IConverters>().LocalTime);
            services.AddSingleton(provider => provider.GetService<IConverters>().LocalDate);

            services.AddSingleton<IAuthService, AuthService>();

            services.AddScoped<AuthenticationStateProvider, CognitoAuthStateProvider>();
            services.AddAuthorizationCore();

            services.AddTransient(provider => new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("http://localhost:8080/graphql"),
                HttpMessageHandler = new WebAssemblyHttpMessageHandler()
            }));

            services.AddScoped<IFactoryAsync, HttpClientFactoryAsync>();

            services.AddSingleton<IQueryBuilder<Light>, LightBuilder>();
            services.AddSingleton<IQueryBuilder<Heat>, HeatBuilder>();
            services.AddSingleton<IQueryBuilder<Court>, CourtsBuilder>();
            services.AddSingleton<IQueryBuilder<Rate>, RateBuilder>();

            services.AddSingleton<IRequestBuilder<Light>, RequestBuilder<Light>>();
            services.AddSingleton<IRequestBuilder<Heat>, RequestBuilder<Heat>>();
            services.AddSingleton<IRequestBuilder<Court>, RequestBuilder<Court>>();
            services.AddSingleton<IRequestBuilder<Rate>, RequestBuilder<Rate>>();

            services.AddSingleton<IGraphQlService<Light>, GraphQlService<Light>>();
            services.AddSingleton<IGraphQlService<Heat>, GraphQlService<Heat>>();
            services.AddSingleton<IGraphQlService<Court>, GraphQlService<Court>>();
            services.AddSingleton<IGraphQlService<Rate>, GraphQlService<Rate>>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}