using System.Net;
using ThreadSharp.Exceptions;
using ThreadSharp.Models;

namespace ThreadSharp.Helpers;

internal static class RetryHelpers
{
    internal const int DefaultMaxRetries = 5;

    internal static async Task<ThreadsResult<T>> RetryOnServerErrorAsync<T>(Func<Task<ThreadsResult<T>>> operation, int maxRetries = DefaultMaxRetries)
    {
        int retries = 0;
        ThreadsResult<T> result;

        do
        {
            result = await operation();

            if ((int)result.StatusCode < 500 || (int)result.StatusCode > 599)
                return result;

            retries++;
        }
        while (retries < maxRetries);

        return new ThreadsResult<T>(new ThreadsServerErrorException(), result.StatusCode);
    }
}