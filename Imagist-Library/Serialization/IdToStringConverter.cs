using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagist_Library.Serialization;

public class IdToStringConverter : JsonConverter<long>
{


    public override bool CanConvert(Type objectType)
    {
        return typeof(System.Int64).Equals(objectType);
    }

    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return long.Parse(reader.GetString()??"0");
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
    
}