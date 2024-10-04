---
title: UserMetricPagingParameters
---

# [ThreadSharp](../).[Models](./).UserMetricPagingParameters

## Definition

```c#
public sealed class UserMetricPagingParameters
```

Parameters to use for paging & selecting metrics to retrieve.

## Properties

| Property  | Type                                    | Summary                                               | Default Value |
|-----------|-----------------------------------------|-------------------------------------------------------|---------------|
| Since     | `DateTimeOffset`                        | The start date for the metric data.                   | `null`        |
| Until     | `DateTimeOffset`                        | The end date for the metric data.                     | `null`        |
| Metrics   | `string[]`                              | An exhaustive list of metrics to retrieve.            | `null`        |
| Period    | [`MetricPeriod`](../Enums/MetricPeriod) | The metrics' period.                                  | `null`        |