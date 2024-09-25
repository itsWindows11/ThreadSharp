using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api;

/// <summary>
/// Represents a user's Threads profile.
/// </summary>
public sealed class ThreadsProfile : ThreadsIdContainer
{
    /// <summary>
    /// The username.
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// The name or title of the user.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The profile picture URL.
    /// </summary>
    [JsonPropertyName("threads_profile_picture_url")]
    public string? ProfilePictureUrl { get; set; }

    /// <summary>
    /// The user's biography.
    /// </summary>
    [JsonPropertyName("threads_biography")]
    public string? Biography { get; set; }

    /// <summary>
    /// Whether or not the user can geo-gate their posts.
    /// </summary>
    [JsonPropertyName("is_eligible_for_geo_gating")]
    public bool? IsEligibleForGeoGating { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => (Username != null ? "@" + Username : base.ToString())!;
}