using NodaTime;

namespace AppiSimo.Client.Abstract
{
    public interface IConverters 
    {
        ITypeConverter<LocalTime> LocalTime { get; }
    }
}