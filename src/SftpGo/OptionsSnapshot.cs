using Microsoft.Extensions.Options;

namespace SftpGo;

/// <summary />
internal class OptionsSnapshot<T> : IOptionsSnapshot<T>
    where T : class
{
    private readonly T _value;


    /// <summary />
    internal OptionsSnapshot( T value )
    {
        _value = value;
    }


    /// <inheritdoc />
    public T Value => _value;


    /// <inheritdoc />
    public T Get( string? name )
    {
        return _value;
    }
}