using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace SftpGo;

public partial class SftpGoClient
{
    /// <inheritdoc />
    public Task<SftpGoResponse<List<EventRule>>> EventRuleListAsync()
    {
        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/eventrules" );

        return Execute<List<EventRule>>( req );
    }
}