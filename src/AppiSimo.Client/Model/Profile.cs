namespace AppiSimo.Client.Model
{
    using Newtonsoft.Json;

    public class Profile : Auth.Profile
    {
        [JsonProperty("vDebtById")]
        public ProfileView Debt { get; set; }
    }

    public class ProfileView
    {
        [JsonProperty("debt")]
        public decimal Value { get; set; }
    }
}