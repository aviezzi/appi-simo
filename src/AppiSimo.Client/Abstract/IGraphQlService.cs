namespace AppiSimo.Client.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGraphQlService<T>
        where T : class, IEntity, new()
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetOneAsync(Guid key);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}