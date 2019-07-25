namespace AppiSimo.Client.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    public interface IResourceService<T>
        where T : Entity, new()
    {
        Task<ICollection<T>> GetAsync();

        Task<T> GetAsync(Guid key);

        Task<Light> UpdateAsync(Light light);

        Task<Light> AddAsync(Light light);
    }
}