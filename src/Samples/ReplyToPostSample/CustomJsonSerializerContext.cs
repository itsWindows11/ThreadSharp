using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReplyToSelfPostSample;

[JsonSerializable(typeof(Dictionary<string, JsonElement>))]
internal sealed partial class CustomJsonSerializerContext : JsonSerializerContext
{
}