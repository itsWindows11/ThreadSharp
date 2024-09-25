![ThreadSharp banner](https://github.com/itsWindows11/ThreadSharp/blob/main/assets/banner.png?raw=true)

# <center>ThreadSharp</center>
<center>A C# API wrapper for the Threads API.</center>

## Table of Contents

1. [Documentation](#documentation):
	- [Authentication](#authentication).
	- [Response Model](#response-model).
	- [Creating Threads](#creating-threads).
	- [Insights](#insights).
2. [Samples](#samples):
	- [Running the samples](#running-the-samples).
	- [Getting current user details]().
	- [Getting current user insights]().
	- [Replying to self]().

## Documentation

### Authentication

For more information regarding authentication, refer to the [official docs](https://developers.facebook.com/docs/threads/get-started) to get started with authentication.

Refreshing tokens is completely the library consumer's responsibility, for now.

### Response Model

In ThreadSharp, the result model is used to return responses, so the library consumer can handle errors gracefully and without too much overhead.



### Creating Threads

There are a few ways to create threads using the library. The most simple way is to use the helper methods as follows:

```csharp
var accessToken = GetAccessToken();
using var threadsClient = new ThreadsClient(accessToken);

// Create a text post.
var textPostResult = await threadsClient.Me.CreateTextPostAsync("Hello, World!", replyControl: ReplyControl.Everyone);
var textPost = textPostResult.Value;

// Create a carousel post with media container statuses.
var mediaContainerStatus1 = await threadsClient.Threads.GetContainerStatusAsync("(media-container-1-id)");
var mediaContainerStatus2 = await threadsClient.Threads.GetContainerStatusAsync("(media-container-2-id)");

if (mediaContainerStatus1.Value is { Status: ThreadsPublishingStatusCode.Finished } && mediaContainerStatus2.Value is { Status: ThreadsPublishingStatusCode.Finished })
{
    var carouselPostResult = await threadsClient.Me.CreateCarouselPostAsync(
        new List<ThreadsMediaContainerStatus> { mediaContainerStatus1.Value, mediaContainerStatus2.Value },
        replyControl: ReplyControl.Everyone
    );
    var carouselPost = carouselPostResult.Value;
}
```

You can also create threads in a fashion similar to how the API does it. This is useful if you want to create carousel item containers, as well as image/video only posts.

```csharp
var accessToken = GetAccessToken();
using var threadsClient = new ThreadsClient(accessToken);

// Create a text post.
var textMediaContainerCreationResult = await threadsClient.Me.CreateMediaContainerAsync(
    new EmptyContainerContent(),
    "Hello World!",
    replyControl: ReplyControl.Everyone
);

if (textMediaContainerCreationResult.Value is not null)
{
    var publishResult = await threadsClient.Me.PublishMediaContainerAsync(textMediaContainerCreationResult.Value.Id);
}

// Create a carousel post.
var image1ContainerResult = await threadsClient.Me.CreateMediaContainerAsync(
    new MediaContainerContent()
    {
        ImageUrl = "https://www.example.com/images/bronz-fonz.jpg",
        IsCarouselItem = true
    },
    "Image 1",
    replyControl: ReplyControl.Everyone
);

// Arbitrary delay as recommended by Threads documentation in:
// https://developers.facebook.com/docs/threads/posts#step-2--publish-a-threads-media-container
// Your mileage may vary depending on the media you upload.
await Task.Delay(30 * 1000);

if (image1ContainerResult.Value is not null)
{
    var image1ContainerStatusResult = await threadsClient.Threads.GetContainerStatusAsync(image1ContainerResult.Value.Id);

    if (image1ContainerStatusResult.Value is { Status: ThreadsPublishingStatusCode.Finished })
    {
        var carouselContainerCreationResult = await threadsClient.Me.CreateMediaContainerAsync(
			new CarouselContainerContent()
			{
				Children = new List<ThreadsMediaContainerStatus> { image1ContainerStatusResult.Value }
			},
			text: "Sample Carousel Post",
			replyControl: ReplyControl.Everyone
		);

        if (carouselContainerCreationResult.Value is not null)
        {
            var publishResult = await threadsClient.Me.PublishMediaContainerAsync(carouselContainerCreationResult.Value.Id);
            ...
        }
    }
}
```

### Insights

## Samples

### Running the samples

In order to run the samples, you must set a `THREADS_ACCESS_TOKEN` environment variable for the samples to use.

For more information regarding authentication and getting an access token for your account, refer to the [official docs](https://developers.facebook.com/docs/threads/get-started).