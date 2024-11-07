using System.Text.Json.Serialization;

namespace ForumUnifeso.src.API.Model
{

    public class ThreadForum
    {
        public int? Id { get; set; }

        public Post? Topic { get; set; }

        public int TopicId { get; set; }

        public List<Post> Answers { get; set; } = new List<Post>();

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Tag Tag { get; set; }

        public ThreadForum() { }

        public ThreadForum(int id, Post topic, Tag tag)
        {
            Id = id;
            Topic = topic;
            Tag = tag;
        }
    }
}
