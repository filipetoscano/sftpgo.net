using McMaster.Extensions.CommandLineUtils;

namespace SftpGo.Cli.Events;

/// <summary />
[Command( "action", Description = "Action commands" )]
[Subcommand( typeof( Actions.ListCommand ) )]
public class ActionCommand
{
    /// <summary />
    public ActionCommand()
    {
    }


    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}