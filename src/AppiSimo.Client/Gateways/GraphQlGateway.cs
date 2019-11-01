namespace AppiSimo.Client.Gateways
{
    using Abstract;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GraphQlGateway<T> : IGateway<T>
        where T : class, IEntity, new()
    {
        readonly IGraphQlService<T> _service;

        public GraphQlGateway(IGraphQlService<T> service)
        {
            _service = service;
        }

        public Task<ICollection<T>> GetAsync() => _service.GetAllAsync();

        public Task<T> GetAsync(Guid key) => _service.GetOneAsync(key);

        public Task<T> CreateAsync(T entity) => _service.CreateAsync(entity);

        public Task<T> UpdateAsync(T entity) => _service.UpdateAsync(entity);
    }
}