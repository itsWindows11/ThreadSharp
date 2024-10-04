using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api.Insights;

/// <summary>
/// Likes data for Threads user insights.
/// </summary>
public sealed class ThreadsUserInsightLikesData : ThreadsUserInsightDataBase
{
    /// <summary>
    /// The total value of the data.
    /// </summary>
    [JsonPropertyName("total_value")]
    public ThreadsUserInsightLikesValue? TotalValue { get; set; }

    /// <summary>
    /// Value of the data.
    /// </summary>
    public sealed class ThreadsUserInsightLikesValue
    {
        /// <summary>
        /// Value of the data.
        /// </summary>
        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}