# Getting Started

## Installing ThreadSharp

Below is a shield that shows the latest version of ThreadSharp that's available:

![NuGet Version](https://img.shields.io/nuget/v/ThreadSharp)

In order to include ThreadSharp in your project, you can install the NuGet package as follows:

::: code-group
```ps [NuGet Package Manager Console (Visual Studio)]
Install-Package ThreadSharp
```

```ps [.NET CLI]
dotnet add package ThreadSharp --version [version]
```
:::

Replace `[version]` with the latest version shown in the badge above.

## Using ThreadSharp

### The Client

The client for ThreadSharp, [`ThreadsClient`](/api-reference/ThreadSharp/ThreadsClient), contains different sub-clients for different use cases, listed below.

- For any operations related to the currently authenticated user, including posting threads, you can use the [`ThreadsClient.Me`](/api-reference/ThreadSharp/ThreadsClient#properties) property to access the [`ThreadsUserClient`](/api-reference/ThreadSharp/Internal/ThreadsUserClient).
- For any operations related to thread management (excluding post/media container creation), you can use the [`ThreadsClient.Threads`](/api-reference/ThreadSharp/ThreadsClient#properties) property to access the [`ThreadsThreadManagementClient`](/api-reference/ThreadSharp/Internal/ThreadsThreadManagementClient).
- For any operations related to insights, you can use the [`ThreadsClient.Insights`](/api-reference/ThreadSharp/ThreadsClient#properties) property to access the [`ThreadsInsightsClient`](/api-reference/ThreadSharp/Internal/ThreadsInsightsClient).

### Samples

You can find a list of samples in the menu (accessed through the hamburger icon), which can be helpful for certain use cases.

Samples can be also accessed [on GitHub](https://github.com/itsWindows11/ThreadSharp/tree/main/src/Samples/).

### Nullable Properties in Models

In most of ThreadSharp's models for responses from the Threads API, all properties are nullable to allow strong typing while also allowing flexibility for choosing which fields to return, since the Threads API is GraphQL-like.

### Responses

ThreadSharp returns responses in the form of a result containing either a model or an exception describing what happened.

For example, consider the below snippet for getting only the username, profile picture and biography of the current user's Threads profile:

```c#
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
var threadsClient = GetThreadsClient();

var getProfileResult = await threadsClient.Me.GetAsync(fields: ["username", "name", "threads_profile_picture_url"]);

if (getProfileResult.IsSuccessStatusCode && getProfileResult.Value is not null)
{
    ThreadsProfile profile = getProfileResult.Value;

    // Write the username (aka. handle) as well as name.
    Console.WriteLine($"@{profile.Username}: {profile.Name}");
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```

The result here is handled without throwing any exception, unless there's an error from the library consumer's end. The library consumer can choose to throw the error or handle it like above.

Each model contained in the responses also supports getting extra data in the JSON which is not yet supported by ThreadSharp, for futureproofing.

::: tip NOTE
If you frequently use the `UnrecognizedData` property for fields added to the Threads API but not yet supported by ThreadSharp, please report your use cases in the [issues tab](https://github.com/itsWindows11/ThreadSharp/issues) in the repository, and it will be worked on.
:::

### Authentication & Token Refreshing

The Threads API conforms to the OAuth2 standard for authentication, so the library consumer will have to use the specific OAuth2 library for their platform.

Token refreshing is not handled automatically by ThreadSharp for security reasons, as a random CSRF token is needed to securely exchange tokens. As a result, the [`ThreadsClient`](/api-reference/ThreadSharp/ThreadsClient) only takes an access token.

::: tip NOTE
To handle the case where an access token is expired upon calling an API, check if the result's `Error` contains a [`ThreadsUnauthenticatedException`](/api-reference/ThreadSharp/Exceptions/ThreadsUnauthenticatedException).
:::