---
title: ThreadsUserClient
---

# [ThreadSharp](../).[Internal](./).ThreadsUserClient

## Definition

```c#
public sealed class ThreadsUserClient
```

Client for all things user related for the current authenticated user, including posting threads.

## Methods

| Method                                                                                                                                                                                                  | Summary                                                        | Return Value                                                                                                                                                               |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `GetAsync(string[]?, CancellationToken cancellationToken = default)`                                                                                                                                    | Gets the profile of the user associated with this client.      | The result, containing either the [`ThreadsProfile`](../Models/Api/ThreadsProfile) or an error.                                                                            |
| `GetThreadsAsync(PostPagingParameters?, int limit = 25, CancellationToken cancellationToken = default)`                                                                                                 | Gets the threads of the user associated with this client.      | The result, containing either a list of [`ThreadsPost`](../Models/Api/ThreadsPost)s or an error.                                                                           |
| `GetRepliesAsync(PostPagingParameters?, int limit = 25, CancellationToken cancellationToken = default)`                                                                                                 | Gets the replies of the user associated with this client.      | The result, containing either a list of [`ThreadsPost`](../Models/Api/ThreadsPost)s or an error.                                                                           |
| `GetPublishingLimitAsync(CancellationToken cancellationToken = default)`                                                                                                                                | Gets the publishing limit of the currently authenticated user. | The result, containing either the [`ThreadsPublishingLimitData`](../Models/Api/ThreadsPublishingLimitData) or an error.                                                    |
| `GetMediaContainerAsync(string, string[]?, CancellationToken cancellationToken = default)`                                                                                                              | Gets a media container, with the provided fields.              | The result, containing either a [`ThreadsIdContainer`](../Models/Api/ThreadsIdContainer) in which the additional fields are in its UnrecognizedData property, or an error. |
| `CreateMediaContainerAsync(BaseMediaContainerContent, string?, string?, ReplyControl = ReplyControl.Everyone, string[]? allowlistedCountryCodes = null, CancellationToken cancellationToken = default)` | Creates a media container.                                     | The result, containing either a [`ThreadsIdContainer`](../Models/Api/ThreadsIdContainer) or an error.                                                                      |
| `PublishMediaContainerAsync(string mediaContainerId, CancellationToken cancellationToken = default)`                                                                                                    | Publishes a media container.                                   | The result, containing either a [`ThreadsIdContainer`](../Models/Api/ThreadsIdContainer) or an error.                                                                      |