using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api.Insights;

/// <summary>
/// Reposts data for Threads user insights.
/// </summary>
public sealed class ThreadsUserInsightRepostsData : ThreadsUserInsightDataBase
{
    /// <summary>
    /// The total value of the data.
    /// </summary>
    [JsonPropertyName("total_value")]
    public ThreadsUserInsightRepostsValue? TotalValue { get; set; }

    /// <summary>
    /// Value of the data.
    /// </summary>
    public sealed class ThreadsUserInsightRepostsValue
    {
        /// <summary>
        /// Value of the data.
        /// </summary>
        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}