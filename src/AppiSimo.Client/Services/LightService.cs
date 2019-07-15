namespace AppiSimo.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
	using GraphQL.Client.Http;
	using Model;

    public class LightService : BaseGraphQlService<Light>, ILightService
    {
		public LightService(GraphQLHttpClient client)
			: base(client)
		{
		}
		
        public async Task<ICollection<Light>> GetAsync()
        {
            const string query =
                @"
 				{
				    allLights {
				        nodes {
				            id,
				            lightType,
							price
				        }
				    }
				}
				";

            return await GetAll(query, "allLights");
        }

        public async Task<Light> GetAsync(Guid key)
        {
            const string query =
                @"
				query GetLightById($id: UUID!) {
					lightById(id: $id) {
						id,
						lightType,
						price
					}
				}
				";

            var result = await GetOne(query, "lightById", key);

			return result;
		}
	}
}