using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace SftpGo;

public partial class SftpGoClient
{
    /// <inheritdoc />
    public Task<SftpGoResponse<List<EventAction>>> EventActionListAsync()
    {
        var req = new HttpRequestMessage( HttpMethod.Get, "/api/v2/eventactions" );

        return Execute<List<EventAction>>( req );
    }
}