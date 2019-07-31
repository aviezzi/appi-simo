namespace AppiSimo.Client.Model
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using NodaTime;

    public class Rate : Entity
    {
        public LocalDate Start { get; set; }
        public LocalDate End { get; set; }

        public ICollection<DailyRate> DailyRates { get; set; }
    }
}