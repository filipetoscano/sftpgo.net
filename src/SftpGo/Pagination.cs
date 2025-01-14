namespace SftpGo;

/// <summary />
public class Pagination
{
    /// <summary>
    /// The maximum number of items to return. Max value is 500, default is 100.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary />
    public int? Offset { get; set; }

    /// <summary />
    public PaginationOrder? Order { get; set; }
}


/// <summary />
public enum PaginationOrder
{
    /// <summary>
    /// Ascending
    /// </summary>
    Ascending,

    /// <summary>
    /// Descending
    /// </summary>
    Descending,
}