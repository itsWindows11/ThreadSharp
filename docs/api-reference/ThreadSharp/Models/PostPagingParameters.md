---
title: PostPagingParameters
---

# [ThreadSharp](../).[Models](./).PostPagingParameters

## Definition

```c#
public sealed class PostPagingParameters
```

Parameters for paging posts.

## Properties

| Property | Type             | Summary                                               | Default Value |
|----------|------------------|-------------------------------------------------------|---------------|
| Limit    | `int`            | Limit of posts to retrieve.                           | 25            |
| Since    | `DateTimeOffset` | Since date for posts.                                 | `null`        |
| Until    | `DateTimeOffset` | Until date for posts.                                 | `null`        |
| Before   | `DateTimeOffset` | The date offset to begin retrieving prior posts.      | `null`        |
| After    | `DateTimeOffset` | The date offset to begin retrieving subsequent posts. | `null`        |