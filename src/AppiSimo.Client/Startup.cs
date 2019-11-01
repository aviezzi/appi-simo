namespace AppiSimo.Client
{
    using System;
    using Abstract;
    using Builders;
    using Converters;
    using Factories;
    using Gateways;
    using GraphQL.Client.Http;
    using Microsoft.AspNetCore.Blazor.Http;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Model;
    using Providers;
    using Services;

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
            
            services.AddSingleton<IStringQueryBuilder<Light>, LightQueryBuilder>();
            services.AddSingleton<IStringQueryBuilder<Heat>, HeatQueryBuilder>();
            services.AddSingleton<IStringQueryBuilder<Court>, CourtsQueryBuilder>();
            services.AddSingleton<IStringQueryBuilder<Rate>, RateQueryBuilder>();

            services.AddSingleton<IQueryBuilder<Light>, QueryBuilderWrapper<Light>>();
            services.AddSingleton<IQueryBuilder<Heat>, QueryBuilderWrapper<Heat>>();
            services.AddSingleton<IQueryBuilder<Court>, QueryBuilderWrapper<Court>>();
            services.AddSingleton<IQueryBuilder<Rate>, QueryBuilderWrapper<Rate>>();

            services.AddSingleton<IGraphQlService<Light>, GraphQlService<Light>>();
            services.AddSingleton<IGraphQlService<Heat>, GraphQlService<Heat>>();
            services.AddSingleton<IGraphQlService<Court>, GraphQlService<Court>>();
            services.AddSingleton<IGraphQlService<Rate>, GraphQlService<Rate>>();

            services.AddSingleton<IGateway<Light>, GraphQlGateway<Light>>();
            services.AddSingleton<IGateway<Heat>, GraphQlGateway<Heat>>();
            services.AddSingleton<IGateway<Court>, GraphQlGateway<Court>>();
            services.AddSingleton<IGateway<Rate>, GraphQlGateway<Rate>>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}