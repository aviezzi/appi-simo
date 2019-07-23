namespace AppiSimo.Client.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Abstract;
    using Model;

    public class CourtService : IResourceService<Court>
    {
        readonly IGraphQlService<Court> _service;

        public CourtService(IGraphQlService<Court> service)
        {
            _service = service;
        }

        public async Task<ICollection<Court>> GetAsync()
        {
            const string query =
                @"
 				{
                    courts{
                        nodes {
                            id,
                            name,
                            light {
                                lightType,
                                price,
                                enabled
                            },
                            heat {
                                heatType,
                                price,
                                enabled
                            },
                            enabled
                        }
                    }
                }
				";

            return await _service.GetAll(query, "courts");
        }

        public async Task<Court> GetAsync(Guid key)
        {
            const string query =
                @"
				query GetCourtById($id: UUID!) {
					court(id: $id) {
						id,
						CourtType,
						price,
						enabled
					}                                                                         
				}
				";

            var result = await _service.GetOne(query, "court", key);

            return result;
        }
    }
}