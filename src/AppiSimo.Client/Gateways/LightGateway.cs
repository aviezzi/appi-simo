namespace AppiSimo.Client.Gateways
{
    using Abstract;
    using Model;

    public class LightGateway : GraphQlGateway<Light>
    {
        public LightGateway(string fields, IGraphQlService<Light> service)
            : base(fields, service)
        {
        }
    }
}