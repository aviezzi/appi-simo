namespace AppiSimo.Client.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Extensions;
    using Model;
    using Newtonsoft.Json;

    public interface IGraphQlService<T>
        where T : Entity, new()
    {
        Task<ICollection<T>> GetAll(string query, string name);

        Task<T> GetOne(string query, string name, Guid key);

        Task<T> Mutate(string query, string name, object variables);

        Task<ICollection<T>> GetAsync(string fields)
        {
            var name = $@"{typeof(T).Name.ToCamelCase()}s";

            var query = $@"
 				{{
				    {name} {{
				        nodes {{
							{fields}
				        }}
				    }}
				}}
				";

            return GetAll(query, name);
        }

        Task<T> GetAsync(Guid key, string fields)
        {
            var name = $"{typeof(T).Name.ToCamelCase()}";

            var query = $@"
				query Get{name}ById($id: UUID!) {{
					{name.ToCamelCase()}(id: $id) {{
						{fields}
					}}                                                                         
				}}
				";

            return GetOne(query, name, key);
        }

        Task<T> CreateAsync(T entity, string fields)
        {
            entity.Id = Guid.NewGuid();

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
				}}
				";

            var variables = ParseEntity(entity);

            var obj = new
            {
                input = new Dictionary<string, IDictionary<string, object>>
                {
                    { name.ToCamelCase(), variables }
                }
            };

            var s = JsonConvert.SerializeObject(obj);

            return Mutate(query, queryName, obj);
        }

        Task<T> UpdateAsync(T entity, string fields)
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
				}}
				";

            var patch = ParseEntity(entity);

            var obj = new
            {
                input = new
                {
                    id = entity.Id, patch
                }
            };

            return Mutate(query, queryName, obj);
        }

        Dictionary<string, object> ParseEntity(T entity) =>
            typeof(T).GetProperties().Select(property =>
                {
                    var key = property.Name.ToCamelCase();
                    var value = property.GetValue(entity);

                    return typeof(Entity).IsAssignableFrom(property.PropertyType)
                        ? (key: key + "Id", value: ((Entity) value)?.Id)
                        : (key, value);
                })
                .ToDictionary(tuple => tuple.key, tuple => tuple.value);
    }
}