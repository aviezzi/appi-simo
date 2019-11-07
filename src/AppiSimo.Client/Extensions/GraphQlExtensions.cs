namespace AppiSimo.Client.Extensions
{
    using GraphQL.Common.Response;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;

    public static class GraphQlExtensions
    {
        public static T ExtGetDataFieldAs<T>(this GraphQLResponse response, string value, JsonSerializerSettings jsonSettings)
        {
            var values = value.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries);
            object data = response.Data as JObject;
            data = values.Aggregate(data, (current, val) => (current as JObject)?.GetValue(val));
            
            return data is JObject o
                ? o.ToObject<T>(JsonSerializer.Create(jsonSettings))
                : throw new NullReferenceException("ExtGetDataFieldAs");
        }

        public static T ExtGetDataFieldAs2<T>(this GraphQLResponse response, string value, JsonSerializerSettings jsonSettings) =>
            ((JObject) response.Data).GetValue(value).ToObject<T>(JsonSerializer.Create(jsonSettings));
    }
}