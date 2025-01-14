using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace SftpGo.Cli;

/// <summary />
[Command( "status", Description = "Retrieves the status of SFTP Go services" )]
public class StatusCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public StatusCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.StatusGet();

        var jso = new JsonSerializerOptions() {  WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 0;
    }
}