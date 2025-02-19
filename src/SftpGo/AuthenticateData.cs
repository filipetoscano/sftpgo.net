namespace SftpGo;

/// <summary />
public class AuthenticateData
{
    /// <summary>
    /// User name.
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    /// User password, in clear.
    /// </summary>
    public string Password { get; set; } = default!;

    /// <summary>
    /// (OTP) One time pad, for users which have (2FA) Two Factor Authentication enabled.
    /// </summary>
    public string? OneTimePad { get; set; }
}