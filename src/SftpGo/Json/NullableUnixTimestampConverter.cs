using System.Text.Json;
using System.Text.Json.Serialization;

namespace SftpGo.Json;

/// <summary />
public class NullableUnixTimestampConverter : JsonConverter<DateTime?>
{
    /// <inheritdoc />
    public override DateTime? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public override void Write( Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }
}
