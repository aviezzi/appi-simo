namespace AppiSimo.Client.Pages
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IndexComponent : ComponentBase
    {
        [Inject] IGateway<Light> LightGateway { get; set; }

        protected ICollection<Light> Lights { get; private set; }
        protected Light Light { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Lights = await LightGateway.GetAsync();
        }

        protected async Task Select(Guid key)
        {
            Light = await LightGateway.GetAsync(key);
            StateHasChanged();
        }
    }
}