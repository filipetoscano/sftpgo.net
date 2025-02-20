using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace SftpGo;

public partial class SftpGoClient : ISftpGo
{
    /// <inheritdoc />
    public async Task<SftpGoResponse<List<User>>> UserList()
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
            var resp = await UserList( p );

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
    public Task<SftpGoResponse<List<User>>> UserList( Pagination pagination )
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
    public Task<SftpGoResponse<User>> UserCreate( User user )
    {
        var req = new HttpRequestMessage( HttpMethod.Post, "/api/v2/users" );
        req.Content = JsonContent.Create( user );

        return Execute<User>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<User>> UserGet( string username )
    {
        var req = new HttpRequestMessage( HttpMethod.Get, $"/api/v2/users/{username}" );

        return Execute<User>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> UserUpdate( User user )
    {
        var req = new HttpRequestMessage( HttpMethod.Put, $"/api/v2/users/{user.Username}" );
        req.Content = JsonContent.Create( user );

        return Execute<NullResponse>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> UserDelete( string username )
    {
        var req = new HttpRequestMessage( HttpMethod.Delete, $"/api/v2/users/{username}" );

        return Execute<NullResponse>( req );
    }
}