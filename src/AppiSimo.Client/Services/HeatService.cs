namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using Model;
    using System;

    public class HeatService : GraphQlServiceBase<Heat>
    {
        protected override string Fields { get; } = "id, heatType, price, enabled";

        protected override Func<Heat, string> CreateQuery { get; } = heat =>
            $@"{{
                ""heat"": {{
                    ""id"": ""{heat.Id}"",
                    ""heatType"": ""{heat.HeatType}"",
                    ""price"": {heat.Price},
                    ""enabled"": {heat.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        protected override Func<Heat, string> UpdateQuery { get; } = heat =>
            $@"{{
                ""id"": ""{heat.Id}"",
                ""patch"": {{
                    ""heatType"": ""{heat.HeatType}"",
                    ""price"": {heat.Price},
                    ""enabled"": {heat.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        public HeatService(IFactoryAsync factoryAsync, GraphQlExtensions extensions)
            : base(factoryAsync, extensions)
        {
        }
    }
}