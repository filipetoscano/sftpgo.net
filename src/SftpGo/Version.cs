using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class Version
{
    /// <summary />
    [JsonPropertyName( "version" )]
    public string VersionNumber { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "buid_date" )]
    public DateTime BuildDate { get; set; }

    /// <summary />
    [JsonPropertyName( "commit_hash" )]
    public string CommitHash { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "features" )]
    public List<string>? Features { get; set; }
}
