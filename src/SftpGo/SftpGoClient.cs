using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;

namespace SftpGo;

/// <summary />
public class SftpGoClient : ISftpGo
{
    private readonly HttpClient _http;

    /// <summary />
    public SftpGoClient( IOptions<SftpGoClientOptions> options, HttpClient httpClient )
    {
        var opt = options.Value;


        /*
         * 
         */
        _http = httpClient;
        _http.BaseAddress = new Uri( opt.ApiUrl );


        /*
         * Ask for JSON responses. Not necessary atm, since SftpGo always/only
         * answers in JSON -- but good for future proofing.
         */
        httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );

        if ( opt.ApiKey != null )
            UseApiKey( opt.ApiKey );


        /*
         * Identification
         */
        var productValue = new ProductInfoHeaderValue( "sftpgo-sdk", Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0" );
        var dotnetValue = new ProductInfoHeaderValue( "dotnet", Environment.Version.ToString() );

        httpClient.DefaultRequestHeaders.UserAgent.Add( productValue );
        httpClient.DefaultRequestHeaders.UserAgent.Add( dotnetValue );
    }


    /// <inheritdoc />
    public void UseAuthToken( string authToken )
    {
        _http.DefaultRequestHeaders.Remove( "X-SFTPGO-API-KEY" );
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", authToken );
    }


    /// <inheritdoc />
    public void UseApiKey( string apiKey )
    {
        _http.DefaultRequestHeaders.Authorization = null;
        _http.DefaultRequestHeaders.Add( "X-SFTPGO-API-KEY", apiKey );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<AuthenticateResult>> Authenticate( AuthenticateData data )
    {
        var value = Convert.ToBase64String( Encoding.ASCII.GetBytes( data.Username + ":" + data.Password ) );

        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/token" );
        req.Headers.Authorization = new AuthenticationHeaderValue( "Basic", value );

        if ( data.OneTimePad != null )
            req.Headers.Add( "X-SFTPGO-OTP", data.OneTimePad );

        return Execute<AuthenticateResult>( req );
    }


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
    public Task<SftpGoResponse<List<User>>> UserList()
    {
        // TODO: Pagination

        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/users" );

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


    /// <summary />
    private void RequireAuthToken()
    {
        // TODO: Require OAuth
    }
}