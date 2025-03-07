using Microsoft.AspNetCore.Mvc.Testing;
using SftpGo.ApiServer;

namespace SftpGo.Tests;

/// <summary />
public partial class UserTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ISftpGo _sftp;


    /// <summary />
    public UserTests( WebApplicationFactory<Program> factory )
    {
        _factory = factory;

        var http = _factory.CreateClient();

        var opt = new SftpGoClientOptions()
        {
            ApiUrl = http.BaseAddress!.ToString(),
        };

        _sftp = SftpGoClient.Create( opt, http );
    }


    /// <summary />
    [Fact]
    public async Task UserList()
    {
        var resp = await _sftp.UserListAsync();

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
        Assert.NotNull( resp.Content );

        Assert.Empty( resp.Content );
    }


    /// <summary />
    [Fact]
    public async Task UserCreate()
    {
        var expected = new User()
        {
            Username = "lft",
            Status = UserStatus.Enabled,
            HasPassword = false,
            HomeDirectory = "/home/lft",
            PublicKeys = new List<string>(),
            Permissions = new Dictionary<string, List<Permission>>()
            {
                { "/", new List<Permission>() { Permission.All } },
            }
        };

        var resp = await _sftp.UserCreateAsync( expected );

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
        Assert.NotNull( resp.Content );

        Assert.Equal( expected.HomeDirectory, resp.Content.HomeDirectory );
        Assert.Single( resp.Content.Permissions );
    }


    /// <summary />
    [Fact]
    public async Task UserGet()
    {
        var resp = await _sftp.UserGetAsync( "lft" );

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
        Assert.NotNull( resp.Content );
    }


    /// <summary />
    [Fact]
    public async Task UserUpdate()
    {
        var expected = new User()
        {
            Username = "lft",
            Status = UserStatus.Enabled,
            HasPassword = false,
            HomeDirectory = "/home/lft",
            PublicKeys = new List<string>(),
            Permissions = new Dictionary<string, List<Permission>>()
            {
                { "/", new List<Permission>() { Permission.All } },
            }
        };

        var resp = await _sftp.UserUpdateAsync( expected );

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
    }


    /// <summary />
    [Fact]
    public async Task UserDelete()
    {
        var resp = await _sftp.UserDeleteAsync( "lft" );

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
    }
}
