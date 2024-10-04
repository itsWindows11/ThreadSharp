---
title: ThreadsInsightsClient
---

# [ThreadSharp](../).[Internal](./).ThreadsInsightsClient

## Definition

```c#
public sealed class ThreadsInsightsClient
```

Client for all things insight/data related for the current authenticated user.

## Methods

| Method                                                                                                        | Summary                                                | Return Value                                                                                                                              |
|---------------------------------------------------------------------------------------------------------------|--------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| GetForCurrentUserAsync(UserMetricPagingParameters, Breakdown?, CancellationToken cancellationToken = default) | Gets the insights of the currently authenticated user. | The result, containing either a list of [`ThreadsUserInsightDataBase`](../Models/Api/ThreadsUserInsightDataBase) derivatives or an error. |
| GetForPostAsync(string mediaContainerId, string[] metrics, CancellationToken cancellationToken = default)     | Gets insights of a specific Thread or media container. | The result, containing either a list of [`ThreadsMediaInsightItem`](../Models/Api/Insights/ThreadsMediaInsightItem)s, or an error.        |