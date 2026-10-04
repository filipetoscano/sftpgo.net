using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace SftpGo;

public partial class SftpGoClient
{
    /// <inheritdoc />
    public async Task<SftpGoResponse<List<Group>>> GroupListAsync()
    {
        var p = new Pagination()
        {
            Offset = 0,
            Limit = 100,
            Order = PaginationOrder.Ascending,
        };

        var groups = new List<Group>();

        while ( true )
        {
            var resp = await GroupListAsync( p );

            if ( resp.Content?.Count() == 0 )
                break;

            groups.AddRange( resp.Content! );

            if ( resp.Content?.Count() < p.Limit )
                break;

            p.Offset += p.Limit;
        }

        return new SftpGoResponse<List<Group>>( groups );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<List<Group>>> GroupListAsync( Pagination pagination )
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

        string uri = QueryHelpers.AddQueryString( "/api/v2/groups", qs );
        var req = new HttpRequestMessage( HttpMethod.Get, uri );

        return Execute<List<Group>>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<Group>> GroupCreateAsync( Group group )
    {
        var req = new HttpRequestMessage( HttpMethod.Post, "/api/v2/groups" );
        req.Content = JsonContent.Create( group );

        return Execute<Group>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<Group>> GroupGetAsync( string name )
    {
        var req = new HttpRequestMessage( HttpMethod.Get, $"/api/v2/groups/{name}" );

        return Execute<Group>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> GroupUpdateAsync( Group group )
    {
        var req = new HttpRequestMessage( HttpMethod.Put, $"/api/v2/groups/{group.Name}" );
        req.Content = JsonContent.Create( group );

        return Execute<NullResponse>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> GroupDeleteAsync( string name )
    {
        var req = new HttpRequestMessage( HttpMethod.Delete, $"/api/v2/groups/{name}" );

        return Execute<NullResponse>( req );
    }
}