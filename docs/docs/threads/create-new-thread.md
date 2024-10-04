# Creating a New Thread

This document explains how to create a new thread in two ways, using helpers or by creating & publishing media containers.

For more information regarding media container creation, check the [official docs](https://developers.facebook.com/docs/threads/posts).

## Creating a media container

To create a media container, you can call the [`CreateMediaContainerAsync()`](/api-reference/ThreadSharp/Internal/ThreadsUserClient#methods) method to create a media container.

There are different types of media containers that can be passed, below is a map of media container content wrappers correspoding to their media types in the Threads API:

| Content Type | Media Container Wrapper                                                                                                                                                                                                                            |
|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `TEXT`       | [`EmptyContainerContent`](/api-reference/ThreadSharp/Models/Api/Content/EmptyContainerContent) or [`AttachmentLinkContainerContent`](/api-reference/ThreadSharp/Models/Api/Content/AttachmentLinkContainerContent) if a link attachment is needed. |
| `IMAGE`      | [`MediaContainerContent`](/api-reference/ThreadSharp/Models/Api/Content/MediaContainerContent) w/ its `ImageUrl` property set.                                                                                                                     |
| `VIDEO`      | [`MediaContainerContent`](/api-reference/ThreadSharp/Models/Api/Content/MediaContainerContent) w/ its `VideoUrl` property set.                                                                                                                     |
| `CAROUSEL`   | [`CarouselContainerContent`](/api-reference/ThreadSharp/Models/Api/Content/CarouselContainerContent)                                                                                                                                               |

::: tip NOTES
- If the media container wrapper is of type [`MediaContainerContent`](/api-reference/ThreadSharp/Models/Api/Content/MediaContainerContent), and you want it to be a part of a carousel post, set the `IsCarouselItem` property to `true` so Threads knows that this item is going to be added to a carousel album.
- No media container wrapper other than [`MediaContainerContent`](/api-reference/ThreadSharp/Models/Api/Content/MediaContainerContent) can be used as a carousel item.
- Adding text to the post is optional if media or a carousel is attached to the post.
:::

Below are examples of creating media containers:

::: code-group
```c# [Text-only post]
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
var threadsClient = GetThreadsClient();

var textOnlyMediaContainerResult = await threadsClient.Me.CreateMediaContainerAsync(new EmptyContainerContent(), "Hello World from Threads API; using ThreadSharp!");

// Handle the result.
```

```c# [Image-only post]
// GetThreadsClient() is a placeholder method for getting a ThreadsClient.
var threadsClient = GetThreadsClient();

var imageOnlyMediaContainerResult = await threadsClient.Me.CreateMediaContainerAsync(
    new MediaContainerContent()
    {
        ImageUrl = "https://www.example.com/images/bronz-fonz.jpg"
    },
    "#BronzFonz"
);

// Handle the result.
```
:::

Optionally, you can also specify which people can reply to your post by setting the `replyControl` parameter, which is of type [`ReplyControl`](/api-reference/ThreadSharp/Enums/ReplyContol).

## Publishing a media container

To publish a media container, it's as straightforward as calling [`PublishMediaContainerAsync()`](/api-reference/ThreadSharp/Internal/ThreadsUserClient#methods) in the [user client](#user-client), along with passing the ID of the media container previously created above.

## Helpers

- A text post can be easily created by using the extension method, `CreateTextPostAsync()`, on the [user client](#user-client).

- A carousel post can be easily created by using the extension method, `CreateCarouselPostAsync()`, on the [user client](#user-client). This takes a list of media container statuses, which can be retrieved like explained in the "[Checking media container status](#checking-media-container-status)" section.

  ::: tip NOTE
  In carousel posts, all media container statuses passed must be of status [`ThreadsPublishingStatusCode.Finished`](/api-reference/ThreadSharp/Enums/ThreadsPublishingStatusCode#values), otherwise the publishing will fail.
  :::

Both of these helpers handle publishing the post behind the scenes, as well as creating the relevant media containers.

## Troubleshooting

### Quota

A quota is enforced on creating posts & replies from the Threads API, so you need to monitor the post/reply quota.

You can do this by calling [`GetPublishingLimitAsync()`](/api-reference/ThreadSharp/Internal/ThreadsUserClient#methods) on the [user client](#user-client).

### Checking media container status

To check the status of a media container with its ID, you can call the [`GetContainerStatusAsync()`](/api-reference/ThreadSharp/Internal/ThreadsThreadManagementClient) method on the [thread management client](#thread-management-client).

This can be used to create carousel posts with either the helper, or by manually creating & publishing the media containers.

## Definitions

### Thread Management Client

An instance of [`ThreadsThreadManagementClient`](/api-reference/ThreadSharp/Internal/ThreadsThreadManagementClient), usually obtained from a `ThreadsClient`'s `Threads` property.

### User Client

An instance of [`ThreadsUserClient`](/api-reference/ThreadSharp/Internal/ThreadsUserClient), usually obtained from a `ThreadsClient`'s `Me` property.