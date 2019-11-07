namespace AppiSimo.Client.Converters
{
    using AppiSimo.Client.Abstract;
    using NodaTime;
    using NodaTime.Text;

    public class LocalTimeConverter : ITypeConverter<LocalTime>
    {
        LocalTimePattern _pattern = LocalTimePattern.CreateWithInvariantCulture("HH:mm");

        public string Pattern
        {
            get => _pattern.PatternText;
            set => _pattern = LocalTimePattern.CreateWithInvariantCulture(value);
        }

        public string FormatValueAsString(LocalTime value) =>
            _pattern.Format(value);

        public bool TryParseValueFromString(string value, out LocalTime result) => 
            _pattern.Parse(value).TryGetValue(default, out result);
    }
}