using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli.Users;

/// <summary />
[Command( "enable", Description = "Enables a user" )]
public class UserEnableCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public UserEnableCommand( ISftpGo client )
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
        var resp = await _client.UserEnableAsync( this.Username! );

        return 0;
    }
}