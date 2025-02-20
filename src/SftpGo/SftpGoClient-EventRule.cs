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


    /// <inheritdoc />
    public Task<SftpGoResponse<EventRule>> EventRuleCreateAsync( EventRule rule )
    {
        var req = new HttpRequestMessage( HttpMethod.Post, "/api/v2/eventrules" );
        req.Content = JsonContent.Create( rule );

        return Execute<EventRule>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<EventRule>> EventRuleGetAsync( string ruleName )
    {
        var req = new HttpRequestMessage( HttpMethod.Get, $"/api/v2/eventrules/{ruleName}" );

        return Execute<EventRule>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> EventRuleUpdateAsync( EventRule rule )
    {
        var req = new HttpRequestMessage( HttpMethod.Put, $"/api/v2/eventrules/{rule.Name}" );
        req.Content = JsonContent.Create( rule );

        return Execute<NullResponse>( req );
    }


    /// <inheritdoc />
    public Task<SftpGoResponse<NullResponse>> EventRuleDeleteAsync( string ruleName )
    {
        var req = new HttpRequestMessage( HttpMethod.Delete, $"/api/v2/eventrules/{ruleName}" );

        return Execute<NullResponse>( req );
    }


    /// <inheritdoc />
    public async Task<SftpGoResponse<NullResponse>> EventRuleEnableAsync( string ruleName )
    {
        var resp = await EventRuleGetAsync( ruleName );
        var rule = resp.Content!;

        if ( rule.Status == EventRuleStatus.Enabled )
            return new SftpGoResponse<NullResponse>( new NullResponse() );

        rule.Status = EventRuleStatus.Enabled;
        return await EventRuleUpdateAsync( resp.Content! );
    }


    /// <inheritdoc />
    public async Task<SftpGoResponse<NullResponse>> EventRuleDisableAsync( string ruleName )
    {
        var resp = await EventRuleGetAsync( ruleName );
        var rule = resp.Content!;

        if ( rule.Status == EventRuleStatus.Disabled )
            return new SftpGoResponse<NullResponse>( new NullResponse() );

        rule.Status = EventRuleStatus.Disabled;
        return await EventRuleUpdateAsync( resp.Content! );
    }
}