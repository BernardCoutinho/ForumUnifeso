namespace ForumUnifeso.src.API.Model
{

    public class Thread
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Post Topic { get; private set; }
        public List<Post> Answers {  get; private set; }
    }
}
