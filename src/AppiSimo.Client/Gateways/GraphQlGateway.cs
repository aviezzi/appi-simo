namespace AppiSimo.Client.Gateways
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AppiSimo.Client.Abstract;
    using AppiSimo.Client.Extensions;

    public class GraphQlGateway<T> : IGateway<T>
        where T : IEntity, new()
    {
        readonly IQueryBuilder<T> _builder;
        readonly IGraphQlService<T> _service;

        public GraphQlGateway(IQueryBuilder<T> builder, IGraphQlService<T> service)
        {
            _builder = builder;
            _service = service;
        }

        public Task<ICollection<T>> GetAsync()
        {
            var name = $@"{typeof(T).Name.ToCamelCase()}s";

            var query = $@"
 				{{
				    {name} {{
						{_builder.Fields}
				    }}
				}}";

            return _service.GetAll(query, name);
        }

        public Task<T> GetAsync(Guid key)
        {
            var name = $"{typeof(T).Name.ToCamelCase()}";

            var query = $@"
				query Get{name}ById($id: UUID!) {{
					{name.ToCamelCase()}(id: $id) {{
						{_builder.Fields}
					}}                                                                         
				}}";

            return _service.GetOne(query, name, key);
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

            return _service.Mutate(query, queryName, obj);
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

            return _service.Mutate(query, queryName, obj);
        }
    }
}