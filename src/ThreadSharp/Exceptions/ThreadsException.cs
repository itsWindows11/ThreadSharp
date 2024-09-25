using System.Collections;
using System.Text.Json;

namespace ThreadSharp.Exceptions;

/// <summary>
/// Exception thrown when an error occurs in the Threads API, or when an error from the library is thrown.
/// </summary>
/// <remarks>
/// Usually, derivatives are used instead of this class, to allow for easier handling of specific errors.
/// </remarks>
public class ThreadsException : Exception
{
    private const string DefaultErrorMessage = "An unexpected error occurred.";

    /// <inheritdoc />
    /// <remarks>
    /// This contains the response from the Threads API.
    /// </remarks>
    public override IDictionary Data { get; } = new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string Message { get; }

    internal ThreadsException(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreadsException"/> class.
    /// </summary>
    internal ThreadsException() : this(DefaultErrorMessage)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreadsException"/> class.
    /// </summary>
    /// <param name="message">The message to use when throwing the exception.</param>
    /// <param name="errorData">The error data provided by the Threads API.</param>
    internal ThreadsException(string message, IEnumerable<KeyValuePair<string, JsonElement>> errorData) : this(message)
    {
        Data = errorData.ToDictionary(x => x.Key, x => x.Value.GetString())!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreadsException"/> class.
    /// </summary>
    /// <param name="errorData">The error data provided by the Threads API.</param>
    internal ThreadsException(IEnumerable<KeyValuePair<string, JsonElement>> errorData)
        : this(DefaultErrorMessage, errorData)
    { }
}