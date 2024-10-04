using Refit;
using ThreadSharp.Enums;

namespace ThreadSharp.Models;

/// <summary>
/// Parameters to use for paging &amp; selecting metrics to retrieve.
/// </summary>
public sealed class UserMetricPagingParameters
{
    private string[]? _metrics;

    /// <summary>
    /// The start date for the metric data.
    /// </summary>
    [AliasAs("since")]
    public DateTimeOffset? Since { get; set; }

    /// <summary>
    /// The end date for the metric data.
    /// </summary>
    [AliasAs("until")]
    public DateTimeOffset? Until { get; set; }

    /// <summary>
    /// An exhaustive list of metrics to retrieve.
    /// </summary>
    [AliasAs("metric")]
    [Query(CollectionFormat.Csv)]
    public string[]? Metrics
    {
        get => _metrics;
        set
        {
            if (value?.Contains("follower_demographics") == true && (Since.HasValue || Until.HasValue))
                throw new InvalidOperationException("Cannot retrieve follower demographics with `since` and `until` parameters set.");

            _metrics = value;
        }
    }

    /// <summary>
    /// The metrics' period.
    /// </summary>
    [AliasAs("period")]
    public MetricPeriod? Period { get; set; }
}