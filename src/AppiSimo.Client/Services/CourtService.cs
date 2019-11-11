namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using Model;
    using System;

    public class CourtService : GraphQlServiceBase<Court>
    {
        protected override string Fields { get; } =
            "id, name, light { lightType, price, enabled, id }, heat { heatType, price, enabled, id }, enabled";

        protected override Func<Court, string> CreateQuery { get; } = court =>
            $@"{{
                ""court"": {{
                    ""id"":""{court.Id}"",
                    ""name"":""{court.Name}"",
                    ""lightId"":""{court.Light.Id}"",
                    ""heatId"":""{court.Heat.Id}"",
                    ""enabled"":{court.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        protected override Func<Court, string> UpdateQuery { get; } = court =>
            $@"{{
                ""id"":""{court.Id}"",
                ""patch"":
                {{
                    ""name"":""{court.Name}"",
                    ""lightId"":""{court.Light.Id}"",
                    ""heatId"":""{court.Heat.Id}"",
                    ""enabled"":{court.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        public CourtService(IFactoryAsync factoryAsync, GraphQlExtensions extensions)
            : base(factoryAsync, extensions)
        {
        }
    }
}