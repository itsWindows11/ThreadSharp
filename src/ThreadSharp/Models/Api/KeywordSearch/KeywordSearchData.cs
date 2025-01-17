using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api.KeywordSearch;

/// <summary>
/// Represents the Threads search data for a keyword.
/// </summary>
public sealed class KeywordSearchData
{
    /// <summary>
    /// The keyword that the user has searched for in the past.
    /// </summary>
    [JsonPropertyName("keyword")]
    public required string Keyword { get; set; }

    // Why is this even an integer timestamp? - itsWindows11
    /// <summary>
    /// The keyword's search timestamp.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required long Timestamp { get; set; }
}