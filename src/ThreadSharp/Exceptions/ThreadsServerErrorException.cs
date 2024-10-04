namespace ThreadSharp.Exceptions;

/// <summary>
/// Represents the exception thrown when there's an unknown error on the Threads API end.
/// </summary>
public sealed class ThreadsServerErrorException : ThreadsException
{
    internal ThreadsServerErrorException() : base("An unknown error occurred on the Threads API end. The service may either be down currently, or this operation isn't supported by the server.")
    {
    }
}