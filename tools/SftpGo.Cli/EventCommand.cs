using McMaster.Extensions.CommandLineUtils;

namespace SftpGo.Cli;

/// <summary />
[Command( "event", Description = "Event commands" )]
[Subcommand( typeof( Events.ActionCommand ) )]
[Subcommand( typeof( Events.RuleCommand ) )]
public class EventCommand
{
    /// <summary />
    public EventCommand()
    {
    }


    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}