namespace AppiSimo.Client.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGateway<T>
        where T : IEntity, new()
    {
        Task<ICollection<T>> GetAsync();

        Task<T> GetAsync(Guid key);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);
    }
}