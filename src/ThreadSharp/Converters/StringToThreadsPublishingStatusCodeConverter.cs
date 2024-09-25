using System.Text.Json;
using System.Text.Json.Serialization;
using ThreadSharp.Enums;

namespace ThreadSharp.Converters;

internal class StringToThreadsPublishingStatusCodeConverter : JsonConverter<ThreadsPublishingStatusCode>
{
    public override ThreadsPublishingStatusCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "EXPIRED" => ThreadsPublishingStatusCode.Expired,
            "ERROR" => ThreadsPublishingStatusCode.Published,
            "FINISHED" => ThreadsPublishingStatusCode.Finished,
            "IN_PROGRESS" => ThreadsPublishingStatusCode.Error,
            "PUBLISHED" => ThreadsPublishingStatusCode.Published,
            _ => ThreadsPublishingStatusCode.Unknown,
        };
    }

    public override void Write(Utf8JsonWriter writer, ThreadsPublishingStatusCode value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case ThreadsPublishingStatusCode.Expired:
                writer.WriteStringValue("EXPIRED");
                break;
            case ThreadsPublishingStatusCode.Error:
                writer.WriteStringValue("ERROR");
                break;
            case ThreadsPublishingStatusCode.Finished:
                writer.WriteStringValue("FINISHED");
                break;
            case ThreadsPublishingStatusCode.InProgress:
                writer.WriteStringValue("IN_PROGRESS");
                break;
            case ThreadsPublishingStatusCode.Published:
                writer.WriteStringValue("PUBLISHED");
                break;
            default:
                writer.WriteStringValue("UNKNOWN");
                break;
        }
    }
}