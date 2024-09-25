using System.Runtime.Serialization;

namespace ThreadSharp.Enums;

/// <summary>
/// Enum representing possible user metric period options.
/// </summary>
public enum UserMetricPeriod
{
    /// <summary>
    /// Metrics in a day.
    /// </summary>
    [EnumMember(Value = "day")]
    Day,
    /// <summary>
    /// Metrics in the lifetime of an account.
    /// </summary>
    [EnumMember(Value = "lifetime")]
    Lifetime
}