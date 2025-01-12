using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
[JsonConverter( typeof( JsonStringEnumConverter<Permission> ) )]
public enum Permission
{
    /// <summary>
    /// All permissions are granted
    /// </summary>
    [JsonStringEnumMemberName( "*" )]
    All = 1,

    /// <summary>
    /// List items is allowed
    /// </summary>
    [JsonStringEnumMemberName( "list" )]
    List,

    /// <summary>
    /// Download files is allowed
    /// </summary>
    [JsonStringEnumMemberName( "download" )]
    Download,

    /// <summary>
    /// Upload files is allowed
    /// </summary>
    [JsonStringEnumMemberName( "upload" )]
    Upload,

    /// <summary>
    /// Overwrite an existing file, while uploading, is allowed.
    /// Upload permission is required to allow file overwrite.
    /// </summary>
    [JsonStringEnumMemberName( "overwrite" )]
    Overwrite,

    /// <summary>
    /// Delete files or directories is allowed
    /// </summary>
    [JsonStringEnumMemberName( "delete" )]
    Delete,

    /// <summary>
    /// Delete files is allowed
    /// </summary>
    [JsonStringEnumMemberName( "delete_files" )]
    DeleteFiles,

    /// <summary>
    /// Delete directories is allowed
    /// </summary>
    [JsonStringEnumMemberName( "delete_dirs" )]
    DeleteDirectories,

    /// <summary>
    /// Rename files or directories is allowed
    /// </summary>
    [JsonStringEnumMemberName( "rename" )]
    Rename,

    /// <summary>
    /// Rename files is allowed
    /// </summary>
    [JsonStringEnumMemberName( "rename_files" )]
    RenameFiles,

    /// <summary>
    /// Rename directories is allowed
    /// </summary>
    [JsonStringEnumMemberName( "rename_dirs" )]
    RenameDirectories,

    /// <summary>
    /// Create directories is allowed
    /// </summary>
    [JsonStringEnumMemberName( "create_dirs" )]
    CreateDirectories,

    /// <summary>
    /// Create symbolic links is allowed
    /// </summary>
    [JsonStringEnumMemberName( "create_symlinks" )]
    CreateSymlinks,

    /// <summary>
    /// Changing file or directory permissions is allowed
    /// </summary>
    [JsonStringEnumMemberName( "chmod" )]
    ChangePermissions,

    /// <summary>
    /// Changing file or directory owner and group is allowed
    /// </summary>
    [JsonStringEnumMemberName( "chown" )]
    ChangeOwner,

    /// <summary>
    /// Changing file or directory access and modification time is allowed
    /// </summary>
    [JsonStringEnumMemberName( "chtimes" )]
    ChangeTimes,

    /// <summary>
    /// Copying files or directories is allowed
    /// </summary>
    [JsonStringEnumMemberName( "copy" )]
    Copy,
}