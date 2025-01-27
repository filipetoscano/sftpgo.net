﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Options;
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

        var opt = Options.Create( new SftpGoClientOptions()
        {
            ApiUrl = http.BaseAddress!.ToString(),
        } );

        _sftp = new SftpGoClient( opt, http );
    }


    /// <summary />
    [Fact]
    public async Task ApiKeyList()
    {
        var resp = await _sftp.ApiKeyList();

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
    }


    /// <summary />
    [Fact]
    public async Task ApiKeyCreate()
    {
        var resp = await _sftp.ApiKeyCreate( new ApiKeyData()
        {
            Name = "Name",
            Scope = ApiKeyScope.Admin,
            Description = "Description",
        } );

        Assert.NotNull( resp );
        Assert.True( resp.IsSuccess );
    }
}
