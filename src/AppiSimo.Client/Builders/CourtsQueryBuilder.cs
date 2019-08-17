namespace AppiSimo.Client.Builders
{
    using AppiSimo.Client.Abstract;
    using AppiSimo.Client.Model;

    public class CourtsQueryBuilder : IStringQueryBuilder<Court>
    {
        public string Fields =>
            "id, name, light { lightType, price, enabled, id }, heat { heatType, price, enabled, id }, enabled";

        public string BuildCreateQuery(Court court) =>
            $@"{{
                ""court"": {{
                    ""id"":""{court.Id}"",
                    ""name"":""{court.Name}"",
                    ""lightId"":""{court.Light.Id}"",
                    ""heatId"":""{court.Heat.Id}"",
                    ""enabled"":{court.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        public string BuildUpdateQuery(Court court) =>
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
    }
}