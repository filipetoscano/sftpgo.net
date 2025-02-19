using McMaster.Extensions.CommandLineUtils;

namespace SftpGo.Cli;

/// <summary />
[Command( "user", Description = "User commands" )]
[Subcommand( typeof( Users.UserCreateCommand ) )]
[Subcommand( typeof( Users.UserDeleteCommand ) )]
[Subcommand( typeof( Users.UserGetCommand ) )]
[Subcommand( typeof( Users.UserListCommand ) )]
[Subcommand( typeof( Users.UserUpdateCommand ) )]
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