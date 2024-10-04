# Getting the Current User's Threads

This document explains how to get posts and replies created by the currently authenticated user, in a few different ways.

## Getting Posts

To get the user's posts, you can call [`GetThreadsAsync()`](/api-reference/ThreadSharp/Internal/ThreadsUserClient#methods) method on the [user client](#user-client).

```c#
ThreadsClient threadsClient = GetThreadsClient();

var postsResult = await threadsClient.Me.GetThreadsAsync(limit: 10);

if (postsResult.IsSuccessStatusCode && postsResult.Value is not null)
{
    List<ThreadsPost> posts = postsResult.Value;

    // Enumerate the list and/or operate on one of the posts.
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```

## Getting Replies

To get the user's replies, you can call [`GetRepliesAsync()`](/api-reference/ThreadSharp/Internal/ThreadsUserClient#methods) method on the [user client](#user-client). This returns a list of posts that represent each reply, if the request was successful.

```c#
ThreadsClient threadsClient = GetThreadsClient();

var repliesResult = await threadsClient.Me.GetRepliesAsync(limit: 10);

if (repliesResult.IsSuccessStatusCode && repliesResult.Value is not null)
{
    List<ThreadsPost> replies = repliesResult.Value;

    // Enumerate the list and/or operate on one of the replies.
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```

## Getting specific fields only

You can get specific fields to return in your response by setting the `fields` parameter to an exhaustive list of fields to request, if you don't want the extra data that comes by default.

::: tip NOTES
- The other fields not included in the list passed to the `fields` parameter will be set to `null`.
- Any fields not supported by ThreadSharp yet will be included in the response's [`UnrecognizedData`](/api-reference/ThreadSharp/Models/BaseJsonUnrecognizedDataModel) property.
- There's no guarantee that all the fields will be returned as is. For example, in some cases, the permalink is omitted.
- The post ID is always included by default.
:::

Consider the following example to get only the post text as well as the media product type, the author's username and the permalink:

```c#
ThreadsClient threadsClient = GetThreadsClient();

var postsResult = await threadsClient.Me.GetThreadsAsync(fields: ["text", "permalink", "username", "media_product_type"], limit: 10);

if (postsResult.IsSuccessStatusCode && postsResult.Value is not null)
{
    List<ThreadsPost> posts = postsResult.Value;

    // Enumerate the list and/or operate on one of the posts.

    // In this case, only the post's Id, Text, Permalink, Username, MediaProductType properties
    // will be non-null unless in specific cases like mentioned in the note above.
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```

## Definitions

### User Client

An instance of [`ThreadsUserClient`](/api-reference/ThreadSharp/Internal/ThreadsUserClient), usually obtained from a `ThreadsClient`'s `Me` property.