using System.Text.Json;

namespace ThreadSharp.Exceptions;

/// <summary>
/// Represents the exception thrown when a request error occurrs.
/// </summary>
public sealed class ThreadsRequestException : ThreadsException
{
    internal ThreadsRequestException(string message, IEnumerable<KeyValuePair<string, JsonElement>> errorData) : base(message, errorData)
    {
    }

    internal ThreadsRequestException(IEnumerable<KeyValuePair<string, JsonElement>> errorData) : base("A Threads API error has occurred.", errorData)
    {
    }
}