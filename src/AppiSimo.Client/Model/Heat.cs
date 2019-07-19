namespace AppiSimo.Client.Model
{
    public class Heat : Entity
    {
        public string HeatType { get; set; }
        public decimal Price { get; set; }
        public bool Enabled { get; set; }
    }
}