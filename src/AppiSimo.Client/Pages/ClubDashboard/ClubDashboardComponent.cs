namespace AppiSimo.Client.Pages.ClubDashboard
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;

    public class ClubDashboardComponent : ComponentBase
    {
        [Parameter]
        protected string Page { get; set; } = string.Empty;

        [Inject]
        IGateway<Light> LightGateway { get; set; }

        [Inject]
        IGateway<Heat> HeatGateway { get; set; }

        [Inject]
        IGateway<Court> CourtGateway { get; set; }

        [Inject]
        IGateway<Rate> RatesGateway { get; set; }

        protected ICollection<Light> Lights { get; private set; }
        protected ICollection<Heat> Heats { get; private set; }
        protected ICollection<Court> Courts { get; private set; }
        protected ICollection<Rate> Rates { get; private set; }

        protected override async Task OnParametersSetAsync()
        {
            switch (Page)
            {
                case "":
                case "lights":
                    if (Lights is null)
                    {
                        Lights = await LightGateway.GetAsync();
                    }

                    break;

                case "heats":
                    if (Heats is null)
                    {
                        Heats = await HeatGateway.GetAsync();
                    }

                    break;

                case "courts":
                    if (Courts is null)
                    {
                        Courts = await CourtGateway.GetAsync();
                    }

                    break;

                case "rates":
                    if (Rates is null)
                    {
                        Rates = await RatesGateway.GetAsync();
                    }

                    break;

                default:
                    throw new Exception("Not Found!");
            }
        }
    }
}