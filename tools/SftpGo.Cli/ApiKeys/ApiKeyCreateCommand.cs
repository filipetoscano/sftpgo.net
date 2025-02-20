using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SftpGo.Cli.ApiKeys;

/// <summary />
[Command( "create", Description = "Creates an API key" )]
public class ApiKeyCreateCommand
{
    private readonly ISftpGo _client;

    /// <summary />
    public ApiKeyCreateCommand( ISftpGo client )
    {
        _client = client;
    }


    /// <summary />
    [Argument( 0, Description = "Name of API key" )]
    [Required]
    public string? Name { get; set; }

    /// <summary />
    [Option( "-a|--admin", CommandOptionType.SingleValue, Description = "Impersonate an admin user" )]
    public string? AsAdmin { get; set; }

    /// <summary />
    [Option( "-d|--description", CommandOptionType.SingleValue, Description = "Description. If not set, will be automatically generated" )]
    public string? Description { get; set; }

    /// <summary />
    [Option( "-s|--scope", CommandOptionType.SingleValue, Description = "API key scope" )]
    public ApiKeyScope Scope { get; set; } = ApiKeyScope.Admin;


    /// <summary />
    public async Task<int> OnExecuteAsync( CommandLineApplication app )
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
        if ( this.Description == null )
            this.Description = "Generated on " + DateTime.Now.ToString( "yyyy-MM-dd" );


        /*
         * 
         */
        var resp = await _client.ApiKeyCreateAsync( new ApiKeyData()
        {
            Name = this.Name!,
            Description = this.Description,
            Scope = this.Scope,
            ImpersonateAdmin = this.AsAdmin,
        } );

        var jso = new JsonSerializerOptions() { WriteIndented = true };
        var json = JsonSerializer.Serialize( resp.Content, jso );

        Console.WriteLine( json );

        return 0;
    }
}