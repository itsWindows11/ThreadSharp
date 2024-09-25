using System.Text.Json.Serialization;
using ThreadSharp.Converters;

namespace ThreadSharp.Models.Api.Insights;

/// <summary>
/// Views data for Threads user insights.
/// </summary>
public sealed class ThreadsUserInsightViewsData : ThreadsUserInsightDataBase
{
    /// <summary>
    /// List of views insight values.
    /// </summary>
    [JsonPropertyName("values")]
    public List<ThreadsUserInsightViewsValue>? Values { get; set; }

    /// <summary>
    /// Views insight value item.
    /// </summary>
    public sealed class ThreadsUserInsightViewsValue
    {
        /// <summary>
        /// The number of views.
        /// </summary>
        [JsonPropertyName("views")]
        public long Views { get; set; }

        /// <summary>
        /// The end time of the views insight item.
        /// </summary>
        [JsonPropertyName("end_time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime EndTime { get; set; }
    }
}