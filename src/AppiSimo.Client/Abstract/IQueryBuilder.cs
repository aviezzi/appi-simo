namespace AppiSimo.Client.Abstract
{
    public interface IQueryBuilder<in T1, out T2>
        where T1 : IEntity
    {
        string Fields { get; }
        T2 BuildCreateQuery(T1 entity);
        T2 BuildUpdateQuery(T1 entity);
    }

    public interface IStringQueryBuilder<in T> : IQueryBuilder<T, string>
        where T : IEntity
    {
    }

    public interface IObjectQueryBuilder<in T> : IQueryBuilder<T, object>
        where T : IEntity
    {
    }
}