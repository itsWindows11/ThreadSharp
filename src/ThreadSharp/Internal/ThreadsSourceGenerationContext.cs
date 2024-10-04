using System.Text.Json;
using System.Text.Json.Serialization;
using ThreadSharp.Models;
using ThreadSharp.Models.Api;
using ThreadSharp.Models.Api.Insights;

namespace ThreadSharp.Internal;

[JsonSerializable(typeof(BaseJsonUnrecognizedDataModel))]
[JsonSerializable(typeof(Dictionary<string, JsonElement>))]
[JsonSerializable(typeof(ThreadsManageReplyResult))]
[JsonSerializable(typeof(ThreadsIdContainer))]
[JsonSerializable(typeof(ThreadsProfile))]
[JsonSerializable(typeof(ThreadsPublishingLimitData))]
[JsonSerializable(typeof(ThreadsMediaContainerStatus))]
[JsonSerializable(typeof(List<ThreadsPost>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsMediaInsightItem>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsUserInsightDataBase>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsUserInsightViewsData>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsUserInsightLikesData>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsUserInsightRepliesData>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsUserInsightQuotesData>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsUserInsightRepostsData>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsUserInsightTotalFollowersData>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsPost>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsPublishingLimitData>>))]
[JsonSerializable(typeof(ThreadsDataContainer<List<ThreadsIdContainer>>))]
internal sealed partial class ThreadsSourceGenerationContext : JsonSerializerContext
{
}