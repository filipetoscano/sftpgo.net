using SftpGo.Json;
using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class ApiKeyData
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "description" )]
    public string Description { get; set; } = default!;

    /// <summary />
    public ApiKeyScope Scope { get; set; }

    /// <summary />
    [JsonPropertyName( "expires_at" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime? MomentExpiration { get; set; }

    /// <summary />
    [JsonPropertyName( "user" )]
    public string? ImpersonateUser { get; set; }

    /// <summary />
    [JsonPropertyName( "admin" )]
    public string? ImpersonateAdmin { get; set; }
}