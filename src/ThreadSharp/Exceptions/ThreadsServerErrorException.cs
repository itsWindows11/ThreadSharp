namespace ThreadSharp.Exceptions;

/// <summary>
/// Represents the exception thrown when the response received from the Threads API is blank.
/// </summary>
public sealed class ThreadsServerErrorException : ThreadsException
{
    internal ThreadsServerErrorException() : base("An unknown error occurred on the Threads API end. The service may either be down currently, or this operation isn't supported by the server.")
    {
    }
}