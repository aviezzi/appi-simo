namespace AppiSimo.Client.Pages.ClubDashboardComponents.CourtComponents
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels;

    public class CourtsComponent : CollectionComponentBase<Court, CourtViewModel>
    {
        [Parameter] public IEnumerable<Court> Courts { get; set; }

        public CourtsComponent() : base("club-dashboard/court")
        {
        }

        private protected override Task<IEnumerable<CourtViewModel>> BuildViewModel() => 
            Task.FromResult(Courts?.Select(court => new CourtViewModel(court)) ?? new List<CourtViewModel>());
    }
}