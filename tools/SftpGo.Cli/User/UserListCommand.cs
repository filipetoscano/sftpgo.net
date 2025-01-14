using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace SftpGo.Cli.User;

/// <summary />
[Command( "list", Description = "List of users" )]
public class UserListCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public UserListCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.UserList();

        var jso = new JsonSerializerOptions() {  WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 0;
    }
}