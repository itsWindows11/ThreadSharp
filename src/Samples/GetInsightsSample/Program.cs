using ReplyToSelfPostSample;
using System.Text.Json;
using ThreadSharp;
using ThreadSharp.Enums;
using ThreadSharp.Models;
using ThreadSharp.Models.Api.Insights;

var accessToken = Environment.GetEnvironmentVariable("THREADS_ACCESS_TOKEN");

if (accessToken is null)
{
    Console.WriteLine("ERROR: Cannot run this sample without a Threads access token.");
    return;
}

#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
var serializerOptions = new JsonSerializerOptions()
{
    WriteIndented = true,
    TypeInfoResolver = CustomJsonSerializerContext.Default
};
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances

var threadsClient = new ThreadsClient(accessToken);

// Get all insights for the current user.
var insightsResult = await threadsClient.Insights.GetForCurrentUserAsync(new UserMetricPagingParameters()
{
    Metrics = [
        "views",
        "likes",
        "reposts",
        "quotes",
        "replies",
        "followers_count",
        "follower_demographics"
    ],
    Period = MetricPeriod.Lifetime
}, Breakdown.Age | Breakdown.Gender);

if (insightsResult.Value is not null)
{
    Console.WriteLine("User Insights:");
    Console.WriteLine("----------------");

    foreach (var insight in insightsResult.Value)
    {
        // There are different types of insights, so we have to handle each of them.
        switch (insight)
        {
            case ThreadsUserInsightViewsData viewsData:
                Console.WriteLine("Views:");

                int i = 0;

                // Filter through different views metrics.
                foreach (var value in viewsData.Values ?? Enumerable.Empty<ThreadsUserInsightViewsData.ThreadsUserInsightViewsValue>())
                {
                    Console.WriteLine($"  - Item n. {i}");
                    Console.WriteLine($"    Views: {value.Views}");
                    Console.WriteLine($"    End Time: {value.EndTime}");
                    i++;
                }
                break;
            case ThreadsUserInsightLikesData likesData:
                Console.WriteLine($"Likes: {likesData.TotalValue?.Value ?? 0}");
                break;
            case ThreadsUserInsightRepostsData repostsData:
                Console.WriteLine($"Reposts: {repostsData.TotalValue?.Value ?? 0}");
                break;
            case ThreadsUserInsightQuotesData quotesData:
                Console.WriteLine($"Quotes: {quotesData.TotalValue?.Value ?? 0}");
                break;
            case ThreadsUserInsightRepliesData repliesData:
                Console.WriteLine($"Replies: {repliesData.TotalValue?.Value ?? 0}");
                break;
            case ThreadsUserInsightTotalFollowersData totalFollowersData:
                Console.WriteLine($"Total Followers: {totalFollowersData.TotalValue?.Value ?? 0}");
                break;
            case ThreadsUserInsightFollowerDemographicsData followerDemographicsData:
                Console.WriteLine("Follower Demographics:");

                int j = 0;

                // Loop through the breakdown data.
                foreach (var value in followerDemographicsData.TotalValue?.BreakdownData ?? Enumerable.Empty<ThreadsUserInsightFollowerDemographicsData.ThreadsUserInsightFollowerDemographicsValue.ThreadsUserInsightFollowerDemographicsBreakdownData>())
                {
                    Console.WriteLine($"  - Item n. {j}");
                    Console.WriteLine($"    Results:");

                    int k = 0;

                    // Loop through the results and match values with different dimension keys.
                    foreach (var result in value.Results)
                    {
                        foreach (var (dimensionKey, dimensionValue) in Enumerable.Zip(value.DimensionKeys, value.Results.Select(x => x.DimensionValues).ElementAt(k)))
                        {
                            Console.WriteLine($"      - {dimensionKey}: {dimensionValue}");
                            Console.WriteLine($"        Value: {value.Results[k].Value}");
                        }

                        k++;
                    }

                    j++;
                }
                break;
            default:
                Console.WriteLine("Detected unsupported insight type.\nPlease report this by going to this link and filling the appropriate details: https://github.com/itsWindows11/ThreadSharp/issues/new");
                break;
        }

        Console.WriteLine("--------");
    }
} else if (insightsResult.ErrorData is not null)
{
    Console.WriteLine("ERROR: Cannot retrieve user insights.");
    Console.WriteLine("----------------------------------------");

    var errorData = insightsResult.ErrorData;

#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
    if (errorData is not null)
        Console.WriteLine(JsonSerializer.Serialize(errorData, serializerOptions));
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
} else
{
    Console.WriteLine("ERROR: An unknown error occurred while retrieving user insights.");
}