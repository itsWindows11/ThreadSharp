using System.Runtime.Serialization;

namespace ThreadSharp.Enums;

/// <summary>
/// Enum representing media types to use for creating media containers.
/// </summary>
public enum MediaType
{
    /// <summary>
    /// For text containers.
    /// </summary>
    [EnumMember(Value = "TEXT")]
    Text,
    /// <summary>
    /// For image containers.
    /// </summary>
    [EnumMember(Value = "IMAGE")]
    Image,
    /// <summary>
    /// For video containers.
    /// </summary>
    [EnumMember(Value = "VIDEO")]
    Video,
    /// <summary>
    /// For carousel containers.
    /// </summary>
    [EnumMember(Value = "CAROUSEL")]
    Carousel,
    /// <summary>
    /// Used for unknown/unrecognized media types.
    /// </summary>
    Unknown
}