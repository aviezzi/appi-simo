namespace AppiSimo.Client.Abstract
{
    using System;
    using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Extensions;
	using Model;

    public interface IGraphQlService<T>
        where T : Entity, new()
    {
        Task<ICollection<T>> GetAll(string query, string name);

        Task<T> GetOne(string query, string name, Guid key);

        Task<T> Mutate(string query, string name, object variables);
		Task<T> Update(T entity)
        {
			var (name, fields) = GetEntityInfo();
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
			
            var obj = new
            {
                input = new
                {
                    id = entity.Id,
                    patch = entity
                }
            };

            return Mutate(query, queryName, obj);
        }

        Task<T> Create(T entity)
        {
			entity.Id = Guid.NewGuid();
			
			var (name, fields) = GetEntityInfo();
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

			var obj = new
            {
                input = new Dictionary<string, object>()
                {
                    [name.ToCamelCase()] = entity
                }
            };

			return Mutate(query, queryName, obj);
        }
		
		private (string, string) GetEntityInfo()
		{
			var name = typeof(T).Name;

			var properties = typeof(T).GetProperties().Select(property => property.Name.ToCamelCase());
			var select = string.Join(",", properties);

			return (name, select);
		}
	}
}