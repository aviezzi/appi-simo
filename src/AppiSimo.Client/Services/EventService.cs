namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using Model;
    using System;

    public class EventService : GraphQlServiceBase<Event>
    {
        protected override string Fields { get; } =
            @"  id, date, start, end, lightDuration, heatDuration,
                court { id, name, light { lightType }, heat { heatType } },
                profileEvents { profile { id, name, surname }, price, paid }";

        protected override Func<Event, string> CreateQuery { get; }
        protected override Func<Event, string> UpdateQuery { get; }

        public EventService(IFactoryAsync factoryAsync, GraphQlExtensions extensions) : base(factoryAsync, extensions)
        {
        }
    }
}