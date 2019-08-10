using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppiSimo.Client.Abstract;
using AppiSimo.Client.Extensions;
using AppiSimo.Client.Model;

namespace AppiSimo.Client.Gateways
{
    public class GraphQlGateway<T> : IGateway<T>
        where T : Entity, new()
    {
        readonly string _fields;
        readonly IGraphQlService<T> _service;

        public GraphQlGateway(string fields, IGraphQlService<T> service)
        {
            _fields = fields;
            _service = service;
        }

        public Task<ICollection<T>> GetAsync()
        {
            var name = $@"{typeof(T).Name.ToCamelCase()}s";

            var query = $@"
 				{{
				    {name} {{
							{_fields}
				    }}
				}}
				";

            return _service.GetAll(query, name);
        }

        public Task<T> GetAsync(Guid key)
        {
            var name = $"{typeof(T).Name.ToCamelCase()}";

            var query = $@"
				query Get{name}ById($id: UUID!) {{
					{name.ToCamelCase()}(id: $id) {{
						{_fields}
					}}                                                                         
				}}
				";

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
							{_fields}
						}}
					}}
				}}
				";

            var variables = ParseEntity(entity, "create", (_, properties) => properties);

            var obj = new
            {
                input = new Dictionary<string, IDictionary<string, object>>
                {
                    {name.ToCamelCase(), variables}
                }
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
			            {_fields}
					}}
				  }}
				}}
				";

            var obj = new
            {
                input = ParseEntity(entity, "updateById", (id, properties) => new Dictionary<string, object>
                {
                    ["id"] = id,
                    ["patch"] = properties
                })
            };

            return _service.Mutate(query, queryName, obj);
        }

        static Dictionary<string, object> ParseEntity(Entity entity, string action, Func<Guid, Dictionary<string, object>, Dictionary<string, object>> selector)
        {
            if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();

            var id = entity.Id;
            var properties = entity.GetType().GetProperties().Select(property =>
                {
                    var key = property.Name.ToCamelCase();
                    var value = property.GetValue(entity);

                    switch (value)
                    {
                        case IEnumerable<Entity> enumerable:
                            return (key, new Dictionary<string, object>
                            {
                                [action] = enumerable.Select(e => ParseEntity(e, action, selector))
                            });
                        case Entity e:

                            return (key, value: new Dictionary<string, object>
                            {
                                [action] = ParseEntity(e, action, selector)
                            });
                        default:
                            return (key, value);
                    };
                })
                .ToDictionary(tuple => tuple.key, tuple => tuple.value);

            return selector(id, properties);
        }
    }
}