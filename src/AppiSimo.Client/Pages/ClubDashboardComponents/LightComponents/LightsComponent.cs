namespace AppiSimo.Client.Pages.ClubDashboardComponents.LightComponents
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels;

    public class LightsComponent : CollectionComponentBase<Light, LightViewModel>
    {
        [Parameter] public IEnumerable<Light> Lights { get; set; } = new List<Light>();

        public LightsComponent() : base("/club-dashboard/light")
        {
        }

        private protected override Task<IEnumerable<LightViewModel>> BuildViewModel() =>
            Task.FromResult(Lights?.Select(light => new LightViewModel(light)) ?? new List<LightViewModel>());
    }
}