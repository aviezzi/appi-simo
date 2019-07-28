namespace AppiSimo.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Model;

    public class LightService : IResourceService<Light>
    {
        const string fields = @"id, lightType, price, enabled";

        readonly IGraphQlService<Light> _service;

        public LightService(IGraphQlService<Light> service)
        {
            _service = service;
        }

        public async Task<ICollection<Light>> GetAsync() => await _service.GetAsync(fields);

        public async Task<Light> GetAsync(Guid key) => await _service.GetAsync(key, fields);

        public Task<Light> AddAsync(Light light) => _service.CreateAsync(light, fields);

        public Task<Light> UpdateAsync(Light light) => _service.UpdateAsync(light, fields);
    }
}