using SftpGo.Json;
using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class VirtualFolder
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public required int Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public required string Name { get; set; }

    /// <summary />
    [JsonPropertyName( "mapped_path" )]
    public string? MappedPath { get; set; }

    /// <summary />
    [JsonPropertyName( "description" )]
    public string? Description { get; set; }

    /// <summary />
    [JsonPropertyName( "used_quota_size" )]
    public long? UsedQuotaSize { get; set; }

    /// <summary />
    [JsonPropertyName( "used_quota_files" )]
    public long? UsedQuotaFiles { get; set; }

    /// <summary />
    [JsonPropertyName( "last_quota_update" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public long? LastQuotaUpdate { get; set; }

    /// <summary />
    [JsonPropertyName( "users" )]
    public List<string>? Users { get; set; }

    /// <summary />
    [JsonPropertyName( "groups" )]
    public List<string>? Groups { get; set; }

    /// <summary />
    [JsonPropertyName( "filesystem" )]
    public Filesystem? Filesystem { get; set; }
}