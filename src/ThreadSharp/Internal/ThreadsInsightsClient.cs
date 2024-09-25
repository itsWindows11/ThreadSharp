using System.Text.Json;
using ThreadSharp.Enums;
using ThreadSharp.Exceptions;
using ThreadSharp.Helpers;
using ThreadSharp.Models;
using ThreadSharp.Models.Api;

namespace ThreadSharp.Internal;

/// <summary>
/// Client for all things insight/data related for the current
/// authenticated user.
/// </summary>
public sealed class ThreadsInsightsClient
{
    private readonly string _accessToken;
    private readonly IThreadSharpRefitClient _refitClient;
    private readonly Func<int> _getMaxRetriesOnServerError;

    internal ThreadsInsightsClient(
        string accessToken,
        IThreadSharpRefitClient retrofitClient,
        Func<int> getMaxRetriesOnServerError)
    {
        _accessToken = accessToken;
        _refitClient = retrofitClient;
        _getMaxRetriesOnServerError = getMaxRetriesOnServerError;
    }

    /// <summary>
    /// Gets the insights of the currently authenticated user.
    /// </summary>
    /// <param name="metricPagingParameters">
    /// Parameters to page &amp; select metrics to retrieve.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <param name="breakdown">
    /// Breakdown for follower demographics. Must be set if metrics to get contain follower demographics.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the associated user with this client is not the currently authenticated user.
    /// </exception>
    /// <returns>
    /// The result, containing either a list of <see cref="ThreadsUserInsightDataBase"/> derivatives or an error.
    /// </returns>
    public Task<ThreadsResult<List<ThreadsUserInsightDataBase>>> GetForCurrentUserAsync(UserMetricPagingParameters metricPagingParameters, Breakdown? breakdown = null, CancellationToken cancellationToken = default)
    {
        if (breakdown is not null && metricPagingParameters.Metrics?.Contains("follower_demographics") != true)
            throw new InvalidOperationException("Cannot set breakdown without the `follower_demographics` metric.");

        List<string>? breakdownStringList = null;

        if (breakdown is not null)
            breakdownStringList = [];

        if (breakdownStringList is not null && breakdown!.Value.HasFlag(Breakdown.Country))
            breakdownStringList.Add("country".ToLowerInvariant());

        if (breakdownStringList is not null && breakdown!.Value.HasFlag(Breakdown.City))
            breakdownStringList.Add("city".ToLowerInvariant());

        if (breakdownStringList is not null && breakdown!.Value.HasFlag(Breakdown.Age))
            breakdownStringList.Add("age".ToLowerInvariant());

        if (breakdownStringList is not null && breakdown!.Value.HasFlag(Breakdown.Gender))
            breakdownStringList.Add("gender".ToLowerInvariant());

        if (breakdownStringList?.Count > 3)
            throw new InvalidOperationException("Cannot have more than 3 breakdowns when `follower_demographics` is set.");

        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = breakdownStringList?.Count > 0
                ? await _refitClient.GetUserInsightsAsync(_accessToken, metricPagingParameters, string.Join(",", breakdownStringList), cancellationToken: cancellationToken)
                : await _refitClient.GetUserInsightsAsync(_accessToken, metricPagingParameters, cancellationToken: cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<List<ThreadsUserInsightDataBase>>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<List<ThreadsUserInsightDataBase>>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<List<ThreadsUserInsightDataBase>>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsDataContainerListThreadsUserInsightDataBase,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<List<ThreadsUserInsightDataBase>>(content?.Data, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }

    /// <summary>
    /// Gets insights of a specific Thread or media container.
    /// </summary>
    /// <param name="mediaContainerId">The ID of the thread or media container.</param>
    /// <param name="metrics">
    /// The metrics to retrieve. Supported metrics are `views`, `likes`, `replies`, `reposts`, `quotes`.<br />
    /// See https://developers.facebook.com/docs/threads/reference/insights.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token to use in case the caller chooses to cancel the operation.
    /// </param>
    /// <returns>
    /// The result, containing either the <see cref="ThreadsMediaInsights"/> or an error.
    /// </returns>
    public Task<ThreadsResult<ThreadsMediaInsights>> GetForPostAsync(string mediaContainerId, string[] metrics, CancellationToken cancellationToken = default)
    {
        return RetryHelpers.RetryOnServerErrorAsync(async () =>
        {
            using var response = await _refitClient.GetMediaInsightsAsync(_accessToken, string.Join(",", metrics), mediaContainerId, cancellationToken);

            if (response.Content == null)
                return new ThreadsResult<ThreadsMediaInsights>(error: new ThreadsBlankResponseException(), response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await JsonSerializer.DeserializeAsync(
                    response.Content,
                    ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement,
                    cancellationToken
                );

                if (errorContent == null)
                    return new ThreadsResult<ThreadsMediaInsights>(error: new ThreadsBlankResponseException(), response.StatusCode);

                return new ThreadsResult<ThreadsMediaInsights>(new ThreadsRequestException(errorContent), response.StatusCode);
            }

            var content = await JsonSerializer.DeserializeAsync(
                response.Content,
                ThreadsSourceGenerationContext.Default.ThreadsDataContainerThreadsMediaInsights,
                cancellationToken: cancellationToken
            );

            return new ThreadsResult<ThreadsMediaInsights>(content?.Data, response.StatusCode);
        }, _getMaxRetriesOnServerError());
    }
}