using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli.Users;

/// <summary />
[Command( "disable", Description = "Disables a user" )]
public class UserDisableCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public UserDisableCommand( ISftpGo client )
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
        var resp = await _client.UserDisableAsync( this.Username! );

        return 0;
    }
}