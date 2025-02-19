using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace SftpGo.Cli;

/// <summary />
[Command( "sftpgo" )]
[Subcommand( typeof( ApiKeyCommand ) )]
[Subcommand( typeof( AuthCommand ) )]
[Subcommand( typeof( StatusCommand ) )]
[Subcommand( typeof( UserCommand ) )]
[Subcommand( typeof( VersionCommand ) )]
public class Program
{
    /// <summary />
    public static int Main( string[] args )
    {
        /*
         * 
         */
        var app = new CommandLineApplication<Program>();

        var svc = new ServiceCollection();
        svc.AddOptions();
        svc.Configure<SftpGoClientOptions>( o =>
        {
            o.ApiUrl = Environment.GetEnvironmentVariable( "SFTPGO_APIURL" )!;
            o.ApiKey = Environment.GetEnvironmentVariable( "SFTPGO_APIKEY" );
        } );
        svc.AddHttpClient<SftpGoClient>();
        svc.AddTransient<ISftpGo, SftpGoClient>();

        var sp = svc.BuildServiceProvider();


        /*
         * 
         */
        try
        {
            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection( sp );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( "ftl: unhandled exception during setup" );
            Console.WriteLine( ex.ToString() );

            return 2;
        }


        /*
         * 
         */
        try
        {
            return app.Execute( args );
        }
        catch ( UnrecognizedCommandParsingException ex )
        {
            Console.WriteLine( "err: " + ex.Message );

            return 2;
        }
        catch ( SftpGoException ex )
        {
            Console.WriteLine( "err: SftpGo API returned an error" );
            Console.WriteLine( "Status Code = {0} {1}", (int) ex.StatusCode, ex.StatusCode );
            Console.WriteLine( "  API Error = {0}", ex.ApiError );
            Console.WriteLine( "API Message = {0}", ex.ApiMessage );

            return 3;
        }
        catch ( Exception ex )
        {
            Console.WriteLine( "ftl: unhandled exception during execution" );
            Console.WriteLine( ex.ToString() );

            return 2;
        }
    }


    /// <summary />
    public static string? AuthTokenGet()
    {
        string? authToken = Environment.GetEnvironmentVariable( "SFTPGO_AUTHTOKEN" );

        if ( string.IsNullOrEmpty( authToken ) == false )
            return authToken;

        if ( File.Exists( ".auth" ) == false )
            return null;

        return File.ReadAllText( ".auth" ).Trim();
    }


    /// <summary />
    public static string? AuthTokenDemand()
    {
        var authToken = AuthTokenGet();

        if ( authToken == null )
            Console.WriteLine( "err: auth token required: set SFTPGO_AUTHTOKEN or save in .auth file" );

        return authToken;
    }


    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}