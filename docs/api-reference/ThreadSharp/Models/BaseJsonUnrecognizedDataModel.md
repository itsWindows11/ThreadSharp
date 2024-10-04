---
title: BaseJsonUnrecognizedDataModel
---

# [ThreadSharp](../).[Models](./).BaseJsonUnrecognizedDataModel

## Definition

```c#
public sealed class BaseJsonUnrecognizedDataModel
```

A model that is used as a base class to provide its derivatives with additional data.

::: tip REMARKS
This class is not intended for public use by apps or libraries that consume this library.
:::

## Properties

| Property         | Type                              | Summary                                                                       | Default Value |
|------------------|-----------------------------------|-------------------------------------------------------------------------------|---------------|
| UnrecognizedData | `Dictionary<string, JsonElement>` | Additional data that is available from the API, but not included in the POCO. | `null`        |