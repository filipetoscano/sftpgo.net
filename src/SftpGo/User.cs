using SftpGo.Json;
using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class User
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int Id { get; set; }

    /// <summary />
    [JsonPropertyName( "status" )]
    public UserStatus Status { get; set; }

    /// <summary />
    [JsonPropertyName( "username" )]
    public string Username { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "public_keys" )]
    public List<string>? PublicKeys { get; set; }

    /// <summary />
    [JsonPropertyName( "has_password" )]
    public bool HasPassword { get; set; }

    /// <summary />
    [JsonPropertyName( "home_dir" )]
    public string HomeDirectory { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "permissions" )]
    public Dictionary<string, List<Permission>> Permissions { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "filters" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public UserFilters? UserFilters { get; set; }

    /// <summary />
    [JsonPropertyName( "created_at" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime? MomentCreated { get; set; }

    /// <summary />
    [JsonPropertyName( "updated_at" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime? MomentUpdated { get; set; }

    /// <summary />
    [JsonPropertyName( "last_login" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime? MomentLastLogin { get; set; }
}


/// <summary />
public class UserFilters
{
    /// <summary>
    /// Allowed IP ranges, in CIDR notation.
    /// </summary>
    [JsonPropertyName( "allowed_ip" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public List<string>? AllowedIpRanges { get; set; }
}