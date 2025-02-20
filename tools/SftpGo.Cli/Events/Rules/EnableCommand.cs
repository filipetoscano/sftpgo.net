using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli.Events.Rules;

/// <summary />
[Command( "enable", Description = "Enables an event rule" )]
public class EnableCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public EnableCommand( ISftpGo client )
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
        var resp = await _client.EventRuleEnableAsync( this.RuleName! );

        return 0;
    }
}