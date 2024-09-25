namespace ThreadSharp.Exceptions;

/// <summary>
/// Represents the exception used when both the Before
/// and After properties are set when fetching Threads
/// posts.
/// </summary>
internal class ThreadsBeforeAfterException : ThreadsException
{
    internal ThreadsBeforeAfterException()
        : base("Both Before and After parameters cannot be set at the same time when fetching Threads posts.")
    {
    }
}