using System.Text.Json.Serialization;

namespace ThreadSharp.Models.Api;

/// <summary>
/// Represents the result when managing a reply.
/// </summary>
public sealed class ThreadsManageReplyResult : BaseJsonUnrecognizedDataModel
{
    /// <summary>
    /// Whether the operation is successful.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => $"Success: {Success}";
}