using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace SftpGo.Cli;

/// <summary />
[Command( "version", Description = "Retrieves the SFTP Go version" )]
public class VersionCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public VersionCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.VersionGet();

        var jso = new JsonSerializerOptions() {  WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 0;
    }
}