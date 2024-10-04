---
title: ThreadsClient
---

# [ThreadSharp](.).ThreadsClient

## Definition

```c#
public sealed class ThreadsClient : IDisposable
```

The client to use for interacting with the Threads API.

Derived from: `IDisposable`.

## Constructors

```c#
public ThreadsClient(string accessToken)
```

Creates an instance of [ThreadsClient](./ThreadsClient) which doesn't automatically renew the access token.

`accessToken`: The access token to call the Threads API with.

## Properties

| Property                | Type                                                                        | Summary                                                                                                                                    | Default Value |
|-------------------------|-----------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|---------------|
| MaxRetriesOnServerError | `int`                                                                       | The maximum amount of retries to do when a request fails on the Threads API's end.                                                         | 5             |
| BackingClient           | `HttpClient`                                                                | The backing HttpClient for the client. **Use of the `SendRequestAsync(HttpMethod, string)` method is preferred over using this directly.** | --            |
| Me                      | [`ThreadsUserClient`](./Internal/ThreadsUserClient)                         | Client for all things user related for the current authenticated user, including posting threads.                                          | --            |
| Threads                 | [`ThreadsThreadManagementClient`](./Internal/ThreadsThreadManagementClient) | Client for thread fetching & management.                                                                                                   | --            |
| Insights                | [`ThreadsInsightsClient`](./Internal/ThreadsInsightsClient)                 | Client for all things insight/data related for the current authenticated user.                                                             | --            |

## Methods

| Method                                 | Summary                             | Return Value                                           |
|----------------------------------------|-------------------------------------|--------------------------------------------------------|
| `SendRequestAsync(HttpMethod, string)` | Sends a request to the Threads API. | `Task<ThreadsResult<Dictionary<string, JsonElement>>>` |