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
        IGateway<Light> LightService { get; set; }    
        
        [Inject]
        IGateway<Heat> HeatService { get; set; }     
        
        [Inject]
        IGateway<Court> CourtService { get; set; }

        protected ICollection<Light> Lights { get; private set; }
        protected ICollection<Heat> Heats { get; private set; }
        protected ICollection<Court> Courts { get; private set; }

        protected override async Task OnParametersSetAsync()
        {
            switch (Page)
            {
                case "":
                case "lights":
                    if (Lights is null)
                    {
                        Lights = await LightService.GetAsync();
                    }

                    break;
                
                case "heats":
                    if (Heats is null)
                    {
                        Heats = await HeatService.GetAsync();
                    }

                    break;
                
                case "courts":
                    if (Courts is null)
                    {
                        Courts = await CourtService.GetAsync();
                    }

                    break;

                default:
                    throw new Exception("Not Found!");
            }
        }
    }
}