using Microsoft.AspNetCore.Mvc;

namespace SftpGo.ApiServer.Controllers;

/// <summary />
[ApiController]
public class ApiKeyController : ControllerBase
{
    private readonly ILogger<ApiKeyController> _logger;


    /// <summary />
    public ApiKeyController( ILogger<ApiKeyController> logger )
    {
        _logger = logger;
    }


    /// <summary />
    [HttpGet]
    [Route( "api/v2/apikeys" )]
    public List<ApiKey> List()
    {
        _logger.LogDebug( "ApiKey/List" );

        var list = new List<ApiKey>();

        return list;
    }


    /// <summary />
    [HttpPost]
    [Route( "api/v2/apikeys" )]
    public ApiKeyResult Create( [FromBody] ApiKeyData data )
    {
        _logger.LogDebug( "ApiKey/Create" );

        return new ApiKeyResult()
        {
            Key = Guid.NewGuid().ToString(),
        };
    }
}
