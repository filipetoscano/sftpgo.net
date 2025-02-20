using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.Text.Json;

namespace SftpGo.Cli.Events.Actions;

/// <summary />
[Command( "list", Description = "List event actions" )]
public class ListCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public ListCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Output as JSON" )]
    public bool AsJson { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync( CommandLineApplication app )
    {
        var resp = await _client.EventActionListAsync();
        var actions = resp.Content!;


        /*
         * 
         */
        if ( this.AsJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( actions, jso );

            Console.WriteLine( json );

            return 0;
        }


        /*
         * 
         */
        var table = new Table();
        table.Border = TableBorder.SimpleHeavy;

        table.AddColumn( "Name" );
        table.AddColumn( "Type" );
        table.AddColumn( "Info" );

        if ( actions.Count == 0 )
            table.AddRow( "[lightsalmon3]No actions[/]" );

        foreach ( var row in actions )
        {
            table.AddRow(
                row.Name,
                row.Type.ToString(),
                ToTypeInfo( row )
            );
        }

        AnsiConsole.Write( table );

        return 0;
    }


    private string ToTypeInfo( EventAction row )
    {
        if ( row.Type == EventActionType.Http )
            return $"{row.Options.HttpConfig?.Method.ToString().ToUpperInvariant()} {row.Options.HttpConfig?.Endpoint}";

        if ( row.Type == EventActionType.Command )
            return $"{row.Options.CommandConfig?.Command}";

        return "";
    }
}