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
				    lights {
				        nodes {
				            id,
				            lightType,
							price,
							enabled
				        }
				    }
				}
				";

            return await _service.GetAll(query, "lights");
        }

        public async Task<Light> GetAsync(Guid key)
        {
            const string query =
                @"
				query GetLightById($id: UUID!) {
					light(id: $id) {
						id,
						lightType,
						price,
						enabled
					}                                                                         
				}
				";

            var result = await _service.GetOne(query, "light", key);

            return result;
        }

        public Task<Light> UpdateAsync(Light light) 
			=> _service.Update(light);

		public  Task<Light> AddAsync(Light light)
			=> _service.Create(light);
	}
}