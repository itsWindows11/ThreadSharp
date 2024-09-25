using Refit;

namespace ThreadSharp.Models.Api.Content;

/// <summary>
/// Media container content for carousel posts.
/// </summary>
public class CarouselContainerContent : BaseMediaContainerContent
{
    /// <summary>
    /// List of statuses of the media containers to include in the carousel.
    /// </summary>
    [AliasAs("children")]
    public required IList<ThreadsMediaContainerStatus> Children { get; set; }
}