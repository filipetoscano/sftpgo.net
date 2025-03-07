using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;

namespace SftpGo;

/// <summary />
public partial class SftpGoClient : ISftpGo
{
    private readonly HttpClient _http;

    /// <summary />
    public SftpGoClient( IOptionsSnapshot<SftpGoClientOptions> options, HttpClient httpClient )
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
    public Task<SftpGoResponse<AuthenticateResult>> AuthenticateAsync( AuthenticateData data )
    {
        var value = Convert.ToBase64String( Encoding.ASCII.GetBytes( data.Username + ":" + data.Password ) );

        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/token" );
        req.Headers.Authorization = new AuthenticationHeaderValue( "Basic", value );

        if ( data.OneTimePad != null )
            req.Headers.Add( "X-SFTPGO-OTP", data.OneTimePad );

        return Execute<AuthenticateResult>( req );
    }


    /// <summary />
    private async Task<SftpGoResponse<T>> Execute<T>( HttpRequestMessage request, CancellationToken cancellationToken = default )
    {
        HttpResponseMessage resp;

        resp = await _http.SendAsync( request );


        /*
         * 
         */
        if ( resp.IsSuccessStatusCode == false )
        {
            ApiError err;

            try
            {
                var obj = await resp.Content.ReadFromJsonAsync<ApiError>( cancellationToken );

                err = obj!;
            }
            catch
            {
                err = new ApiError()
                {
                    Error = "",
                    Message = "",
                };
            }

            throw new SftpGoException( resp.StatusCode, err.Error, err.Message );
        }


        /*
         * If no (meaningful) response was expected from API call, don't read
         * the response body at all: just return NullResponse.
         */
        if ( typeof( T ) == typeof( NullResponse ) )
        {
            object obj = new SftpGoResponse<NullResponse>( new NullResponse() );
            return (SftpGoResponse<T>) obj;
        }


        /*
         * 
         */
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


    /// <summary />
    public static SftpGoClient Create( SftpGoClientOptions options, HttpClient? http )
    {
        var opt = new OptionsSnapshot<SftpGoClientOptions>( options );

        return new SftpGoClient( opt, http ?? new HttpClient() );
    }
}