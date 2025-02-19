using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli;

/// <summary />
[Command( "auth", Description = "Authenticate" )]
public class AuthCommand
{
    private readonly ISftpGo _client;


    /// <summary />
    public AuthCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "Username" )]
    [Required]
    public string? Username { get; set; }

    /// <summary />
    [Option( "-p|--password", CommandOptionType.SingleValue, Description = "Password" )]
    public string? Password { get; set; }

    /// <summary />
    [Option( "-2|--two-factor", CommandOptionType.NoValue, Description = "Whether to prompt for OTP" )]
    public bool HasTwoFactor { get; set; }

    /// <summary />
    [Option( "-t|--otp", CommandOptionType.SingleValue, Description = "(OTP) One time pad" )]
    public string? OneTimePad { get; set; }

    /// <summary />
    [Option( "-O|--console", CommandOptionType.NoValue, Description = "Write access token to console, otherwise to .auth file" )]
    public bool Output { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync( CommandLineApplication app )
    {
        string? password = this.Password;
        string? oneTimePad = this.OneTimePad;


        /*
         * 
         */
        if ( password == null )
            password = AnsiConsole.Prompt( new TextPrompt<string>( "Enter password:" ).Secret() );

        if ( HasTwoFactor == true && oneTimePad == null )
            oneTimePad = AnsiConsole.Prompt( new TextPrompt<string>( "Enter OTP:" ).Secret() );


        /*
         * 
         */
        var resp = await _client.Authenticate( new AuthenticateData()
        {
            Username = this.Username!,
            Password = password!,
            OneTimePad = oneTimePad,
        } );


        /*
         * 
         */
        if ( this.Output == true )
        {
            Console.WriteLine( resp.Content!.AccessToken );
        }
        else
        {
            Console.WriteLine( "Writing access token to .auth" );
            File.WriteAllText( ".auth", resp.Content!.AccessToken );
        }

        return 0;
    }
}