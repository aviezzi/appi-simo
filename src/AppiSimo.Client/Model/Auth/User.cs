namespace AppiSimo.Client.Model.Auth
{
    using System;
    using System.Text.Json.Serialization;

    public class User
    {
        public static User Anonymous { get; } = new User
        {
            Token = string.Empty,
            Profile = new Profile
            {
                Name = "Anonymous User"
            }
        };

        public string Token { get; set; }

        public Profile Profile { get; set; }
    }
}