using System.Runtime.Serialization;

namespace ThreadSharp.Enums;

/// <summary>
/// Enum representing breakdown values.
/// </summary>
[Flags]
public enum Breakdown
{
    /// <summary>
    /// Breakdown by country.
    /// </summary>
    [EnumMember(Value = "country")]
    Country = 1 << 0,
    /// <summary>
    /// Breakdown by city.
    /// </summary>
    [EnumMember(Value = "city")]
    City = 1 << 1,
    /// <summary>
    /// Breakdown by age.
    /// </summary>
    [EnumMember(Value = "age")]
    Age = 1 << 2,
    /// <summary>
    /// Breakdown by gender.
    /// </summary>
    [EnumMember(Value = "gender")]
    Gender = 1 << 3
}