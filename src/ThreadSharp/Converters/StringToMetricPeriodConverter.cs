using System.Text.Json.Serialization;
using System.Text.Json;
using ThreadSharp.Enums;

namespace ThreadSharp.Converters;

internal class StringToMetricPeriodConverter : JsonConverter<MetricPeriod>
{
    public override MetricPeriod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "lifetime" => MetricPeriod.Lifetime,
            "day" => MetricPeriod.Day,
            _ => MetricPeriod.Unknown
        };
    }

    public override void Write(Utf8JsonWriter writer, MetricPeriod value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case MetricPeriod.Lifetime:
                writer.WriteStringValue("lifetime");
                break;
            case MetricPeriod.Day:
                writer.WriteStringValue("day");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
}