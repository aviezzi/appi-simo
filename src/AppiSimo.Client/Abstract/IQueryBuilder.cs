namespace AppiSimo.Client.Abstract
{
    using GraphQL.Common.Request;
    using System;

    public interface IQueryBuilder<in T1, out T2>
        where T1 : IEntity
    {
        string Fields { get; }
        T2 BuildCreate(T1 entity);
        T2 BuildUpdate(T1 entity);
    }

    public interface IQueryBuilder<in T> : IQueryBuilder<T, string>
        where T : IEntity
    {
    }

    public interface IRequestBuilder<in T> : IQueryBuilder<T, (string name, GraphQLRequest request)>
        where T : IEntity
    {
        (string name, GraphQLRequest request) BuildGetAllQuery();
        (string name, GraphQLRequest request) BuildGetOne(Guid key);
    }
}