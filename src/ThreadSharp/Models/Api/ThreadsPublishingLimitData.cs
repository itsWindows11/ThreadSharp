using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api;

/// <summary>
/// Publishing data information.
/// </summary>
public sealed class ThreadsPublishingLimitData : BaseJsonUnrecognizedDataModel
{
    /// <summary>
    /// The post quota usage.
    /// </summary>
    [JsonPropertyName("quota_usage")]
    public int QuotaUsage { get; set; }

    /// <summary>
    /// The reply quota usage.
    /// </summary>
    [JsonPropertyName("reply_quota_usage")]
    public int ReplyQuotaUsage { get; set; }

    /// <summary>
    /// Config for post quota.
    /// </summary>
    [JsonPropertyName("config")]
    public required QuotaConfig Config { get; set; }

    /// <summary>
    /// Config for reply quota.
    /// </summary>
    [JsonPropertyName("reply_config")]
    public required QuotaConfig ReplyConfig { get; set; }

    /// <summary>
    /// Quota config.
    /// </summary>
    public sealed class QuotaConfig
    {
        /// <summary>
        /// The total quota.
        /// </summary>
        [JsonPropertyName("quota_total")]
        public int QuotaTotal { get; set; }

        /// <summary>
        /// The duration remaining for the quota to expire.
        /// </summary>
        [JsonPropertyName("quota_duration")]
        public int QuotaDuration { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Total: {QuotaTotal}, Duration: {QuotaDuration}";
        }
    }
}