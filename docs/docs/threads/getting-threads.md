# Getting Threads by ID & Replies

This document explains how to get a media container or post by its ID, as well as getting its replies if the post's published.

## Getting a thread by ID

To get a thread from its ID, you can use the [`GetThreadAsync()`](/api-reference/ThreadSharp/Internal/ThreadsThreadManagementClient#methods) method on the [thread management client](#thread-management-client), providing it with a thread or media container ID, and optionally the specific fields you want to retrieve.

Below is an example that gets a thread with all the available fields (i.e. the `fields` parameter is not set), then prints the post permalink and the text.

```c#
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
var threadsClient = GetThreadsClient();

var threadResult = await threadsClient.Threads.GetThreadAsync("[thread ID]");

if (threadResult.IsSuccessStatusCode && threadResult.Value is not null)
{
    ThreadsPost post = threadResult.Value;

    // Print the permalink as well as the text.
    Console.WriteLine($"Permalink: {post.Permalink}"");
    Console.WriteLine($"Text: {post.Text}");
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```

## Getting replies of a thread

With a thread's ID, you can also retrieve replies, or the entire conversation, which is a list of replies with its child replies as separate items. No nesting involved here.

### Getting only the top-level replies

To get only the top-level replies, you can use the [`GetRepliesAsync()`](/api-reference/ThreadSharp/Internal/ThreadsThreadManagementClient#methods) method on the [thread management client](#thread-management-client), providing it with a thread or media container ID, and optionally the specific fields you want to retrieve  for each reply.

Below is an example that retrieves the top-level replies:

```c#
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
var threadsClient = GetThreadsClient();

var repliesResult = await threadsClient.Threads.GetRepliesAsync("[thread ID]");

if (repliesResult.IsSuccessStatusCode && repliesResult.Value is not null)
{
    List<ThreadsPost> replies = repliesResult.Value;

    // Operate on each reply in the list.
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```

### Getting replies w/ children replies

If you want the top-level replies along with their children, you can use the [`GetConversationAsync()`](/api-reference/ThreadSharp/Internal/ThreadsThreadManagementClient#methods) method on the [thread management client](#thread-management-client), providing it with a thread or media container ID, and optionally the specific fields you want to retrieve for each reply.

Below is an example that retrieves the replies, along with the children replies, and filters child replies from the top level ones:

```c#
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
var threadsClient = GetThreadsClient();

var repliesResult = await threadsClient.Threads.GetConversationAsync("[thread ID]");

if (repliesResult.IsSuccessStatusCode && repliesResult.Value is not null)
{
    List<ThreadsPost> replies = repliesResult.Value;

    foreach (var replyPost in replies)
    {
        if (replyPost.RepliedTo is not null)
            // Child reply, use its Id property to get the reply ID.
        else
        {
            // Top-level reply.
        }
    }
} else
{
    // Handle gracefully based on the exception data in the result's "Error" property & the Value if exists.
}
```

A recursive reply tree can be created by filtering the replies and seeing if the `RepliedTo`'s `Id` property matches the top-level reply.

## Definitions

### Thread Management Client

An instance of [`ThreadsThreadManagementClient`](/api-reference/ThreadSharp/Internal/ThreadsThreadManagementClient), usually obtained from a `ThreadsClient`'s `Threads` property.