namespace SftpGo;

/// <summary />
public class AuthenticateData
{
    /// <summary />
    public string Username { get; set; } = default!;

    /// <summary />
    public string Password { get; set; } = default!;

    /// <summary />
    public string? OneTimePad { get; set; }
}