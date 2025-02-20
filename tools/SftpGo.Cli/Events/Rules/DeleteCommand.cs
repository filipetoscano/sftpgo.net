using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli.Events.Rules;

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
    [Argument( 0, Description = "Event rule name" )]
    [Required]
    public string? RuleName { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.EventRuleDeleteAsync( this.RuleName! );

        return 0;
    }
}