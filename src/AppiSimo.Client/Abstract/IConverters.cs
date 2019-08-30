namespace AppiSimo.Client.Abstract
{
    using NodaTime;

    public interface IConverters
    {
        ITypeConverter<LocalTime> LocalTime { get; }
        ITypeConverter<LocalDate> LocalDate { get; }
    }
}