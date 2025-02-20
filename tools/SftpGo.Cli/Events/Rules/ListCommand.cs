using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.Text.Json;

namespace SftpGo.Cli.Events.Rules;

/// <summary />
[Command( "list", Description = "List event rules" )]
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
        var resp = await _client.EventRuleListAsync();
        var rules = resp.Content!;


        /*
         * 
         */
        if ( this.AsJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( rules, jso );

            Console.WriteLine( json );

            return 0;
        }


        /*
         * 
         */
        var table = new Table();
        table.Border = TableBorder.SimpleHeavy;

        table.AddColumn( "Name" );
        table.AddColumn( "Status" );
        table.AddColumn( "Trigger" );
        table.AddColumn( "Conditions" );
        table.AddColumn( "#A", x => x.RightAligned() );
        table.AddColumn( "Actions" );

        if ( rules.Count == 0 )
            table.AddRow( "[lightsalmon3]No rules[/]" );

        foreach ( var row in rules )
        {
            table.AddRow(
                row.Name,
                row.Status.ToString(),
                row.Trigger.ToString(),
                ToConditions( row ),
                row.Actions?.Count().ToString() ?? "0",
                ToActions( row )
            );
        }

        AnsiConsole.Write( table );

        return 0;
    }


    /// <summary />
    private string ToActions( EventRule row )
    {
        if ( row.Actions == null )
            return "";

        if ( row.Actions.Count == 0 )
            return "";

        return string.Join( " ", row.Actions.Select( x => x.Name ) );
    }


    /// <summary />
    private string ToConditions( EventRule row )
    {
        if ( row.Trigger == EventTrigger.Filesystem )
        {
            if ( row.Conditions.Filesystem == null )
                return "";

            if ( row.Conditions.Filesystem.Count == 0 )
                return "";

            return string.Join( " ", row.Conditions.Filesystem.Select( x => x.ToString() ) );
        }

        return "";
    }
}