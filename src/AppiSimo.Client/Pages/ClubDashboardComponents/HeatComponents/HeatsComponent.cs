namespace AppiSimo.Client.Pages.ClubDashboardComponents.HeatComponents
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels;

    public class HeatsComponent : CollectionComponentBase<Heat, HeatViewModel>
    {
        [Parameter] public IEnumerable<Heat> Heats { get; set; }

        public HeatsComponent() : base("/club-dashboard/heat")
        {
        }

        private protected override Task<IEnumerable<HeatViewModel>> BuildViewModel() =>
            Task.FromResult(Heats?.Select(heat => new HeatViewModel(heat)) ?? new List<HeatViewModel>());
    }
}