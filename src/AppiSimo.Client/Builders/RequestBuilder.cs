namespace AppiSimo.Client.Builders
{
    using Abstract;
    using Extensions;
    using GraphQL.Common.Request;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    public class RequestBuilder<T> : IRequestBuilder<T>
        where T : class, IEntity
    {
        readonly IQueryBuilder<T> _builder;

        public RequestBuilder(IQueryBuilder<T> builder)
        {
            _builder = builder;
        }

        public string Fields => _builder.Fields;

        public (string name, GraphQLRequest request) BuildGetOne(Guid key)
        {
            var name = $"{typeof(T).Name.ToCamelCase()}";
            var query = $@"
				query Get{name}ById($id: UUID!) {{
					{name.ToCamelCase()}(id: $id) {{
						{_builder.Fields}
					}}                                                                         
				}}";

            return (name, request: new GraphQLRequest
            {
                Query = query,
                Variables = new {id = key}
            });
        }

        public (string name, GraphQLRequest request) BuildGetAllQuery()
        {
            var name = $@"{typeof(T).Name.ToCamelCase()}s";
            var query = $@"
 				{{
				    {name} {{
						{_builder.Fields}
				    }}
				}}";

            return (name, request: new GraphQLRequest
            {
                Query = query
            });
        }

        public (string name, GraphQLRequest request) BuildCreate(T entity)
        {
            entity.Id = Guid.NewGuid();

            var name = typeof(T).Name;
            var queryName = $@"create{name}";

            var query = $@"
				mutation Create{name}($input: Create{name}Input!){{
				  {queryName}(input: $input)
					{{
						{name.ToCamelCase()} {{
							{_builder.Fields}
						}}
					}}
				}}";

            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new
                {
                    input = ParseValueFromString(_builder.BuildCreate(entity))
                }
            };

            return (queryName, request);
        }

        public (string name, GraphQLRequest request) BuildUpdate(T entity)
        {
            var name = typeof(T).Name;
            var queryName = $@"update{name}";

            var query = $@"
				mutation Update{name}($input: Update{name}Input!) {{
				  {queryName}(input: $input) {{
					{name.ToCamelCase()} {{
			            {_builder.Fields}
					}}
				  }}
				}}";

            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new
                {
                    input = ParseValueFromString(_builder.BuildUpdate(entity))
                }
            };

            return (queryName, request);
        }

        static object ParseValueFromString(string query) => JsonConvert.DeserializeObject<JObject>(query);
    }
}