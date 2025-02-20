﻿using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SftpGo.Cli.Events.Actions;

/// <summary />
[Command( "get", Description = "Retrieve an event rule" )]
public class GetCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public GetCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "Event action name" )]
    [Required]
    public string? ActionName { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        var resp = await _client.EventActionGetAsync( this.ActionName! );

        var jso = new JsonSerializerOptions() { WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );
        return 0;
    }
}