---
title: ThreadsPublishingErrorCode
---

# [ThreadSharp](../).[Enums](./).ThreadsPublishingErrorCode

## Definition

```c#
public enum ThreadsPublishingErrorCode
```

Enum representing possible error codes for media container publishing.

## Values

| Value                     | Summary                                                                             | Numeric Value |
|---------------------------|-------------------------------------------------------------------------------------|---------------|
| FailedDownloadingVideo    | The video has failed to download from the Threads API end.                          | --            |
| FailedProcessingAudio     | The audio processing has failed.                                                    | --            |
| FailedProcessingVideo     | The video processing has failed.                                                    | --            |
| InvalidAspectRatio        | The aspect ratio is invalid or unsupported by Threads.                              | --            |
| InvalidBitRate            | The bitrate is invalid or unsupported by Threads.                                   | --            |
| InvalidDuration           | The video duration is invalid or unsupported by Threads.                            | --            |
| InvalidFrameRate          | The framerate is invalid or unsupported by Threads.                                 | --            |
| InvalidAudioChannels      | The audio channels are invalid or unsupported by Threads.                           | --            |
| InvalidAudioChannelLayout | The audio channel layout are invalid or unsupported by Threads.                     | --            |
| Unknown                   | Used for unrecognized error values, or if the Threads API returns an unknown error. | --            |