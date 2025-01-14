using McMaster.Extensions.CommandLineUtils;

namespace SftpGo.Cli;

/// <summary />
[Command( "user", Description = "User commands" )]
[Subcommand( typeof( User.UserGetCommand ) )]
[Subcommand( typeof( User.UserListCommand ) )]
public class UserCommand
{
    /// <summary />
    public UserCommand()
    {
    }


    /// <summary />
    public int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}