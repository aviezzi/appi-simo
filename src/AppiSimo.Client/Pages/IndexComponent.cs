namespace AppiSimo.Client.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class IndexComponent : ComponentBase
    {
        [Inject]
        IGateway<Light> LightService { get; set; }

        protected ICollection<Light> Lights { get; private set; }
        protected Light Light { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Lights = await LightService.GetAsync();

        }
        
        protected async Task Select(Guid key)
        {
            Light = await LightService.GetAsync(key);
            StateHasChanged();
        }
    }
}