using System.Text.Json.Serialization;
using ThreadSharp.Converters;
using ThreadSharp.Enums;
using ThreadSharp.Models.Api.Insights;

namespace ThreadSharp.Models.Api;

/// <summary>
/// Base class for all the potential insight types.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "name", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
[JsonDerivedType(typeof(ThreadsUserInsightViewsData), typeDiscriminator: "views")]
[JsonDerivedType(typeof(ThreadsUserInsightLikesData), typeDiscriminator: "likes")]
[JsonDerivedType(typeof(ThreadsUserInsightRepostsData), typeDiscriminator: "reposts")]
[JsonDerivedType(typeof(ThreadsUserInsightRepliesData), typeDiscriminator: "replies")]
[JsonDerivedType(typeof(ThreadsUserInsightQuotesData), typeDiscriminator: "quotes")]
[JsonDerivedType(typeof(ThreadsUserInsightTotalFollowersData), typeDiscriminator: "followers_count")]
[JsonDerivedType(typeof(ThreadsUserInsightFollowerDemographicsData), typeDiscriminator: "follower_demographics")]
public class ThreadsUserInsightDataBase : ThreadsIdContainer
{
    /// <summary>
    /// The period of the insight/metric.
    /// </summary>
    [JsonPropertyName("period")]
    [JsonConverter(typeof(StringToMetricPeriodConverter))]
    public required MetricPeriod Period { get; set; }

    /// <summary>
    /// The metric title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// The metric description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}