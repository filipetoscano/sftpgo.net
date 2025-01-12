using System.Text.Json.Serialization;

namespace SftpGo;

[JsonConverter( typeof( JsonStringEnumConverter<AdminPermission> ) )]
public enum AdminPermission
{
    /// <summary>
    /// All permissions are granted
    /// </summary>
    [JsonStringEnumMemberName( "*" )]
    All = 1,
}