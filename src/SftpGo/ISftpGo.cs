﻿namespace SftpGo;

/// <summary>
/// Client for SftpGo API.
/// </summary>
public interface ISftpGo
{
    /// <summary>
    /// Use an AuthToken for authentication. Required for some objects.
    /// </summary>
    /// <param name="authToken">Authentication token.</param>
    void UseAuthToken( string authToken );

    /// <summary>
    /// Use an API key for authentication.
    /// </summary>
    /// <param name="apikey">API key.</param>
    void UseApiKey( string apikey );


    /// <summary>
    /// Authenticates a user in order to obtain an AuthToken.
    /// </summary>
    /// <param name="data">Authentication data.</param>
    /// <returns>Auth token.</returns>
    Task<SftpGoResponse<AuthenticateResult>> AuthenticateAsync( AuthenticateData data );


    /// <summary>
    /// Retrieves a list of API keys. Requires AuthToken.
    /// </summary>
    /// <returns>List of API keys.</returns>
    Task<SftpGoResponse<List<ApiKey>>> ApiKeyListAsync();

    /// <summary>
    /// Creates an API key. Requires AuthToken.
    /// </summary>
    /// <param name="data">Data for key creation.</param>
    /// <returns>Created API key.</returns>
    Task<SftpGoResponse<ApiKeyResult>> ApiKeyCreateAsync( ApiKeyData data );

    /// <summary>
    /// Deletes an API key. Requires AuthToken.
    /// </summary>
    /// <param name="keyId">Key identifier.</param>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> ApiKeyDeleteAsync( string keyId );


    /// <summary>
    /// Retrieves SFTPGo version information.
    /// </summary>
    /// <returns>Version information.</returns>
    Task<SftpGoResponse<Version>> VersionGetAsync();

    /// <summary>
    /// Retrieves services status from the SFTPGo server.
    /// </summary>
    /// <returns>Service status.</returns>
    Task<SftpGoResponse<ServicesStatus>> StatusGetAsync();


    /// <summary>
    /// Retrieves a page of SFTP users.
    /// </summary>
    /// <param name="pagination">Pagination.</param>
    /// <returns>List of users.</returns>
    Task<SftpGoResponse<List<User>>> UserListAsync( Pagination pagination );

    /// <summary>
    /// Retrieves a list of SFTP users.
    /// </summary>
    /// <returns>List of users.</returns>
    Task<SftpGoResponse<List<User>>> UserListAsync();

    /// <summary>
    /// Creates an SFTP user.
    /// </summary>
    /// <param name="user">User data.</param>
    /// <returns>User.</returns>
    Task<SftpGoResponse<User>> UserCreateAsync( User user );

    /// <summary>
    /// Retrieves an SFTP user.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <returns>User.</returns>
    Task<SftpGoResponse<User>> UserGetAsync( string username );

    /// <summary>
    /// Updates an SFTP user.
    /// </summary>
    /// <param name="user">User data.</param>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> UserUpdateAsync( User user );

    /// <summary>
    /// Deletes an SFTP user.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> UserDeleteAsync( string username );

    /// <summary>
    /// Enables an SFTP user.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> UserEnableAsync( string username );

    /// <summary>
    /// Disables an SFTP user.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> UserDisableAsync( string username );



    /// <summary>
    /// Retrieves a list of event actions.
    /// </summary>
    /// <returns>Event actions.</returns>
    Task<SftpGoResponse<List<EventAction>>> EventActionListAsync();

    /// <summary>
    /// Creates an event actions.
    /// </summary>
    /// <returns>Event action.</returns>
    Task<SftpGoResponse<EventAction>> EventActionCreateAsync( EventAction action );

    /// <summary>
    /// Retrieves an event action.
    /// </summary>
    /// <returns>Event action.</returns>
    Task<SftpGoResponse<EventAction>> EventActionGetAsync( string actionName );

    /// <summary>
    /// Updates an event action.
    /// </summary>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> EventActionUpdateAsync( EventAction action );

    /// <summary>
    /// Deletes an event action.
    /// </summary>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> EventActionDeleteAsync( string actionName );


    /// <summary>
    /// Retrieves a list of event rules.
    /// </summary>
    /// <returns>Event rules.</returns>
    Task<SftpGoResponse<List<EventRule>>> EventRuleListAsync();

    /// <summary>
    /// Creates an event rule.
    /// </summary>
    /// <returns>Event rule.</returns>
    Task<SftpGoResponse<EventRule>> EventRuleCreateAsync( EventRule rule );

    /// <summary>
    /// Retrieves an event rule.
    /// </summary>
    /// <returns>Event rule.</returns>
    Task<SftpGoResponse<EventRule>> EventRuleGetAsync( string ruleName );

    /// <summary>
    /// Updates an event rule.
    /// </summary>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> EventRuleUpdateAsync( EventRule rule );

    /// <summary>
    /// Deletes an event rule.
    /// </summary>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> EventRuleDeleteAsync( string ruleName );

    /// <summary>
    /// Enables an event rule.
    /// </summary>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> EventRuleEnableAsync( string ruleName );

    /// <summary>
    /// Disables an event rule.
    /// </summary>
    /// <returns>API response.</returns>
    Task<SftpGoResponse<NullResponse>> EventRuleDisableAsync( string ruleName );
}