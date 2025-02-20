using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
[JsonConverter( typeof( JsonStringEnumConverter<FilesystemEvents> ) )]
public enum FilesystemEvents
{
    /// <summary />
    [JsonStringEnumMemberName( "upload" )]
    Upload,

    /// <summary />
    [JsonStringEnumMemberName( "download" )]
    Download,

    /// <summary />
    [JsonStringEnumMemberName( "delete" )]
    Delete,

    /// <summary />
    [JsonStringEnumMemberName( "rename" )]
    Rename,

    /// <summary />
    [JsonStringEnumMemberName( "mkdir" )]
    MakeDirectory,

    /// <summary />
    [JsonStringEnumMemberName( "rmdir" )]
    RemoveDirectory,

    /// <summary />
    [JsonStringEnumMemberName( "copy" )]
    Copy,

    /// <summary />
    [JsonStringEnumMemberName( "ssh_cmd" )]
    SshCommand,

    /// <summary />
    [JsonStringEnumMemberName( "pre-upload" )]
    PreUpload,

    /// <summary />
    [JsonStringEnumMemberName( "pre-download" )]
    PreDownload,

    /// <summary />
    [JsonStringEnumMemberName( "pre-delete" )]
    PreDelete,

    /// <summary />
    [JsonStringEnumMemberName( "first-upload" )]
    FirstUpload,

    /// <summary />
    [JsonStringEnumMemberName( "first-download" )]
    FirstDownload,
}