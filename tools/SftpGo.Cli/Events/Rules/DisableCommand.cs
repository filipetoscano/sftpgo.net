using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli.Events.Rules;

/// <summary />
[Command( "disable", Description = "Disables an event rule" )]
public class DisableCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public DisableCommand( ISftpGo client )
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
        var resp = await _client.EventRuleDisableAsync( this.RuleName! );

        return 0;
    }
}