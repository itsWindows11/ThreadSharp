using Refit;
using System.Net;
using System.Text.Json;
using ThreadSharp.Internal;
using ThreadSharp.Models;
using ThreadSharp.Exceptions;

namespace ThreadSharp;

/// <summary>
/// The client to use for interacting with the Threads API.
/// </summary>
public sealed class ThreadsClient : IDisposable
{
    private string _accessToken;

    private readonly HttpClient _httpClient;
    private readonly IThreadSharpRefitClient _refitClient;

    /// <summary>
    /// The maximum amount of retries to do when a request fails on
    /// the Threads API's end.
    /// </summary>
    public int MaxRetriesOnServerError { get; set; } = 5;

    /// <summary>
    /// Sets the current user's access token, mostly for emergency
    /// purposes or when a new access token is generated.
    /// </summary>
    public string AccessToken
    {
        set => _accessToken = value;
    }

    /// <summary>
    /// The backing <see cref="HttpClient"/> for the client.
    /// </summary>
    /// <remarks>
    /// Use of the <see cref="SendRequestAsync(HttpMethod, string)"/>
    /// method is preferred over using this directly.
    /// </remarks>
    public HttpClient BackingClient => _httpClient;

    /// <summary>
    /// Client for all things user related for the current authenticated
    /// user, including posting threads.
    /// </summary>
    public ThreadsUserClient Me { get; }

    /// <summary>
    /// Client for thread fetching &amp; management.
    /// </summary>
    public ThreadsThreadManagementClient Threads { get; }

    /// <summary>
    /// Client for all things insight/data related for the current
    /// authenticated user.
    /// </summary>
    public ThreadsInsightsClient Insights { get; }

    /// <summary>
    /// Creates an instance of <see cref="ThreadsClient"/> which doesn't
    /// automatically renew the access token.
    /// </summary>
    /// <param name="accessToken">The access token to call the Threads API with.</param>
    public ThreadsClient(string accessToken)
    {
        _accessToken = accessToken;

        var httpClientHandler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        _httpClient = new HttpClient(httpClientHandler)
        {
            BaseAddress = new Uri("https://graph.threads.net"),
            DefaultRequestHeaders =
            {
                { "Authorization", $"Bearer {accessToken}" },
            }
        };

        _refitClient = RestService.For<IThreadSharpRefitClient>(_httpClient, new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions()
            {
                TypeInfoResolver = ThreadsSourceGenerationContext.Default
            })
        });

        Me = new(() => _accessToken, _refitClient, () => MaxRetriesOnServerError);
        Threads = new(() => _accessToken, _refitClient, () => MaxRetriesOnServerError);
        Insights = new(() => _accessToken, _refitClient, () => MaxRetriesOnServerError);
    }

    /*/// <summary>
    /// Creates an instance of <see cref="ThreadsUserClient"/> for fetching other users' info &amp; posts.
    /// </summary>
    /// <param name="threadsUserId">The user ID to use for retrieving.</param>
    /// <returns>A client for user info &amp; post retrieval.</returns>
    public ThreadsUserClient User(string threadsUserId)
        => new(threadsUserId, _accessToken, _refreshToken, _refitClient);*/

    /// <summary>
    /// Sends a request to the Threads API.
    /// </summary>
    /// <param name="method">The method to use for the HTTP request.</param>
    /// <param name="path">The path or endpoint you want to call. Prefixed by "https://graph.threads.net/".</param>
    /// <returns>A result, if successful, contains the dictionary that contains the full response.</returns>
    public async Task<ThreadsResult<Dictionary<string, JsonElement>>> SendRequestAsync(HttpMethod method, string path)
    {
        using var request = new HttpRequestMessage(method, path);

        using var response = await _httpClient.SendAsync(request);

        using var content = await response.Content.ReadAsStreamAsync();
        var json = await JsonSerializer.DeserializeAsync(content, ThreadsSourceGenerationContext.Default.DictionaryStringJsonElement);

        if (response.IsSuccessStatusCode)
            return new(json, response.StatusCode);

        return new(new ThreadsException(), response.StatusCode);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}