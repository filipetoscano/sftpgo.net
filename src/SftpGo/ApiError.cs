using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class ApiError
{
    /// <summary />
    [JsonPropertyName( "error" )]
    public string Error { get; set; } = "";

    /// <summary />
    [JsonPropertyName( "message" )]
    public string Message { get; set; } = "";
}