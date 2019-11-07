namespace AppiSimo.Client.Builders
{
    using Abstract;
    using Model.Auth;
    using System;
    using System.Globalization;

    public class ProfileBuilder : IQueryBuilder<Profile>
    {
        public string Fields => "id, name, surname, gender, address, email, birthdate";

        public string BuildCreate(Profile profile) =>
            $@"{{
                ""profile"": {{
                    ""id"":""{profile.Id}"",
                    ""name"":""{profile.Name}"",
                    ""surname"":""{profile.Surname}"",
                    ""gender"":""{profile.Gender.ToString()}"",
                    ""birthdate"":""{profile.BirthDate}"",
                    ""address"":""{profile.Address}"",
                    ""Email"":""{profile.Email}""
                }}
            }}";

        public string BuildUpdate(Profile profile) =>
            $@"{{
                ""id"":""{profile.Id}"",
                ""patch"":
                {{
                    ""name"":""{profile.Name}"",
                    ""surname"":""{profile.Surname}"",
                    ""gender"":""{profile.Gender.ToString()}"",
                    ""birthdate"":""{profile.BirthDate}"",
                    ""address"":""{profile.Address}"",
                    ""Email"":""{profile.Email}""
                }}
            }}";
    }
}