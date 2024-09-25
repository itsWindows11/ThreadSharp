using System.Text.Json.Serialization;

namespace ThreadSharp.Models;

/// <summary>
/// Container for Threads responses where there's a `data` child.
/// </summary>
/// <typeparam name="T">Type for the data.</typeparam>
public sealed class ThreadsDataContainer<T>
{
    /// <summary>
    /// The data.
    /// </summary>
    [JsonPropertyName("data")]
    public required T Data { get; set; }

    /// <summary>
    /// Paging data from the API.
    /// </summary>
    [JsonPropertyName("paging")]
    public ThreadsPagingData? Paging { get; set; }

    /// <summary>
    /// Paging data from the API.
    /// </summary>
    public sealed class ThreadsPagingData
    {
        /// <summary>
        /// The pointer or URL to the next page.
        /// </summary>
        [JsonPropertyName("next")]
        public string? Next { get; set; }

        /// <summary>
        /// The pointer or URL to the previous page.
        /// </summary>
        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        /// <summary>
        /// Cursor data.
        /// </summary>
        [JsonPropertyName("cursors")]
        public ThreadsPagingDataCursors? Cursors { get; set; }

        /// <summary>
        /// Cursor data.
        /// </summary>
        public sealed class ThreadsPagingDataCursors
        {
            /// <summary>
            /// The pointer or URL to the previous page.
            /// </summary>
            [JsonPropertyName("before")]
            public string? Before { get; set; }

            /// <summary>
            /// The pointer or URL to the next page.
            /// </summary>
            [JsonPropertyName("after")]
            public string? After { get; set; }
        }
    }
}