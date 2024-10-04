# Insights

This document explains how to get, and work with Threads insights for either the media or the currently authenticated user as a whole.

## Media Insights

To get media insights, you first have to know the media container ID of the thread you want insights for. Then, you can pass this ID to the [`GetForPostAsync()`](/api-reference/ThreadSharp/Internal/ThreadsInsightsClient) method on the [insights client](#insights-client) in order to get insights for the post. This includes metrics like views, likes, quotes, reposts etc.

You can optionally specify which metrics you want to retrieve by passing an exhaustive list of fields to the `metrics` parameter.

Below is an example for getting only the like, quote & repost metrics:

```c#
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
var threadsClient = GetThreadsClient();

var insightsResult = await threadsClient.Insights.GetForPostAsync("[thread ID]", ["likes", "quotes", "reposts"]);

// Work with the result.
```

For more details, refer to the [official docs](https://developers.facebook.com/docs/threads/insights#media-insights).

## User Insights

For getting the user insights, you can use the [`GetForCurrentUserAsync()`](/api-reference/ThreadSharp/Internal/ThreadsInsightsClient#methods) method on the [insights client](#insights-client).

::: caution IMPORTANT
If you are retrieving follower demographics, you must specify the `breakdown` parameter, or else an exception will be thrown.
:::

See the "[Getting User Insights](https://github.com/itsWindows11/ThreadSharp/tree/main/src/Samples/GetInsightsSample)" sample for an idea on how retrieving user insights work.

For more details, refer to the [official docs](https://developers.facebook.com/docs/threads/insights#user-insights).

## Definitions

### Insights Client

An instance of [`ThreadsInsightsClient`](/api-reference/ThreadSharp/Internal/ThreadsInsightsClient), usually obtained from a `ThreadsClient`'s `Insights` property.