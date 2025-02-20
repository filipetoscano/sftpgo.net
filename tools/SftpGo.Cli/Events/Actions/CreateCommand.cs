using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace SftpGo.Cli.Events.Actions;

/// <summary />
[Command( "create", Description = "Creates an event rule" )]
public class CreateCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public CreateCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "JSON" )]
    [FileExists]
    public string? Filename { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync( CommandLineApplication app )
    {
        /*
         * 
         */
        string input;

        if ( Console.IsInputRedirected == true )
        {
            input = await Console.In.ReadToEndAsync();
        }
        else if ( this.Filename != null )
        {
            input = await File.ReadAllTextAsync( this.Filename! );
        }
        else
        {
            app.ShowHelp();
            return 1;
        }


        /*
         * 
         */
        var jso = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            WriteIndented = true,
        };

        var obj = JsonSerializer.Deserialize<EventAction>( input, jso );

        if ( obj == null )
        {
            Console.Error.WriteLine( "err: Input isn't JSON" );
            return 2;
        }


        /*
         * 
         */
        var resp = await _client.EventActionCreateAsync( obj );

        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 0;
    }
}