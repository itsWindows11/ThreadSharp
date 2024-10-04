---
title: ThreadsUserInsightRepostsData
---

# [ThreadSharp](../../../).[Models](../../).[Api](../).[Insights](.).ThreadsUserInsightRepostsData

## Definition

```c#
public sealed class ThreadsUserInsightRepostsData : ThreadsUserInsightDataBase
```

Reposts data for Threads user insights.

Derived from: [`ThreadsUserInsightDataBase`](../ThreadsUserInsightDataBase) --> [`ThreadsIdContainer`](../ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../../BaseJsonUnrecognizedDataModel.md).

::: tip NOTE
In the relevant [Threads API reference for user insights](https://developers.facebook.com/docs/threads/reference/insights#get---threads-user-id--threads-insights), the property `name` is omitted as it is used as a type discriminator in the `System.Text.Json`, which is used for (de)serialization in ThreadSharp.
:::

## Properties

| Property   | Type                                                                | Summary                      | Default Value |
|------------|---------------------------------------------------------------------|------------------------------|---------------|
| TotalValue | [`ThreadsUserInsightRepostsValue`](#threadsuserinsightrepostsvalue) | The total value of the data. | `null`        |

## Nested Classes

---

### ThreadsUserInsightRepostsValue

#### Definition

```c#
public sealed class ThreadsUserInsightRepostsValue
```

Value of the data.

#### Properties

| Property | Type   | Summary            | Default Value |
|----------|--------|--------------------|---------------|
| Value    | `long` | Value of the data. | --            |