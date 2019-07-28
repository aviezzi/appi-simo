namespace AppiSimo.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Model;

    public class CourtService : IResourceService<Court>
    {
        const string fields = @"id, name, light { lightType, price, enabled, id }, heat { heatType, price, enabled, id }, enabled";

        readonly IGraphQlService<Court> _service;

        public CourtService(IGraphQlService<Court> service)
        {
            _service = service;
        }

        public async Task<ICollection<Court>> GetAsync() => await _service.GetAsync(fields);

        public async Task<Court> GetAsync(Guid key) => await _service.GetAsync(key, fields);

        public Task<Court> AddAsync(Court court) => _service.CreateAsync(court, fields);

        public Task<Court> UpdateAsync(Court court) => _service.UpdateAsync(court, fields);
    }
}