---
title: ThreadsBlankResponseException
---

# [ThreadSharp](../).[Exceptions](./).ThreadsBlankResponseException

## Definition

```c#
internal class ThreadsBlankResponseException : ThreadsException
```

Represents the exception thrown when the response received from the Threads API is blank.

Derived from: [`ThreadsException`](./ThreadsException).

## Constructors

```c#
internal ThreadsBlankResponseException()
    : base("Response received from the Threads API is blank.")
```