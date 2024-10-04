---
title: ThreadsUserInsightViewsData
---

# [ThreadSharp](../../../).[Models](../../).[Api](../).[Insights](./).ThreadsUserInsightViewsData

## Definition

```c#
public sealed class ThreadsUserInsightViewsData : ThreadsUserInsightDataBase
```

Views data for Threads user insights.

Derived from: [`ThreadsUserInsightDataBase`](../ThreadsUserInsightDataBase) --> [`ThreadsIdContainer`](../ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../../BaseJsonUnrecognizedDataModel).

::: tip NOTE
In the relevant [Threads API reference for user insights](https://developers.facebook.com/docs/threads/reference/insights#get---threads-user-id--threads-insights), the property `name` is omitted as it is used as a type discriminator in the `System.Text.Json`, which is used for (de)serialization in ThreadSharp.
:::

## Properties

| Property | Type                                                                  | Summary                       | Default Value |
|----------|-----------------------------------------------------------------------|-------------------------------|---------------|
| Values   | [`List<ThreadsUserInsightViewsValue>`](#threadsuserinsightviewsvalue) | List of views insight values. | `null`        |

## Nested Classes

---

### ThreadsUserInsightViewsValue

#### Definition

```c#
public sealed class ThreadsUserInsightViewsValue
```

Value of the data.

#### Properties

| Property   | Type       | Summary                                 | Default Value |
|------------|------------|-----------------------------------------|---------------|
| Views      | `long`     | Value of the data.                      | --            |
| EndTime    | `DateTime` | The end time of the views insight item. | --            |