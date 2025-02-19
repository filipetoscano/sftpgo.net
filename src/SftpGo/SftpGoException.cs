using System.Net;

namespace SftpGo;

/// <summary />
public class SftpGoException : ApplicationException
{
    /// <summary />
    public SftpGoException( HttpStatusCode statusCode, string error, string message )
        : base( error )
    {
        this.StatusCode = statusCode;
        this.ApiError = error;
        this.ApiMessage = message;
    }


    /// <summary />
    public HttpStatusCode StatusCode { get; private set; }

    /// <summary />
    public string ApiError { get; private set; }

    /// <summary />
    public string ApiMessage { get; private set; }
}