namespace AppiSimo.Client.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseGraphQlService<T>
    {
        Task<ICollection<T>> GetAll(string query, string name);
        Task<T> GetOne(string query, string name, Guid key);
        Task<T> Mutate(string query, string name, object variables);
    }
}