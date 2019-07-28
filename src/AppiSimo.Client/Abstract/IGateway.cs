namespace AppiSimo.Client.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    public interface IGateway<T>
        where T : Entity, new()
    {
        Task<ICollection<T>> GetAsync();

        Task<T> GetAsync(Guid key);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);
    }
}