namespace AppiSimo.Client.Model
{
    using System;
    using Newtonsoft.Json;

    public class Court : Entity
    {
        public string Name { get; set; }
        [JsonProperty("lightByLightId")]
        public Light Light { get; set; } = new Light();
        [JsonProperty("heatByHeatId")]
        public Heat Heat { get; set; } = new Heat();  
        public bool Enabled { get; set; }
    }
}