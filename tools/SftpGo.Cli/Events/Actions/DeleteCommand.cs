using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli.Events.Actions;

/// <summary />
[Command( "delete", Description = "Deletes an event rule" )]
public class DeleteCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public DeleteCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "Event action name" )]
    [Required]
    public string? ActionName { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.EventActionDeleteAsync( this.ActionName! );

        return 0;
    }
}