using System.Runtime.Serialization;

namespace ThreadSharp.Enums;

/// <summary>
/// Enum representing media types of already published posts.
/// </summary>
public enum ThreadsPostMediaType
{
    /// <summary>
    /// For text posts.
    /// </summary>
    [EnumMember(Value = "TEXT_POST")]
    TextPost,
    /// <summary>
    /// For image posts.
    /// </summary>
    [EnumMember(Value = "IMAGE")]
    Image,
    /// <summary>
    /// For video posts.
    /// </summary>
    [EnumMember(Value = "VIDEO")]
    Video,
    /// <summary>
    /// For carousel albums.
    /// </summary>
    [EnumMember(Value = "CAROUSEL_ALBUM")]
    CarouselAlbum,
    /// <summary>
    /// For audio posts.
    /// </summary>
    [EnumMember(Value = "AUDIO")]
    Audio,
    /// <summary>
    /// For reposts.
    /// </summary>
    [EnumMember(Value = "REPOST_FACADE")]
    RepostFacade,
    /// <summary>
    /// Used for unknown/not yet recognized media types by ThreadSharp.
    /// </summary>
    Unknown
}