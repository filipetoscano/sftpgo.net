namespace SftpGo;

/// <summary>
/// Client for SftpGo API.
/// </summary>
public interface ISftpGo
{
    void UseAuthToken( string authToken );

    void UseApiKey( string apikey );

    Task<SftpGoResponse<AuthenticateResult>> Authenticate( AuthenticateData data );

    Task<SftpGoResponse<List<ApiKey>>> ApiKeyList();

    Task<SftpGoResponse<ApiKeyResult>> ApiKeyCreate( ApiKeyData data );

    Task<SftpGoResponse<List<User>>> UserList();

    Task<SftpGoResponse<User>> UserCreate( User user );

    Task<SftpGoResponse<User>> UserGet( string username );

    Task<SftpGoResponse<NullResponse>> UserUpdate( User user );

    Task<SftpGoResponse<NullResponse>> UserDelete( string username );
}