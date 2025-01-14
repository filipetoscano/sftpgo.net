namespace SftpGo;

public partial class SftpGoClient : ISftpGo
{
    /// <inheritdoc />
    public Task<SftpGoResponse<Version>> VersionGet()
    {
        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/version" );

        return Execute<Version>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<ServicesStatus>> StatusGet()
    {
        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/status" );

        return Execute<ServicesStatus>( req );
    }
}