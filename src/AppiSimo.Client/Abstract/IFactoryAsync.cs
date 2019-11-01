namespace AppiSimo.Client.Abstract
{
    using GraphQL.Client.Http;
    using System.Threading.Tasks;

    public interface IFactoryAsync
    {
        Task<GraphQLHttpClient> Create();
    }
}