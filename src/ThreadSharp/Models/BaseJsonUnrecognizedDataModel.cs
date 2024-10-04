using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThreadSharp.Models;

/// <summary>
/// A model that is used as a base class to provide its derivatives with additional data.
/// </summary>
/// <remarks>
/// This class is not intended for public use by apps or libraries that consume this library.
/// </remarks>
public class BaseJsonUnrecognizedDataModel
{
    /// <summary>
    /// Additional data that is available from the API, but
    /// not included in the POCO.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnrecognizedData { get; set; }
}