---
title: ThreadsResult
---

# [ThreadSharp](../).[Models](./).ThreadsResult

## Definition

```c#
public sealed class ThreadsResult<T>
```

Result class used to wrap Threads API responses.

`T`: The type of the response body.

## Constructors

```c#
internal ThreadsResult(T? value, HttpStatusCode statusCode)
```

```c#
internal ThreadsResult(ThreadsException error, HttpStatusCode statusCode)
```

## Properties

| Property            | Type                                                 | Summary                                              | Default Value |
|---------------------|------------------------------------------------------|------------------------------------------------------|---------------|
| Value               | `T`                                                  | The value of this result. If successful, isn't null. | `null`        |
| Error               | [`ThreadsException`](../Exceptions/ThreadsException) | Paging data from the API.                            | `null`        |
| ErrorData           | `Dictionary<string, JsonElement>`                    | Additional data about the error, if one occurred.    | `null`        |
| StatusCode          | `HttpStatusCode`                                     | The status code of the result.                       | --            |
| IsSuccessStatusCode | `bool`                                               | Gets whether the status code is successful.          | --            |

## Methods

| Method       | Summary                                                                               | Return Value |
|--------------|---------------------------------------------------------------------------------------|--------------|
| `ToString()` | Returns a string that represents the current object.<br>**This method is overriden.** | `string`     |