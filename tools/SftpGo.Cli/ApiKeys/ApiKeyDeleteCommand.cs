using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace SftpGo.Cli.ApiKeys;

/// <summary />
[Command( "delete", Description = "Deletes a user" )]
public class ApiKeyDeleteCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public ApiKeyDeleteCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "Key identifier" )]
    [Required]
    public string? KeyId { get; set; }


    /// <summary />
    public async Task<int> OnExecuteAsync()
    {
        /*
         * Requires auth token
         */
        var authToken = Program.AuthTokenDemand();

        if ( authToken == null )
            return 1;

        _client.UseAuthToken( authToken );


        /*
         * 
         */
        var resp = await _client.ApiKeyDeleteAsync( this.KeyId! );

        return 0;
    }
}