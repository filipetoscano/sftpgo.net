using SftpGo.Json;
using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class EventAction
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "description" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? Description { get; set; }

    /// <summary />
    [JsonPropertyName( "type" )]
    public EventActionType Type { get; set; }

    /// <summary />
    [JsonPropertyName( "options" )]
    public EventActionOptions Options { get; set; } = default!;
}


/// <summary />
[JsonConverter( typeof( EventActionOptionsConverter ) )]
public class EventActionOptions
{
    /// <summary />
    [JsonPropertyName( "http_config" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public HttpActionConfig? HttpConfig { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "cmd_config" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public CommandActionConfig? CommandConfig { get; set; } = default!;
}


/// <summary />
public class HttpActionConfig
{
    /// <summary />
    [JsonPropertyName( "method" )]
    public HttpActionMethod Method { get; set; }

    /// <summary />
    [JsonPropertyName( "endpoint" )]
    public string Endpoint { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "headers" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public List<KeyValue>? Headers { get; set; }

    /// <summary />
    [JsonPropertyName( "query_parameters" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public List<KeyValue>? Query { get; set; }

    /// <summary />
    [JsonPropertyName( "timeout" )]
    public int Timeout { get; set; }

    /// <summary />
    [JsonPropertyName( "skip_tls_verify" )]
    public bool SkipTlsVerify { get; set; }

    /// <summary />
    [JsonPropertyName( "body" )]
    public string Body { get; set; } = default!;
}


/// <summary />
public class CommandActionConfig
{
    /// <summary />
    [JsonPropertyName( "cmd" )]
    public string Command { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "args" )]
    public List<string>? Arguments { get; set; }

    /// <summary />
    [JsonPropertyName( "timeout" )]
    public int Timeout { get; set; }

    /// <summary />
    [JsonPropertyName( "env_vars" )]
    public List<KeyValue>? EnvironmentVariables { get; set; }
}


/// <summary />
public class KeyValue
{
    /// <summary />
    [JsonPropertyName( "key" )]
    public string Key { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "value" )]
    public string Value { get; set; } = default!;
}


/// <summary />
[JsonConverter( typeof( JsonStringEnumConverter<HttpActionMethod> ) )]
public enum HttpActionMethod
{
    /// <summary />
    [JsonStringEnumMemberName( "GET" )]
    Get,

    /// <summary />
    [JsonStringEnumMemberName( "POST" )]
    Post,

    /// <summary />
    [JsonStringEnumMemberName( "PUT" )]
    Put,

    /// <summary />
    [JsonStringEnumMemberName( "DELETE" )]
    Delete,
}


/// <summary />
public enum EventActionType
{
    /// <summary />
    Http = 1,

    /// <summary />
    Command = 2,

    /// <summary />
    Email = 3,

    /// <summary />
    Backup = 4,

    /// <summary />
    UserQuotaReset = 5,

    /// <summary />
    FolderQuotaReset = 6,

    /// <summary />
    TransferQuotaReset = 7,

    /// <summary />
    DataRetentionCheck = 8,

    /// <summary />
    Filesystem = 9,

    /// <summary />
    PasswordExpirationCheck = 11,

    /// <summary />
    UserExpirationCheck = 12,

    /// <summary />
    IdpAccountCheck = 13,

    /// <summary />
    UserInactivityCheck = 14,

    /// <summary />
    LogFileRotate = 15,
}