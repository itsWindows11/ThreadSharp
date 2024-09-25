using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api;

/// <summary>
/// Represents a container that contains a Threads ID, could be a media container.
/// </summary>
public class ThreadsIdContainer : BaseJsonUnrecognizedDataModel
{
    /// <summary>
    /// The ID of the item.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }
}