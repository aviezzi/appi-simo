namespace AppiSimo.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Model;

    public class HeatService : IResourceService<Heat>
    {
        readonly IGraphQlService<Heat> _service;

        public HeatService(IGraphQlService<Heat> service)
        {
            _service = service;
        }

        public async Task<ICollection<Heat>> GetAsync()
        {
            const string query =
                @"
 				{
				    allHeats {
				        nodes {
				            id,
				            heatType,
							price,
							enabled
				        }
				    }
				}
				";

            return await _service.GetAll(query, "allHeats");
        }

        public async Task<Heat> GetAsync(Guid key)
        {
            const string query =
                @"
				query GetHeatById($id: UUID!) {
					heatById(id: $id) {
						id,
						heatType,
						price,
						enabled
					}                                                                         
				}
				";

            var result = await _service.GetOne(query, "heatById", key);

            return result;
        }
    }
}