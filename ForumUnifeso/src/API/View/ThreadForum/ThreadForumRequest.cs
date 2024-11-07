using System.Text.Json.Serialization;
using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.View
{
    public class ThreadForumRequest {
        public PostResponse? Topic { get;  set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Tag Tag { get; set; }
    }
}