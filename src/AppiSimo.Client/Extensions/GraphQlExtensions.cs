namespace AppiSimo.Client.Extensions
{
    using GraphQL.Common.Response;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphQlExtensions
    {
        readonly JsonSerializerSettings _jsonSettings;

        public GraphQlExtensions(JsonSerializerSettings jsonSettings)
        {
            _jsonSettings = jsonSettings;
        }

        public T ExtGetDataFieldAs<T>(GraphQLResponse response, string value)
        {
            var values = value.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries);
            object data = response.Data as JObject;
            data = values.Aggregate(data, (current, val) => (current as JObject)?.GetValue(val));

            return data is JObject o
                ? o.ToObject<T>(JsonSerializer.Create(_jsonSettings))
                : throw new NullReferenceException("ExtGetDataFieldAs !!!Exception!!!");
        }

        public IEnumerable<T> ExtGetDataFieldAs2<T>(GraphQLResponse response, string value) =>
            ((JObject) response.Data).GetValue(value).ToObject<IEnumerable<T>>(JsonSerializer.Create(_jsonSettings));
    }
}