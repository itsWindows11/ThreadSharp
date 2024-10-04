---
title: ThreadsPublishingLimitData
---

# [ThreadSharp](../../).[Models](../).[Api](./).ThreadsPublishingLimitData

## Definition

```c#
public sealed class ThreadsPublishingLimitData : BaseJsonUnrecognizedDataModel
```

Derived from: [`BaseJsonUnrecognizedDataModel`](../BaseJsonUnrecognizedDataModel).

## Properties

| Property         | Type                          | Summary                 | Default Value |
|------------------|-------------------------------|-------------------------|---------------|
| QuotaUsage       | `int`                         | The post quota usage.   | 0             |
| ReplyQuotaUsage  | `int`                         | The reply quota usage.  | 0             |
| QuotaConfig      | [`QuotaConfig`](#quotaconfig) | Config for post quota.  | `null`        |
| ReplyQuotaConfig | [`QuotaConfig`](#quotaconfig) | Config for reply quota. | `null`        |

## Nested Classes

---

### QuotaConfig

#### Definition

```c#
public sealed class QuotaConfig
```

Quota config.

#### Properties

| Property      | Type  | Summary                                         | Default Value |
|---------------|-------|-------------------------------------------------|---------------|
| QuotaTotal    | `int` | The total quota.                                | 0             |
| QuotaDuration | `int` | The duration remaining for the quota to expire. | 0             |

#### Methods

| Method       | Summary                                                                               | Return Value |
|--------------|---------------------------------------------------------------------------------------|--------------|
| `ToString()` | Returns a string that represents the current object.<br>**This method is overriden.** | `string`     |