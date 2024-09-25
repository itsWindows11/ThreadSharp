namespace ThreadSharp.Enums;

/// <summary>
/// Enum representing possible error codes for media container publishing.
/// </summary>
public enum ThreadsPublishingErrorCode
{
    /// <summary>
    /// The video has failed to download from the Threads API end.
    /// </summary>
    FailedDownloadingVideo,
    /// <summary>
    /// The audio processing has failed. 
    /// </summary>
    FailedProcessingAudio,
    /// <summary>
    /// The video processing has failed.
    /// </summary>
    FailedProcessingVideo,
    /// <summary>
    /// The aspect ratio is invalid or unsupported by Threads.
    /// </summary>
    InvalidAspectRatio,
    /// <summary>
    /// The bitrate is invalid or unsupported by Threads.
    /// </summary>
    InvalidBitRate,
    /// <summary>
    /// The video duration is invalid or unsupported by Threads.
    /// </summary>
    InvalidDuration,
    /// <summary>
    /// The framerate is invalid or unsupported by Threads.
    /// </summary>
    InvalidFrameRate,
    /// <summary>
    /// The audio channels are invalid or unsupported by Threads.
    /// </summary>
    InvalidAudioChannels,
    /// <summary>
    /// The audio channel layout are invalid or unsupported by Threads.
    /// </summary>
    InvalidAudioChannelLayout,
    /// <summary>
    /// Used for unrecognized error values, or if the Threads API returns an unknown error.
    /// </summary>
    Unknown
}