using McMaster.Extensions.CommandLineUtils;

namespace SftpGo.Cli;

/// <summary />
[Command( "apikey", Description = "API key commands" )]
[Subcommand( typeof( ApiKeys.ApiKeyCreateCommand ) )]
[Subcommand( typeof( ApiKeys.ApiKeyDeleteCommand ) )]
[Subcommand( typeof( ApiKeys.ApiKeyListCommand ) )]
public class ApiKeyCommand
{
    /// <summary />
    public ApiKeyCommand()
    {
    }


    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}