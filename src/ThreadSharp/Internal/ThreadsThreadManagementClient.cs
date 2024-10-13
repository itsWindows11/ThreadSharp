using System.Text.Json;
using ThreadSharp.Models;
using ThreadSharp.Models.Api;
using ThreadSharp.Exceptions;
using ThreadSharp.Helpers;
using System.Net;

namespace ThreadSharp.Internal;

/// <summary>
/// Client for thread fetching &amp; management.
/// </summary>
public sealed class ThreadsThreadManagementClient
{
    private readonly Func<string> _getAccessToken;
    private readonly IThreadSharpRefitClient _refitClient;
    private readonly Func<int> _getMaxRetriesOnServerError;

    internal ThreadsThreadManagementClient(
        Func<string> getAccessToken,
        IThreadSharpRefitClient retrofitClient,
        Func<int> getMaxRetriesOnServerError)
    {
        _getAccessToken = getAccessToken;
        _refitClient = retrofitClient;
        _getMaxRetriesOnServerError = getMaxRetriesOnServerError;
    }

    /// <summary>
    /// Gets the status of a Threads media container.
    /// </summary>
    /// <param name="mediaContainerId">The ID of the media container.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either the <see cref="ThreadsMediaContainerStatus"/> or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsMediaContainerStatus>> GetContainerStatusAsync(string mediaContainerId, CancellationToken cancellationToken = default)
    {
        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = await _refitClient.GetThreadAsync(_getAccessToken(), mediaContainerId, "id,status,error_message", cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<ThreadsMediaContainerStatus>(new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<ThreadsMediaContainerStatus>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsMediaContainerStatus>(new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsMediaContainerStatus>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsMediaContainerStatus,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<ThreadsMediaContainerStatus>(content, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Gets a specific thread with its media container ID.
    /// </summary>
    /// <param name="threadId">The ID of the thread or media container.</param>
    /// <param name="fields">
    /// The exhaustive list of fields of the post that you want to retrieve.<br />
    /// See https://developers.facebook.com/docs/threads/reference/media-retrieval.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either the <see cref="ThreadsPost"/> or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsPost>> GetThreadAsync(string threadId, string[]? fields = null, CancellationToken cancellationToken = default)
    {
        if (fields is not null && (fields.Contains("status") || fields.Contains("error_message")))
            throw new ArgumentException("The fields parameter cannot contain error_message or error_code.\nDid you mean to use `ThreadsClient.Threads.GetContainerStatusAsync()`?", nameof(fields));

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = fields is not null
                ? await _refitClient.GetThreadAsync(_getAccessToken(), threadId, string.Join(",", fields), cancellationToken)
                : await _refitClient.GetThreadAsync(_getAccessToken(), threadId, cancellationToken: cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<ThreadsPost>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<ThreadsPost>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsPost>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsPost>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsPost,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<ThreadsPost>(content, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Gets replies to a specific thread.
    /// </summary>
    /// <param name="threadId">The ID of the thread or media container.</param>
    /// <param name="fields">
    /// The exhaustive list of fields of the post that you want to retrieve.<br />
    /// See https://developers.facebook.com/docs/threads/reference/media-retrieval.
    /// </param>
    /// <param name="pagingParameters">Additional parameters to use when paging threads.</param>
    /// <param name="reverse">Whether or not to retrieve the replies in reverse order.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either a list of <see cref="ThreadsPost"/>s or an error.
    /// </returns>
    public Task<ThreadsResult<List<ThreadsPost>>> GetRepliesAsync(string threadId, PostPagingParameters? pagingParameters = null, string[]? fields = null, bool reverse = false, CancellationToken cancellationToken = default)
    {
        pagingParameters ??= new PostPagingParameters();

        if (pagingParameters.Until is not null || pagingParameters.Since is not null)
            throw new InvalidOperationException("Cannot get replies for a specific post with the `until` or `since` parameter set.");

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = fields is not null
                ? await _refitClient.GetRepliesAsync(_getAccessToken(), threadId, reverse, pagingParameters, string.Join(",", fields), cancellationToken)
                : await _refitClient.GetRepliesAsync(_getAccessToken(), threadId, reverse, pagingParameters, cancellationToken: cancellationToken);

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
    /// Gets replies to a specific thread, along with the child replies as separate
    /// replies.
    /// </summary>
    /// <remarks>
    /// Note: Replies are in separate items in the list, not nested in each post.
    /// Finding out how to display replies in a tree-like manner is an exercice
    /// for the library consumer.
    /// </remarks>
    /// <param name="threadId">The ID of the thread or media container.</param>
    /// <param name="fields">
    /// The exhaustive list of fields of the post that you want to retrieve.<br />
    /// See https://developers.facebook.com/docs/threads/reference/media-retrieval.
    /// </param>
    /// <param name="pagingParameters">Additional parameters to use when paging threads.</param>
    /// <param name="reverse">Whether or not to retrieve the replies in reverse order.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either a list of <see cref="ThreadsPost"/>s or an error.
    /// </returns>
    public Task<ThreadsResult<List<ThreadsPost>>> GetConversationAsync(string threadId, PostPagingParameters? pagingParameters = null, string[]? fields = null, bool reverse = false, CancellationToken cancellationToken = default)
    {
        pagingParameters ??= new PostPagingParameters();

        if (pagingParameters.Until is not null || pagingParameters.Since is not null)
            throw new InvalidOperationException("Cannot get replies for a specific post with the `until` or `since` parameter set.");

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = fields is not null
                ? await _refitClient.GetConversationAsync(_getAccessToken(), threadId, reverse, pagingParameters, string.Join(",", fields), cancellationToken)
                : await _refitClient.GetConversationAsync(_getAccessToken(), threadId, reverse, pagingParameters, cancellationToken: cancellationToken);

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
    /// Hides or unhides a specific thread.
    /// </summary>
    /// <param name="threadId">The ID of the thread or media container.</param>
    /// <param name="hide">
    /// Whether to hide the reply or not.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either a <see cref="ThreadsManageReplyResult"/> or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsManageReplyResult>> ManageReplyAsync(string threadId, bool hide, CancellationToken cancellationToken = default)
    {
        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = await _refitClient.ManageReplyAsync(_getAccessToken(), threadId, hide, cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<ThreadsManageReplyResult>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ThreadsResult<ThreadsManageReplyResult>(error: new ThreadsUnauthenticatedException(), response.StatusCode);

                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsManageReplyResult>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsManageReplyResult>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsManageReplyResult,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<ThreadsManageReplyResult>(content, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }
}