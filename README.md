SftpGo
===============================================================================

[![CI](https://github.com/filipetoscano/sftpgo.net/workflows/CI/badge.svg)](https://github.com/filipetoscano/sftpgo.net/actions)
[![NuGet](https://img.shields.io/nuget/vpre/sftpgo.svg?label=NuGet)](https://www.nuget.org/packages/SftpGo/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

.NET client for [SftpGo](https://sftpgo.com/), an SFTP server, written in C#.

Functionality
--------------------------------------------------------------------------

The `SftpGoClient` supports the following objects (and methods):

* ApiKeys (List, Create, Delete)
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
using SftpGo;

builder.Services.AddOptions();
builder.Services.AddHttpClient<SftpGoClient>();
builder.Services.Configure<SftpGoClientOptions>( o =>
{
    o.ApiUrl = Environment.GetEnvironmentVariable( "SFTPGO_APIURL" )!;
    o.ApiKey = Environment.GetEnvironmentVariable( "SFTPGO_APIKEY" );
} );
builder.Services.AddTransient<ISftpGo, SftpGoClient>()
```


Auth: Mostly API key, but sometimes AuthToken
--------------------------------------------------------------------------

Most objects in the REST API can use an API key, but there are a few
objects (namely API Keys) which can only be invoked using an Access Token.
Moreover, the SFTPGo admin web application does not currently implement
any UI to manage API keys. The only manner is through the REST API.

As such, the necessary flow is as follows:

* In SFTPGo admin web, go to the admin user and check the "API key authentication"
  option. This will allow the use of API keys associated with that admin user
* Authenticate as an admin (using username/password/OTP), using `Authenticate`
* Set the access token on the client instance, using `UseAuthToken`
* Create an API key, using `ApiKeyCreate`
* Persist the API key: it is only visible once -- as a result of key create operation
* Set the API key on the client instance, using `UseApiKey`
* Use the rest of the API (e.g. users, services, etc)
