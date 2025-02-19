using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.Text.Json;

namespace SftpGo.Cli.ApiKeys;

/// <summary />
[Command( "list", Description = "List of users" )]
public class ApiKeyListCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public ApiKeyListCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Output as JSON" )]
    public bool AsJson { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        /*
         * Requires auth token
         */
        var authToken = Program.AuthTokenDemand();

        if ( authToken == null )
            return 1;

        _client.UseAuthToken( authToken );


        /*
         * 
         */
        var resp = await _client.ApiKeyList();
        var keys = resp.Content!;


        /*
         * 
         */
        if ( this.AsJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( keys, jso );

            Console.WriteLine( json );

            return 0;
        }


        /*
         * 
         */
        var table = new Table();
        table.Border = TableBorder.SimpleHeavy;

        table.AddColumn( "Id" );
        table.AddColumn( "Name" );
        table.AddColumn( "Expires At" );
        table.AddColumn( "Scope" );
        table.AddColumn( "Impersonate" );

        if ( keys.Count == 0 )
            table.AddRow( "[lightsalmon3]No keys[/]" );

        foreach ( var row in keys )
        {
            table.AddRow(
                row.Id,
                row.Name,
                row.MomentExpiration?.ToString() ?? "",
                row.Scope.ToString(),
                row.ImpersonateAdmin ?? ""
            );
        }

        AnsiConsole.Write( table );

        return 0;
    }
}