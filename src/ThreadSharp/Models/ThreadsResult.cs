using System.Net;
using System.Text.Json;
using ThreadSharp.Exceptions;

namespace ThreadSharp.Models;

/// <summary>
/// Result class used to wrap Threads API responses.
/// </summary>
/// <typeparam name="T">The type of the response body.</typeparam>
public sealed class ThreadsResult<T>
{
    /// <summary>
    /// The value of this result. If successful, isn't null.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// The error of this result, if one occurred.
    /// </summary>
    public ThreadsException? Error { get; }

    /// <summary>
    /// Additional data about the error, if one occurred.
    /// </summary>
    public Dictionary<string, JsonElement>? ErrorData => Error?.Data as Dictionary<string, JsonElement>;

    /// <summary>
    /// The status code of the result.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Gets whether the status code is successful.
    /// </summary>
    public bool IsSuccessStatusCode => (int)StatusCode >= 200 && (int)StatusCode <= 299;

    internal ThreadsResult(T? value, HttpStatusCode statusCode)
    {
        Value = value;
        StatusCode = statusCode;
    }

    internal ThreadsResult(ThreadsException error, HttpStatusCode statusCode)
    {
        Error = error;
        StatusCode = statusCode;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        if (Value is null)
            return $"{(IsSuccessStatusCode ? "Success" : "Error")} (empty response), {base.ToString()}";

        return $"{(IsSuccessStatusCode ? "Success" : "Error")}, {base.ToString()}";
    }
}