using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class EventRule
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "status" )]
    public EventRuleStatus Status { get; set; }

    /// <summary />
    [JsonPropertyName( "description" )]
    public string? Description { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "trigger" )]
    public EventTrigger Trigger { get; set; }

    /// <summary />
    [JsonPropertyName( "conditions" )]
    public EventRuleConditions Conditions { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "actions" )]
    public List<EventRuleActions> Actions { get; set; } = default!;
}


/// <summary />
public class EventRuleConditions
{
    /// <summary />
    [JsonPropertyName( "fs_events" )]
    public List<FilesystemEvents>? Filesystem { get; set; }
}


/// <summary />
public class EventRuleActions
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "order" )]
    public int Order { get; set; }

    /// <summary />
    [JsonPropertyName( "relation_options" )]
    public EventRuleActionsRelationOptions RelationOptions { get; set; } = default!;
}


/// <summary />
public class EventRuleActionsRelationOptions
{
    /// <summary />
    [JsonPropertyName( "is_failure_action" )]
    public bool IsFailureAction { get; set; }

    /// <summary />
    [JsonPropertyName( "stop_on_failure" )]
    public bool StopOnFailure { get; set; }

    /// <summary />
    [JsonPropertyName( "execute_sync" )]
    public bool ExecuteSync { get; set; }
}


/// <summary />
public enum EventTrigger
{
    /// <summary />
    Filesystem = 1,

    /// <summary />
    Provider = 2,

    /// <summary />
    Schedule = 3,

    /// <summary />
    IpBlocked = 4,

    /// <summary />
    CertificateRenewal = 5,

    /// <summary />
    OnDemand = 6,

    /// <summary />
    IdpLogin = 7,
}


/// <summary />
public enum EventRuleStatus
{
    /// <summary />
    Disabled = 0,

    /// <summary />
    Enabled = 1,
}