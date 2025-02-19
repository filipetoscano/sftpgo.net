using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli.Users;

/// <summary />
[Command( "delete", Description = "Deletes a user" )]
public class UserDeleteCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public UserDeleteCommand( ISftpGo client )
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
        var resp = await _client.UserDelete( this.Username! );

        return 0;
    }
}