namespace AppiSimo.Client.Model
{
    public class Court : Entity
    {
        public string Name { get; set; }
        public Light Light { get; set; } = new Light();
        public Heat Heat { get; set; } = new Heat();
        public bool Enabled { get; set; }
    }
}