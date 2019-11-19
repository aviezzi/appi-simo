namespace AppiSimo.Client
{
    using Abstract;
    using Converters;
    using Extensions;
    using Factories;
    using GraphQL.Client.Http;
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
    using Providers;
    using Services;
    using System;
    using System.Net.Http;
    using System.Reflection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConverters, ConvertersMap>();
            services.AddSingleton(provider => provider.GetService<IConverters>().LocalTime);
            services.AddSingleton(provider => provider.GetService<IConverters>().LocalDate);

            services.AddSingleton<IAuthService, AuthService>();

            services.AddScoped<AuthenticationStateProvider, CognitoAuthStateProvider>();
            services.AddAuthorizationCore();

            var handler = Assembly.Load("WebAssembly.Net.Http")
                .GetType("WebAssembly.Net.Http.HttpClient.WasmHttpMessageHandler");

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
                HttpMessageHandler = (HttpMessageHandler) Activator.CreateInstance(handler),
                JsonSerializerSettings = jsonSerializerSettings
            }));

            services.AddScoped<IFactoryAsync, HttpClientFactoryAsync>();
            services.AddSingleton<GraphQlExtensions>();

            services.AddSingleton<IGraphQlService<Light>, LightService>();
            services.AddSingleton<IGraphQlService<Heat>, HeatService>();
            services.AddSingleton<IGraphQlService<Court>, CourtService>();
            services.AddSingleton<IGraphQlService<Rate>, RateService>();
            services.AddSingleton<IGraphQlService<Profile>, ProfileService>();
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