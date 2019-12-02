namespace AppiSimo.Client.Pages.EventsComponent
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

    public class EventsComponent : CollectionComponentBase<Event, EventViewModel>
    {
        [Inject] IGraphQlService<Event> EventService { get; set; }
        [Inject] protected IConverters Converters { get; set; }

        public EventsComponent() : base("profile")
        {
        }

        private protected override async Task<IEnumerable<EventViewModel>> BuildViewModel() => (await EventService.GetAllAsync()).Select(@event => new EventViewModel(@event));
    }
}