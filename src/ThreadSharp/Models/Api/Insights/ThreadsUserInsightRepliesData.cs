using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api.Insights;

/// <summary>
/// Replies data for Threads user insights.
/// </summary>
public sealed class ThreadsUserInsightRepliesData : ThreadsUserInsightDataBase
{
    /// <summary>
    /// The total value of the data.
    /// </summary>
    [JsonPropertyName("total_value")]
    public ThreadsUserInsightRepliesValue? TotalValue { get; set; }

    /// <summary>
    /// Value of the data.
    /// </summary>
    public sealed class ThreadsUserInsightRepliesValue
    {
        /// <summary>
        /// Value of the data.
        /// </summary>
        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}