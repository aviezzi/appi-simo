namespace AppiSimo.Client.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    public interface ILightService : IBaseGraphQlService<Light>
    {
        Task<ICollection<Light>> GetAsync();

        Task<Light> GetAsync(Guid key);
    }
}