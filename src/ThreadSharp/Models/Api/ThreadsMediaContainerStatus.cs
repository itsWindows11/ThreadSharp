using System.Text.Json.Serialization;
using ThreadSharp.Converters;
using ThreadSharp.Enums;

namespace ThreadSharp.Models.Api;

/// <summary>
/// Represents the status of a media container.
/// </summary>
public sealed class ThreadsMediaContainerStatus : ThreadsIdContainer
{
    /// <summary>
    /// The status of a media container. Indicates whether the publishing went smoothly or not.
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringToThreadsPublishingStatusCodeConverter))]
    public required ThreadsPublishingStatusCode Status { get; set; }

    /// <summary>
    /// The error message, if exists.
    /// </summary>
    [JsonPropertyName("error_message")]
    [JsonConverter(typeof(StringToThreadsPublishingErrorCodeConverter))]
    public ThreadsPublishingErrorCode? ErrorMessage { get; set; }
}