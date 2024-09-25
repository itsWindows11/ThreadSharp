using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api.Insights;

/// <summary>
/// Quotes data for Threads user insights.
/// </summary>
public sealed class ThreadsUserInsightQuotesData : ThreadsUserInsightDataBase
{
    /// <summary>
    /// Total value of the data.
    /// </summary>
    [JsonPropertyName("total_value")]
    public ThreadsUserInsightQuotesValue? TotalValue { get; set; }

    /// <summary>
    /// Value of the data.
    /// </summary>
    public sealed class ThreadsUserInsightQuotesValue
    {
        /// <summary>
        /// Value of the data.
        /// </summary>
        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}