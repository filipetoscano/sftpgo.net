using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SftpGo;

/// <summary />
public class SftpGoClient : ISftpGo
{
    private readonly HttpClient _http;

    /// <summary />
    public SftpGoClient( HttpClient httpClient )
    {
        _http = httpClient;

        _http.DefaultRequestHeaders.Add( "Content-Type", "application /json" );
    }


    /// <summary />
    public void UseAuthToken( string authToken )
    {
        _http.DefaultRequestHeaders.Remove( "X-SFTPGO-API-KEY" );
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", authToken );
    }


    /// <summary />
    public void UseApiKey( string key )
    {
        _http.DefaultRequestHeaders.Authorization = null;
        _http.DefaultRequestHeaders.Add( "X-SFTPGO-API-KEY", key );
    }


    /// <summary />
    public Task<SftpGoResponse<AuthenticateResult>> Authenticate( AuthenticateData data )
    {
        var value = Convert.ToBase64String( Encoding.ASCII.GetBytes( data.Username + ":" + data.Password ) );

        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/token" );
        req.Headers.Authorization = new AuthenticationHeaderValue( "Basic", value );

        if ( data.OneTimePad != null )
            req.Headers.Add( "X-SFTPGO-OTP", data.OneTimePad );

        return Execute<AuthenticateResult>( req );
    }


    /// <summary />
    public Task<SftpGoResponse<List<ApiKey>>> ApiKeyList()
    {
        // TODO: OAuth only

        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/apikeys" );

        return Execute<List<ApiKey>>( req );
    }


    /// <summary />
    public Task<SftpGoResponse<ApiKeyResult>> ApiKeyCreate( ApiKeyData data )
    {
        // TODO: OAuth only

        var req = new HttpRequestMessage( HttpMethod.Post, "/api/v2/apikeys" );
        req.Content = JsonContent.Create( data );

        return Execute<ApiKeyResult>( req );
    }


    /// <summary />
    public Task<SftpGoResponse<List<User>>> UserList()
    {
        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/users" );

        return Execute<List<User>>( req );
    }


    /// <summary />
    public Task<SftpGoResponse<User>> UserCreate( User user )
    {
        var req = new HttpRequestMessage( HttpMethod.Post, "/api/v2/users" );
        req.Content = JsonContent.Create( user );

        return Execute<User>( req );
    }


    /// <summary />
    public Task<SftpGoResponse<User>> UserGet( int userId )
    {
        var req = new HttpRequestMessage( HttpMethod.Get, $"/api/v2/users/{userId}" );

        return Execute<User>( req );
    }


    /// <summary />
    public Task<SftpGoResponse<NullResponse>> UserUpdate( User user )
    {
        var req = new HttpRequestMessage( HttpMethod.Put, $"/api/v2/users/{user.Id}" );
        req.Content = JsonContent.Create( user );

        return Execute<NullResponse>( req );
    }


    /// <summary />
    public Task<SftpGoResponse<NullResponse>> UserDelete( int userId )
    {
        var req = new HttpRequestMessage( HttpMethod.Delete, $"/api/v2/users/{userId}" );

        return Execute<NullResponse>( req );
    }


    /// <summary />
    private async Task<SftpGoResponse<T>> Execute<T>( HttpRequestMessage request, CancellationToken cancellationToken = default )
    {
        var resp = await _http.SendAsync( request );

        resp.EnsureSuccessStatusCode();

        var content = await resp.Content.ReadFromJsonAsync<T>( cancellationToken );

        if ( content == null )
            throw new InvalidOperationException();

        return new SftpGoResponse<T>( content );
    }
}