namespace AppiSimo.Client.Gateways
{
    using Abstract;
    using Model;

    public class HeatGateway : GraphQlGateway<Heat>
    {
        public HeatGateway(string fields, IGraphQlService<Heat> service)
            : base(fields, service)
        {
        }
    }
}