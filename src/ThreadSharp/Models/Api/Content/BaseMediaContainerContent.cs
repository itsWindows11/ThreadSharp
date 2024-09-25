using Refit;

namespace ThreadSharp.Models.Api.Content;

/// <summary>
/// Base media container content.
/// </summary>
public class BaseMediaContainerContent
{
    /// <summary>
    /// Whether or not this media container item is a carousel item.
    /// </summary>
    [AliasAs("is_carousel_item")]
    public bool IsCarouselItem { get; set; }
}