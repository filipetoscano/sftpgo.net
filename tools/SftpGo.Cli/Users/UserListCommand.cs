﻿using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using System.Text.Json;

namespace SftpGo.Cli.Users;

/// <summary />
[Command( "list", Description = "List of users" )]
public class UserListCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public UserListCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Option( "-j|--json", CommandOptionType.NoValue, Description = "Output as JSON" )]
    public bool AsJson { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        /*
         * 
         */
        var p = new Pagination()
        {
            Offset = 0,
            Limit = 50,
            Order = PaginationOrder.Ascending,
        };

        var users = new List<User>();

        while ( true )
        {
            var resp = await _client.UserList( p );

            if ( resp.Content?.Count() == 0 )
                break;

            users.AddRange( resp.Content! );

            if ( resp.Content?.Count() < p.Limit )
                break;

            p.Offset += p.Limit;
        }


        /*
         * 
         */
        if ( this.AsJson == true )
        {
            var jso = new JsonSerializerOptions() { WriteIndented = true };
            var json = JsonSerializer.Serialize( users, jso );

            Console.WriteLine( json );

            return 0;
        }


        /*
         * 
         */
        var table = new Table();
        table.Border = TableBorder.SimpleHeavy;

        table.AddColumn( "Id" );
        table.AddColumn( "Status" );
        table.AddColumn( "Username" );
        table.AddColumn( "Home" );
        table.AddColumn( "Has keys" );

        if ( users.Count == 0 )
            table.AddRow( "[lightsalmon3]No users[/]" );

        foreach ( var u in users )
        {
            table.AddRow(
                u.Id.ToString(),
                u.Status.ToString(),
                u.Username,
                u.HomeDirectory,
                ( u.PublicKeys?.Count() > 0 ) ? "Yes" : "No"
            );
        }

        AnsiConsole.Write( table );

        return 0;
    }
}