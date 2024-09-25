namespace ThreadSharp.Enums;

/// <summary>
/// Enum representing the status code for publishing a certain media container.
/// </summary>
public enum ThreadsPublishingStatusCode
{
    /// <summary>
    /// The container is expired.
    /// </summary>
    Expired,
    /// <summary>
    /// An error occurred while creating the container.
    /// </summary>
    Error,
    /// <summary>
    /// The container has finished processing, and is ready for publishing.
    /// </summary>
    Finished,
    /// <summary>
    /// The container creation is in progress.
    /// </summary>
    InProgress,
    /// <summary>
    /// The container is published.
    /// </summary>
    Published,
    /// <summary>
    /// For undefined values.
    /// </summary>
    Unknown
}