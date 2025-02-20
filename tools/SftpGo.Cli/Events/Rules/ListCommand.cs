using McMaster.Extensions.CommandLineUtils;
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
    public async Task<int> OnExecuteAsync( CommandLineApplication app )
    {
        var resp = await _client.EventRuleListAsync();

        var jso = new JsonSerializerOptions() { WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 1;
    }
}