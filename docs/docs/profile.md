# Getting the Current User's Profile

To get the currently authenticated user's profile details, you can call [`GetAsync()`](/api-reference/ThreadSharp/Internal/ThreadsUserClient#methods) on the [user client](#user-client), optionally specifying the specific fields to retrieve.

```c#
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
var threadsClient = GetThreadsClient();

var getProfileResult = await threadsClient.Me.GetAsync();

if (getProfileResult.IsSuccessStatusCode && getProfileResult.Value is not null)
{
    ThreadsProfile profile = getProfileResult.Value;

    // Read the profile details, or get the ID.
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```

## Definitions

### User Client

An instance of [`ThreadsUserClient`](/api-reference/ThreadSharp/Internal/ThreadsUserClient), usually obtained from a `ThreadsClient`'s `Me` property.