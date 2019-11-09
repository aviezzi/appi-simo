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
    using Model.Auth;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using NodaTime;
    using NodaTime.Serialization.JsonNet;
    using NodaTime.Text;
    using Pages.Users;
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

            var jsonSerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    DateParseHandling = DateParseHandling.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
                .ConfigureForNodaTime(DateTimeZoneProviders.Tzdb)
                .ReplaceExistingConverters<LocalDate>(
                    new NodaPatternConverter<LocalDate>(LocalDatePattern.CreateWithInvariantCulture("yyyy-MM-dd")));

            services.AddSingleton(jsonSerializerSettings);
            services.AddTransient(provider => new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("https://localhost:8080/graphql"),
                HttpMessageHandler = new WebAssemblyHttpMessageHandler(),
                JsonSerializerSettings = jsonSerializerSettings
            }));

            services.AddScoped<IFactoryAsync, HttpClientFactoryAsync>();

            services.AddSingleton<IQueryBuilder<Light>, LightBuilder>();
            services.AddSingleton<IQueryBuilder<Heat>, HeatBuilder>();
            services.AddSingleton<IQueryBuilder<Court>, CourtsBuilder>();
            services.AddSingleton<IQueryBuilder<Rate>, RateBuilder>();
            services.AddSingleton<IQueryBuilder<Profile>, ProfileBuilder>();

            services.AddSingleton<IRequestBuilder<Light>, RequestBuilder<Light>>();
            services.AddSingleton<IRequestBuilder<Heat>, RequestBuilder<Heat>>();
            services.AddSingleton<IRequestBuilder<Court>, RequestBuilder<Court>>();
            services.AddSingleton<IRequestBuilder<Rate>, RequestBuilder<Rate>>();
            services.AddSingleton<IRequestBuilder<Profile>, RequestBuilder<Profile>>();

            services.AddSingleton<ProfileViewModel>();

            services.AddSingleton<IViewModelFactory<Profile, ProfileViewModel>>(provider =>
                new ViewModelFactory<Profile, ProfileViewModel>
                {
                    ViewModel = provider.GetService<ProfileViewModel>(),
                    Build = (profile, viewModel) =>
                    {
                        viewModel.Entity = profile;
                        return viewModel;
                    }
                });

            services.AddSingleton<IGraphQlService<Light>, GraphQlService<Light>>();
            services.AddSingleton<IGraphQlService<Heat>, GraphQlService<Heat>>();
            services.AddSingleton<IGraphQlService<Court>, GraphQlService<Court>>();
            services.AddSingleton<IGraphQlService<Rate>, GraphQlService<Rate>>();
            services.AddSingleton<IGraphQlService<Profile>, GraphQlService<Profile>>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }

    public static class Ext
    {
        public static JsonSerializerSettings ReplaceExistingConverters<T>(this JsonSerializerSettings settings,
            JsonConverter newConverter)
        {
            var converters = settings.Converters;
            for (var i = converters.Count - 1; i >= 0; i--)
                if (converters[i].CanConvert(typeof(T)))
                    converters.RemoveAt(i);

            converters.Add(newConverter);

            return settings;
        }
    }
}