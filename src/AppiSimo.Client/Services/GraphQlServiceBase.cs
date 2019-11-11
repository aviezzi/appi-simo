namespace AppiSimo.Client.Services
{
    using Abstract;
    using Builders;
    using Extensions;
    using GraphQL.Common.Request;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class GraphQlServiceBase<T> : IGraphQlService<T>
        where T : Entity, new()
    {
        readonly GraphQlExtensions _extensions;
        readonly IFactoryAsync _factoryAsync;

        protected abstract string Fields { get; }

        protected GraphQlServiceBase(IFactoryAsync factoryAsync, GraphQlExtensions extensions)
        {
            _factoryAsync = factoryAsync;
            _extensions = extensions;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            var (name, request) = GraphQlQueryBuilder.BuildGetAllQuery<T>(Fields);
            var client = await _factoryAsync.Create();

            var res = await client.SendQueryAsync(request);
            return _extensions.ExtGetDataFieldAs2<T>(res, name).ToList();
        }

        public async Task<T> GetOneAsync(Guid key)
        {
            var (name, request) = GraphQlQueryBuilder.BuildGetOne<T>(Fields, key);
            var client = await _factoryAsync.Create();

            var res = await client.SendQueryAsync(request);
            return _extensions.ExtGetDataFieldAs<T>(res, name);
        }

        public Task<T> CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            var request = GraphQlQueryBuilder.BuildCreate(CreateQuery, Fields, entity);

            return MutateAsync(request);
        }

        public Task<T> UpdateAsync(T entity)
        {
            var request = GraphQlQueryBuilder.BuildUpdate(UpdateQuery, Fields, entity);

            return MutateAsync(request);
        }

        protected abstract Func<T, string> CreateQuery { get; }
        protected abstract Func<T, string> UpdateQuery { get; }

        async Task<T> MutateAsync((string, GraphQLRequest) graphQlRequest)
        {
            var (name, request) = graphQlRequest;

            var client = await _factoryAsync.Create();
            var res = await client.SendMutationAsync(request);

            return _extensions.ExtGetDataFieldAs<T>(res, name);
        }
    }
}