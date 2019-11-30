namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using Model;
    using System;

    public class ProfileService : GraphQlServiceBase<Profile>
    {
        protected override string Fields { get; } = "id, name, surname, gender, address, email, birthdate, vDebtById{ debt }, phone";

        protected override Func<Profile, string> CreateQuery => profile =>
            $@"{{
                ""profile"": {{
                    ""id"":""{profile.Id}"",
                    ""name"":""{profile.Name.Trim()}"",
                    ""surname"":""{profile.Surname.Trim()}"",
                    ""gender"":""{profile.Gender.ToString()}"",
                    ""birthdate"":""{profile.BirthDate}"",
                    ""address"":""{profile.Address.Trim()}"",
                    ""email"":""{profile.Email.Trim()}"",
                    ""phone"":""{profile.Phone.Trim()}"",
                    ""sub"":""{Guid.Empty}""
                }}
            }}";


        protected override Func<Profile, string> UpdateQuery => profile =>
            $@"{{
                ""id"":""{profile.Id}"",
                ""patch"":
                {{
                    ""name"":""{profile.Name.Trim()}"",
                    ""surname"":""{profile.Surname.Trim()}"",
                    ""gender"":""{profile.Gender.ToString()}"",
                    ""birthdate"":""{profile.BirthDate}"",
                    ""address"":""{profile.Address.Trim()}"",
                    ""email"":""{profile.Email.Trim()}"",
                    ""phone"":""{profile.Phone.Trim()}"",
                }}
            }}";

        public ProfileService(IFactoryAsync factoryAsync, GraphQlExtensions extensions) : base(factoryAsync,
            extensions)
        {
        }
    }
}