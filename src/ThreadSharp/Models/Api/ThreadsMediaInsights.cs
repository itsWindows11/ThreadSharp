using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api;

/// <summary>
/// The media insights.
/// </summary>
public sealed class ThreadsMediaInsights : BaseJsonUnrecognizedDataModel
{
    /// <summary>
    /// The number of views on a post/media container.
    /// </summary>
    [JsonPropertyName("views")]
    public long? Views { get; set; }

    /// <summary>
    /// The number of likes on a post/media container.
    /// </summary>
    [JsonPropertyName("likes")]
    public long? Likes { get; set; }

    /// <summary>
    /// The number of replies on a post/media container.
    /// </summary>
    [JsonPropertyName("replies")]
    public long? Replies { get; set; }

    /// <summary>
    /// The number of reposts on a post/media container.
    /// </summary>
    [JsonPropertyName("reposts")]
    public long? Reposts { get; set; }

    /// <summary>
    /// The number of quotes on a post/media container.
    /// </summary>
    [JsonPropertyName("quotes")]
    public long? Quotes { get; set; }
}
