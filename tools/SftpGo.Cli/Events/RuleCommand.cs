using McMaster.Extensions.CommandLineUtils;

namespace SftpGo.Cli.Events;

/// <summary />
[Command( "rule", Description = "Rule commands" )]
[Subcommand( typeof( Rules.CreateCommand ) )]
[Subcommand( typeof( Rules.DeleteCommand ) )]
[Subcommand( typeof( Rules.DisableCommand ) )]
[Subcommand( typeof( Rules.EnableCommand ) )]
[Subcommand( typeof( Rules.GetCommand ) )]
[Subcommand( typeof( Rules.ListCommand ) )]
[Subcommand( typeof( Rules.UpdateCommand ) )]
public class RuleCommand
{
    /// <summary />
    public RuleCommand()
    {
    }


    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}