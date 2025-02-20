using System.Net.Http.Json;

namespace SftpGo;

public partial class SftpGoClient
{
    /// <inheritdoc />
    public Task<SftpGoResponse<List<EventAction>>> EventActionListAsync()
    {
        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/eventactions" );

        return Execute<List<EventAction>>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<EventAction>> EventActionCreateAsync( EventAction action )
    {
        var req = new HttpRequestMessage( HttpMethod.Post, "/api/v2/eventactions" );
        req.Content = JsonContent.Create( action );

        return Execute<EventAction>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<EventAction>> EventActionGetAsync( string actionName )
    {
        var req = new HttpRequestMessage( HttpMethod.Get, $"/api/v2/eventactions/{actionName}" );

        return Execute<EventAction>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> EventActionUpdateAsync( EventAction action )
    {
        var req = new HttpRequestMessage( HttpMethod.Put, $"/api/v2/eventactions/{action.Name}" );
        req.Content = JsonContent.Create( action );

        return Execute<NullResponse>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> EventActionDeleteAsync( string actionName )
    {
        var req = new HttpRequestMessage( HttpMethod.Delete, $"/api/v2/eventactions/{actionName}" );

        return Execute<NullResponse>( req );
    }
}