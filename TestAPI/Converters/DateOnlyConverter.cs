using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestAPI.Converters;

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    private const string _format = "dd.MM.yyyy";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!, _format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format, CultureInfo.InvariantCulture));
    }
}
