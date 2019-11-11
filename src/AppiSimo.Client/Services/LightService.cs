namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using Model;
    using System;

    public class LightService : GraphQlServiceBase<Light>
    {
        protected override string Fields { get; } = "id, lightType, price, enabled";

        protected override Func<Light, string> CreateQuery { get; } = light =>
            $@"{{
                ""light"": {{
                    ""id"": ""{light.Id}"",
                    ""lightType"": ""{light.LightType}"",
                    ""price"": {light.Price},
                    ""enabled"": {light.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        protected override Func<Light, string> UpdateQuery { get; } = light =>
            $@"{{
                ""id"":""{light.Id}"",
                ""patch"":{{
                    ""lightType"":""{light.LightType}"",
                    ""price"":{light.Price},
                    ""enabled"":{light.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        public LightService(IFactoryAsync factoryAsync, GraphQlExtensions extensions)
            : base(factoryAsync, extensions)
        {
        }
    }
}