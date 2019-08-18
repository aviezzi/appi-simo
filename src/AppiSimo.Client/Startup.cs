namespace AppiSimo.Client
{
    using AppiSimo.Client.Abstract;
    using AppiSimo.Client.Builders;
    using AppiSimo.Client.Converters;
    using AppiSimo.Client.Gateways;
    using AppiSimo.Client.Model;
    using AppiSimo.Client.Services;
    using GraphQL.Client.Http;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton<IConverters, ConvertersMap>();
            services.AddSingleton(provider => provider.GetService<IConverters>().LocalTime);
            services.AddSingleton(provider => provider.GetService<IConverters>().LocalDate);

            services.AddSingleton(new GraphQLHttpClient("http://localhost:8080/graphql"));

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