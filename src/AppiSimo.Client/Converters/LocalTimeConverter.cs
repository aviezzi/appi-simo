using AppiSimo.Client.Abstract;
using NodaTime;
using NodaTime.Text;

namespace AppiSimo.Client.Converters
{
    public class LocalTimeConverter : ITypeConverter<LocalTime>
    {
        static readonly LocalTimePattern Pattern = LocalTimePattern.CreateWithInvariantCulture("HH:mm");

        public string FormatValueAsString(LocalTime value) => Pattern.Format(value);

        public bool TryParseValueFromString(string value, out LocalTime result) => Pattern.Parse(value).TryGetValue(default, out result);
    }
}