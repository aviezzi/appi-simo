using AppiSimo.Client.Abstract;
using AppiSimo.Client.Model;

namespace AppiSimo.Client.Builders
{
    public class HeatQueryBuilder : IStringQueryBuilder<Heat>
    {
        public string Fields => "id, heatType, price, enabled";

        public string BuildCreateQuery(Heat heat) =>
            $@"{{
                ""heat"": {{
                    ""id"": ""{heat.Id}"",
                    ""heatType"": ""{heat.HeatType}"",
                    ""price"": {heat.Price},
                    ""enabled"": {heat.Enabled.ToString().ToLowerInvariant()}
                }}
            }}";

        public string BuildUpdateQuery(Heat heat) =>
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