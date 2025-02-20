using System.Text.Json;
using System.Text.Json.Serialization;

namespace SftpGo.Json;

/// <inheritdoc />
public class EventActionOptionsConverter : JsonConverter<EventActionOptions>
{
    /// <inheritdoc />
    public EventActionOptionsConverter()
    {
    }


    /// <inheritdoc />
    public override EventActionOptions? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType == JsonTokenType.Null )
            return null;

        if ( reader.TokenType != JsonTokenType.StartObject )
            throw new InvalidOperationException();

        var obj = new EventActionOptions();

        while ( reader.Read() )
        {
            if ( reader.TokenType == JsonTokenType.EndObject )
                break;

            if ( reader.TokenType != JsonTokenType.PropertyName )
                throw new InvalidOperationException();


            var propName = reader.GetString();

            switch ( propName )
            {
                case "http_config":
                    obj.HttpConfig = JsonSerializer.Deserialize<HttpActionConfig>( ref reader, options );

                    if ( obj.HttpConfig?.Endpoint == null )
                        obj.HttpConfig = null;

                    break;


                case "cmd_config":
                    obj.CommandConfig = JsonSerializer.Deserialize<CommandActionConfig>( ref reader, options );

                    if ( obj.CommandConfig?.Command == null )
                        obj.CommandConfig = null;

                    break;


                default:
                    JsonSerializer.Deserialize<JsonDocument>( ref reader, options );
                    break;
            }
        }

        return obj;
    }


    /// <inheritdoc />
    public override void Write( Utf8JsonWriter writer, EventActionOptions value, JsonSerializerOptions options )
    {
        writer.WriteStartObject();

        if ( value.HttpConfig?.Endpoint != null )
        {
            writer.WritePropertyName( "http_config" );
            JsonSerializer.Serialize( writer, value.HttpConfig!, options );
        }

        if ( value.CommandConfig?.Command != null )
        {
            writer.WritePropertyName( "cmd_config" );
            JsonSerializer.Serialize( writer, value.CommandConfig!, options );
        }

        writer.WriteEndObject();
    }
}
