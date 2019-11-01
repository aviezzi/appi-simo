namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using GraphQL.Common.Request;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GraphQlService<T> : IGraphQlService<T>
        where T : Entity, new()
    {
        readonly IQueryBuilder<T> _builder;
        readonly IFactoryAsync _factoryAsync;

        public GraphQlService(IQueryBuilder<T> builder, IFactoryAsync factoryAsync)
        {
            _builder = builder;
            _factoryAsync = factoryAsync;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            var name = $@"{typeof(T).Name.ToCamelCase()}s";
            var query = $@"
 				{{
				    {name} {{
						{_builder.Fields}
				    }}
				}}";
            
            var req = new GraphQLRequest
            {
                Query = query
            };

            var client = await _factoryAsync.Create();

            var res = await client.SendQueryAsync(req);
            return res.GetDataFieldAs<ICollection<T>>(name);
        }

        public async Task<T> GetOneAsync(Guid key)
        {
            var name = $"{typeof(T).Name.ToCamelCase()}";

            var query = $@"
				query Get{name}ById($id: UUID!) {{
					{name.ToCamelCase()}(id: $id) {{
						{_builder.Fields}
					}}                                                                         
				}}";
            
            var req = new GraphQLRequest
            {
                Query = query,
                Variables = new {key}
            };

            var client = await _factoryAsync.Create();
            var res = await client.SendQueryAsync(req);

            return res.ExtGetDataFieldAs<T>(name);
        }
        public Task<T> CreateAsync(T entity)
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

            var obj = new
            {
                input = _builder.BuildCreateQuery(entity)
            };

            return MutateAsync(query, queryName, obj);
        }

        public Task<T> UpdateAsync(T entity)
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

            var obj = new
            {
                input = _builder.BuildUpdateQuery(entity)
            };

            return MutateAsync(query, queryName, obj);
        }

        async Task<T> MutateAsync(string query, string name, object variables)
        {
            var req = new GraphQLRequest
            {
                Query = query,
                Variables = variables
            };

            var client = await _factoryAsync.Create();
            var res = await client.SendMutationAsync(req);

            return res.ExtGetDataFieldAs<T>(name);
        }
    }
}