---
title: ThreadsDataContainer
---

# [ThreadSharp](../).[Models](./).ThreadsDataContainer

## Definition

```c#
public sealed class ThreadsDataContainer<T>
```

Container for Threads responses where there's a `data` child.

`T`: Type for the data.

## Properties

| Property | Type                                      | Summary                    | Default Value |
|----------|-------------------------------------------|----------------------------|---------------|
| Data     | `T`                                       | The data.                  | --            |
| Paging   | [`ThreadsPagingData`](#threadspagingdata) | Paging data from the API.  | `null`        |

## Nested Classes

---

### ThreadsPagingData

#### Definition

```c#
public sealed class ThreadsPagingData
```

Paging data from the API.

#### Properties

| Property   | Type                                                                     | Summary                                   | Default Value |
|------------|--------------------------------------------------------------------------|-------------------------------------------|---------------|
| Next       | `string`                                                                 | The pointer or URL to the next page.      | `null`        |
| Previous   | `string`                                                                 | The pointer or URL to the previous page.  | `null`        |
| Cursors    | [`ThreadsPagingDataCursors`](#threadspagingdatathreadspagingdatacursors) | Cursor data.                              | `null`        |

### ThreadsPagingData.ThreadsPagingDataCursors

#### Definition

```c#
public sealed class ThreadsPagingDataCursors
```

#### Properties

| Property | Type     | Summary                                   | Default Value |
|----------|----------|-------------------------------------------|---------------|
| Before   | `string` | The pointer or URL to the previous page.  | `null`        |
| After    | `string` | The pointer or URL to the next page.      | `null`        |