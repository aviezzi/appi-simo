namespace AppiSimo.Client.Pages.EventsComponent
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
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

        private protected override async Task<IEnumerable<EventViewModel>> BuildViewModel()
        {
            var ar = (await EventService.GetAllAsync());

            foreach (var a in ar)
            {
                Console.WriteLine($"flag QL: {a.Heat == null}");
                Console.WriteLine($"value QL: {a?.Heat?.HeatType ?? "sdsadas"}");
            }
            
            var result = ar.Select(@event =>
                new EventViewModel(@event));

            foreach (var r in result)
            {
                Console.WriteLine($"flag: {r.Heat != default}");
                Console.WriteLine($"value: {r?.Heat?.Type ?? "zero"}");
            }
            
            return result;
        }
    }
}