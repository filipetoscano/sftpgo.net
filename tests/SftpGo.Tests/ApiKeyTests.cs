using Microsoft.AspNetCore.Mvc.Testing;
using SftpGo.ApiServer;

namespace SftpGo.Tests;

/// <summary />
public partial class ApiKeyTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ISftpGo _sftp;


    /// <summary />
    public ApiKeyTests( WebApplicationFactory<Program> factory )
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
    public async Task ApiKeyList()
    {
        var resp = await _sftp.ApiKeyListAsync();

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
    }


    /// <summary />
    [Fact]
    public async Task ApiKeyCreate()
    {
        var resp = await _sftp.ApiKeyCreateAsync( new ApiKeyData()
        {
            Name = "Name",
            Scope = ApiKeyScope.Admin,
            Description = "Description",
        } );

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
    }


    /// <summary />
    [Fact]
    public async Task ApiKeyDelete()
    {
        var resp = await _sftp.ApiKeyDeleteAsync( "11111111111" );

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
    }
}
