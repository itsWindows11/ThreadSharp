using Refit;

namespace ThreadSharp.Models.Api.Content;

/// <summary>
/// Media container content that includes a link attachment.
/// </summary>
public class AttachmentLinkContainerContent : BaseMediaContainerContent
{
    /// <summary>
    /// The link to add to the post as an attachment.
    /// </summary>
    [AliasAs("link_attachment")]
    public required string LinkAttachment { get; set; }
}