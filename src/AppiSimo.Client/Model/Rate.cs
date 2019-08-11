namespace AppiSimo.Client.Model
{
    using System.Collections.Generic;
    using NodaTime;

    public class Rate : Entity
    {
        public string Name { get; set; } = string.Empty;
        public LocalDate Start { get; set; }
        public LocalDate End { get; set; }
        public ICollection<DailyRate> DailyRates { get; set; } = new List<DailyRate>();
    }
}