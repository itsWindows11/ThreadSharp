# Calling API endpoints unsupported by ThreadSharp

To futureproof the ThreadSharp library, you can call the [`ThreadsClient.SendRequestAsync(HttpMethod, string endpoint)`](/api-reference/ThreadSharp/ThreadsClient#methods) method for unsupported endpoints.

::: tip NOTE
If you frequently use the [`ThreadsClient.SendRequestAsync(HttpMethod, string endpoint)`](/api-reference/ThreadSharp/ThreadsClient#methods) method for endpoints added to the Threads API but not yet supported by ThreadSharp, please report your use cases in the [issues tab](https://github.com/itsWindows11/ThreadSharp/issues) in the repository, and it will be worked on.
:::

Below is an example for getting the current user's visitor country insights in the form of a result, containing a `Dictionary<string, JsonElement>`:

```c#
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
ThreadsClient threadsClient = GetThreadsClient();

var result = await threadsClient.SendRequestAsync(HttpMethod.Get, "/me/threads_insights?metric=follower_demographics&breakdown=country");

if (result.IsSuccessStatusCode && result.Value is not null)
{
    Dictionary<string, JsonElement> insightData = result.Value;

    // Operate on specific properties by deserializing the JsonElement into the type you want, or enumerate the properties.
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```