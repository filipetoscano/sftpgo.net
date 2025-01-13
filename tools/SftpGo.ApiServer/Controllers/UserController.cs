using Microsoft.AspNetCore.Mvc;

namespace SftpGo.ApiServer.Controllers;

/// <summary />
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;


    /// <summary />
    public UserController( ILogger<UserController> logger )
    {
        _logger = logger;
    }


    /// <summary />
    [HttpGet]
    [Route( "api/v2/users" )]
    public List<User> List()
    {
        _logger.LogDebug( "User/List" );

        var list = new List<User>();

        return list;
    }


    /// <summary />
    [HttpPost]
    [Route( "api/v2/users" )]
    public User Create( [FromBody] User user )
    {
        _logger.LogDebug( "ApiKey/Create" );

        return user;
    }


    /// <summary />
    [HttpGet]
    [Route( "api/v2/users/{username}" )]
    public User Get( [FromRoute] string username )
    {
        _logger.LogDebug( "User/Get" );

        return new User()
        {
            Id = 1,
            Username = username,
        };
    }


    /// <summary />
    [HttpPut]
    [Route( "api/v2/users/{username}" )]
    public User Update( [FromRoute] string username, [FromBody] User user )
    {
        _logger.LogDebug( "User/Update" );

        return new User()
        {
            Id = 1,
            Username = username,
        };
    }


    /// <summary />
    [HttpDelete]
    [Route( "api/v2/users/{username}" )]
    public ActionResult Delete( [FromRoute] string username )
    {
        _logger.LogDebug( "User/Delete" );

        return Ok();
    }
}
