namespace AppiSimo.Client.Gateways
{
    using Abstract;
    using Model;

    public class CourtGateway : GraphQlGateway<Court>
    {
        public CourtGateway(string fields, IGraphQlService<Court> service)
            : base(fields, service)
        {
        }
    }
}