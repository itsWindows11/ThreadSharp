---
title: ThreadsPost
---

# [ThreadSharp](../../).[Models](../).[Api](.).ThreadsPost

## Definition

```c#
public sealed class ThreadsPost : ThreadsIdContainer
```

Represents a Threads post.

Derived from: [`ThreadsIdContainer`](./ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../BaseJsonUnrecognizedDataModel).

## Properties

| Property          | Type                                                                        | Summary                                                               | Default Value |
|-------------------|-----------------------------------------------------------------------------|-----------------------------------------------------------------------|---------------|
| MediaProductType  | `string`                                                                    | The media product type. Usually has the value `"THREADS"`.            | `null`        |
| MediaType         | [`ThreadsPostMediaType`](../../Enums/ThreadsPostMediaType)                  | The post's media type.                                                | `null`        |
| MediaUrl          | `string`                                                                    | The media URL of the post, if it contains a single image or video.    | `null`        |
| LinkAttachmentUrl | `string`                                                                    | The attached link's URL, if exists.                                   | `null`        |
| Permalink         | `string`                                                                    | The post's permalink.                                                 | `null`        |
| Owner             | [`ThreadsIdContainer`](./ThreadsIdContainer)                                | The owner data.                                                       | `null`        |
| Username          | `string`                                                                    | The post author's username.                                           | `null`        |
| Text              | `string`                                                                    | The post text.                                                        | `null`        |
| Timestamp         | `DateTime?`                                                                 | The date the post was created.                                        | `null`        |
| Shortcode         | `string`                                                                    | The post's shortcode.                                                 | `null`        |
| ThumbnailUrl      | `string`                                                                    | The URL of the post thumbnail, usually from a link.                   | `null`        |
| Children          | [`ThreadsDataContainer<List<ThreadsIdContainer>>`](../ThreadsDataContainer) | List of children media container IDs, if the post is a carousel post. | `null`        |
| IsQuotePost       | `bool`                                                                      | Whether or not the post quotes someone else's post.                   | `false`       |
| AltText           | `string`                                                                    | Alt text for single image/video post.                                 | `null`        |
| HasReplies        | `bool`                                                                      | Whether or not the post has replies.                                  | `false`       |
| IsReply           | `bool`                                                                      | Whether or not the post is a reply to another post.                   | `false`       |
| IsReplyOwnedByMe  | `bool`                                                                      | Whether the reply is owned by the currently authenticated user.       | `false`       |
| RootPost          | [`ThreadsIdContainer`](./ThreadsIdContainer)                                | The root post.                                                        | `null`        |
| RepliedTo         | [`ThreadsIdContainer`](./ThreadsIdContainer)                                | The media container ID of the parent post.                            | `null`        |
| HideStatus        | TBD, for now this is `string`.                                              | The post's hide status.                                               | `null`        |
| ReplyAudience     | TBD, for now this is `string`.                                              | The reply audience.                                                   | `null`        |

## Methods

| Method       | Summary                                                                               | Return Value |
|--------------|---------------------------------------------------------------------------------------|--------------|
| `ToString()` | Returns a string that represents the current object.<br>**This method is overriden.** | `string`     |