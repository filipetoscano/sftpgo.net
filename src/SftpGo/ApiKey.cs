using SftpGo.Json;
using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class ApiKey
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public string Id { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "description" )]
    public string Description { get; set; } = default!;

    /// <summary />
    public ApiKeyScope Scope { get; set; }

    /// <summary />
    [JsonPropertyName( "created_at" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime MomentCreated { get; set; }

    /// <summary />
    [JsonPropertyName( "updated_at" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime MomentUpdated { get; set; }

    /// <summary />
    [JsonPropertyName( "last_use_at" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime? MomentLastUsed { get; set; }

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


/// <summary />
public enum ApiKeyScope
{
    /// <summary />
    Admin = 1,

    /// <summary />
    User = 2,
}