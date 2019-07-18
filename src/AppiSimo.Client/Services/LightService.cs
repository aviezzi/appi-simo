namespace AppiSimo.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Model;

    public class LightService : IResourceService<Light>
    {
        readonly IGraphQlService<Light> _service;

        public LightService(IGraphQlService<Light> service)
        {
            _service = service;
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
							price,
							enabled
				        }
				    }
				}
				";

            return await _service.GetAll(query, "allLights");
        }

        public async Task<Light> GetAsync(Guid key)
        {
            const string query =
                @"
				query GetLightById($id: UUID!) {
					lightById(id: $id) {
						id,
						lightType,
						price,
						enabled
					}                                                                         
				}
				";

            var result = await _service.GetOne(query, "lightById", key);

            return result;
        }
    }
}