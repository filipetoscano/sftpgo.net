namespace SftpGo;

/// <summary />
public class SftpGoResponse<T>
{
    /// <summary />
    public SftpGoResponse( T response )
    {
        this.Content = response;
        this.Exception = null;
    }


    /// <summary />
    public SftpGoResponse( Exception exception )
    {
        this.Exception = exception;
    }


    /// <summary />
    public bool IsSuccess { get => Content != null; }

    /// <summary />
    public Exception? Exception { get; set; }

    /// <summary />
    public T? Content { get; set; }
}


/// <summary />
public struct NullResponse
{
}