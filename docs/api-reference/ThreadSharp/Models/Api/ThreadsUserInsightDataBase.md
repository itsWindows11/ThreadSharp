---
title: ThreadsUserInsightDataBase
---

# [ThreadSharp](../../).[Models](../).[Api](.).ThreadsUserInsightDataBase

## Definition

```c#
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "name", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
[JsonDerivedType(typeof(ThreadsUserInsightViewsData), typeDiscriminator: "views")]
[JsonDerivedType(typeof(ThreadsUserInsightLikesData), typeDiscriminator: "likes")]
[JsonDerivedType(typeof(ThreadsUserInsightRepostsData), typeDiscriminator: "reposts")]
[JsonDerivedType(typeof(ThreadsUserInsightRepliesData), typeDiscriminator: "replies")]
[JsonDerivedType(typeof(ThreadsUserInsightQuotesData), typeDiscriminator: "quotes")]
[JsonDerivedType(typeof(ThreadsUserInsightTotalFollowersData), typeDiscriminator: "followers_count")]
[JsonDerivedType(typeof(ThreadsUserInsightFollowerDemographicsData), typeDiscriminator: "follower_demographics")]
public class ThreadsUserInsightDataBase : ThreadsIdContainer
```

Base class for all the potential insight types.

Derived from: [`ThreadsIdContainer`](./ThreadsIdContainer) --> [`BaseJsonUnrecognizedDataModel`](../BaseJsonUnrecognizedDataModel).

## Properties

| Property    | Type     | Summary                           | Default Value |
|-------------|----------|-----------------------------------|---------------|
| Period      | `string` | The period of the insight/metric. | --            |
| Title       | `string` | The metric title.                 | `null`        |
| Description | `string` | The metric description.           | `null`        |