namespace ThreadSharp.Exceptions;

/// <summary>
/// Represents the exception thrown when the response received from the Threads API is blank.
/// </summary>
public sealed class ThreadsBlankResponseException : ThreadsException
{
    internal ThreadsBlankResponseException() : base("Response received from the Threads API is blank.")
    {
    }
}