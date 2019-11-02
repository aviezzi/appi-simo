namespace AppiSimo.Client.Builders
{
    using Abstract;
    using Model;

    public class HeatBuilder : IQueryBuilder<Heat>
    {
        public string Fields => "id, heatType, price, enabled";

        public string BuildCreate(Heat heat) =>
            $@"{{
                ""heat"": {{
                    ""id"": ""{heat.Id}"",
                    ""heatType"": ""{heat.HeatType}"",
                    ""price"": {heat.Price},
                    ""enabled"": {heat.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        public string BuildUpdate(Heat heat) =>
            $@"{{
                ""id"": ""{heat.Id}"",
                ""patch"": {{
                    ""heatType"": ""{heat.HeatType}"",
                    ""price"": {heat.Price},
                    ""enabled"": {heat.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";
    }
}