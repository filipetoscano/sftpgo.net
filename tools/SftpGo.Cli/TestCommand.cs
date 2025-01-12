using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace SftpGo.Cli;

/// <summary />
[Command( "test", Description = "Test" )]
public class TestCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public TestCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.UserGet( "lft" );

        var jso = new JsonSerializerOptions() {  WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 0;
    }
}
