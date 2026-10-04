using SftpGo.Json;
using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class UserSettings
{
    /// <summary />
    [JsonPropertyName( "home_dir" )]
    public string? HomeDirectory { get; set; }

    /// <summary />
    [JsonPropertyName( "permissions" )]
    public Dictionary<string, List<Permission>>? Permissions { get; set; }

    /// <summary />
    [JsonPropertyName( "upload_bandwidth" )]
    public long? UploadBandwidth { get; set; }

    /// <summary />
    [JsonPropertyName( "download_bandwidth" )]
    public long? DownloadBandwidth { get; set; }

    /// <summary />
    [JsonPropertyName( "upload_data_transfer" )]
    public long? UploadDataTransfer { get; set; }

    /// <summary />
    [JsonPropertyName( "download_data_transfer" )]
    public long? DownloadDataTransfer { get; set; }

    /// <summary />
    [JsonPropertyName( "total_data_transfer" )]
    public long? TotalDataTransfer { get; set; }

    /// <summary />
    [JsonPropertyName( "expires_in" )]
    [JsonConverter( typeof( UnixTimestampConverter ) )]
    public DateTime? MomentExpiration { get; set; }

    /// <summary />
    [JsonPropertyName( "filters" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public UserFilters? UserFilters { get; set; }
}