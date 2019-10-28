namespace AppiSimo.Client.Model.Auth
{
    using System.Text.Json.Serialization;

    public class User
    {
        public static User Anonymous { get; } = new User
        {
            Profile = new Profile
            {
                Name = "Anonymous User"
            }
        };

        [JsonPropertyName("id_token")] public string IdToken { get; set; }

        [JsonPropertyName("profile")] public Profile Profile { get; set; }
    }
}