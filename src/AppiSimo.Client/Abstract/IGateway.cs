using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppiSimo.Client.Abstract
{
    public interface IGateway<T>
        where T : IEntity, new()
    {
        Task<ICollection<T>> GetAsync();

        Task<T> GetAsync(Guid key);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);
    }
}