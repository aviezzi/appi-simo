namespace AppiSimo.Client.Model.Auth
{
    using NodaTime;
    using System;
    using System.Text.Json.Serialization;

    public class Profile : Entity
    {
        public Guid Sub { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public LocalDate BirthDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public bool EmailVerified { get; set; }

        public string Phone { get; set; }
        public bool PhoneVerified { get; set; }
    }
}