using System.Text.Json.Serialization;
using ThreadSharp.Converters;
using ThreadSharp.Enums;
using ThreadSharp.Models;

namespace ThreadSharp.Models.Api;

/// <summary>
/// Represents a Threads post.
/// </summary>
public sealed class ThreadsPost : ThreadsIdContainer
{
    /// <summary>
    /// The media product type. Usually has the value "THREADS".
    /// </summary>
    [JsonPropertyName("media_product_type")]
    public string? MediaProductType { get; set; }

    /// <summary>
    /// The post's media type.
    /// </summary>
    [JsonPropertyName("media_type")]
    [JsonConverter(typeof(StringToThreadsPostMediaTypeConverter))]
    public ThreadsPostMediaType? MediaType { get; set; }

    /// <summary>
    /// The media URL of the post, if it contains a single image or video.
    /// </summary>
    [JsonPropertyName("media_url")]
    public string? MediaUrl { get; set; }

    /// <summary>
    /// The attached link's URL, if exists.
    /// </summary>
    [JsonPropertyName("link_attachment_url")]
    public string? LinkAttachmentUrl { get; set; }

    /// <summary>
    /// The post's permalink.
    /// </summary>
    [JsonPropertyName("permalink")]
    public string? Permalink { get; set; }

    /// <summary>
    /// The owner data.
    /// </summary>
    [JsonPropertyName("owner")]
    public ThreadsIdContainer? Owner { get; set; }

    /// <summary>
    /// The post author's username.
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// The post text.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// The date the post was created.
    /// </summary>
    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? Timestamp { get; set; }

    /// <summary>
    /// The post shortcode.
    /// </summary>
    [JsonPropertyName("shortcode")]
    public string? Shortcode { get; set; }

    /// <summary>
    /// The URL of the post thumbnail, usually from a link.
    /// </summary>
    [JsonPropertyName("thumbnail_url")]
    public string? ThumbnailUrl { get; set; }

    /// <summary>
    /// List of children media container IDs, if the post is a carousel post.
    /// </summary>
    [JsonPropertyName("children")]
    public ThreadsDataContainer<List<ThreadsIdContainer>>? Children { get; set; }

    /// <summary>
    /// Whether or not the post quotes someone else's post.
    /// </summary>
    [JsonPropertyName("is_quote_post")]
    public bool IsQuotePost { get; set; } = false;

    /// <summary>
    /// Alt text for single image/video post.
    /// </summary>
    [JsonPropertyName("alt_text")]
    public string? AltText { get; set; }

    /// <summary>
    /// Whether or not the post has replies.
    /// </summary>
    [JsonPropertyName("has_replies")]
    public bool HasReplies { get; set; } = false;

    /// <summary>
    /// Whether or not the post is a reply to another post.
    /// </summary>
    [JsonPropertyName("is_reply")]
    public bool IsReply { get; set; } = false;

    /// <summary>
    /// Whether the reply is owned by the currently authenticated user.
    /// </summary>
    [JsonPropertyName("is_reply_owned_by_me")]
    public bool IsReplyOwnedByMe { get; set; } = false;

    /// <summary>
    /// The root post.
    /// </summary>
    [JsonPropertyName("root_post")]
    public ThreadsIdContainer? RootPost { get; set; }

    /// <summary>
    /// The media container ID of the parent post. 
    /// </summary>
    [JsonPropertyName("replied_to")]
    public ThreadsIdContainer? RepliedTo { get; set; }

    /// <summary>
    /// The post's hide status.
    /// </summary>
    // TODO: Determine if this should be an enum.
    [JsonPropertyName("hide_status")]
    public string? HideStatus { get; set; }

    /// <summary>
    /// The reply audience.
    /// </summary>
    // TODO: Determine if this should be an enum.
    [JsonPropertyName("reply_audience")]
    public string? ReplyAudience { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Username: @{Username}, Text: \"{Text}\"";
    }
}