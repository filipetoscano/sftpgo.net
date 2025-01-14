using Microsoft.AspNetCore.Mvc;

namespace SftpGo.ApiServer.Controllers;

/// <summary />
[ApiController]
public class MaintenanceController : ControllerBase
{
    private readonly ILogger<MaintenanceController> _logger;


    /// <summary />
    public MaintenanceController( ILogger<MaintenanceController> logger )
    {
        _logger = logger;
    }


    /// <summary />
    [HttpGet]
    [Route( "api/v2/version" )]
    public Version Version()
    {
        _logger.LogDebug( "Maintenance/Version" );

        return new Version()
        {
            VersionNumber = "1.2.3",
            BuildDate = DateTime.UtcNow,
            CommitHash = "not-really-a-hash",
            Features = new List<string>()
            {
                "feature-1",
                "feature-2",
                "feature-3",
            },
        };
    }


    /// <summary />
    [HttpGet]
    [Route( "api/v2/status" )]
    public ServicesStatus Status()
    {
        _logger.LogDebug( "Maintenance/Status" );

        var ss = new ServicesStatus();
        
        ss.Ssh = new SshServiceStatus();
        ss.Ssh.IsActive = true;

        ss.Ftp = new FtpServiceStatus();
        ss.Ftp.IsActive = false;

        return ss;
    }
}
