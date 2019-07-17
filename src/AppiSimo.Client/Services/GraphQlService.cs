namespace AppiSimo.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abstract;
    using Extensions;
    using GraphQL.Client.Http;
    using GraphQL.Common.Request;
    using Model;

    public class GraphQlService<T> : IGraphQlService<T>
        where T : Entity, new()
    {
        readonly GraphQLHttpClient _client;

        public GraphQlService(GraphQLHttpClient client)
        {
            _client = client;
        }

        public async Task<ICollection<T>> GetAll(string query, string name)
        {
            var req = new GraphQLRequest
            {
                Query = query
            };

            var res = await _client.SendQueryAsync(req);
            return res.GetDataFieldAs<ConnectionGraphQl<T>>(name).Nodes;
        }

        public async Task<T> GetOne(string query, string name, Guid key)
        {
            var id = key;

            var req = new GraphQLRequest
            {
                Query = query,
                Variables = new { id }
            };

            var res = await _client.SendQueryAsync(req);
            return res.ExtGetDataFieldAs<T>(name);
        }

        public async Task<T> Mutate(string query, string name, object variables)
        {
            var req = new GraphQLRequest
            {
                Query = query,
                Variables = variables
            };

            var res = await _client.SendQueryAsync(req);
            return res.ExtGetDataFieldAs<T>(name);
        }
    }
}