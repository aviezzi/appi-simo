namespace AppiSimo.Client.Converters
{
    using AppiSimo.Client.Abstract;
    using NodaTime;
    using NodaTime.Text;

    public class LocalTimeConverter : ITypeConverter<LocalTime?>
    {
        LocalTimePattern _pattern = LocalTimePattern.CreateWithInvariantCulture("HH:mm");

        public string Pattern
        {
            get => _pattern.PatternText;
            set => _pattern = LocalTimePattern.CreateWithInvariantCulture(value);
        }

        public string FormatValueAsString(LocalTime? value) =>
            value.HasValue ? _pattern.Format((LocalTime) value) : string.Empty;

        public bool TryParseValueFromString(string value, out LocalTime? result)
        {
            var success = _pattern.Parse(value).TryGetValue(default, out var r);
            result = r;

            return success;
        }
    }
}