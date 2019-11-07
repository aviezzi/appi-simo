namespace AppiSimo.Client.Services
{
    using Abstract;
    using Extensions;
    using GraphQL.Common.Request;
    using Model;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GraphQlService<T> : IGraphQlService<T>
        where T : Entity, new()
    {
        readonly IRequestBuilder<T> _builder;
        readonly IFactoryAsync _factoryAsync;
        readonly JsonSerializerSettings _jsonSettings;

        public GraphQlService(IRequestBuilder<T> builder, IFactoryAsync factoryAsync, JsonSerializerSettings jsonSettings)
        {
            _builder = builder;
            _factoryAsync = factoryAsync;
            _jsonSettings = jsonSettings;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            var (name, request) = _builder.BuildGetAllQuery();
            var client = await _factoryAsync.Create();

            var res = await client.SendQueryAsync(request);
            return res.ExtGetDataFieldAs2<ICollection<T>>(name, _jsonSettings);
        }

        public async Task<T> GetOneAsync(Guid key)
        {
            var (name, request) = _builder.BuildGetOne(key);
            var client = await _factoryAsync.Create();

            var res = await client.SendQueryAsync(request);
            return res.ExtGetDataFieldAs<T>(name, _jsonSettings);
        }
        
        public Task<T> CreateAsync(T entity)
        {
            var (name, request) = _builder.BuildCreate(entity);
            
            return MutateAsync(name, request);
        }

        public Task<T> UpdateAsync(T entity)
        {
            var (name, request) = _builder.BuildUpdate(entity);

            return MutateAsync(name, request);
        }

        async Task<T> MutateAsync(string name, GraphQLRequest request)
        {
            var client = await _factoryAsync.Create();
            var res = await client.SendMutationAsync(request);

            return res.ExtGetDataFieldAs<T>(name, _jsonSettings);
        }
    }
}