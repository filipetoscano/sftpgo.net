﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Options;
using SftpGo.ApiServer;

namespace SftpGo.Tests;

/// <summary />
public partial class MaintenanceTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ISftpGo _sftp;


    /// <summary />
    public MaintenanceTests( WebApplicationFactory<Program> factory )
    {
        _factory = factory;

        var http = _factory.CreateClient();

        var opt = Options.Create( new SftpGoClientOptions()
        {
            ApiUrl = http.BaseAddress!.ToString(),
        } );

        _sftp = new SftpGoClient( opt, http );
    }


    /// <summary />
    [Fact]
    public async Task VersionGet()
    {
        var resp = await _sftp.VersionGet();

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
        Assert.NotNull( resp.Content );

        Assert.Equal( "1.2.3", resp.Content.VersionNumber );
    }


    /// <summary />
    [Fact]
    public async Task Status()
    {
        var resp = await _sftp.StatusGet();

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
        Assert.NotNull( resp.Content );

        Assert.NotNull( resp.Content.Ssh );
        Assert.True( resp.Content.Ssh.IsActive );

        Assert.NotNull( resp.Content.Ftp );
        Assert.False( resp.Content.Ftp.IsActive );
    }
}