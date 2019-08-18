namespace AppiSimo.Client.Converters
{
    using AppiSimo.Client.Abstract;
    using NodaTime;

    public class ConvertersMap : IConverters
    {
        public ITypeConverter<LocalTime?> LocalTime { get; } = new LocalTimeConverter();
        public ITypeConverter<LocalDate> LocalDate { get; } = new LocalDateConverter();
    }
}