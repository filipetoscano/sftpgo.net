using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SftpGo.Cli.User;

/// <summary />
[Command( "get", Description = "Retrieve a user" )]
public class UserGetCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public UserGetCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "Username" )]
    [Required]
    public string? Username { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.UserGet( this.Username! );

        var jso = new JsonSerializerOptions() { WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 0;
    }
}