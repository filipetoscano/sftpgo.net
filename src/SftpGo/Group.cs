using SftpGo.Json;
using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class Group
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public required int Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public required string Name { get; set; }

    /// <summary />
    [JsonPropertyName( "description" )]
    public string? Description { get; set; }

    /// <summary />
    [JsonPropertyName( "created_at" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime? MomentCreated { get; set; }

    /// <summary />
    [JsonPropertyName( "updated_at" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime? MomentUpdated { get; set; }

    /// <summary />
    [JsonPropertyName( "user_settings" )]
    public UserSettings? UserSettings { get; set; }

    /// <summary />
    [JsonPropertyName( "virtual_folders" )]
    public List<VirtualFolder>? VirtualFolders { get; set; }

    /// <summary />
    [JsonPropertyName( "filesystem" )]
    public Filesystem? Filesystem { get; set; }

    /// <summary />
    [JsonPropertyName( "users" )]
    public List<string>? Users { get; set; }

    /// <summary />
    [JsonPropertyName( "admins" )]
    public List<string>? Admins { get; set; }

    /// <summary />
    [JsonPropertyName( "role" )]
    public string? Role { get; set; }
}