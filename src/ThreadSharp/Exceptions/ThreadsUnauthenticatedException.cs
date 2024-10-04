namespace ThreadSharp.Exceptions;

/// <summary>
/// Represents the exception thrown when an invalid access token is being used.
/// </summary>
public sealed class ThreadsUnauthenticatedException : ThreadsException
{
    internal ThreadsUnauthenticatedException() : base("The access token has either expired, or an invalid access token was passed.")
    {
    }
}