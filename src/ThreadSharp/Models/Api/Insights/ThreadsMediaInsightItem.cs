using System.Text.Json.Serialization;
using ThreadSharp.Converters;
using ThreadSharp.Enums;

namespace ThreadSharp.Models.Api.Insights;

/// <summary>
/// An item representing a metric in media insights.
/// </summary>
public sealed class ThreadsMediaInsightItem : ThreadsIdContainer
{
    /// <summary>
    /// The insight's name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The insight's title.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The insight's description.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// The insight's values.
    /// </summary>
    [JsonPropertyName("values")]
    public List<ThreadsMediaInsightItemValue>? Values { get; set; }

    /// <summary>
    /// The insight's period
    /// </summary>
    [JsonPropertyName("period")]
    [JsonConverter(typeof(StringToMetricPeriodConverter))]
    public MetricPeriod Period { get; set; }

    /// <summary>
    /// Value item for a media insights metric.
    /// </summary>
    public sealed class ThreadsMediaInsightItemValue
    {
        /// <summary>
        /// The value of the metric.
        /// </summary>
        [JsonPropertyName("value")]
        public required int Value { get; set; }
    }
}