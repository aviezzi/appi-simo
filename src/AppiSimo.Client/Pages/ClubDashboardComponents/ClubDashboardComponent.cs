namespace AppiSimo.Client.Pages.ClubDashboardComponents
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ClubDashboardComponent : ComponentBase
    {
        [Parameter] public string Page { get; set; }

        [Inject] IGraphQlService<Light> LightService { get; set; }

        [Inject] IGraphQlService<Heat> HeatService { get; set; }

        [Inject] IGraphQlService<Court> CourtService { get; set; }

        [Inject] IGraphQlService<Rate> RatesService { get; set; }

        protected ICollection<Light> Lights { get; private set; }
        protected ICollection<Heat> Heats { get; private set; }
        protected ICollection<Court> Courts { get; private set; }
        protected ICollection<Rate> Rates { get; private set; }

        protected override async Task OnParametersSetAsync()
        {
            switch (Page)
            {
                case null:
                case "lights":
                    if (Lights is null) Lights = await LightService.GetAllAsync();
                    break;

                case "heats":
                    if (Heats is null) Heats = await HeatService.GetAllAsync();
                    break;

                case "courts":
                    if (Courts is null) Courts = await CourtService.GetAllAsync();
                    break;

                case "rates":
                    if (Rates is null) Rates = await RatesService.GetAllAsync();
                    break;

                default:
                    throw new KeyNotFoundException("Dashboard nested page not found!");
            }
        }
    }
}