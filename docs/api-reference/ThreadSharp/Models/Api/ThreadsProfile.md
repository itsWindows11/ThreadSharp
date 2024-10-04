---
title: ThreadsProfile
---

# [ThreadSharp](../../).[Models](../).[Api](./).ThreadsProfile

## Definition

```c#
public sealed class ThreadsProfile : ThreadsIdContainer
```

Represents a user's Threads profile.

Derived from: [`ThreadsIdContainer`](./ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../BaseJsonUnrecognizedDataModel).

## Properties

| Property               | Type     | Summary                                           | Default Value |
|------------------------|----------|---------------------------------------------------|---------------|
| Username               | `string` | The username.                                     | `null`        |
| Name                   | `string` | The name or title of the user.                    | `null`        |
| ProfilePictureUrl      | `string` | The profile picture URL.                          | `null`        |
| Biography              | `string` | The user's biography.                             | `null`        |
| IsEligibleForGeoGating | `bool?`  | Whether or not the user can geo-gate their posts. | `null`        |

## Methods

| Method       | Summary                                                                               | Return Value |
|--------------|---------------------------------------------------------------------------------------|--------------|
| `ToString()` | Returns a string that represents the current object.<br>**This method is overriden.** | `string`     |