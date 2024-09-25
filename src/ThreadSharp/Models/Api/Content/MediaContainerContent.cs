using Refit;

namespace ThreadSharp.Models.Api.Content;

/// <summary>
/// Media container content for image or video containers.
/// </summary>
public class MediaContainerContent : BaseMediaContainerContent
{
    private string? _imageUrl;
    private string? _videoUrl;

    /// <summary>
    /// The URL of the image to use in the media container.
    /// </summary>
    [AliasAs("image_url")]
    public string? ImageUrl
    {
        get => _imageUrl;
        set
        {
            if (VideoUrl != null)
                _videoUrl = null;

            _imageUrl = value;
        }
    }

    /// <summary>
    /// The URL of the video to use in the media container.
    /// </summary>
    [AliasAs("video_url")]
    public string? VideoUrl
    {
        get => _videoUrl;
        set
        {
            if (ImageUrl != null)
                _imageUrl = null;

            _videoUrl = value;
        }
    }

    /// <summary>
    /// The alt text for the media.
    /// </summary>
    [AliasAs("alt_text")]
    public string? AltText { get; set; }
}