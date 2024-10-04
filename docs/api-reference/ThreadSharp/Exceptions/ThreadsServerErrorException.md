---
title: ThreadsServerErrorException
---

# [ThreadSharp](../).[Exceptions](./).ThreadsServerErrorException

## Definition

```c#
public sealed class ThreadsServerErrorException : ThreadsException
```

Represents the exception thrown when there's an unknown error on the Threads API end.

Derived from: [`ThreadsException`](./ThreadsException).

## Constructors

```c#
internal ThreadsServerErrorException() : base("An unknown error occurred on the Threads API end. The service may either be down currently, or this operation isn't supported by the server.")
```