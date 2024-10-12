using System.Net;
using System.Text.Json;
using ThreadSharp.Enums;
using ThreadSharp.Exceptions;
using ThreadSharp.Helpers;
using ThreadSharp.Models;
using ThreadSharp.Models.Api;
using ThreadSharp.Models.Api.Content;

namespace ThreadSharp.Internal;

/// <summary>
/// Client for all things user related for the current authenticated
/// user, including posting threads.
/// </summary>
public sealed class ThreadsUserClient
{
    private readonly string? _threadsUserId;

    private readonly string _accessToken;
    private readonly IThreadSharpRefitClient _refitClient;
    private readonly Func<int> _getMaxRetriesOnServerError;

    internal ThreadsUserClient(
        string accessToken,
        IThreadSharpRefitClient retrofitClient,
        Func<int> getMaxRetriesOnServerError)
    {
        _accessToken = accessToken;
        _refitClient = retrofitClient;
        _getMaxRetriesOnServerError = getMaxRetriesOnServerError;
    }

    /// <summary>
    /// Gets the profile of the user associated with this client.
    /// </summary>
    /// <remarks>
    /// Note: the user associated with this client is the authenticated user if used from <see cref="ThreadsClient.Me"/>.
    /// </remarks>
    /// <param name="fields">
    /// Exhaustive list of fields to retrieve, if not set then gets the complete profile details by default.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either the <see cref="ThreadsProfile"/> or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsProfile>> GetAsync(string[]? fields = null, CancellationToken cancellationToken = default)
    {
        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = _threadsUserId is not null
                ? (fields is not null ? await _refitClient.GetProfileAsync(_accessToken, _threadsUserId, string.Join(",", fields), cancellationToken: cancellationToken) : await _refitClient.GetProfileAsync(_accessToken, _threadsUserId, cancellationToken: cancellationToken))
                : (fields is not null ? await _refitClient.GetProfileAsync(_accessToken, string.Join(",", fields), cancellationToken: cancellationToken) : await _refitClient.GetProfileAsync(_accessToken, cancellationToken: cancellationToken));

            if (response.Content == null)
                return new ThreadsResult<ThreadsProfile>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<ThreadsProfile>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsProfile>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsProfile>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsProfile,
                cancellationToken
            );

            return new ThreadsResult<ThreadsProfile>(content, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Gets the threads of the user associated with this client.
    /// </summary>
    /// <remarks>
    /// Note: the user associated with this client is the authenticated user if used from <see cref="ThreadsClient.Me"/>.
    /// </remarks>
    /// <param name="pagingParameters">Additional parameters to use when paging threads.</param>
    /// <param name="limit">Limit for retrieving threads. Must be &gt;= 25, and &lt;= 100.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either a list of <see cref="ThreadsPost"/>s or an error.
    /// </returns>
    public Task<ThreadsResult<List<ThreadsPost>>> GetThreadsAsync(PostPagingParameters? pagingParameters = null, int limit = 25, CancellationToken cancellationToken = default)
    {
        pagingParameters ??= new PostPagingParameters();

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = _threadsUserId is not null
                ? await _refitClient.GetThreadsAsync(_accessToken, pagingParameters, _threadsUserId, limit: limit, cancellationToken: cancellationToken)
                : await _refitClient.GetThreadsAsync(_accessToken, pagingParameters, limit: limit, cancellationToken: cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<List<ThreadsPost>>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<List<ThreadsPost>>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<List<ThreadsPost>>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<List<ThreadsPost>>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsDataContainerListThreadsPost,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<List<ThreadsPost>>(content?.Data, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Gets the replies of the user associated with this client.
    /// </summary>
    /// <remarks>
    /// Note: the user associated with this client is the authenticated user if used from <see cref="ThreadsClient.Me"/>.
    /// </remarks>
    /// <param name="pagingParameters">Additional parameters to use when paging threads.</param>
    /// <param name="limit">Limit for retrieving threads. Must be &gt;= 25, and &lt;= 100.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either a list of <see cref="ThreadsPost"/>s or an error.
    /// </returns>
    public Task<ThreadsResult<List<ThreadsPost>>> GetRepliesAsync(PostPagingParameters? pagingParameters = null, int limit = 25, CancellationToken cancellationToken = default)
    {
        pagingParameters ??= new PostPagingParameters();

        if (pagingParameters.Until is not null || pagingParameters.Since is not null)
            throw new InvalidOperationException("Cannot get replies for a specific post with the `until` or `since` parameter set.");

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = _threadsUserId is not null
                ? await _refitClient.GetRepliesAsync(_accessToken, pagingParameters, _threadsUserId, limit: limit, cancellationToken: cancellationToken)
                : await _refitClient.GetRepliesAsync(_accessToken, pagingParameters, limit: limit, cancellationToken: cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<List<ThreadsPost>>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<List<ThreadsPost>>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<List<ThreadsPost>>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<List<ThreadsPost>>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsDataContainerListThreadsPost,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<List<ThreadsPost>>(content?.Data, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Gets the publishing limit of the currently authenticated user.
    /// </summary>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the associated user with this client is not the currently authenticated user.
    /// </exception>
    /// <returns>
    /// The result, containing either the <see cref="ThreadsPublishingLimitData"/> or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsPublishingLimitData>> GetPublishingLimitAsync(CancellationToken cancellationToken = default)
    {
        if (_threadsUserId is not null)
            throw new InvalidOperationException("Cannot get publishing limit for any user other than the currently authenticated one.");

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = await _refitClient.GetPublishingLimitAsync(_accessToken, cancellationToken: cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<ThreadsPublishingLimitData>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<ThreadsPublishingLimitData>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsPublishingLimitData>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsPublishingLimitData>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsDataContainerListThreadsPublishingLimitData,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<ThreadsPublishingLimitData>(content?.Data?.FirstOrDefault(), response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Gets a media container, with the provided fields.
    /// </summary>
    /// <param name="mediaContainerId">The media container ID to retrieve details of.</param>
    /// <param name="fields">Exhaustive list of fields to retrieve. Includes ID by default.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either a <see cref="ThreadsIdContainer"/> in which the
    /// additional fields are in its UnrecognizedData property, or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsIdContainer>> GetMediaContainerAsync(string mediaContainerId, string[]? fields = null, CancellationToken cancellationToken = default)
    {
        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = fields is not null
                ? await _refitClient.GetMediaContainerAsync(_accessToken, mediaContainerId, string.Join(",", fields), cancellationToken: cancellationToken)
                : await _refitClient.GetMediaContainerAsync(_accessToken, mediaContainerId, cancellationToken: cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsIdContainer>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsIdContainer,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<ThreadsIdContainer>(content, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Creates a media container.
    /// </summary>
    /// <param name="postContent">
    /// The content to use. Available types are:<br/>
    /// - <see cref="AttachmentLinkContainerContent"/><br/>
    /// - <see cref="CarouselContainerContent"/><br/>
    /// - <see cref="EmptyContainerContent"/> (for text only posts)<br/>
    /// - <see cref="MediaContainerContent"/> (for image &amp; video only containers)<br/>
    /// </param>
    /// <param name="text">The text to put in the post.</param>
    /// <param name="replyToId">The post/media container ID to reply to.</param>
    /// <param name="quotePostId">The post/media container ID to quote.</param>
    /// <param name="replyControl">An option to restrict replies or open them to everyone.</param>
    /// <param name="allowlistedCountryCodes">List of valid ISO 3166-1 alpha-2 country codes to restrict viewing the post to.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <exception cref="ThreadsException">Thrown when image/video container content is used, and text is set, or for other errors.</exception>
    /// <returns>
    /// The result, containing either a <see cref="ThreadsIdContainer"/> or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsIdContainer>> CreateMediaContainerAsync(
        BaseMediaContainerContent postContent,
        string? text = null,
        string? replyToId = null,
        string? quotePostId = null,
        ReplyControl replyControl = ReplyControl.Everyone,
        string[]? allowlistedCountryCodes = null,
        CancellationToken cancellationToken = default
    )
    {
        if (_threadsUserId is not null)
            throw new InvalidOperationException("Cannot create a media container for any user other than the currently authenticated one.");

        var mediaType = postContent switch
        {
            MediaContainerContent => ((MediaContainerContent)postContent).ImageUrl != null ? MediaType.Image : MediaType.Video,
            CarouselContainerContent => MediaType.Carousel,
            _ => MediaType.Text
        };

        if ((mediaType == MediaType.Image || mediaType == MediaType.Video) && !string.IsNullOrEmpty(text))
            throw new ThreadsException("Cannot have text set with image/video media type. Did you mean to use the `AltText` property in `MediaContainerContent`?");

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = await _refitClient.CreateMediaContainerAsync(
                _accessToken,
                mediaType,
                postContent,
                replyControl,
                text,
                replyToId,
                quotePostId,
                allowlistedCountryCodes is not null ? string.Join(",", allowlistedCountryCodes) : null,
                cancellationToken
            );

            if (response.Content == null)
                return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsIdContainer>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsIdContainer,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<ThreadsIdContainer>(content, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Publishes a media container.
    /// </summary>
    /// <param name="mediaContainerId">The ID of the media container to publish.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either a <see cref="ThreadsIdContainer"/> or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsIdContainer>> PublishMediaContainerAsync(string mediaContainerId, CancellationToken cancellationToken = default)
    {
        if (_threadsUserId is not null)
            throw new InvalidOperationException("Cannot publish a media container for any user other than the currently authenticated one.");

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = await _refitClient.PublishMediaContainerAsync(_accessToken, mediaContainerId, cancellationToken: cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsIdContainer>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsIdContainer>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsIdContainer,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<ThreadsIdContainer>(content, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }
}