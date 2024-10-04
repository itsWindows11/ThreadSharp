---
title: ThreadsBeforeAfterException
---

# [ThreadSharp](../).[Exceptions](./).ThreadsBeforeAfterException

## Definition

```c#
internal class ThreadsBeforeAfterException : ThreadsException
```

Represents the exception used when both the Before and After properties are set when fetching Threads posts.

Derived from: [`ThreadsException`](./ThreadsException).

## Constructors

```c#
internal ThreadsBeforeAfterException()
    : base("Both Before and After parameters cannot be set at the same time when fetching Threads posts.")
```