namespace AppiSimo.Client.Model
{
    using NodaTime;

    public class DailyRate : Entity
    {
        public LocalTime? Start { get; set; }
        public LocalTime? End { get; set; }
        public decimal Price { get; set; }
    }
}