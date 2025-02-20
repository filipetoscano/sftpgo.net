using McMaster.Extensions.CommandLineUtils;

namespace SftpGo.Cli.Events;

/// <summary />
[Command( "rule", Description = "Rule commands" )]
[Subcommand( typeof( Rules.ListCommand ) )]
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