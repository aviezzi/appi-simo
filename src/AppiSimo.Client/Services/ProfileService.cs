namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using Model.Auth;
    using NodaTime;
    using System;

    public class ProfileService : GraphQlServiceBase<Profile>
    {
        readonly ITypeConverter<LocalDate> _converter;
        protected override string Fields { get; } = "id, name, surname, gender, address, email, birthdate";

        protected override Func<Profile, string> CreateQuery => profile =>
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


        protected override Func<Profile, string> UpdateQuery => profile =>
            $@"{{
                ""id"":""{profile.Id}"",
                ""patch"":
                {{
                    ""name"":""{profile.Name}"",
                    ""surname"":""{profile.Surname}"",
                    ""gender"":""{profile.Gender.ToString()}"",
                    ""birthdate"":""{_converter.FormatValueAsString(profile.BirthDate)}"",
                    ""address"":""{profile.Address}"",
                    ""email"":""{profile.Email}""
                }}
            }}";

        public ProfileService(IFactoryAsync factoryAsync, GraphQlExtensions extensions,
            ITypeConverter<LocalDate> converter) : base(factoryAsync,
            extensions)
        {
            _converter = converter;
            _converter.Pattern = "yyyy-MM-dd";
        }
    }
}