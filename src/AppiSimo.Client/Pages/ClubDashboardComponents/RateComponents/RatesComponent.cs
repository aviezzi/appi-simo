namespace AppiSimo.Client.Pages.ClubDashboardComponents.RateComponents
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using NodaTime;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels;

    public class RatesComponent : CollectionComponentBase<Rate, RateViewModel>
    {
        [Parameter] public ICollection<Rate> Rates { get; set; }

        [Inject] protected IConverters Converters { get; set; }

        public RatesComponent() : base("/club-dashboard/rates")
        {
        }

        private protected override Task<IEnumerable<RateViewModel>> BuildViewModel() =>
            Task.FromResult(Rates?.Select(rate => new RateViewModel(rate)) ?? new List<RateViewModel>());
    }
}