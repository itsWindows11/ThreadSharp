using Refit;
using ThreadSharp.Enums;
using ThreadSharp.Models;
using ThreadSharp.Models.Api.Content;

namespace ThreadSharp;

internal static class Constants
{
    internal const string CurrentUserId = "me";
}

// User part for the Refit client, used as a base for the ThreadSharp wrapper.
// https://developers.facebook.com/docs/threads/reference/user
internal partial interface IThreadSharpRefitClient
{
    [Get("/v1.0/{threadsUserId}")]
    Task<ApiResponse<Stream>> GetProfileAsync(
        [AliasAs("access_token")] string accessToken,
        string threadsUserId = Constants.CurrentUserId,
        string fields = "id,username,name,threads_profile_picture_url,threads_biography,is_eligible_for_geo_gating",
        CancellationToken cancellationToken = default
    );

    [Get("/v1.0/{threadsUserId}/threads")]
    Task<ApiResponse<Stream>> GetThreadsAsync(
        [AliasAs("access_token")] string accessToken,
        PostPagingParameters pagingParameters,
        string threadsUserId = Constants.CurrentUserId,
        string fields = "id,media_product_type,media_type,media_url,permalink,owner,username,text,timestamp,shortcode,thumbnail_url,children,is_quote_post,alt_text,has_replies,reply_audience",
        int limit = 25,
        CancellationToken cancellationToken = default
    );

    [Get("/v1.0/{threadsUserId}/replies")]
    Task<ApiResponse<Stream>> GetRepliesAsync(
        [AliasAs("access_token")] string accessToken,
        PostPagingParameters pagingParameters,
        string threadsUserId = Constants.CurrentUserId,
        string fields = "id,media_product_type,media_type,media_url,permalink,username,text,timestamp,shortcode,thumbnail_url,children,is_quote_post,has_replies,root_post,replied_to,is_reply,is_reply_owned_by_me,reply_audience",
        int limit = 25,
        CancellationToken cancellationToken = default
    );

    [Get($"/v1.0/{Constants.CurrentUserId}/threads_publishing_limit")]
    Task<ApiResponse<Stream>> GetPublishingLimitAsync(
        [AliasAs("access_token")] string accessToken,
        string fields = "config,quota_usage,reply_config,reply_quota_usage",
        CancellationToken cancellationToken = default
    );
}

// Thread management part for the Refit client, used as a base for the ThreadSharp wrapper.
// https://developers.facebook.com/docs/threads/reference/insights,
// https://developers.facebook.com/docs/threads/reference/reply-management
internal partial interface IThreadSharpRefitClient
{
    [Get("/v1.0/{threadsMediaId}")]
    Task<ApiResponse<Stream>> GetThreadAsync(
        [AliasAs("access_token")] string accessToken,
        string threadsMediaId,
        string fields = "id,media_product_type,media_type,media_url,permalink,owner,username,text,timestamp,shortcode,thumbnail_url,children,is_quote_post,alt_text,has_replies,is_reply,is_reply_owned_by_me,root_post,replied_to,hide_status,reply_audience",
        CancellationToken cancellationToken = default
    );

    [Get("/v1.0/{threadsMediaId}/insights")]
    Task<ApiResponse<Stream>> GetMediaInsightsAsync(
        [AliasAs("access_token")] string accessToken,
        string metric,
        string threadsMediaId,
        CancellationToken cancellationToken = default
    );

    [Get("/v1.0/{threadsMediaId}/replies")]
    Task<ApiResponse<Stream>> GetRepliesAsync(
        [AliasAs("access_token")] string accessToken,
        string threadsMediaId,
        bool reverse,
        PostPagingParameters pagingParameters,
        string fields = "id,media_product_type,media_type,media_url,permalink,owner,username,text,timestamp,shortcode,thumbnail_url,children,is_quote_post,has_replies,root_post,replied_to,is_reply,is_reply_owned_by_me,hide_status,reply_audience",
        CancellationToken cancellationToken = default
    );

    [Get("/v1.0/{threadsMediaId}/conversation")]
    Task<ApiResponse<Stream>> GetConversationAsync(
        [AliasAs("access_token")] string accessToken,
        string threadsMediaId,
        bool reverse,
        PostPagingParameters pagingParameters,
        string fields = "id,media_product_type,media_type,media_url,permalink,owner,username,text,timestamp,shortcode,thumbnail_url,children,is_quote_post,has_replies,root_post,replied_to,is_reply,is_reply_owned_by_me,hide_status,reply_audience",
        CancellationToken cancellationToken = default
    );

    [Post("/v1.0/{threadsReplyId}/manage_reply")]
    Task<ApiResponse<Stream>> ManageReplyAsync(
        [AliasAs("access_token")] string accessToken,
        string threadsReplyId,
        bool hide,
        CancellationToken cancellationToken = default
    );

    [Get("/v1.0/{threadsUserId}/threads_insights")]
    Task<ApiResponse<Stream>> GetUserInsightsAsync(
        [AliasAs("access_token")] string accessToken,
        UserMetricPagingParameters metrics,
        string? breakdown = null,
        string threadsUserId = Constants.CurrentUserId,
        CancellationToken cancellationToken = default
    );
}

// Thread publishing part of the Refit client, used as a base for the ThreadSharp wrapper.
// https://developers.facebook.com/docs/threads/reference/publishing
internal partial interface IThreadSharpRefitClient
{
    [Get("/v1.0/{threadsMediaId}")]
    Task<ApiResponse<Stream>> GetMediaContainerAsync(
        [AliasAs("access_token")] string accessToken,
        string threadsMediaId,
        string fields = "id",
        CancellationToken cancellationToken = default
    );

    [Post($"/v1.0/{Constants.CurrentUserId}/threads")]
    Task<ApiResponse<Stream>> CreateMediaContainerAsync(
        [AliasAs("access_token")] string accessToken,
        [AliasAs("media_type")] MediaType mediaType,
        BaseMediaContainerContent postContent,
        [AliasAs("reply_control")] ReplyControl replyControl = ReplyControl.Everyone,
        [AliasAs("reply_to_id")] string? replyToId = null,
        [AliasAs("quote_post_id")] string? quotePostId = null,
        string? text = null,
        [AliasAs("allowlisted_country_codes")] string? allowlistedCountryCodes = null,
        CancellationToken cancellationToken = default
    );

    [Post($"/v1.0/{Constants.CurrentUserId}/threads_publish")]
    Task<ApiResponse<Stream>> PublishMediaContainerAsync(
        [AliasAs("access_token")] string accessToken,
        [AliasAs("creation_id")] string threadsMediaIdToPublish,
        CancellationToken cancellationToken = default
    );
}