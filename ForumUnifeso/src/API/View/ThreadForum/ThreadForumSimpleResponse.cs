using System.Text.Json.Serialization;
using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.View
{
    public class ThreadForumSimpleResponse {
        public int? Id { get; set; }
        public PostResponse? Topic { get;  set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Tag Tag { get; set; }
    }
}