---
title: ThreadsRequestException
---

# [ThreadSharp](../).[Exceptions](./).ThreadsRequestException

## Definition

```c#
public sealed class ThreadsRequestException : ThreadsException
```

Represents the exception thrown when a request error occurrs.

Derived from: [`ThreadsException`](./ThreadsException).

## Constructors

```c#
internal ThreadsRequestException(string message, IEnumerable<KeyValuePair<string, JsonElement>> errorData) : base(message, errorData)
```

```c#
internal ThreadsRequestException(IEnumerable<KeyValuePair<string, JsonElement>> errorData) : base("A Threads API error has occurred.", errorData)
```