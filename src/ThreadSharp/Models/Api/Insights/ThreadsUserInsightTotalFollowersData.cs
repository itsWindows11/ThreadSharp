using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api.Insights;

/// <summary>
/// Total follower data for Threads user insights.
/// </summary>
public sealed class ThreadsUserInsightTotalFollowersData : ThreadsUserInsightDataBase
{
    /// <summary>
    /// The total value of the data.
    /// </summary>
    [JsonPropertyName("total_value")]
    public ThreadsUserInsightTotalFollowersValue? TotalValue { get; set; }

    /// <summary>
    /// Value of the data.
    /// </summary>
    public sealed class ThreadsUserInsightTotalFollowersValue
    {
        /// <summary>
        /// Value of the data.
        /// </summary>
        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}