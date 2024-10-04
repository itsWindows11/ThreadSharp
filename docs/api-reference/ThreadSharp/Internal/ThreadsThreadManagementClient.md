---
title: ThreadsThreadManagementClient
---

# [ThreadSharp](../).[Internal](./).ThreadsThreadManagementClient

## Definition

```c#
public sealed class ThreadsThreadManagementClient
```

Client for thread fetching & management.

## Methods

| Method                                                                                                                                | Summary                                                                              | Return Value                                                                                                              |
|---------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------|
| `GetContainerStatusAsync(string, CancellationToken cancellationToken = default)`                                                      | Gets the status of a Threads media container.                                        | The result, containing either the [`ThreadsMediaContainerStatus`](../Models/Api/ThreadsMediaContainerStatus) or an error. |
| `GetThreadAsync(string, string[]?, CancellationToken cancellationToken = default)`                                                    | Gets a specific thread with its media container ID.                                  | The result, containing either the [`ThreadsPost`](../Models/Api/ThreadsPost) or an error.                                 |
| `GetRepliesAsync(string, PostPagingParameters?, string[]?, bool reverse = false, CancellationToken cancellationToken = default)`      | Gets replies to a specific thread.                                                   | The result, containing either a list of [`ThreadsPost`](../Models/Api/ThreadsPost)s or an error.                          |
| `GetConversationAsync(string, PostPagingParameters?, string[]?, bool reverse = false, CancellationToken cancellationToken = default)` | Gets replies to a specific thread, along with the child replies as separate replies. | The result, containing either a list of [`ThreadsPost`](../Models/Api/ThreadsPost)s or an error.                          |
| `ManageReplyAsync(string, bool hide, CancellationToken cancellationToken = default)`                                                  | Hides or unhides a specific thread.                                                  | The result, containing either a [`ThreadsManageReplyResult`](../Models/Api/ThreadsManageReplyResult) or an error.         |