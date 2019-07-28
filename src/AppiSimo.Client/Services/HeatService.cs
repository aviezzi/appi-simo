namespace AppiSimo.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Model;

    public class HeatService : IResourceService<Heat>
    {
        const string fields = @"id, heatType, price, enabled";

        readonly IGraphQlService<Heat> _service;

        public HeatService(IGraphQlService<Heat> service)
        {
            _service = service;
        }

        public async Task<ICollection<Heat>> GetAsync() => await _service.GetAsync(fields);

        public async Task<Heat> GetAsync(Guid key) => await _service.GetAsync(key, fields);

        public Task<Heat> AddAsync(Heat heat) => _service.CreateAsync(heat, fields);

        public Task<Heat> UpdateAsync(Heat heat) => _service.UpdateAsync(heat, fields);
    }
}