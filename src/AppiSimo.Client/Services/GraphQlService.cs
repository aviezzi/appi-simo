namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using GraphQL.Common.Request;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GraphQlService<T> : IGraphQlService<T>
        where T : Entity, new()
    {
        readonly IFactoryAsync _factoryAsync;

        public GraphQlService(IFactoryAsync factoryAsync)
        {
            _factoryAsync = factoryAsync;
        }

        public async Task<ICollection<T>> GetAll(string query, string name)
        {
            var req = new GraphQLRequest
            {
                Query = query
            };

            var client = await _factoryAsync.Create();

            var res = await client.SendQueryAsync(req);
            return res.GetDataFieldAs<ICollection<T>>(name);
        }

        public async Task<T> GetOne(string query, string name, Guid key)
        {
            var id = key;

            var req = new GraphQLRequest
            {
                Query = query,
                Variables = new {id}
            };

            var client = await _factoryAsync.Create();
            var res = await client.SendQueryAsync(req);

            return res.ExtGetDataFieldAs<T>(name);
        }

        public async Task<T> Mutate(string query, string name, object variables)
        {
            var req = new GraphQLRequest
            {
                Query = query,
                Variables = variables
            };

            var client = await _factoryAsync.Create();
            var res = await client.SendMutationAsync(req);

            return res.ExtGetDataFieldAs<T>(name);
        }
    }
}