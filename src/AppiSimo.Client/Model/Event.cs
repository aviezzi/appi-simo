namespace AppiSimo.Client.Model
{
    using NodaTime;
    using System.Collections.Generic;

    public class Event : Entity
    {
        public LocalDate Date { get; set; }

        public LocalTime Start { get; set; }
        public LocalTime End { get; set; }

        public Light Light { get; set; }
        public double? LightDuration { get; set; }

        public Heat Heat { get; set; }
        public double? HeatDuration { get; set; }

        public IEnumerable<ProfileEvent> ProfileEvents { get; set; }
    }
}