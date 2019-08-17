using AppiSimo.Client.Abstract;
using AppiSimo.Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppiSimo.Client.Builders
{
    public class QueryBuilderWrapper<T> : IObjectQueryBuilder<T> 
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

        static object ParseValueFromString(string query)
        {
            var a = JsonConvert.DeserializeObject<JObject>(query);
            return a;
        }
    }
}