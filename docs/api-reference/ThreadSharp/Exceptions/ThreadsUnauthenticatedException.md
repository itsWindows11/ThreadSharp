---
title: ThreadsUnauthenticatedException
---

# [ThreadSharp](../).[Exceptions](./).ThreadsUnauthenticatedException

## Definition

```c#
public sealed class ThreadsUnauthenticatedException : ThreadsException
```

Represents the exception thrown when an invalid access token is being used.

Derived from: [`ThreadsException`](./ThreadsException).

## Constructors

```c#
internal ThreadsUnauthenticatedException() : base("The access token has either expired, or an invalid access token was passed.")
```