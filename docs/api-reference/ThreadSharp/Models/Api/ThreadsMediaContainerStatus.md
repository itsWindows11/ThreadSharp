---
title: ThreadsMediaContainerStatus
---

# [ThreadSharp](../../).[Models](../).[Api](./).ThreadsMediaContainerStatus

## Definition

```c#
public sealed class ThreadsMediaContainerStatus : ThreadsIdContainer
```

Represents the status of a media container.

Derived from: [`ThreadsIdContainer`](ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../BaseJsonUnrecognizedDataModel).

## Properties

| Property       | Type                                                                     | Summary                                                                                 | Default Value |
|----------------|--------------------------------------------------------------------------|-----------------------------------------------------------------------------------------|---------------|
| Status         | [`ThreadsPublishingStatusCode`](../../Enums/ThreadsPublishingStatusCode) | The status of a media container. Indicates whether the publishing went smoothly or not. | --            |
| ErrorMessage   | [`ThreadsPublishingErrorCode`](../../Enums/ThreadsPublishingErrorCode)   | The error message, if exists.                                                           | `null`        |

## Methods

| Method       | Summary                                                                               |
|--------------|---------------------------------------------------------------------------------------|
| `ToString()` | Returns a string that represents the current object.<br>**This method is overriden.** |