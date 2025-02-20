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
public class EventActionOptions
{
    /// <summary />
    [JsonPropertyName( "http_config" )]
    public HttpActionConfig HttpConfig { get; set; } = default!;
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
    public List<KeyValue>? Headers { get; set; }

    /// <summary />
    [JsonPropertyName( "query_parameters" )]
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
}