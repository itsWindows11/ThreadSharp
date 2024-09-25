using Refit;
using ThreadSharp.Exceptions;

namespace ThreadSharp.Models;

/// <summary>
/// Parameters for paging posts.
/// </summary>
public sealed class PostPagingParameters
{
    private DateTimeOffset? _before;
    private DateTimeOffset? _after;

    /// <summary>
    /// Limit of posts to retrieve.
    /// </summary>
    [AliasAs("limit")]
    public int Limit { get; set; } = 25;

    /// <summary>
    /// Since date for posts.
    /// </summary>
    [AliasAs("since")]
    public DateTimeOffset? Since { get; set; }

    /// <summary>
    /// Until date for posts.
    /// </summary>
    [AliasAs("until")]
    public DateTimeOffset? Until { get; set; }

    /// <summary>
    /// The date offset to begin retrieving prior posts.
    /// </summary>
    [AliasAs("before")]
    public DateTimeOffset? Before
    {
        get => _before;
        set
        {
            if (After.HasValue)
                throw new ThreadsBeforeAfterException();

            _before = value;
        }
    }

    /// <summary>
    /// The date offset to begin retrieving subsequent posts.
    /// </summary>
    [AliasAs("after")]
    public DateTimeOffset? After
    {
        get => _after;
        set
        {
            if (_before.HasValue)
                throw new ThreadsBeforeAfterException();

            _after = value;
        }
    }
}