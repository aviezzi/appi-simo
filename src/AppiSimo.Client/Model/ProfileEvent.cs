namespace AppiSimo.Client.Model
{
    public class ProfileEvent : Entity
    {
        public Profile Profile { get; set; }
        public decimal Price { get; set; }
        public bool Paid { get; set; }
    }
}