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
        [Inject] IGraphQlService<Light> LightService { get; set; }

        protected ICollection<Light> Lights { get; private set; }
        protected Light Light { get; private set; }

        protected override async Task OnInitializedAsync() =>
            Lights = await LightService.GetAllAsync();

        protected async Task Select(Guid key)
        {
            Light = await LightService.GetOneAsync(key);
            StateHasChanged();
        }
    }
}