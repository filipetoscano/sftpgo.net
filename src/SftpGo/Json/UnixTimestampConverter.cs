using System.Text.Json;
using System.Text.Json.Serialization;

namespace SftpGo.Json;

/// <summary />
public class UnixTimestampConverter : JsonConverter<DateTime>
{
    /// <inheritdoc />
    public override DateTime Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        var int64 = reader.GetInt64();

        return DateTimeOffset.FromUnixTimeMilliseconds( int64 ).UtcDateTime;
    }


    /// <inheritdoc />
    public override void Write( Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options )
    {
        var dto = (DateTimeOffset) value;

        var int64 = dto.ToUnixTimeMilliseconds();

        writer.WriteNumberValue( int64 );
    }
}
