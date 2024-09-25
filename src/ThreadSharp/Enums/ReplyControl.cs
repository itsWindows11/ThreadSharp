using System.Runtime.Serialization;

namespace ThreadSharp.Enums;

/// <summary>
/// Enum representing possible reply control values.
/// </summary>
public enum ReplyControl
{
    /// <summary>
    /// Everyone can reply.
    /// </summary>
    [EnumMember(Value = "everyone")]
    Everyone,
    /// <summary>
    /// Accounts you follow can reply.
    /// </summary>
    [EnumMember(Value = "accounts_you_follow")]
    AccountsYouFollow,
    /// <summary>
    /// Accounts you mention can reply.
    /// </summary>
    [EnumMember(Value = "mentioned_only")]
    MentionedOnly
}