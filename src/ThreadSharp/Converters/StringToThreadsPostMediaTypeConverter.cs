using System.Text.Json.Serialization;
using System.Text.Json;
using ThreadSharp.Enums;

namespace ThreadSharp.Converters;

internal class StringToThreadsPostMediaTypeConverter : JsonConverter<ThreadsPostMediaType>
{
    public override ThreadsPostMediaType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "TEXT_POST" => ThreadsPostMediaType.TextPost,
            "IMAGE" => ThreadsPostMediaType.Image,
            "VIDEO" => ThreadsPostMediaType.Video,
            "CAROUSEL_ALBUM" => ThreadsPostMediaType.CarouselAlbum,
            "AUDIO" => ThreadsPostMediaType.Audio,
            "REPOST_FACADE" => ThreadsPostMediaType.RepostFacade,
            _ => ThreadsPostMediaType.Unknown
        };
    }

    public override void Write(Utf8JsonWriter writer, ThreadsPostMediaType value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case ThreadsPostMediaType.TextPost:
                writer.WriteStringValue("TEXT_POST");
                break;
            case ThreadsPostMediaType.Image:
                writer.WriteStringValue("IMAGE");
                break;
            case ThreadsPostMediaType.Video:
                writer.WriteStringValue("VIDEO");
                break;
            case ThreadsPostMediaType.CarouselAlbum:
                writer.WriteStringValue("CAROUSEL_ALBUM");
                break;
            case ThreadsPostMediaType.Audio:
                writer.WriteStringValue("AUDIO");
                break;
            case ThreadsPostMediaType.RepostFacade:
                writer.WriteStringValue("REPOST_FACADE");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
}