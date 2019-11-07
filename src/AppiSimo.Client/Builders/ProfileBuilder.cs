namespace AppiSimo.Client.Builders
{
    using Abstract;
    using Model.Auth;
    using NodaTime;
    using System;

    public class ProfileBuilder : IQueryBuilder<Profile>
    {
        readonly ITypeConverter<LocalDate> _converter;

        public ProfileBuilder(ITypeConverter<LocalDate> converter)
        {
            _converter = converter;
            _converter.Pattern = "yyyy-MM-dd";
        }
        
        public string Fields => "id, name, surname, gender, address, email, birthdate";

        public string BuildCreate(Profile profile) =>
            $@"{{
                ""profile"": {{
                    ""id"":""{profile.Id}"",
                    ""name"":""{profile.Name}"",
                    ""surname"":""{profile.Surname}"",
                    ""gender"":""{profile.Gender.ToString()}"",
                    ""birthdate"":""{_converter.FormatValueAsString(profile.BirthDate)}"",
                    ""address"":""{profile.Address}"",
                    ""email"":""{profile.Email}"",
                    ""sub"":""{Guid.Empty}""
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
                    ""email"":""{profile.Email}""
                }}
            }}";
    }
}