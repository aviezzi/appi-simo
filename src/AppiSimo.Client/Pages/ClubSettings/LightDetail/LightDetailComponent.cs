namespace AppiSimo.Client.Pages.ClubSettings.LightDetail
{
    using System;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class LightDetailComponent : ComponentBase
    {
        [Inject]
        IResourceService<Light> EndPoint { get; set; }
        
        [Inject]
        IUriHelper UriHelper { get; set; }

        [Parameter]
        protected Guid Id { get; set; }
        
        protected async Task Save()
        {
            Console.WriteLine("Saved");
        }
    }
}