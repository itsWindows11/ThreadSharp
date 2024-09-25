using ThreadSharp.Enums;
using ThreadSharp.Internal;
using ThreadSharp.Models;
using ThreadSharp.Models.Api;
using ThreadSharp.Models.Api.Content;

namespace ThreadSharp.Helpers;

/// <summary>
/// Posting helpers for the Threads API to help make sharing easier, as sharing is caring! :)
/// </summary>
public static class ThreadsPostingHelpers
{
    /// <summary>
    /// Creates and publishes a text post without directly dealing with media containers.
    /// </summary>
    /// <param name="threadsUserClient">The client to use for publishing.</param>
    /// <param name="text">The text to use in the post.</param>
    /// <param name="replyToId">The post/media container ID to reply to.</param>
    /// <param name="replyControl">An option to restrict replies or open them to everyone.</param>
    /// <param name="allowlistedCountryCodes">List of valid ISO 3166-1 alpha-2 country codes to restrict viewing the post to.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either the <see cref="ThreadsIdContainer"/> or an error.
    /// </returns>
    public static async Task<ThreadsResult<ThreadsIdContainer>> CreateTextPostAsync(
        this ThreadsUserClient threadsUserClient,
        string text,
        string? replyToId = null,
        ReplyControl replyControl = ReplyControl.Everyone,
        string[]? allowlistedCountryCodes = null,
        CancellationToken cancellationToken = default
    )
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text must not be null or whitespace when posting.", nameof(text));

        var mediaContainerCreationResponse = await threadsUserClient.CreateMediaContainerAsync(
            new EmptyContainerContent(),
            text,
            replyToId,
            replyControl,
            allowlistedCountryCodes,
            cancellationToken
        );

        if (!mediaContainerCreationResponse.IsSuccessStatusCode || mediaContainerCreationResponse.Value is null)
            return mediaContainerCreationResponse;

        return await threadsUserClient.PublishMediaContainerAsync(mediaContainerCreationResponse.Value!.Id, cancellationToken);
    }

    /// <summary>
    /// Creates and publishes a carousel post without directly dealing with media containers.
    /// </summary>
    /// <param name="threadsUserClient">The client to use for publishing.</param>
    /// <param name="mediaContainerStatuses">The statuses of the media containers to upload.</param>
    /// <param name="text">Text to include in the carousel post. Optional.</param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <param name="replyToId">The post/media container ID to reply to.</param>
    /// <param name="replyControl">An option to restrict replies or open them to everyone.</param>
    /// <param name="allowlistedCountryCodes">List of valid ISO 3166-1 alpha-2 country codes to restrict viewing the post to.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when any of the media containers aren't successfully uploaded.
    /// </exception>
    /// <returns>
    /// The result, containing either the <see cref="ThreadsIdContainer"/> or an error.
    /// </returns>
    public static async Task<ThreadsResult<ThreadsIdContainer>> CreateCarouselPostAsync(
        this ThreadsUserClient threadsUserClient,
        IEnumerable<ThreadsMediaContainerStatus> mediaContainerStatuses,
        string? text = null,
        string? replyToId = null,
        ReplyControl replyControl = ReplyControl.Everyone,
        string[]? allowlistedCountryCodes = null,
        CancellationToken cancellationToken = default
    )
    {
        if (mediaContainerStatuses.Any(x => x.Status != ThreadsPublishingStatusCode.Finished))
            throw new ArgumentException($"All media containers must be of status \"{nameof(ThreadsPublishingStatusCode)}.{nameof(ThreadsPublishingStatusCode.Finished)}\" before a carousel post can be created.", nameof(mediaContainerStatuses));

        var mediaContainerCreationResponse = await threadsUserClient.CreateMediaContainerAsync(
            new CarouselContainerContent()
            {
                Children = mediaContainerStatuses.ToList()
            },
            text,
            replyToId,
            replyControl,
            allowlistedCountryCodes,
            cancellationToken
        );

        if (!mediaContainerCreationResponse.IsSuccessStatusCode || mediaContainerCreationResponse.Value is null)
            return mediaContainerCreationResponse;

        return await threadsUserClient.PublishMediaContainerAsync(mediaContainerCreationResponse.Value!.Id, cancellationToken);
    }
}