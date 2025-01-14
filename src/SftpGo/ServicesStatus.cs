using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class ServicesStatus
{
    /// <summary />
    [JsonPropertyName( "ssh" )]
    public SshServiceStatus? Ssh { get; set; }

    /// <summary />
    [JsonPropertyName( "ftp" )]
    public FtpServiceStatus? Ftp { get; set; }

    // TODO: Other properties
}


/// <summary />
public class SshServiceStatus
{
    /// <summary />
    [JsonPropertyName( "is_active" )]
    public bool IsActive { get; set; }

    /// <summary />
    [JsonPropertyName( "bindings" )]
    public List<SShBinding>? Bindings { get; set; }

    /// <summary />
    [JsonPropertyName( "ssh_commands" )]
    public List<string> SshCommands { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "host_keys" )]
    public List<SshHostKey> HostKeys { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "authentications" )]
    public List<string>? Authentications { get; set; }

    /// <summary />
    [JsonPropertyName( "macs" )]
    public List<string>? Macs { get; set; }

    /// <summary />
    [JsonPropertyName( "kex_algorithms" )]
    public List<string>? KexAlgorithms { get; set; }

    /// <summary />
    [JsonPropertyName( "ciphers" )]
    public List<string>? Ciphers { get; set; }

    /// <summary />
    [JsonPropertyName( "public_key_algorithms" )]
    public List<string>? PublicKeyAlgorithms { get; set; }
}


/// <summary />
public class SShBinding
{
    /// <summary />
    [JsonPropertyName( "address" )]
    public string Address { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "port" )]
    public int Port { get; set; }

    /// <summary />
    [JsonPropertyName( "apply_proxy_config" )]
    public bool ApplyProxyConfig { get; set; }
}


/// <summary />
public class SshHostKey
{
    /// <summary />
    [JsonPropertyName( "path" )]
    public string Path { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "fingerprint" )]
    public string Fingerprint { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "algorithms" )]
    public List<string> Algorithms { get; set; } = default!;
}


/// <summary />
public class FtpServiceStatus
{
    /// <summary />
    [JsonPropertyName( "is_active" )]
    public bool IsActive { get; set; }

    /// <summary />
    [JsonPropertyName( "bindings" )]
    public List<FtpBinding>? Bindings { get; set; }

    /// <summary />
    [JsonPropertyName( "passive_port_range" )]
    public FtpPortRange PassivePortRange { get; set; } = default!;
}


/// <summary />
public class FtpBinding
{
    // TODO:
}


/// <summary />
public class FtpPortRange
{
    /// <summary />
    [JsonPropertyName( "range" )]
    public int Start { get; set; }

    /// <summary />
    [JsonPropertyName( "end" )]
    public int End { get; set; }
}