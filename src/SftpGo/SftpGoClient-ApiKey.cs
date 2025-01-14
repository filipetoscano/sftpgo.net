﻿using System.Net.Http.Json;

namespace SftpGo;

public partial class SftpGoClient : ISftpGo
{
    /// <inheritdoc />
    public Task<SftpGoResponse<List<ApiKey>>> ApiKeyList()
    {
        RequireAuthToken();

        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/apikeys" );

        return Execute<List<ApiKey>>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<ApiKeyResult>> ApiKeyCreate( ApiKeyData data )
    {
        RequireAuthToken();

        var req = new HttpRequestMessage( HttpMethod.Post, "/api/v2/apikeys" );
        req.Content = JsonContent.Create( data );

        return Execute<ApiKeyResult>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> ApiKeyDelete( string keyId )
    {
        RequireAuthToken();

        var req = new HttpRequestMessage( HttpMethod.Delete, $"/api/v2/apikeys/{keyId}" );

        return Execute<NullResponse>( req );
    }
}