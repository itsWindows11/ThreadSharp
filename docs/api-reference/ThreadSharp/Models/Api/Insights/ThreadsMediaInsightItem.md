---
title: ThreadsMediaInsightItem
---

# [ThreadSharp](../../../).[Models](../../).[Api](../).[Insights](./).ThreadsMediaInsightItem

## Definition

```c#
public sealed class ThreadsMediaInsightItem : ThreadsIdContainer
```

An item representing a metric in media insights.

Derived from: [`ThreadsIdContainer`](../ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../../BaseJsonUnrecognizedDataModel).

## Properties

| Property                            | Type                                                                   | Summary                                   | Default Value |
|-------------------------------------|------------------------------------------------------------------------|-------------------------------------------|---------------|
| `Name`                              | `string`                                                               | The insight's name.                       | --            |
| `Title`                             | `string`                                                               | The insight's title.                      | --            |
| `Description`                       | `string`                                                               | The insight's description.                | --            |
| `Values`                            | [`List<ThreadsMediaInsightItemValue>?`](#ThreadsMediaInsightItemValue) | The insight's values.                     | `null`        |
| `Period`                            | [`MetricPeriod`](../../../Enums/MetricPeriod)                          | The insight's period.                     | --            |

## Nested Classes

### ThreadsMediaInsightItemValue

#### Definition

```c#
public sealed class ThreadsMediaInsightItemValue
```

#### Properties

| Property | Type  | Summary                  | Default Value |
|----------|-------|--------------------------|---------------|
| `Value`  | `int` | The value of the metric. | `0`           |