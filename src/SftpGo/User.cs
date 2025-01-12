using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class User
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public string Id { get; set; } = default!;

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
}