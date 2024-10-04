---
title: ThreadsException
---

# [ThreadSharp](../).[Exceptions](./).ThreadsException

## Definition

```c#
public class ThreadsException : Exception
```

Exception thrown when an error occurs in the Threads API, or when an error from the library is thrown.

::: tip REMARKS
Usually, derivatives are used instead of this class, to allow for easier handling of specific errors.
:::

## Constructors

```c#
internal ThreadsException(string message)
```

```c#
internal ThreadsException() : this(DefaultErrorMessage)
```

```c#
internal ThreadsException(string message, IEnumerable<KeyValuePair<string, JsonElement>> errorData) : this(message)
```

```c#
internal ThreadsException(IEnumerable<KeyValuePair<string, JsonElement>> errorData)
    : this(DefaultErrorMessage, errorData)
```