namespace AppiSimo.Client.Builders
{
    using AppiSimo.Client.Abstract;
    using AppiSimo.Client.Model;

    public class LightQueryBuilder : IStringQueryBuilder<Light>
    {
        public string Fields => "id, lightType, price, enabled";

        public string BuildCreateQuery(Light light) =>
            $@"{{
                ""light"":{{
                    ""id"":""{light.Id}"",
                    ""lightType"":""{light.LightType}"",
                    ""price"":{light.Price},
                    ""enabled"":{light.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        public string BuildUpdateQuery(Light light) =>
            $@"{{
                ""id"":""{light.Id}"",
                ""patch"":{{
                    ""lightType"":""{light.LightType}"",
                    ""price"":{light.Price},
                    ""enabled"":{light.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";
    }
}