using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api.Insights;

/// <summary>
/// Follower demographic data for Threads user insights.
/// </summary>
public sealed class ThreadsUserInsightFollowerDemographicsData : ThreadsUserInsightDataBase
{
    /// <summary>
    /// The total value of the data.
    /// </summary>
    [JsonPropertyName("total_value")]
    public ThreadsUserInsightFollowerDemographicsValue? TotalValue { get; set; }

    /// <summary>
    /// Total value of the data.
    /// </summary>
    public sealed class ThreadsUserInsightFollowerDemographicsValue
    {
        /// <summary>
        /// Breakdown data.
        /// </summary>
        [JsonPropertyName("breakdowns")]
        public required List<ThreadsUserInsightFollowerDemographicsBreakdownData> BreakdownData { get; set; }

        /// <summary>
        /// Breakdown data.
        /// </summary>
        public sealed class ThreadsUserInsightFollowerDemographicsBreakdownData
        {
            /// <summary>
            /// Dimension keys as specified in the request.
            /// </summary>
            [JsonPropertyName("dimension_keys")]
            public required string[] DimensionKeys { get; set; }

            /// <summary>
            /// The results of the breakdown data.
            /// </summary>
            [JsonPropertyName("results")]
            public required List<ThreadsUserInsightFollowerDemographicsBreakdownDataValue> Results { get; set; }

            /// <summary>
            /// The breakdown data item.
            /// </summary>
            public sealed class ThreadsUserInsightFollowerDemographicsBreakdownDataValue
            {
                /// <summary>
                /// The dimension values.
                /// </summary>
                [JsonPropertyName("dimension_values")]
                public required string[] DimensionValues { get; set; }

                /// <summary>
                /// The value of the breakdown data item.
                /// </summary>
                [JsonPropertyName("value")]
                public int Value { get; set; }
            }
        }
    }
}