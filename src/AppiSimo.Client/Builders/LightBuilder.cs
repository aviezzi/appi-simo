namespace AppiSimo.Client.Builders
{
    using Abstract;
    using Model;

    public class LightBuilder : IQueryBuilder<Light>
    {
        public string Fields => "id, lightType, price, enabled";

        public string BuildCreate(Light light) =>
            $@"{{
                ""light"":{{
                    ""id"":""{light.Id}"",
                    ""lightType"":""{light.LightType}"",
                    ""price"":{light.Price},
                    ""enabled"":{light.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        public string BuildUpdate(Light light) =>
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