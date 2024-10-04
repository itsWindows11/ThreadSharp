---
title: ThreadsUserInsightFollowerDemographicsData
---

# [ThreadSharp](../../../).[Models](../../).[Api](../).[Insights](./).ThreadsUserInsightFollowerDemographicsData

## Definition

```c#
public sealed class ThreadsUserInsightFollowerDemographicsData : ThreadsUserInsightDataBase
```

Follower demographic data for Threads user insights.

Derived from: [`ThreadsUserInsightDataBase`](../ThreadsUserInsightDataBase) --> [`ThreadsIdContainer`](../ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../../BaseJsonUnrecognizedDataModel).

::: tip NOTE
In the relevant [Threads API reference for user insights](https://developers.facebook.com/docs/threads/reference/insights#get---threads-user-id--threads-insights), the property `name` is omitted as it is used as a type discriminator in the `System.Text.Json`, which is used for (de)serialization in ThreadSharp.
:::

## Properties

| Property   | Type                                                                                          | Summary                      | Default Value |
|------------|-----------------------------------------------------------------------------------------------|------------------------------|---------------|
| TotalValue | [`ThreadsUserInsightFollowerDemographicsValue`](#threadsuserinsightfollowerdemographicsvalue) | The total value of the data. | `null`        |

## Nested Classes

---

### ThreadsUserInsightFollowerDemographicsValue

#### Definition

```c#
public sealed class ThreadsUserInsightFollowerDemographicsValue
```

Total value of the data.

#### Properties

| Property      | Type                                                                                                                | Summary         | Default Value |
|---------------|---------------------------------------------------------------------------------------------------------------------|-----------------|---------------|
| BreakdownData | [`List<ThreadsUserInsightFollowerDemographicsBreakdownData>`](#threadsuserinsightfollowerdemographicsbreakdowndata) | Breakdown data. | --            |

### ThreadsUserInsightFollowerDemographicsValue.ThreadsUserInsightFollowerDemographicsBreakdownData

#### Definition

```c#
public sealed class ThreadsUserInsightFollowerDemographicsBreakdownData
```

Breakdown data.

#### Properties

| Property      | Type                                                                 | Summary                                     | Default Value |
|---------------|----------------------------------------------------------------------|---------------------------------------------|---------------|
| DimensionKeys | `string[]`                                                           | Dimension keys as specified in the request. | --            |
| Results       | [`List<ThreadsUserInsightFollowerDemographicsBreakdownDataValue>`]() | The results of the breakdown data.          | --            |

### ThreadsUserInsightFollowerDemographicsValue.ThreadsUserInsightFollowerDemographicsBreakdownData.ThreadsUserInsightFollowerDemographicsBreakdownDataValue

#### Definition

```c#
public sealed class ThreadsUserInsightFollowerDemographicsBreakdownDataValue
```

The breakdown data item.

#### Properties

| Property        | Type       | Summary                               | Default Value |
|-----------------|------------|---------------------------------------|---------------|
| DimensionValues | `string[]` | The dimension values.                 | --            |
| Value           | `int`      | The value of the breakdown data item. | --            |