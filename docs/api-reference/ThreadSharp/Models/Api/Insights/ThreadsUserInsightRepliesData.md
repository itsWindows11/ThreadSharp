---
title: ThreadsUserInsightRepliesData
---

# [ThreadSharp](../../../).[Models](../../).[Api](../).[Insights](./).ThreadsUserInsightRepliesData

## Definition

```c#
public sealed class ThreadsUserInsightRepliesData : ThreadsUserInsightDataBase
```

Replies data for Threads user insights.

Derived from: [`ThreadsUserInsightDataBase`](../ThreadsUserInsightDataBase) --> [`ThreadsIdContainer`](../ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../../BaseJsonUnrecognizedDataModel).

::: tip NOTE
In the relevant [Threads API reference for user insights](https://developers.facebook.com/docs/threads/reference/insights#get---threads-user-id--threads-insights), the property `name` is omitted as it is used as a type discriminator in the `System.Text.Json`, which is used for (de)serialization in ThreadSharp.
:::

## Properties

| Property   | Type                                                                | Summary                      | Default Value |
|------------|---------------------------------------------------------------------|------------------------------|---------------|
| TotalValue | [`ThreadsUserInsightrepliesValue`](#threadsuserinsightrepliesvalue) | The total value of the data. | `null`        |

## Nested Classes

---

### ThreadsUserInsightRepliesValue

#### Definition

```c#
public sealed class ThreadsUserInsightRepliesValue
```

Value of the data.

#### Properties

| Property | Type   | Summary            | Default Value |
|----------|--------|--------------------|---------------|
| Value    | `long` | Value of the data. | --            |