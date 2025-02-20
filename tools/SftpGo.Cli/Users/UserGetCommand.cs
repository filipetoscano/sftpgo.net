using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SftpGo.Cli.Users;

/// <summary />
[Command( "get", Description = "Retrieve a user" )]
public class UserGetCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public UserGetCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "Username" )]
    [Required]
    public string? Username { get; set; }

    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Output as JSON" )]
    public bool AsJson { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.UserGetAsync( this.Username! );

        if ( this.AsJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( resp.Content, jso );

            Console.WriteLine( json );
            return 0;
        }


        /*
         * 
         */
        var user = resp.Content!;


        // Headers
        var table = new Table();
        table.Border = TableBorder.SimpleHeavy;

        table.AddColumn( "Id" );
        table.AddColumn( "Status" );
        table.AddColumn( "Username" );
        table.AddColumn( "Home" );
        table.AddColumn( "Has keys" );

        table.AddRow(
            user.Id.ToString(),
            user.Status.ToString(),
            user.Username,
            user.HomeDirectory,
            ( user.PublicKeys?.Count() > 0 ) ? "Yes" : "No"
        );


        // Permissions
        var perms = new Table();
        perms.Border = TableBorder.SimpleHeavy;

        perms.AddColumn( "Folder" );
        perms.AddColumn( "Permissions" );

        foreach ( var p in user.Permissions )
        {
            perms.AddRow(
                p.Key,
                string.Join( ", ", p.Value )
            );
        }


        AnsiConsole.Write( table );
        AnsiConsole.Write( perms );

        return 0;
    }
}