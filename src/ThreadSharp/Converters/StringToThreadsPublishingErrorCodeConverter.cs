using System.Text.Json;
using System.Text.Json.Serialization;
using ThreadSharp.Enums;

namespace ThreadSharp.Converters;

internal class StringToThreadsPublishingErrorCodeConverter : JsonConverter<ThreadsPublishingErrorCode>
{
    public override ThreadsPublishingErrorCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "FAILED_DOWNLOADING_VIDEO" => ThreadsPublishingErrorCode.FailedDownloadingVideo,
            "FAILED_PROCESSING_AUDIO" => ThreadsPublishingErrorCode.FailedProcessingAudio,
            "FAILED_PROCESSING_VIDEO" => ThreadsPublishingErrorCode.FailedProcessingVideo,
            "INVALID_ASPECT_RATIO" => ThreadsPublishingErrorCode.InvalidAspectRatio,
            "INVALID_BIT_RATE" => ThreadsPublishingErrorCode.InvalidBitRate,
            "INVALID_DURATION" => ThreadsPublishingErrorCode.InvalidDuration,
            "INVALID_FRAME_RATE" => ThreadsPublishingErrorCode.InvalidFrameRate,
            "INVALID_AUDIO_CHANNELS" => ThreadsPublishingErrorCode.InvalidAudioChannels,
            "INVALID_AUDIO_CHANNEL_LAYOUT" => ThreadsPublishingErrorCode.InvalidAudioChannelLayout,
            _ => ThreadsPublishingErrorCode.Unknown
        };
    }

    public override void Write(Utf8JsonWriter writer, ThreadsPublishingErrorCode value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case ThreadsPublishingErrorCode.FailedDownloadingVideo:
                writer.WriteStringValue("FAILED_DOWNLOADING_VIDEO");
                break;
            case ThreadsPublishingErrorCode.FailedProcessingAudio:
                writer.WriteStringValue("FAILED_PROCESSING_AUDIO");
                break;
            case ThreadsPublishingErrorCode.FailedProcessingVideo:
                writer.WriteStringValue("FAILED_PROCESSING_VIDEO");
                break;
            case ThreadsPublishingErrorCode.InvalidAspectRatio:
                writer.WriteStringValue("INVALID_ASPECT_RATIO");
                break;
            case ThreadsPublishingErrorCode.InvalidBitRate:
                writer.WriteStringValue("INVALID_BIT_RATE");
                break;
            case ThreadsPublishingErrorCode.InvalidDuration:
                writer.WriteStringValue("INVALID_DURATION");
                break;
            case ThreadsPublishingErrorCode.InvalidFrameRate:
                writer.WriteStringValue("INVALID_FRAME_RATE");
                break;
            case ThreadsPublishingErrorCode.InvalidAudioChannels:
                writer.WriteStringValue("INVALID_AUDIO_CHANNELS");
                break;
            case ThreadsPublishingErrorCode.InvalidAudioChannelLayout:
                writer.WriteStringValue("INVALID_AUDIO_CHANNEL_LAYOUT");
                break;
            case ThreadsPublishingErrorCode.Unknown:
                writer.WriteStringValue("UNKNOWN");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
}