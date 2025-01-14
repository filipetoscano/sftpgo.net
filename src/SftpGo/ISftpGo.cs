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

    Task<SftpGoResponse<NullResponse>> ApiKeyDelete( string keyId );


    Task<SftpGoResponse<Version>> VersionGet();

    Task<SftpGoResponse<ServicesStatus>> StatusGet();


    Task<SftpGoResponse<List<User>>> UserList( Pagination? pagination = null );

    Task<SftpGoResponse<User>> UserCreate( User user );

    Task<SftpGoResponse<User>> UserGet( string username );

    Task<SftpGoResponse<NullResponse>> UserUpdate( User user );

    Task<SftpGoResponse<NullResponse>> UserDelete( string username );
}