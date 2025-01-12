using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class AuthenticateResult
{
    /// <summary />
    [JsonPropertyName( "access_token" )]
    public string AccessToken { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "expires_at" )]
    public DateTime MomentExpiration { get; set; }
}