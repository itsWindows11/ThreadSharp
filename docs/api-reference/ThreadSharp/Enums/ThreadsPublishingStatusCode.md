---
title: ThreadsPublishingStatusCode
---

# [ThreadSharp](../).[Enums](./).ThreadsPublishingStatusCode

## Definition

```c#
public enum ThreadsPublishingStatusCode
```

Enum representing the status code for publishing a certain media container.

## Values

| Value      | Summary                                                             | Numeric Value |
|------------|---------------------------------------------------------------------|---------------|
| Expired    | The container is expired.                                           | --            |
| Error      | An error occurred while creating the container.                     | --            |
| Finished   | The container has finished processing, and is ready for publishing. | --            |
| InProgress | The container creation is in progress.                              | --            |
| Published  | The container is published.                                         | --            |
| Unknown    | For undefined values.                                               | --            |