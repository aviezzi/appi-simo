namespace AppiSimo.Client.Builders
{
    using Extensions;
    using GraphQL.Common.Request;
    using Model;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    public static class GraphQlQueryBuilder
    {
        public static (string name, GraphQLRequest request) BuildGetOne<T>(string fields, Guid key)
            where T : Entity, new()
        {
            var name = $"{typeof(T).Name.ToCamelCase()}";
            var query = $@"
				query Get{name}ById($id: UUID!) {{
					{name.ToCamelCase()}(id: $id) {{
						{fields}
					}}                                                                         
				}}";

            return (name, request: new GraphQLRequest
            {
                Query = query,
                Variables = new {id = key}
            });
        }

        public static (string name, GraphQLRequest request) BuildGetAllQuery<T>(string fields) where T : Entity, new()
        {
            var name = $@"{typeof(T).Name.ToCamelCase()}s";
            var query = $@"
 				{{
				    {name} {{
						{fields}
				    }}
				}}";

            return (name, request: new GraphQLRequest
            {
                Query = query
            });
        }

        public static (string name, GraphQLRequest request) BuildCreate<T>(Func<T, string> createQuery, string fields, T entity)
            where T : Entity, new()
        {
            var name = typeof(T).Name;
            var queryName = $@"create{name}";

            var query = $@"
				mutation Create{name}($input: Create{name}Input!){{
				  {queryName}(input: $input)
					{{
						{name.ToCamelCase()} {{
							{fields}
						}}
					}}
				}}";

            Console.WriteLine($"Entity: {entity.Id}");
            
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new
                {
                    input = ParseValueFromString(createQuery(entity))
                }
            };

            return (queryName, request);
        }

        public static (string name, GraphQLRequest request) BuildUpdate<T>(Func<T, string> updateQuery, string fields, T entity)
            where T : Entity, new()
        {
            var name = typeof(T).Name;
            var queryName = $@"update{name}";

            var query = $@"
				mutation Update{name}($input: Update{name}Input!) {{
				  {queryName}(input: $input) {{
					{name.ToCamelCase()} {{
			            {fields}
					}}
				  }}
				}}";

            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new
                {
                    input = ParseValueFromString(updateQuery(entity))
                }
            };

            return (queryName, request);
        }

        static object ParseValueFromString(string query) => JsonConvert.DeserializeObject<JObject>(query);
    }
}