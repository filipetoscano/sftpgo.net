﻿using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace SftpGo.Cli.User;

/// <summary />
[Command( "create", Description = "Creates a user" )]
public class UserCreateCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public UserCreateCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "JSON" )]
    [FileExists]
    public string? Filename { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync( CommandLineApplication app )
    {
        /*
         * 
         */
        string input;

        if ( Console.IsInputRedirected == true )
        {
            input = await Console.In.ReadToEndAsync();
        }
        else if ( this.Filename != null )
        {
            input = await File.ReadAllTextAsync( this.Filename! );
        }
        else
        {
            app.ShowHelp();
            return 1;
        }


        /*
         * 
         */
        var u = JsonSerializer.Deserialize<SftpGo.User>( input );

        if ( u == null )
        {
            Console.Error.WriteLine( "err: Input isn't JSON" );
            return 2;
        }


        /*
         * 
         */
        var resp = await _client.UserCreate( u );

        var jso = new JsonSerializerOptions() { WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 0;
    }
}