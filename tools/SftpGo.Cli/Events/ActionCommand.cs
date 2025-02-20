using McMaster.Extensions.CommandLineUtils;

namespace SftpGo.Cli.Events;

/// <summary />
[Command( "action", Description = "Action commands" )]
[Subcommand( typeof( Actions.CreateCommand ) )]
[Subcommand( typeof( Actions.DeleteCommand ) )]
[Subcommand( typeof( Actions.GetCommand ) )]
[Subcommand( typeof( Actions.ListCommand ) )]
[Subcommand( typeof( Actions.UpdateCommand ) )]
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