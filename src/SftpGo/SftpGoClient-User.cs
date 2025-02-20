using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace SftpGo;

public partial class SftpGoClient
{
    /// <inheritdoc />
    public async Task<SftpGoResponse<List<User>>> UserListAsync()
    {
        var p = new Pagination()
        {
            Offset = 0,
            Limit = 100,
            Order = PaginationOrder.Ascending,
        };

        var users = new List<User>();

        while ( true )
        {
            var resp = await UserListAsync( p );

            if ( resp.Content?.Count() == 0 )
                break;

            users.AddRange( resp.Content! );

            if ( resp.Content?.Count() < p.Limit )
                break;

            p.Offset += p.Limit;
        }

        return new SftpGoResponse<List<User>>( users );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<List<User>>> UserListAsync( Pagination pagination )
    {
        var qs = new Dictionary<string, string?>();

        if ( pagination.Limit != null )
            qs.Add( "limit", pagination.Limit.ToString() );

        if ( pagination.Offset != null )
            qs.Add( "offset", pagination.Offset.ToString() );

        if ( pagination.Order == PaginationOrder.Ascending )
            qs.Add( "order", "ASC" );

        if ( pagination.Order == PaginationOrder.Descending )
            qs.Add( "order", "DESC" );

        string uri = QueryHelpers.AddQueryString( "/api/v2/users", qs );
        var req = new HttpRequestMessage( HttpMethod.Get, uri );

        return Execute<List<User>>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<User>> UserCreateAsync( User user )
    {
        var req = new HttpRequestMessage( HttpMethod.Post, "/api/v2/users" );
        req.Content = JsonContent.Create( user );

        return Execute<User>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<User>> UserGetAsync( string username )
    {
        var req = new HttpRequestMessage( HttpMethod.Get, $"/api/v2/users/{username}" );

        return Execute<User>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> UserUpdateAsync( User user )
    {
        var req = new HttpRequestMessage( HttpMethod.Put, $"/api/v2/users/{user.Username}" );
        req.Content = JsonContent.Create( user );

        return Execute<NullResponse>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> UserDeleteAsync( string username )
    {
        var req = new HttpRequestMessage( HttpMethod.Delete, $"/api/v2/users/{username}" );

        return Execute<NullResponse>( req );
    }
}