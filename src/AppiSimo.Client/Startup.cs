using AppiSimo.Client.Converters;
using NodaTime;

namespace AppiSimo.Client
{
    using Abstract;
    using Gateways;
    using GraphQL.Client.Http;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Model;
    using Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton(new GraphQLHttpClient("http://localhost:8080/graphql"));
            
            services.AddSingleton<IGraphQlService<Light>, GraphQlService<Light>>();
            services.AddSingleton<IGraphQlService<Heat>, GraphQlService<Heat>>();
            services.AddSingleton<IGraphQlService<Court>, GraphQlService<Court>>();
            services.AddSingleton<IGraphQlService<Rate>, GraphQlService<Rate>>();

            services.AddSingleton<IConverters, ConvertersMap>();
            services.AddSingleton(provider => provider.GetService<IConverters>().LocalTime);

            services.AddSingleton<IGateway<Light>>(provider => new GraphQlGateway<Light>(
                "id, lightType, price, enabled",
                provider.GetService<IGraphQlService<Light>>()
            ));
            services.AddSingleton<IGateway<Heat>>(provider => new GraphQlGateway<Heat>(
                "id, heatType, price, enabled",
                provider.GetService<IGraphQlService<Heat>>()
            ));
            services.AddSingleton<IGateway<Court>>(provider => new GraphQlGateway<Court>(
                "id, name, light { lightType, price, enabled, id }, heat { heatType, price, enabled, id }, enabled",
                provider.GetService<IGraphQlService<Court>>()
            ));
            services.AddSingleton<IGateway<Rate>>(provider => new GraphQlGateway<Rate>(
                "id, start, end, dailyRates  { id, start, end, price }",
                provider.GetService<IGraphQlService<Rate>>()
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}