namespace AppiSimo.Client.Pages.EventsComponent
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels;

    public class EventDetailComponent : DetailComponentBase<Event, EventViewModel>
    {
        IEnumerable<Court> _courts;

        [Inject] IGraphQlService<Court> CourtService { get; set; }

        private protected override Func<Event, EventViewModel> BuildViewModel =>
            @event => new EventViewModel(@event, _courts);

        public EventDetailComponent() : base("events")
        {
        }

        protected override async Task OnInitializedAsync() => _courts = await CourtService.GetAllAsync();
    }
}