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
				    heats {
				        nodes {
				            id,
				            heatType,
							price,
							enabled
				        }
				    }
				}
				";

            return await _service.GetAll(query, "heats");
        }

        public async Task<Heat> GetAsync(Guid key)
        {
            const string query =
                @"
				query GetHeatById($id: UUID!) {
					heat(id: $id) {
						id,
						heatType,
						price,
						enabled
					}                                                                         
				}
				";

            var result = await _service.GetOne(query, "heat", key);

            return result;
        }

		public Task<Heat> UpdateAsync(Heat heat) => _service.Update(heat);

		public Task<Heat> AddAsync(Heat heat) => _service.Create(heat);
	}
}