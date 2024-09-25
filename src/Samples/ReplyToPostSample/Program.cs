using ReplyToSelfPostSample;
using System.Text.Json;
using ThreadSharp;
using ThreadSharp.Enums;
using ThreadSharp.Helpers;

var accessToken = Environment.GetEnvironmentVariable("THREADS_ACCESS_TOKEN");

if (accessToken is null)
{
    Console.WriteLine("ERROR: Cannot run this sample without a Threads access token.");
    return;
}

var threadsClient = new ThreadsClient(accessToken);

#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
var serializerOptions = new JsonSerializerOptions()
{
    WriteIndented = true,
    TypeInfoResolver = CustomJsonSerializerContext.Default
};
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances

var threadsIdContainerResult = await threadsClient.Me.CreateTextPostAsync(
    "Hello World from ThreadSharp! This is a C# wrapper for the Threads API.\nThis is a read only post.",
    replyControl: ReplyControl.MentionedOnly
);

if (threadsIdContainerResult.Value is not null)
{
    Console.WriteLine("SUCCESS: Root post has been created.");
    var rootPostId = threadsIdContainerResult.Value.Id;

    var rootPermalink = (await threadsClient.Threads.GetThreadAsync(rootPostId)).Value!.Permalink;
    Console.WriteLine($"PERMALINK: {rootPermalink}");

    var replyResult = await threadsClient.Me.CreateTextPostAsync(
        "Hello from a reply using ThreadSharp!",
        replyToId: rootPostId
    );

    Console.WriteLine("-----------");

    if (replyResult.Value is not null)
    {
        Console.WriteLine("SUCCESS: Reply post has been created.");

        var replyPermalink = (await threadsClient.Threads.GetThreadAsync(replyResult.Value.Id)).Value!.Permalink;
        Console.WriteLine($"PERMALINK: {replyPermalink}");
    }
    else
    {
        Console.WriteLine("ERROR: Failed to create reply post.");
    }
} else
{
    Console.WriteLine("ERROR: Failed to create post.");

    var errorData = threadsIdContainerResult.ErrorData;

#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
    if (errorData is not null)
        Console.WriteLine(JsonSerializer.Serialize(errorData, serializerOptions));
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
}