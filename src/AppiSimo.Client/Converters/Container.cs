using AppiSimo.Client.Abstract;
using NodaTime;

namespace AppiSimo.Client.Converters
{
    public class DefaultConverters : IConverters 
    {
        public ITypeConverter<LocalTime> LocalTime { get; } =  new LocalTimeConverter();
    }
}