namespace AppiSimo.Client.Abstract
{
    public interface ITypeConverter<T>
    {
        string FormatValueAsString(T value);
        bool TryParseValueFromString(string value, out T result);
    }
}