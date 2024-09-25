using ReplyToSelfPostSample;
using System.Text.Json;
using ThreadSharp;

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

var currentUserProfileResult = await threadsClient.Me.GetAsync();

if (currentUserProfileResult.Value is not null)
{
    Console.WriteLine("User Info:");
    Console.WriteLine("----------------");

    Console.WriteLine($"""
    Display Name: "{currentUserProfileResult.Value.Name}"
    Username: "@{currentUserProfileResult.Value.Username}"
    Biography: "{currentUserProfileResult.Value.Biography}"
    Profile picture URL: "{currentUserProfileResult.Value.ProfilePictureUrl}"
    User ID: {currentUserProfileResult.Value.Id}
    Is eligible for geo-gating: {currentUserProfileResult.Value.IsEligibleForGeoGating}
    """);
} else if (currentUserProfileResult.ErrorData is not null)
{
    Console.WriteLine("ERROR: Cannot retrieve user info.");
    Console.WriteLine("-------------------------------------");

    var errorData = currentUserProfileResult.ErrorData;

#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
    if (errorData is not null)
        Console.WriteLine(JsonSerializer.Serialize(errorData, serializerOptions));
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
}