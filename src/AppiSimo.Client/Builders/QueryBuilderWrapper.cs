namespace AppiSimo.Client.Builders
{
    using Abstract;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class QueryBuilderWrapper<T> : IQueryBuilder<T>
        where T : IEntity
    {
        readonly IStringQueryBuilder<T> _builder;

        public QueryBuilderWrapper(IStringQueryBuilder<T> builder)
        {
            _builder = builder;
        }

        public string Fields => _builder.Fields;

        public object BuildCreateQuery(T entity) => ParseValueFromString(_builder.BuildCreateQuery(entity));

        public object BuildUpdateQuery(T entity) => ParseValueFromString(_builder.BuildUpdateQuery(entity));

        static object ParseValueFromString(string query) => JsonConvert.DeserializeObject<JObject>(query);
    }
}