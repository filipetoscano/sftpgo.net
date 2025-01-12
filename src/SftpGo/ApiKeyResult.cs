using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class ApiKeyResult
{
    /// <summary />
    [JsonPropertyName( "key" )]
    public string Key { get; set; } = default!;
}