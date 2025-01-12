SftpGo
===============================================================================

[![CI](https://github.com/filipetoscano/sftpgo.net/workflows/CI/badge.svg)](https://github.com/filipetoscano/sftpgo.net/actions)
[![NuGet](https://img.shields.io/nuget/vpre/sftpgo.svg?label=NuGet)](https://www.nuget.org/packages/SftpGo/)

 .NET client for [SftpGo](https://sftpgo.com/), an SFTP server, written in C#.

 Functionality
--------------------------------------------------------------------------

The `SftpGoClient` supports the following objects (and methods):

* ApiKeys (List, Create)
* Users (List, Get, Create, Update, Delete)


Installing via NuGet
--------------------------------------------------------------------------

Package is published in the [NuGet](https://www.nuget.org/packages/SftpGo/) gallery.

From the command-line:

```
> dotnet add package SftpGo
```

From within Visual Studio using Package Manager Console:

```
PM> Install-Package SftpGo
```


Getting started
--------------------------------------------------------------------------

In the startup of your application, configure the DI container as follows:

```
using Resend;

builder.Services.AddOptions();
builder.Services.AddHttpClient<SftpGoClient>();
builder.Services.Configure<SftpGoClientOptions>( o =>
{
    o.ApiUrl = Environment.GetEnvironmentVariable( "SFTPGO_APIURL" )!;
    o.ApiKey = Environment.GetEnvironmentVariable( "SFTPGO_APIKEY" );
} );
builder.Services.AddTransient<IResend, ResendClient>()
```